using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;
using System.Diagnostics;


namespace _3Dto2D
{
    public partial class Main : Form
    {
        public Device device;
        public PresentParameters presentParams = new PresentParameters();
        public Color backgroundColour = Color.Black;
        public Mesh mesh;
        public Material[] meshMaterials;
        public ExtendedMaterial[] materials = null;
        public Texture[] meshTextures;
        public bool meshLoaded = false;
        public Sprite sprite;

        public string meshFileName = "no mesh loaded";
        public string characterTypeFileName = @".\Data\_Mir2_CArmour.Lib"; //default to Mir2 WarWizTao character
        
        //Variables for the Libraries
        private MLibraryV2 _library, _refLibrary, _handLibrary;
        private MLibraryV2.MImage _selectedImage, _selectedRefImage, _selectedHandImage;

        public int characterGlobalOffsetX = 100;
        public int characterGlobalOffsetY = 150;
        public bool showRefImage = true;
        public bool showHandImage = false;
        public bool blankHandImage = false;

        //Exporting to .Lib may be best to use a thread (background?)
        public Thread t1;

        public Main()
        {
            //Sets an Event for when the form is closed
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler); //try to find error
            
            //Initialize Form
            InitializeComponent();
            //Initialize DirectX
            InitializeGraphics();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Starts a Thread that updates the DirectX panel
            //t1 = new Thread(Loop);
            //t1.IsBackground = true; //setting as background stops the infinite looped thread when main app is closed
            //t1.Start();

            //Load Reference File for the naked character images (default to Mir2 War/WizTao)
            if (_refLibrary != null) _refLibrary.Close();
            _refLibrary = new MLibraryV2(characterTypeFileName, true);
            
            nud_frame.Maximum = _refLibrary.Count - 1; //-1 as Frame number and number up down control is zero based
            nud_frame.Value = 0;

            text_test_framemax.Text = _refLibrary.Count.ToString();
            text_test_framemin.Text = "0";

            UpdateTextBoxes();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Render();
        }

        //private void Loop()
        //{
        //    //REMOVED (Just update when needed)
        //    //infinite loop
        //    while (true)
        //    {
        //        Render(); //
        //        Thread.Sleep(50); //slows the Thread down to 20 x per second
        //    }
        //}

        public bool InitializeGraphics()
        {
            try
            {
                //Setup our D3D stuff
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                presentParams.EnableAutoDepthStencil = true;
                presentParams.PresentFlag = PresentFlag.LockableBackBuffer;
                
                device = new Device(
                    0,
                    DeviceType.Hardware,
                    DXpanel,
                    CreateFlags.HardwareVertexProcessing,
                    presentParams
                    );

                //create OnDeviceReset Event
                device.DeviceReset += new EventHandler(OnDeviceReset);

                device.Transform.View = Microsoft.DirectX.Matrix.OrthoLH(device.Viewport.Width, device.Viewport.Height, -1000, 1000);

                //device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0F, device.Viewport.Width / device.Viewport.Height, 1.0f, 80.0f);

                device.RenderState.Ambient = System.Drawing.Color.White; //testing Ambient
                //device.RenderState.Lighting = false; //no lighting... textures should be baked with lighting
                

                OnDeviceReset(null, EventArgs.Empty);

                return true;
            }
            catch
            {
                return false;
            }
        }

        
        private void Render()
        {
            //I had to draw the scene twice here as I could not figure out how to draw the sprite behind the mesh
            //Must be a better way to do this but this works and I quite like the flicker it causes as you can see through the mesh for a moment which is good for alignment.

            if (device == null)
                return;

            //using try{} stops application error on exit when device is disposed before Thread closed
            try
            {
                //Clear the backbuffer to a solid color and clears the zbuffer so the mesh renders each face with the correct overlapping
                device.Clear(
                    ClearFlags.Target | ClearFlags.ZBuffer,
                    backgroundColour, //Black is good to target later when removing borders
                    1.0f,
                    0);



                //******************* Sprite ********************



                //This showRefImage should disable drawing the character images while converting the Directx panel to the final .lib images
                if (showRefImage) {
                        _selectedRefImage = _refLibrary.GetMImage((int)nud_frame.Value);
                        textBox_OffSetX.Text = _selectedRefImage.X.ToString();
                        textBox_OffSetY.Text = _selectedRefImage.Y.ToString();
                        if(_selectedRefImage.Image != null) {

                            //Begin the scene for the sprite images
                            device.BeginScene();

                            //draw 2d Character Image behind the mesh
                            sprite = new Sprite(device);
                            sprite.Begin(SpriteFlags.AlphaBlend);
                    
                            Texture character = Texture.FromBitmap(device, _selectedRefImage.Image, Usage.None, Pool.Managed);
                            sprite.Draw2D(
                                character,
                                new Rectangle(0, 0, _selectedRefImage.Width, _selectedRefImage.Height),
                                new Size(_selectedRefImage.Width, _selectedRefImage.Height),
                                new Point(characterGlobalOffsetX + _selectedRefImage.X, characterGlobalOffsetY + _selectedRefImage.Y),
                                Color.White);
                    



                            sprite.End();
                            sprite.Dispose();

                            device.EndScene(); //end scene here so images are saved to the backbuffer and drawn behind the mesh
                            device.Present();

                                //only clear ZBuffer here so it keeps the sprite on the screen as the background
                            device.Clear(
                                ClearFlags.ZBuffer,
                                backgroundColour,
                                1.0f,
                                0);
                        }
                    }




                //******************* Hands ********************

                

                if (_handLibrary != null && (showHandImage == true || blankHandImage == true))
                {
                    _selectedHandImage = _handLibrary.GetMImage((int)nud_frame.Value);
                    if (_selectedHandImage.Image != null) { 

                        //Begin the scene for the sprite images (hands)
                        device.BeginScene();

                        //draw 2d Character hands Image infront of the mesh
                        sprite = new Sprite(device);
                        sprite.Begin(SpriteFlags.AlphaBlend);

                        //if blankHands checkbox selected turn the hand image black so it gets removed when rendered
                        Bitmap TempHandBMP = new Bitmap(_selectedHandImage.Image); //create a new bitmap to store image (this way the original wont be updated and we can switch back at any time)
                        if (blankHandImage)
                        {
                            unsafe
                            {
                                BitmapData bitmapdata =
                                    TempHandBMP.LockBits(new Rectangle(0, 0, TempHandBMP.Width, TempHandBMP.Height),
                                    ImageLockMode.ReadWrite, TempHandBMP.PixelFormat);

                                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(TempHandBMP.PixelFormat) / 8;
                                int heightInPixels = bitmapdata.Height;
                                int widthInBytes = bitmapdata.Width * bytesPerPixel;

                                byte* ptrFirstPixel = (byte*)bitmapdata.Scan0;

                                Parallel.For(0, heightInPixels, y =>
                                {
                                    byte* currentLine = ptrFirstPixel + (y * bitmapdata.Stride);

                                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                                    {
                                        //GET (not needed for this)
                                        //int oldBlue = currentLine[x];
                                        //int oldGreen = currentLine[x + 1];
                                        //int oldRed = currentLine[x + 2];
                                        //int oldAlpha = currentLine[x + 3];

                                        //checks for alpha value
                                        if (currentLine[x + 3] != 0)
                                        {
                                            //SET
                                            //set this pixel to Black so it won't show up later
                                            currentLine[x] = 0; //blue
                                            currentLine[x + 1] = 0; //green
                                            currentLine[x + 2] = 0; //red
                                            currentLine[x + 3] = 255; //alpha
                                        }
                                    }
                                });
                                TempHandBMP.UnlockBits(bitmapdata);
                            }
                        }

                        // if the BlankHands checkbox is not selected it will have skipped the code to change the colours to pure black and the image will be unedited normal hands drawn on top of the mesh
                        // otherwise the image will be black and be removed from the black background when we capture the backbuffer
                        Texture hand = Texture.FromBitmap(device, TempHandBMP, Usage.None, Pool.Managed);
                        sprite.Draw2D(
                            hand,
                            new Rectangle(0, 0, _selectedHandImage.Width, _selectedHandImage.Height),
                            new Size(_selectedHandImage.Width, _selectedHandImage.Height),
                            new Point(characterGlobalOffsetX + _selectedHandImage.X, characterGlobalOffsetY + _selectedHandImage.Y),
                            Color.White);

                        TempHandBMP.Dispose(); // don't need this anymore
                        
                        sprite.End();
                        sprite.Dispose();

                        device.EndScene(); //end scene here so images are saved to the backbuffer and drawn behind the mesh
                        device.Present();
                    }
                }





                //******************* Mesh ********************




                //begin the scene for drawing the mesh
                device.BeginScene();

                //draw mesh
                if (meshLoaded)
                {
                    for (int i = 0; i < meshMaterials.Length; i++)
                    {
                        // Set the material and texture for this subset.
                        device.Material = meshMaterials[i];
                        device.SetTexture(0, meshTextures[i]);

                        Microsoft.DirectX.Matrix mat1 = new Microsoft.DirectX.Matrix();
                        mat1 = Microsoft.DirectX.Matrix.Multiply(Microsoft.DirectX.Matrix.RotationX((float)(_selectedRefImage.RotationX * (6.28/360))), Microsoft.DirectX.Matrix.RotationY((float)(_selectedRefImage.RotationY * (6.28 / 360))));
                        mat1 = Microsoft.DirectX.Matrix.Multiply(mat1, Microsoft.DirectX.Matrix.RotationZ((float)(_selectedRefImage.RotationZ * (6.28 / 360))));
                        mat1 = Microsoft.DirectX.Matrix.Multiply(mat1, Microsoft.DirectX.Matrix.Translation(_selectedRefImage.MoveX, _selectedRefImage.MoveY, 0));
                        device.Transform.World = mat1;
                        
                        // Draw the mesh subset.
                        mesh.DrawSubset(i);
                    }
                }
                //End the scene
                device.EndScene();
                device.Present();
            }
            catch
            {

            }
        }
        
        private void Btn_Import_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Mesh";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadMesh();
            }
        }

        private void loadMesh()
        {
            mesh = Mesh.FromFile(openFileDialog1.FileName,
                            MeshFlags.SystemMemory,
                            device,
                            out materials);

            meshFileName = openFileDialog1.FileName;

            if (meshTextures == null)
            {
                // Extract the material properties and texture names.
                meshTextures = new Texture[materials.Length];
                meshMaterials = new Material[materials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    meshMaterials[i] = materials[i].Material3D;

                    // Set the ambient color for the material. Direct3D
                    // does not do this by default.
                    //meshMaterials[i].Ambient = meshMaterials[i].Diffuse;
                    meshMaterials[i].Ambient = Color.FromArgb(200,200,200); //changed to be quite bright but not full bright

                    // Create the texture from image file.
                    try
                    {
                        meshTextures[i] = TextureLoader.FromFile(device,  @".\Mesh\" + materials[i].TextureFilename);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load a TextureFile");
                    }
                }
            }
            meshLoaded = true;

            UpdateTextBoxes();
            Render();
        }

        private void OnDeviceReset(object sender, EventArgs e)
        {
            InitializeGraphics();
        }

        private void nud_rotx_ValueChanged(object sender, EventArgs e)
        {
            if (nud_rotx.Value > (decimal)359.99) nud_rotx.Value -= 360;
            if (nud_rotx.Value < 0) nud_rotx.Value += 360;

            _selectedRefImage.RotationX = (float)nud_rotx.Value;
            Render();
        }

        private void nud_roty_ValueChanged(object sender, EventArgs e)
        {
            if (nud_roty.Value > (decimal)359.99) nud_roty.Value -= 360;
            if (nud_roty.Value < 0) nud_roty.Value += 360;

            _selectedRefImage.RotationY = (float)nud_roty.Value;
            Render();
        }

        private void nud_rotz_ValueChanged(object sender, EventArgs e)
        {
            if (nud_rotz.Value > (decimal)359.99) nud_rotz.Value -= 360;
            if (nud_rotz.Value < 0) nud_rotz.Value += 360;

            _selectedRefImage.RotationZ = (float)nud_rotz.Value;
            Render();
        }

        private void nud_x_ValueChanged(object sender, EventArgs e)
        {
            _selectedRefImage.MoveX = (float)nud_x.Value;
            Render();
        }

        private void nud_y_ValueChanged(object sender, EventArgs e)
        {
            _selectedRefImage.MoveY = (float)nud_y.Value;
            Render();
        }

        private void btn_Colour_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            backgroundColour = colorDialog.Color;
            Render();
        }

        private void nud_frame_ValueChanged(object sender, EventArgs e)
        {
            UpdateTextBoxes();
            Render();
        }

        private void checkBox_ShowHands_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowHands.Checked) showHandImage = true;
            else showHandImage = false;
            Render();
        }
        
        private void checkBox_BlankHands_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BlankHands.Checked) blankHandImage = true;
            else blankHandImage = false;
            Render();
        }

        private void Btn_OpenHandRef_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Data\Hands";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            _selectedHandImage = null;

            if (_handLibrary != null) _handLibrary.Close();
            _handLibrary = new MLibraryV2(openFileDialog1.FileName, false);

            Lbl_HandRefName.Text = Path.GetFileName(_handLibrary.FileName);
        }

        private void Btn_ImportLib_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Data";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            _selectedRefImage = null;

            //open reference file character images
            if (_refLibrary != null) _refLibrary.Close();
            _refLibrary = new MLibraryV2(openFileDialog1.FileName, true);
            
            //open Library containing the hand images if file exists
            //I can't get this to work this way... seems access to file is denied when I check if file exists so it always returns false
            //string hfilename = Path.GetDirectoryName(openFileDialog1.FileName) + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_Hands.Lib";
            //if (_handLibrary != null) _handLibrary.Close();
            //if (File.Exists(hfilename)) _handLibrary = new MLibraryV2(hfilename);

            //set number up down control max value and default back to frame 0
            nud_frame.Maximum = _refLibrary.Count - 1;
            nud_frame.Value = 0;

            //set the min and max frames so the user does not need to render every frame each time if only editing a few frames (and importing them to another file using Library editor)
            text_test_framemax.Text = _refLibrary.Count.ToString();
            text_test_framemin.Text = "0";

            UpdateTextBoxes();
            Render();
        }


        //private void button1_Click(object sender, EventArgs e)
        //{

        //    //This code will copy the rotation/location data to another loaded file (used to copy the data from the weapon file I used to set the rotations to the character file used to preview the mesh)

        //    for (int i = 0; i < 80; i++)
        //    {
        //        _selectedRefImage = _refLibrary.GetMImage(i);
        //        _selectedHandImage = _handLibrary.GetMImage(i);
        //        _selectedRefImage.RotationX = _selectedHandImage.RotationX;
        //        _selectedRefImage.RotationY = _selectedHandImage.RotationY;
        //        _selectedRefImage.RotationZ = _selectedHandImage.RotationZ;
        //        _selectedRefImage.MoveX = _selectedHandImage.MoveX;
        //        _selectedRefImage.MoveY = _selectedHandImage.MoveY;
        //    }



        //    //quick button to remove the image for frames I need to be blanked out
        //    //_refLibrary.ReplaceImage((int)nud_frame.Value, null, 0, 0);

        //    Render();
        //}

        //This code will duplicate the rotation/location data from the male to female frames to save some time setting the files up (it is set as 416 for the CWeapons(Mir2 War/Wiz/Tao))
        //private void button_duplicate416_Click(object sender, EventArgs e)
        //{
        //    for(int x = 0; x < 416; x++)
        //    {
        //        _selectedRefImage = _refLibrary.GetMImage(x);
        //        float tmovex = _selectedRefImage.MoveX;
        //        float tmovey = _selectedRefImage.MoveY;
        //        float trotx = _selectedRefImage.RotationX;
        //        float troty = _selectedRefImage.RotationY;
        //        float trotz = _selectedRefImage.RotationZ;
        //        _selectedRefImage = _refLibrary.GetMImage(x + 416);
        //        _selectedRefImage.MoveX = tmovex;
        //        _selectedRefImage.MoveY = tmovey;
        //        _selectedRefImage.RotationX = trotx;
        //        _selectedRefImage.RotationY = troty;
        //        _selectedRefImage.RotationZ = trotz;
        //    }
        //}


        private void Btn_ExportLib_Click(object sender, EventArgs e)
        {
            //Really small Images may break this as I've not added checks for creating images that are 0 pixels width or height

            //create a new Library to store everything as each frame is rendered and saved
            if (_library != null) _library.Close();
            _library = new MLibraryV2("", false);
            
            //open saveFileDialog so the user can select a file name for the new .lib file
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "CompletedLibs";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".lib";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            _library.FileName = saveFileDialog.FileName;

            toolStripProgressBar.Maximum = Convert.ToInt16(text_test_framemax.Text);
            toolStripProgressBar.Step = (Convert.ToInt16(text_test_framemax.Text) - Convert.ToInt16(text_test_framemin.Text)) / 20;

            t1 = new Thread(ExportThread);
            //t1.IsBackground = true; //setting as background stops the infinite looped thread when main app is closed
            t1.Start();

            
        }

        private void ExportThread()
        {
            //create timer so we can check how long it takes to create the whole file
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing
            stopwatch.Start();

            //for (int i = 0; i < _refLibrary.Count; i++)
            for (int i = Convert.ToInt16(text_test_framemin.Text); i < Convert.ToInt16(text_test_framemax.Text); i++)
            {
                showRefImage = false; //turns off the ref image while we render the new library
                nud_frame.Value = i; //just setting this value and then calling Render() is enough to cycle through the frames
                backgroundColour = Color.Black; //set the background to black so the crop code can detect the blank areas and remove pure black pixels from the image, if set to any other colour the image will have a solid colour background and not become transparent
                UpdateTextBoxes(); //this will set the _selectedRefImage for the current frame
                Render();

                #region Save Snapshot of the Directx panel
                try
                {
                    Surface backbuffer = device.GetBackBuffer(0, 0, BackBufferType.Mono);
                    //SurfaceLoader.Save("Screenshot.bmp", ImageFileFormat.Bmp, backbuffer); //saves file (to test it is working)

                    //if you continue to Render the DirectX panel while updating the GraphicsStream it causes the device to be lost and crashes
                    //so I just call Render(); when I need to update the panel instead of using the infinite loop thread
                    #region Graphics Lock
                    GraphicsStream gs = backbuffer.LockRectangle(LockFlags.Discard);

                    gs.Position = 0; //set start position
                    int bytesPerPixel = 4;
                    int currentPosition = 0;
                    int heightInPixels = 250;
                    int widthInPixels = 250;

                    //Crop offsets
                    int XMin = 249;
                    int XMax = 0;
                    int YMin = 249;
                    int YMax = 0;

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        //couldn't use the Parallel.For loop as it would overwrite the GraphicsStream.Position because it was working on two or
                        //more pixels at once causing a speckled effect as it misses pixels (well I think that is what was causing the errors I was having)
                        //Parallel.For(0, heightInPixels, y =>
                        //{
                        //int currentLine = (y * ((widthInPixels * bytesPerPixel) + (4 *12))); //4*12 is how many pixels (12 for 500pixel image) was missing from each row (not sure why 12 but I guess the backbuffer extends beyond the screen)
                        int currentLine = (y * (widthInPixels * bytesPerPixel) + (y * (4 * 6))); //4*6 is how many pixels (6 for 250pixel image) was missing from each row (not sure why 6 but I guess the backbuffer extends beyond the screen)

                        for (int x = 0; x < widthInPixels; x++)
                        {
                            byte[] bu = new byte[4]; //new byte to store current pixel data
                            currentPosition = currentLine + (x * bytesPerPixel); //calculate current position
                            gs.Position = currentPosition; //set pixel position in GraphicsStream
                            gs.Read(bu, 0, 4); //read image pixel data

                            //gets RGB values
                            int r = bu[2];
                            int g = bu[1];
                            int b = bu[0];
                            Color c = Color.FromArgb(r, g, b);

                            if (c.R != backgroundColour.R && c.G != backgroundColour.G && c.B != backgroundColour.B) //if not the same as backgroundColour set the min/max values
                            {
                                if (XMin > x) XMin = x;
                                if (XMax < x) XMax = x;
                                if (YMin > y) YMin = y;
                                if (YMax < y) YMax = y;
                            }

                            //if (y == YMin) //this is a way to show where the image is cropped
                            //{
                            //    bu[2] = 255;
                            //    bu[1] = 0;
                            //    bu[0] = 0;
                            //}

                            gs.Position = currentPosition; //sets the position back to the starting pixel
                            gs.Write(bu, 0, 4); //updates the GraphicsStream with the new changes

                        }
                        //}); //end of Parallel.For loop
                    }

                    //Shows the detected bounds of the image for testing
                    //MessageBox.Show("XMin: " + XMin
                    //    + Environment.NewLine + "XMax: " + XMax
                    //    + Environment.NewLine + "YMin: " + YMin
                    //    + Environment.NewLine + "YMax: " + YMax
                    //    + Environment.NewLine + "Width: " + (XMax - XMin)
                    //    + Environment.NewLine + "Height: " + (YMax - YMin));

                    backbuffer.UnlockRectangle();
                    gs.Dispose();
                    #endregion

                    Bitmap Preview = new Bitmap(SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, backbuffer));

                    #region crop

                    //create target image and draw cropped part of the Preview image to the target image
                    Bitmap target = new Bitmap((XMax - XMin) + 1, (YMax - YMin) + 1, PixelFormat.Format32bppArgb);
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(Preview, new RectangleF(0, 0, target.Width, target.Height), new RectangleF(XMin, YMin, (XMax - XMin) + 1, (YMax - YMin) + 1), GraphicsUnit.Pixel);
                    }

                    #endregion

                    //Add Image and offsets to the _library
                    _library.AddImage(target,
                        (short)(XMin - characterGlobalOffsetX),
                        (short)(YMin - characterGlobalOffsetY));

                    //target.Save("Test1.PNG", ImageFormat.Png); //testing screen capture and crop image from directx works by saving to file

                    target.Dispose();
                    Preview.Dispose();
                    backbuffer.Dispose();
                }
                catch (Direct3DXException ee) //Display error Messages with the DirectX code
                {
                    MessageBox.Show("Message: " + ee.Message
                        + Environment.NewLine + "ErrorString: " + ee.ErrorString
                        + Environment.NewLine + "ErrorCode: " + ee.ErrorCode
                        + Environment.NewLine + "StackTrace: " + ee.StackTrace
                        );
                }
                #endregion


                toolStripProgressBar.Value = i + 1;
            }

            //save file as normal .lib (true = reference file, false = normal .lib)
            _library.Save(false);

            stopwatch.Stop();
            MessageBox.Show(string.Format("Time Taken: {0:n0} Seconds", stopwatch.Elapsed.TotalMilliseconds / 1000));
            toolStripProgressBar.Value = 0;
            showRefImage = true;
            nud_frame.Value = 0;
            Render();
        }

        private void UpdateTextBoxes()
        {
            _selectedRefImage = _refLibrary.GetMImage((int)nud_frame.Value);

            Lbl_RefName.Text = Path.GetFileName(_refLibrary.FileName);
            Lbl_MeshName.Text = Path.GetFileName(meshFileName);
            textBox_OffSetX.Text = _selectedRefImage.X.ToString();
            textBox_OffSetY.Text = _selectedRefImage.Y.ToString();
            nud_rotx.Value = (decimal)_selectedRefImage.RotationX;
            nud_roty.Value = (decimal)_selectedRefImage.RotationY;
            nud_rotz.Value = (decimal)_selectedRefImage.RotationZ;
            nud_x.Value = (decimal)_selectedRefImage.MoveX;
            nud_y.Value = (decimal)_selectedRefImage.MoveY;
        }

        private void btn_SaveRef_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Data";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            _refLibrary.FileName = saveFileDialog.FileName;
            _refLibrary.Save(true);
        }

        //private void OnProcessExit(object sender, EventArgs e)
        //{
        //    //do not need to abort the thread because it is set as a background thread and closes with the main programme
        //    //t1.Abort();
        //}

        //static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        //{
        //    Exception e = (Exception)args.ExceptionObject;
        //    MessageBox.Show("MyHandler caught : " + e.Message);
        //    //MessageBox.Show("Runtime terminating: {0}", args.IsTerminating);
        //    //Console.WriteLine("MyHandler caught : " + e.Message);
        //    //Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        //}
    }
}
