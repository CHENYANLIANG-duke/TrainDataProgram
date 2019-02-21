using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Threading;
using System.Diagnostics;
#if !(__IOS__ || NETFX_CORE)
using Emgu.CV.Cuda;
#endif


namespace TrainDataProgram
{
    public partial class btnharrtrf : Form
    {
        public btnharrtrf()
        {
            InitializeComponent();
        }

        #region define
        Image<Bgr, byte> img;
        Image<Bgr, byte> img2;
        Image<Bgr, byte> img3;
        Image<Gray, byte> imagehsv;
        List<Point> listPoint = new List<Point>();
        Rectangle Rect;
        String datapath = Path.GetDirectoryName(Application.UserAppDataPath);
        float objectcenterinX;
        float objectcenterinY;
        float objectwidthinX;
        float objectwidthinY;
        float c1x; //左上角的x點
        float c2x; //右下角的X點
        float c1y; //左上角的Y點
        float c2y; //右下角的Y點
        float cx;
        float cy;
        string traindatainfo;
        int classno;
        string[] classname;
        string[] imgjpg;//存放所有的jpg
        List<string> imgroi = new List<string>();//存放所有的roijpg
        string[] haarmodel; //存放haar model
        string[,] haarmodell;
        string filename;
        string fileroot;
        int recordcount = 0;
        int jpgcount = 0;
        int haartimes = 0;
        int haarscore = 0;
        Boolean hsvcheck;
        Boolean haarcheck;
        List<float> calp1x = new List<float>();
        List<float> calp1y = new List<float>();
        List<float> calp2x = new List<float>();
        List<float> calp2y = new List<float>();
        List<Mat> mats = new List<Mat>();
        List<List<int>> temppoints = new List<List<int>>();
        Random ran = new Random();

        #endregion

        #region btnaction

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                jpgcount = 0;
                txtPath.Text = openFileDialog1.FileName;
                // img = new Image<Bgr, byte>(txtPath.Text).Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.Inter.Area, true);
                img = new Image<Bgr, byte>(txtPath.Text);
                pictureBox1.Image = img.ToBitmap();

                Recordlabel(openFileDialog1.FileName);
            }

        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileroot + @"\" + filename + ".txt", true);
                sw.Write(traindatainfo + "\r\n");
                sw.Close();

                classno = Convert.ToInt32(comboBox1.SelectedItem);
                MessageBox.Show("Save");

                pictureBox1.Image = img.ToBitmap();
                if (checkBox1.Checked)
                {
                    classno++;
                }
                comboBox1.SelectedIndex = classno;
                label13.Text = classname[comboBox1.SelectedIndex];
                listPoint.Clear();
            }
            catch (Exception ex) { }
        }

        private Point UnScale(Point scaledP)
        {
            if (pictureBox1.SizeMode != PictureBoxSizeMode.Zoom) //only zoom mode need to scale
                return scaledP;
            Point unscaled_p = new Point();
            // image and container dimensions
            int w_i = pictureBox1.Image.Width;
            int h_i = pictureBox1.Image.Height;
            int w_c = pictureBox1.Width;
            int h_c = pictureBox1.Height;
            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                // horizontal image
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                // calculate gap between top of container and top of image
                float filler = Math.Abs(h_c - scaledHeight) / 2;
                unscaled_p.X = (int)(scaledP.X / scaleFactor);
                unscaled_p.Y = (int)((scaledP.Y - filler) / scaleFactor);
            }
            else
            {
                // vertical image
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
                unscaled_p.X = (int)((scaledP.X - filler) / scaleFactor);
                unscaled_p.Y = (int)(scaledP.Y / scaleFactor);
            }
            return unscaled_p;
        }

        private void PictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            try
            {
                listPoint.Add(UnScale(e.Location));
                if (listPoint.Count > 1)
                {
                    CvInvoke.Circle(img2, listPoint[0], 2, new MCvScalar(0, 255, 0), 3);
                    CvInvoke.Circle(img2, listPoint[1], 2, new MCvScalar(0, 255, 0), 3);

                    label3.Text = listPoint[0].ToString();
                    label5.Text = listPoint[1].ToString();

                    Point PointC = new Point();

                    c1x = listPoint[0].X;
                    c2x = listPoint[1].X;
                    c1y = listPoint[0].Y;
                    c2y = listPoint[1].Y;
                    cx = (c1x + c2x) / 2;
                    cy = (c1y + c2y) / 2;

                    PointC.X = (int)cx;
                    PointC.Y = (int)cy;

                    label7.Text = PointC.ToString();

                    CvInvoke.Circle(img2, PointC, 2, new MCvScalar(0, 255, 0), 3);
                    pictureBox1.Image = img2.ToBitmap();

                    objectcenterinX = cx / img.Width; //centerX / ImageW
                    objectcenterinY = cy / img.Height; //centerY / ImageH
                    objectwidthinX = (c2x - c1x) / img.Width;   //BBoxW / ImageW
                    objectwidthinY = (c2y - c1y) / img.Height;  //BBoxH / ImageH

                    traindatainfo = comboBox1.SelectedIndex.ToString() + " " + objectcenterinX + " " + objectcenterinY + " " + objectwidthinX + " " + objectwidthinY;
                    txtTrainingData.Text = traindatainfo;

                    img3 = img.Clone();

                    Rect = new Rectangle();
                    Rect.Location = listPoint[0];
                    Rect.Size = new Size((int)(c2x - c1x), (int)(c2y - c1y));
                    img3.ROI = Rect;
                    pictureBox2.Image = img3.Resize(pictureBox2.Width, pictureBox2.Height, Inter.Linear, true).ToBitmap();
                    recordcount++;
                }
                if (listPoint.Count > 2)
                {
                    MessageBox.Show("over pointcount!");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void BtnSaveClass_Click(object sender, EventArgs e)
        {
            classname = textBox1.Text.Split(',');
            for (int i = 0; i < classname.Length; i++)
            {
                comboBox1.Items.Add(i);
            }
            StreamWriter sa = File.CreateText(Path.Combine(datapath, "unitech_scaner.cfg"));
            sa.Write(textBox1.Text);
            sa.Flush();
            sa.Close();
            MessageBox.Show("save succesed!!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] strxml;
                strxml = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory(), "*.xml");

                for (int i = 0; i < strxml.Length; i++)
                {
                    comboBox2.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox3.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox4.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox5.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox6.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox7.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox8.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox9.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox10.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox11.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox12.Items.Add(Path.GetFileName(strxml[i]));
                    comboBox13.Items.Add(Path.GetFileName(strxml[i]));
                }

                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 3;
                comboBox4.SelectedIndex = 6;
                comboBox5.SelectedIndex = 9;
                comboBox6.SelectedIndex = 10;
                comboBox7.SelectedIndex = 7;
                comboBox8.SelectedIndex = 4;
                comboBox9.SelectedIndex = 1;
                comboBox10.SelectedIndex = 11;
                comboBox11.SelectedIndex = 8;
                comboBox12.SelectedIndex = 5;
                comboBox13.SelectedIndex = 2;

                StreamReader sa = File.OpenText(Path.Combine(this.datapath, "unitech_scaner.cfg"));
                textBox1.Text = sa.ReadLine();
                classname = textBox1.Text.Split(',');
                for (int i = 0; i < classname.Length; i++)
                {
                    comboBox1.Items.Add(i);
                }
                sa.Close();
            }
            catch (Exception EX) { }
        }

        private void Btnfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                imgjpg = Directory.GetFileSystemEntries(folder.SelectedPath, "*.jpg");

                txtPath.Text = imgjpg[jpgcount];

                img = new Image<Bgr, byte>(imgjpg[jpgcount]);

                pictureBox1.Image = img.ToBitmap();

                Recordlabel(imgjpg[jpgcount]);

                MessageBox.Show("ok");
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (jpgcount < imgjpg.Length)
                {
                    jpgcount++;
                    img = new Image<Bgr, byte>(imgjpg[jpgcount]);
                    txtPath.Text = imgjpg[jpgcount];
                    pictureBox1.Image = img.ToBitmap();
                    Recordlabel(imgjpg[jpgcount]);
                }
                else
                {
                    MessageBox.Show("last image , already");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Btnpre_Click(object sender, EventArgs e)
        {
            try
            {
                if (jpgcount > 0)
                {
                    jpgcount--;
                    img = new Image<Bgr, byte>(imgjpg[jpgcount]);
                    txtPath.Text = imgjpg[jpgcount];
                    pictureBox1.Image = img.ToBitmap();
                    Recordlabel(imgjpg[jpgcount]);
                }
                else
                {
                    MessageBox.Show("first image , already !");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text = classname[comboBox1.SelectedIndex];
        }

        private void BtnAutocombine_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;

                string[] imgpng;//存放所有的png
                imgpng = Directory.GetFileSystemEntries(folderpath, "*.png");

                string[] imgjpg;
                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");

                progressBar1.Maximum = imgpng.Length;

                for (int i = 0; i < imgpng.Length; i++)
                {
                    progressBar1.Value = i + 1;

                    for (int j = i; j < imgjpg.Length; j = j + imgpng.Length)
                    {
                        //取得檔案名稱
                        string imgpngfilename = Path.GetFileNameWithoutExtension(imgpng[i]);
                        Image<Bgra, byte> imglogo = new Image<Bgra, byte>(imgpng[i]);
                        Image<Bgra, byte> imgbackground = new Image<Bgra, byte>(imgjpg[j]);
                        string txtcpath = imgjpg[j].Replace(".jpg", ".txt");
                        CvInvoke.MedianBlur(imglogo, imglogo, 3);
                        cvAdd4cMat(imglogo, imgbackground, 1.0, imgjpg[j], txtcpath, imgpngfilename);
                        imgbackground.Dispose();
                        imglogo.Dispose();
                        Thread.Sleep(200);
                    }
                }


                //清除原始背景圖檔
                for (int d = 0; d < imgjpg.Length; d++)
                {
                    File.Delete(imgjpg[d]);
                }

                MessageBox.Show("ok!");

                progressBar1.Value = 0;
            }
        }

        private void Btnresize_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {

                //  string[] imgjpg;//存放所有的png
                imgjpg = Directory.GetFileSystemEntries(folder.SelectedPath, "*.jpg");

                progressBar1.Maximum = imgjpg.Length;

                for (int j = 0; j < imgjpg.Length; j++)
                {
                    progressBar1.Value = 1 + j;

                    Image<Bgr, byte> imgbackground = new Image<Bgr, byte>(imgjpg[j]);

                    Image<Bgr, byte> imgnewbackground = imgbackground.Resize(Convert.ToInt32(txtwidth.Text), Convert.ToInt32(txtheight.Text), Inter.Linear);

                    imgnewbackground.Save(imgjpg[j].Replace(" ", "_"));

                    imgbackground.Dispose();
                    imgnewbackground.Dispose();
                    File.Delete(imgjpg[j]);
                }
                MessageBox.Show("resize complete !");
            }
            progressBar1.Value = 0;
        }

        private void BtnBrigtness_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;
                //  string[] imgjpg;
                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");
                progressBar1.Maximum = imgjpg.Length;

                for (int i = 0; i < imgjpg.Length; i++)
                {

                    Image<Bgr, byte> imgbackground = new Image<Bgr, byte>(imgjpg[i]);
                    ChangeBrigtness(imgbackground, imgjpg[i]);

                    progressBar1.Value = i + 1;
                    imgbackground.Dispose();
                    Thread.Sleep(200);
                }

                MessageBox.Show("finished!");
                progressBar1.Value = 0;

            }
        }

        private void Btnallnoisy_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;
                //  string[] imgjpg;
                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");
                progressBar1.Maximum = imgjpg.Length;

                for (int i = 0; i < imgjpg.Length; i++)
                {
                    Image<Bgr, byte> imgbackground = new Image<Bgr, byte>(imgjpg[i]);
                    progressBar1.Value = i + 1;

                    int rd = ran.Next(0, 8);

                    switch (rd)
                    {
                        case 1:
                            imgEqualizeHist(imgbackground, imgjpg[i]);
                            break;

                        case 2:
                            medfilter(imgbackground, imgjpg[i]);
                            break;
                        case 3:
                            SaltPepperNoise(imgbackground, imgjpg[i], 800, "A");
                            break;
                        case 4:
                            SaltPepperNoise(imgbackground, imgjpg[i], 800, "B");
                            break;

                    }

                    imgbackground.Dispose();
                }
                MessageBox.Show("finished!");
                progressBar1.Value = 0;
            }
        }

        private void BtnGetCount_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;
                string[] imgjpg;
                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg", SearchOption.AllDirectories);
                textBox1.Text = imgjpg.Length.ToString();
            }
        }

        private void BtnDetectTRF_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string haardetectpath = folder.SelectedPath + @"\haar_detected";

                foreach (string roi in Directory.GetFileSystemEntries(haardetectpath, "*.jpg"))
                {
                    if (roi.Contains("-roi") == true)
                    {
                        imgroi.Add(roi);
                    }
                }

                Log(folder.SelectedPath, "imgroi.count =" + imgroi.Count.ToString() + "\n\r");

                for (int i = 0; i < imgroi.Count; i++)
                {
                    hsvcheck = false;

                    img = new Image<Bgr, byte>(imgroi[i]);
                    int stroi = imgroi[i].IndexOf("-roi");
                    var roifilename = Path.GetFileNameWithoutExtension(imgroi[i]);//roi file

                    //roi name and full name
                    string FullImagePath = imgroi[i].Remove(stroi, 4);
                    string FullImageName = Path.GetFileNameWithoutExtension(FullImagePath);

                    if (hsvcheck == false)
                    {
                        HSVfilit(haardetectpath, FullImageName, 0, img);
                        if (hsvcheck == true)
                        {
                            Log(folder.SelectedPath, FullImageName + "find red hsv" + "\n\r");
                        }
                    }

                    if (hsvcheck == false)
                    {
                        Log(folder.SelectedPath, FullImageName + "can't find red hsv" + "\n\r");
                        HSVfilit(haardetectpath, FullImageName, 1, img);
                        if (hsvcheck == true)
                        {
                            Log(folder.SelectedPath, FullImageName + "find blue hsv" + "\n\r");
                        }
                    }
                    if (hsvcheck == false)
                    {
                        Log(folder.SelectedPath, FullImageName + "can't find blue hsv" + "\n\r");
                        File.Delete(FullImagePath);
                        File.Delete(FullImagePath.Replace(".jpg", ".txt"));
                        File.Delete(imgroi[i]);
                        Log(folder.SelectedPath, "delete : " + FullImageName);
                    }
                    Thread.Sleep(10);
                }
                Log(folder.SelectedPath, "finished hsv filit total image  \n\r");
                MessageBox.Show("Hsv finished");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                IImage image;
                image = new UMat(txtPath.Text, ImreadModes.Color); //UMat version

                List<Rectangle> faces = new List<Rectangle>();

                txtTrainingData.Text = "";

                using (InputArray iaImage = image.GetInputArray())
                {
                    if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
                    {

                        using (CudaCascadeClassifier face = new CudaCascadeClassifier(comboBox2.SelectedItem.ToString()))
                        {
                            face.ScaleFactor = 1.1;
                            face.MinNeighbors = 10;
                            face.MinObjectSize = Size.Empty;

                            using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(image))
                            using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                            using (GpuMat region = new GpuMat())
                            {
                                face.DetectMultiScale(gpuGray, region);
                                Rectangle[] faceRegion = face.Convert(region);
                                faces.AddRange(faceRegion);
                            }
                        }
                    }
                    else
                    {
                        using (CascadeClassifier face = new CascadeClassifier(comboBox2.SelectedItem.ToString()))
                        {
                            using (UMat ugray = new UMat())
                            {
                                CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                                //normalizes brightness and increases contrast of the image
                                CvInvoke.EqualizeHist(ugray, ugray);

                                //Detect the faces  from the gray scale image and store the locations as rectangle
                                //The first dimensional is the channel
                                //The second dimension is the index of the rectangle in the specific channel                     
                                Rectangle[] facesDetected = face.DetectMultiScale(
                                   ugray,
                                   1.1,
                                   10,
                                   new Size(100, 100));
                                faces.AddRange(facesDetected);

                                for (int i = 0; i < facesDetected.Length; i++)
                                {
                                    if (facesDetected[i].Width >= 100 && facesDetected[i].Height >= 100)
                                    {
                                        var imgtemp = facesDetected[i];
                                        img.ROI = imgtemp;
                                        img.Save(txtPath.Text.Replace(".jpg", "-" + i.ToString() + ".jpg"));
                                        pictureBox2.Image = img.Bitmap;
                                        img.ROI = new Rectangle();

                                        int harrpointX1 = facesDetected[i].X;
                                        int harrpointY1 = facesDetected[i].Y;
                                        int harrpointX2 = facesDetected[i].X + facesDetected[i].Width;
                                        int harrpointY2 = facesDetected[i].Y + facesDetected[i].Height;

                                        label3.Text = harrpointX1.ToString() + "," + harrpointY1.ToString();
                                        label5.Text = harrpointX2.ToString() + "," + harrpointY2.ToString();
                                        label7.Text = (harrpointX2 - harrpointX1).ToString() + "," + (harrpointY2 - harrpointY1).ToString();

                                        calyolopoint(harrpointX1, harrpointY1, harrpointX2, harrpointY2, img.Width, img.Height, txtPath.Text.Replace(".jpg", "-" + i.ToString() + ".txt"));
                                        File.Delete(txtPath.Text);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (Rectangle face in faces)
                {
                    CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
                }

                pictureBox1.Image = image.Bitmap;

                using (InputArray iaImage = image.GetInputArray())
                {
                    if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
                    { textBox1.Text = "use cuda"; }
                    else if (iaImage.IsUMat && CvInvoke.UseOpenCL)
                    {
                        textBox1.Text = "use openCL";
                    }
                    else
                    { textBox1.Text = "USE CPU"; }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }

        private void Btnhaarauto_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;

                // creat p folder
                Directory.CreateDirectory(folderpath + @"\p");
                // creat n folder
                Directory.CreateDirectory(folderpath + @"\n");
                //creat haar_detected
                Directory.CreateDirectory(folderpath + @"\haar_detected");


                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");

                progressBar1.Maximum = imgjpg.Length;

                //reacher all .jpg
                Stopwatch sw = new Stopwatch();
                sw.Start();

                haarmodel = new string[4] { comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.ToString() };

                for (int c = 0; c < imgjpg.Length; c++)
                {
                    haarcheck = false;

                    IImage scr = new UMat(imgjpg[c], ImreadModes.Color); //UMat version

                    Log(folderpath, c.ToString() + "\r\n" + "in:" + imgjpg[c]);

                    using (img = new Image<Bgr, byte>(imgjpg[c]))
                    using (InputArray iaImage = scr.GetInputArray())
                    {
                        //設定haar全自動或半自動
                        if (radsinglemodel.Checked)
                        {
                            haarscore = 0;
                            Haardetection(scr, folderpath, c.ToString() + ".jpg", comboBox2.SelectedItem.ToString(), Convert.ToInt32(comboBox1.SelectedItem));
                        }
                        if (radallmodel.Checked)
                        {
                            haartimes = 4;     //哈爾計數       
                            Log(folderpath, "haar in:" + imgjpg[c]);
                            //輪巡model
                            for (int h = 0; h < haarmodel.Length; h++)
                            {
                                if (haarcheck == false)
                                {
                                    Haardetection(scr, folderpath, c.ToString() + ".jpg", haarmodel[h], h);
                                    Thread.Sleep(1);
                                    Application.DoEvents();
                                }
                                else if (haarcheck == true)
                                    break;
                            }
                            Log(folderpath, "haar out:" + imgjpg[c] + "\n\r");
                        }
                    }

                    progressBar1.Value = c + 1;
                    Thread.Sleep(1);
                }

                for (int i = 0; i < imgjpg.Length; i++)
                {
                    File.Delete(imgjpg[i]);
                }
                sw.Stop();
                MessageBox.Show("finished!" + sw.Elapsed.TotalMilliseconds);
                progressBar1.Value = 0;
            }
        }

        private void BtnHaarHsv_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                //doing haar

                string folderpath = folder.SelectedPath;
                // creat p folder
                Directory.CreateDirectory(folderpath + @"\p");
                // creat n folder
                Directory.CreateDirectory(folderpath + @"\n");
                //creat haar_detected
                Directory.CreateDirectory(folderpath + @"\haar_detected");

                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");

                progressBar1.Maximum = imgjpg.Length;

                //reacher all .jpg
                Stopwatch sw = new Stopwatch();
                sw.Start();

                haarmodel = new string[4] { comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.ToString() };

                for (int c = 0; c < imgjpg.Length; c++)
                {
                    IImage scr = new UMat(imgjpg[c], ImreadModes.Color); //UMat version

                    haarcheck = false;

                    Log(folderpath, c.ToString() + "\r\n" + "in:" + imgjpg[c]);

                    using (img = new Image<Bgr, byte>(imgjpg[c]))
                    using (InputArray iaImage = scr.GetInputArray())
                    {
                        //設定haar全自動或半自動
                        if (radsinglemodel.Checked)
                        {
                            Haardetection(scr, folderpath, c.ToString() + ".jpg", comboBox2.SelectedItem.ToString(), Convert.ToInt32(comboBox1.SelectedItem));
                        }
                        if (radallmodel.Checked)
                        {
                            haartimes = 4;     //哈爾計數       
                            Log(folderpath, "haar in:" + imgjpg[c]);
                            //輪巡model
                            for (int h = 0; h < haarmodel.Length; h++)
                            {
                                if (haarcheck == false)
                                {
                                    Haardetection(scr, folderpath, c.ToString() + ".jpg", haarmodel[h], h);
                                    Thread.Sleep(10);
                                    Application.DoEvents();
                                }
                                else if (haarcheck == true)
                                    break;
                            }
                            Log(folderpath, "haar out:" + imgjpg[c] + "\r\n");
                        }
                    }

                    progressBar1.Value = c + 1;
                    Thread.Sleep(1);
                }

                for (int i = 0; i < imgjpg.Length; i++)
                {
                    File.Delete(imgjpg[i]);
                }


                //doing HSV Filiter

                string haardetectpath = folder.SelectedPath + @"\haar_detected";

                foreach (string roi in Directory.GetFileSystemEntries(haardetectpath, "*.jpg"))
                {
                    if (roi.Contains("-roi") == true)
                    {
                        imgroi.Add(roi);
                    }
                }

                Log(folder.SelectedPath, "imgroi.count =" + imgroi.Count.ToString() + "\r\n");

                for (int i = 0; i < imgroi.Count; i++)
                {
                    hsvcheck = false;

                    img = new Image<Bgr, byte>(imgroi[i]);
                    int stroi = imgroi[i].IndexOf("-roi");
                    var roifilename = Path.GetFileNameWithoutExtension(imgroi[i]);//roi file

                    //roi name and full name
                    string FullImagePath = imgroi[i].Remove(stroi, 4);
                    string FullImageName = Path.GetFileNameWithoutExtension(FullImagePath);

                    if (hsvcheck == false)
                    {
                        HSVfilit(haardetectpath, FullImageName, 0, img);
                        if (hsvcheck == true)
                        {
                            Log(folder.SelectedPath, FullImageName + "find red hsv" + "\n\r");
                        }
                    }

                    if (hsvcheck == false)
                    {
                        Log(folder.SelectedPath, FullImageName + "can't find red hsv" + "\n\r");
                        HSVfilit(haardetectpath, FullImageName, 1, img);
                        if (hsvcheck == true)
                        {
                            Log(folder.SelectedPath, FullImageName + "find blue hsv" + "\n\r");
                        }
                    }
                    if (hsvcheck == false)
                    {
                        Log(folder.SelectedPath, FullImageName + "can't find blue hsv" + "\n\r");
                        File.Delete(FullImagePath);
                        File.Delete(FullImagePath.Replace(".jpg", ".txt"));
                        File.Delete(imgroi[i]);
                        Log(folder.SelectedPath, "delete : " + FullImageName);
                    }
                    Thread.Sleep(10);
                }
                Log(folder.SelectedPath, "finished hsv filit total image  \r\n");

                sw.Stop();
                MessageBox.Show("finished!" + sw.Elapsed.TotalMilliseconds);
                progressBar1.Value = 0;
            }
        }

        private void btnreadhsv_Click(object sender, EventArgs e)
        {
            Image<Hsv, Byte> Hsvimage = img.Convert<Hsv, Byte>();

            //range 156 - 180
            List<double> Hred1 = new List<double>();
            //range 0-10
            List<double> Hred2 = new List<double>();
            //range 100-124
            List<double> HBlue = new List<double>();

            double hdata;

            for (int row = 0; row < img.Height; row++)
            {
                for (int col = 0; col < img.Width; col++)
                {
                    Boolean HSVcheck = false;

                    hdata = Hsvimage.Data[row, col, 0];

                    if (hsvcheck == false)
                    {
                        if (hdata < 180 && hdata > 156)
                        {
                            Hred1.Add(hdata);
                            HSVcheck = true;
                        }
                        if (hdata < 10 && hdata > 0)
                        {
                            Hred2.Add(hdata);
                            hsvcheck = true;
                        }
                    }
                    if (hsvcheck = false && hdata < 124 && hdata > 100)
                    {
                        HBlue.Add(hdata);
                    }
                }
            }

            Hred1.Sort();
            Hred2.Sort();
            HBlue.Sort();

            for (int i = 0; i < Hred1.Count; i++)
            {
                Log(@"C:\Users\user\Desktop\hdata", Hred1[i].ToString());
            }
            MessageBox.Show("OK");
        }
        #endregion

        #region method

        void Recordlabel(string imgpath)
        {
            listPoint.Clear();
            label9.Text = img.Width.ToString();
            label11.Text = img.Height.ToString();
            classno = 0;

            img2 = img.Clone();

            label13.Text = classname[Convert.ToInt16(comboBox1.SelectedItem)];
            filename = Path.GetFileNameWithoutExtension(imgpath);
            fileroot = Path.GetDirectoryName(imgpath);
        }

        void Changesize(Image<Bgra, byte> scr, string imgcombinepath)
        {
            Image<Bgr, byte> imgtemp;

            Random rd = new Random();
            int cutw = rd.Next(1, 5) * 15;
            int resizecount = 100 / cutw;

            for (int i = 1; i < resizecount + 1; i++)
            {
                // resize height
                int resizeW = scr.Width + ((scr.Width * cutw) / 100) * i;

                using (imgtemp = new Image<Bgr, byte>(resizeW, scr.Height))
                {
                    //產生座標
                    for (int p = 0; p < calp1x.Count; p++)
                    {
                        calyolopoint(calp1x[p], calp1y[p], calp2x[p], calp2y[p], resizeW, scr.Height, imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + i + ".txt"));
                    }
                    //產生變形圖
                    for (int row = 0; row < scr.Height; row++)
                    {
                        for (int col = 0; col < scr.Width; col++)
                        {
                            imgtemp.Data[row, col, 0] = scr.Data[row, col, 0];
                            imgtemp.Data[row, col, 1] = scr.Data[row, col, 1];
                            imgtemp.Data[row, col, 2] = scr.Data[row, col, 2];
                        }
                    }
                    imgtemp.Save(imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + i + ".jpg"));
                    imgtemp.Dispose();
                }
                // resize width
                int resizeH = scr.Height + ((scr.Height * cutw) / 100) * i;
                using (imgtemp = new Image<Bgr, byte>(scr.Width, resizeH))
                {
                    //產生座標
                    for (int p = 0; p < calp1x.Count; p++)
                    {
                        calyolopoint(calp1x[p], calp1y[p], calp2x[p], calp2y[p], scr.Width, resizeH, imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + (i + resizecount) + ".txt"));
                    }
                    //產生變形圖
                    for (int row = 0; row < scr.Height; row++)
                    {
                        for (int col = 0; col < scr.Width; col++)
                        {
                            imgtemp.Data[row, col, 0] = scr.Data[row, col, 0];
                            imgtemp.Data[row, col, 1] = scr.Data[row, col, 1];
                            imgtemp.Data[row, col, 2] = scr.Data[row, col, 2];
                        }
                    }
                    imgtemp.Save(imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + (i + resizecount) + ".jpg"));
                    imgtemp.Dispose();
                }
                // resize width & height
                int resizeH1 = scr.Height + ((scr.Height * cutw) / 100) * i;
                int resizeW1 = scr.Width + ((scr.Width * cutw) / 100) * i;
                using (imgtemp = new Image<Bgr, byte>(resizeW1, resizeH1))
                {
                    //產生座標
                    for (int p = 0; p < calp1x.Count; p++)
                    {
                        calyolopoint(calp1x[p], calp1y[p], calp2x[p], calp2y[p], resizeW1, resizeH1, imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + (i + resizecount * 2) + ".txt"));
                    }
                    //產生變形圖
                    for (int row = 0; row < scr.Height; row++)
                    {
                        for (int col = 0; col < scr.Width; col++)
                        {
                            imgtemp.Data[row, col, 0] = scr.Data[row, col, 0];
                            imgtemp.Data[row, col, 1] = scr.Data[row, col, 1];
                            imgtemp.Data[row, col, 2] = scr.Data[row, col, 2];
                        }
                    }
                    imgtemp.Save(imgcombinepath.Replace(".jpg", "-" + "c" + comboBox1.SelectedIndex + (i + resizecount * 2) + ".jpg"));
                    imgtemp.Dispose();
                }
            }

            calp1x.Clear();
            calp1y.Clear();
            calp2x.Clear();
            calp2y.Clear();

        }

        void ChangeBrigtness(Image<Bgr, byte> scr, string savepath)
        {
            //brigtness亮度直接乘以一个系数，也就是RGB整体缩放，调整亮度
            //random.NextDouble() * (maxValue - minValue) + minValue;
            double brigtness = ran.NextDouble() * (1.3 - 0.4) + 0.4;


            Image<Bgr, double> imgscr = scr.Convert<Bgr, double>();

            for (int row = 0; row < imgscr.Height; row++)
            {
                for (int col = 0; col < imgscr.Width; col++)
                {
                    imgscr.Data[row, col, 0] = brigtness * imgscr.Data[row, col, 0];
                    imgscr.Data[row, col, 1] = brigtness * imgscr.Data[row, col, 1];
                    imgscr.Data[row, col, 2] = brigtness * imgscr.Data[row, col, 2];
                }
            }

            imgscr.Save(savepath);

            imgscr.Dispose();

        }

        void SaltPepperNoise(Image<Bgr, byte> image, string savepath, int n, string type)
        {
            //random number generator
            Random random = new Random();
            for (int k = 0; k < n; k++)
            {
                //random pixel to set white color
                int w = random.Next() % image.Width;
                int h = random.Next() % image.Height;

                switch (type)
                {
                    case "A":
                        image[h, w] = new Bgr(0, 0, 0);
                        break;
                    case "B":
                        image[h, w] = new Bgr(255, 255, 255);
                        break;
                }
            }

            image.Save(savepath);
            image.Dispose();

        }

        void copypng1()
        {
            try
            {
                Image<Bgra, byte> imgbackground = new Image<Bgra, byte>(@"C:\Users\user\Desktop\test\Tulips.png");
                Image<Bgra, byte> imglogo = new Image<Bgra, byte>(@"C:\Users\user\Desktop\test\a.png");
                Image<Gray, byte> imggraylogo = new Image<Gray, byte>(@"C:\Users\user\Desktop\test\a.png");
                CvInvoke.Threshold(imggraylogo, imggraylogo, 180, 255, ThresholdType.Binary);
                Image<Gray, byte> mask = new Image<Gray, byte>(imglogo.Width, imglogo.Height, new Gray(255));

                imggraylogo = mask - imggraylogo; //掩模反色
                Rect.Location = new Point(100, 100);
                Rect.Size = new Size(imglogo.Cols, imglogo.Rows);
                imgbackground.ROI = Rect;
                imglogo.Mat.CopyTo(imgbackground.Mat, imggraylogo.Mat);
                imgbackground.ROI = new Rectangle();

                pictureBox1.Image = imgbackground.Bitmap;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        void cvAdd4cMat(Image<Bgra, byte> scr, Image<Bgra, byte> dst, double scale, string imgcombinepath, string txtcombinepath, string pngname)
        {
            try
            {
                //亂數產生位移位置 
                int xmove = ran.Next(Convert.ToInt32(txtxmove.Text), Convert.ToInt32(txtymove.Text)) * 5;
                int ymove = ran.Next(Convert.ToInt32(txtxmove.Text), Convert.ToInt32(txtymove.Text)) * 5;

                int temp = 0;
                //產生混合圖
                for (int w = 0; w < (dst.Width - xmove) / scr.Width; w++)
                {
                    for (int h = 0; h < (dst.Height - ymove) / scr.Height; h++)
                    {
                        //紀錄座標
                        //    calp1x.Add(w * scr.Width);
                        //    calp1y.Add(h * scr.Height);
                        //    calp2x.Add(w * scr.Width + scr.Width);
                        //    calp2y.Add(h * scr.Height + scr.Height);

                        Rect.Location = new Point(w * scr.Width + xmove, h * scr.Height + ymove);
                        Rect.Size = new Size(scr.Cols, scr.Rows);
                        dst.ROI = Rect;

                        //混合四個通道
                        Mat outMat = new Mat();
                        Image<Gray, byte>[] scr_channels = scr.Split();
                        Image<Gray, byte>[] dst_channels = dst.Split();

                        for (int i = 0; i < 3; i++)
                        {
                            dst_channels[i] = dst_channels[i].Mul(255.0 / scale - scr_channels[3], scale / 255.0);
                            dst_channels[i] += scr_channels[i].Mul(scr_channels[3], scale / 255.0);
                        }

                        using (VectorOfMat vm = new VectorOfMat(dst_channels[0].Mat, dst_channels[1].Mat, dst_channels[2].Mat))
                        {
                            CvInvoke.Merge(vm, outMat);
                        }

                        outMat.ToImage<Bgra, byte>().CopyTo(dst);

                        outMat.Dispose();

                        //亂數產生背景尺寸   
                        int min = Convert.ToInt32(txtminsize.Text);
                        int max = Convert.ToInt32(txtmaxsize.Text);

                        int ranw = ran.Next(min, max) * 6;
                        int ranh = ran.Next(min, max) * 6;

                        //拉回roi的座標
                        Rect.Location = new Point(w * scr.Width, h * scr.Height);
                        Rect.Size = new Size(scr.Cols + ranw, scr.Rows + ranh);
                        dst.ROI = Rect;

                        Image<Bgra, byte> imgtemp1;
                        imgtemp1 = dst.Clone();

                        calyolopoint(xmove, ymove, scr.Width + xmove, scr.Height + ymove, imgtemp1.Width, imgtemp1.Height, txtcombinepath.Replace(".txt", "-" + pngname + "-" + temp + ".txt"));

                        string newfilename = imgcombinepath.Replace(".jpg", "-" + pngname + "-" + temp + ".jpg");

                        imgtemp1.Save(newfilename);
                        temp++;
                        dst.ROI = new Rectangle();
                        imgtemp1.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void calyolopoint(float p1x, float p1y, float p2x, float p2y, int ImageW, int ImageH, string fileroots)
        {
            string traindatainfo1 = "";

            //計算yolo座標           
            float px = (p1x + p2x) / 2;
            float py = (p1y + p2y) / 2;

            float BOXcenterinX = px / ImageW; //centerX / ImageW
            float BOXcenterinY = py / ImageH; //centerY / ImageH
            float BOXwidthinX = (p2x - p1x) / ImageW;   //BBoxW / ImageW
            float BOXwidthinY = (p2y - p1y) / ImageH;  //BBoxH / ImageH
            traindatainfo1 = comboBox1.SelectedIndex.ToString() + " " + BOXcenterinX + " " + BOXcenterinY + " " + BOXwidthinX + " " + BOXwidthinY;

            txtTrainingData.Text += traindatainfo1 + "\r\n";

            StreamWriter sw = new StreamWriter(fileroots, true);
            sw.Write(traindatainfo1 + "\r\n");
            sw.Close();
        }

        void calhaaryolopoint(float p1x, float p1y, float p2x, float p2y, int ImageW, int ImageH, string fileroots)
        {
            string traindatainfo1 = "";

            //計算yolo座標           
            float px = (p1x + p2x) / 2;
            float py = (p1y + p2y) / 2;

            float BOXcenterinX = px / ImageW; //centerX / ImageW
            float BOXcenterinY = py / ImageH; //centerY / ImageH
            float BOXwidthinX = (p2x - p1x) / ImageW;   //BBoxW / ImageW
            float BOXwidthinY = (p2y - p1y) / ImageH;  //BBoxH / ImageH
            traindatainfo1 = " " + BOXcenterinX + " " + BOXcenterinY + " " + BOXwidthinX + " " + BOXwidthinY;

            StreamWriter sw = new StreamWriter(fileroots, true);
            sw.Write(traindatainfo1 + "\r\n");
            sw.Close();
        }

        void medfilter(Image<Bgr, byte> scr, string savepath)
        {
            CvInvoke.GaussianBlur(scr, scr, new Size(13, 13), 1.5);
            scr.Save(savepath);
        }

        void imgEqualizeHist(Image<Bgr, byte> scr, string savepath)
        {
            scr._EqualizeHist();
            scr.Save(savepath);
        }

        void HSVfilit(string folderpath, string filename, int c, Image<Bgr, byte> scr)
        {
            Hsv lowerLimit = new Hsv(156, 43, 35);
            Hsv upperLimit = new Hsv(180, 255, 255);
            Hsv lowerLimit2 = new Hsv(0, 43, 35);
            Hsv upperLimit2 = new Hsv(10, 255, 255);
            Hsv lowerLimit3 = new Hsv(100, 43, 46);
            Hsv upperLimit3 = new Hsv(124, 255, 255);

            Image<Hsv, Byte> Hsvimage = scr.Convert<Hsv, Byte>();
            Image<Hsv, Byte> Hsv2image = scr.Convert<Hsv, Byte>();

            var imageHSVDest = Hsvimage.InRange(lowerLimit, upperLimit);
            var image2HSVDest = Hsvimage.InRange(lowerLimit2, upperLimit2);
            var imageblue = Hsvimage.InRange(lowerLimit3, upperLimit3);

            switch (c)
            {
                case 0:
                    imagehsv = imageHSVDest + image2HSVDest;
                    break;
                case 1:
                    imagehsv = imageblue;
                    break;
            }

            //mediafilter
            imagehsv = imagehsv.SmoothMedian(3);

            CvInvoke.Dilate(imagehsv, imagehsv, null, new Point(0, 0), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Erode(imagehsv, imagehsv, null, new Point(0, 0), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(imagehsv, contours, null, RetrType.External, ChainApproxMethod.ChainApproxNone);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        //取得近似輪廓
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        RotatedRect box = CvInvoke.MinAreaRect(approxContour);

                        if (box.Size.Width > 50 && box.Size.Height > 50)
                        {
                            double bbradio = box.Size.Width / box.Size.Height;
                            if (bbradio < 1.2 && bbradio > 0.8)
                            {
                                Rectangle BoundingBox = new Rectangle();
                                BoundingBox = CvInvoke.BoundingRectangle(approxContour);
                                Log(folderpath, filename + ";" + c.ToString() + ";  Get bbox w=" + box.Size.Width.ToString() + "; h=" + box.Size.Height.ToString() + "\r\n");
                                hsvcheck = true;
                            }
                        }
                    }
                }
            }

        }

        void Haardetection(IImage image, string foldpath, string filename, string model, int classes)
        {
            Boolean haarsize = false;

            List<Rectangle> faces = new List<Rectangle>();
            using (CascadeClassifier face = new CascadeClassifier(model))
            {
                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.EqualizeHist(ugray, ugray);

                    Rectangle[] facesDetected = face.DetectMultiScale(ugray, 1.1, 10, new Size(100, 100));

                    faces.AddRange(facesDetected);

                    if (facesDetected.Length == 0)
                    {
                        haartimes--;
                        Log(foldpath, filename + ":no find ,haartimes=" + haartimes.ToString());
                    }

                    if ((radallmodel.Checked && haartimes == 0) || (radsinglemodel.Checked && facesDetected.Length == 0))
                    {
                        img.Save(foldpath + @"\n\" + "n" + filename);
                        Log(foldpath, filename + ",save to n folder , haartimes=" + haartimes.ToString());
                    }
                    else
                    {
                        for (int i = 0; i < facesDetected.Length; i++)
                        {
                            if (facesDetected[i].Width >= 70 && facesDetected[i].Height >= 70)
                            {
                                haarsize = true;

                                Log(foldpath, filename + "> ruled size ,boolen=" + haarsize.ToString());
                                string imagereplace = "-" + classes.ToString() + "-" + i.ToString();
                                string roiimagereplace = imagereplace + "-roi";

                                img.Save(foldpath + @"\p\" + "p" + filename);

                                try
                                {
                                    facesDetected[i].X = facesDetected[i].X - Convert.ToInt16(facesDetected[i].Width * 0.2);
                                    facesDetected[i].Y = facesDetected[i].Y - Convert.ToInt16(facesDetected[i].Height * 0.2);
                                    facesDetected[i].Width = facesDetected[i].Width + Convert.ToInt16(facesDetected[i].Width * 0.4);
                                    facesDetected[i].Height = facesDetected[i].Height + Convert.ToInt16(facesDetected[i].Height * 0.4);

                                    var imgtemp = facesDetected[i];
                                    img.ROI = imgtemp;
                                }
                                catch
                                {
                                    var imgtemp = facesDetected[i];
                                    img.ROI = imgtemp;
                                }

                                // save roi image

                                img.Save(foldpath + @"\haar_detected\" + filename.Replace(".jpg", roiimagereplace + ".jpg"));

                                img.ROI = new Rectangle();

                                //save original image

                                img.Save(foldpath + @"\haar_detected\" + filename.Replace(".jpg", imagereplace + ".jpg"));

                                int harrpointX1 = facesDetected[i].X;
                                int harrpointY1 = facesDetected[i].Y;
                                int harrpointX2 = facesDetected[i].X + facesDetected[i].Width;
                                int harrpointY2 = facesDetected[i].Y + facesDetected[i].Height;

                                calhaaryolopoint(harrpointX1, harrpointY1, harrpointX2, harrpointY2, img.Width, img.Height, foldpath + @"\haar_detected\" + filename.Replace(".jpg", imagereplace + ".txt"));

                                haarcheck = true;
                            }
                            else if (i == facesDetected.Length - 1 && haarsize == false)
                            {
                                haartimes--;
                                Log(foldpath, filename + ":no find," + haarsize.ToString());
                            }
                        }
                    }
                }
            }
        }

        void Log(string logpath, string data)
        {
            StreamWriter sw = new StreamWriter(logpath + @"\log.txt", true);
            sw.WriteLine(data);
            sw.Close();
        }
        #endregion


        void Haardetection_three(IImage image, string foldpath, string filename, string model, int classes)
        {
            Boolean haarsize = false;

            List<Rectangle> faces = new List<Rectangle>();
            using (CascadeClassifier face = new CascadeClassifier(model))
            {
                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.EqualizeHist(ugray, ugray);

                    Rectangle[] facesDetected = face.DetectMultiScale(ugray, 1.1, 10, new Size(100, 100));

                    faces.AddRange(facesDetected);

                    //若沒測到haar 則往下一個model
                    if (facesDetected.Length == 0)
                    {
                        haartimes--;
                        Log(foldpath, filename + ":no find ,haartimes=" + haartimes.ToString());
                    }

                    //若第二次還是沒測到，則判定fail
                    if (haartimes == 1 && facesDetected.Length == 0 && classes == 4)
                    {
                        img.Save(foldpath + @"\n2\" + "n" + filename);
                        Log(foldpath, filename + ",save to n2 folder , haartimes=" + haartimes.ToString());
                    }

                    else if (facesDetected.Length != 0)
                    {
                        for (int i = 0; i < facesDetected.Length; i++)
                        {
                            if (facesDetected[i].Width >= 70 && facesDetected[i].Height >= 70)
                            {
                                haarsize = true; //判斷目標大小
                                haarscore++; //計算哈爾得分

                                Log(foldpath, "> ruled size =" + haarsize.ToString());

                                string imagereplace = "-" + classes.ToString() + "-" + i.ToString();
                                string roiimagereplace = imagereplace + "-roi";


                                //計算ROIRECT
                                try
                                {
                                    facesDetected[i].X = facesDetected[i].X - Convert.ToInt16(facesDetected[i].Width * 0.2);
                                    facesDetected[i].Y = facesDetected[i].Y - Convert.ToInt16(facesDetected[i].Height * 0.2);
                                    facesDetected[i].Width = facesDetected[i].Width + Convert.ToInt16(facesDetected[i].Width * 0.4);
                                    facesDetected[i].Height = facesDetected[i].Height + Convert.ToInt16(facesDetected[i].Height * 0.4);

                                    img.ROI = facesDetected[i];
                                }
                                catch
                                {
                                    img.ROI = facesDetected[i];
                                }

                                //紀錄座標
                                int harrpointX1 = facesDetected[i].X;
                                int harrpointY1 = facesDetected[i].Y;
                                int harrpointX2 = facesDetected[i].X + facesDetected[i].Width;
                                int harrpointY2 = facesDetected[i].Y + facesDetected[i].Height;

                                // save roi image

                                /*  if (haarscore == 1)//紀錄偵測一分的影像跟座標
                                  {
                                      mats.Add(img.Mat);
                                      List<int> points = new List<int>();
                                      points.Add(harrpointX1);
                                      points.Add(harrpointY1);
                                      points.Add(harrpointX2);
                                      points.Add(harrpointY2);
                                      temppoints.Add(points);

                                      Log(foldpath, "get 1 score .......");
                                  }*/

                                if (haarscore > 1)
                                {
                                    img.Save(foldpath + @"\haar_detected_final\" + filename.Replace(".jpg", roiimagereplace + ".jpg"));

                                    //復原影像大小
                                    img.ROI = new Rectangle();

                                    //save original image
                                    img.Save(foldpath + @"\haar_detected_final\" + filename.Replace(".jpg", imagereplace + ".jpg"));
                                    img.Save(foldpath + @"\p2\" + "p" + filename);

                                    calhaaryolopoint(harrpointX1, harrpointY1, harrpointX2, harrpointY2, img.Width, img.Height, foldpath + @"\haar_detected_final\" + filename.Replace(".jpg", imagereplace + ".txt"));
                                }
                            }

                            //如果小於目標大小則一樣不算
                            else if (i == facesDetected.Length - 1 && haarsize == false)
                            {
                                haartimes--;
                                Log(foldpath, filename + ":no find," + haarsize.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void btnthreehaar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                string folderpath = folder.SelectedPath;


                //creat haar_detected
                Directory.CreateDirectory(folderpath + @"\haar_detected_final");
                Directory.CreateDirectory(folderpath + @"\p2");
                Directory.CreateDirectory(folderpath + @"\n2");


                imgjpg = Directory.GetFileSystemEntries(folderpath, "*.jpg");
                progressBar1.Maximum = imgjpg.Length;

                //reacher all .jpg
                Stopwatch sw = new Stopwatch();
                sw.Start();

                haarmodell = new string[4, 3]
                {
                    { comboBox2.SelectedItem.ToString(),comboBox9.SelectedItem.ToString(),comboBox13.SelectedItem.ToString()},
                    { comboBox3.SelectedItem.ToString(),comboBox8.SelectedItem.ToString(),comboBox12.SelectedItem.ToString()},
                    { comboBox4.SelectedItem.ToString(),comboBox7.SelectedItem.ToString(),comboBox11.SelectedItem.ToString()},
                    { comboBox5.SelectedItem.ToString(),comboBox6.SelectedItem.ToString(),comboBox10.SelectedItem.ToString()},
                };

                for (int c = 0; c < imgjpg.Length; c++)
                {
                    IImage scr = new UMat(imgjpg[c], ImreadModes.Color); //UMat version

                    Log(folderpath, c.ToString() + "\r\n" + "in:" + imgjpg[c]);

                    using (img = new Image<Bgr, byte>(imgjpg[c]))
                    using (InputArray iaImage = scr.GetInputArray())
                    {
                        //執行三個哈爾的辨識
                        for (int i = 0; i < haarmodell.GetLength(0); i++)
                        {
                            temppoints.Clear();
                            haartimes = 3;     //哈爾計數 
                            haarscore = 0;     //判斷哈爾的得分

                            Log(folderpath, "haar in:" + "model class=" + i.ToString());

                            //輪巡model
                            for (int j = 0; j < haarmodell.GetLength(1); j++)
                            {
                                if (haarscore < 2)
                                {
                                    Haardetection_three(scr, folderpath, c.ToString() + ".jpg", haarmodell[i, j], i);
                                    Thread.Sleep(1);
                                    Application.DoEvents();
                                }
                                else if (haarscore == 2)
                                    break;
                            }

                            Log(folderpath, "haar :" + i.ToString() + "  score =" + haarscore.ToString() + "  haar out: \n\r");

                            if (haarscore == 2)
                                break;
                        }
                    }
                    progressBar1.Value = c + 1;
                    Thread.Sleep(1);
                }

                for (int i = 0; i < imgjpg.Length; i++)
                {
                    File.Delete(imgjpg[i]);
                }
                sw.Stop();

                MessageBox.Show("finished!" + sw.Elapsed.TotalSeconds);
                progressBar1.Value = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //random number generator
            Random random = new Random();
            for (int k = 0; k < 1000; k++)
            {
                //random pixel to set white color
                int w = random.Next() % img.Width;
                int h = random.Next() % img.Height;

                img[h, w] = new Bgr(0, 0, 0);

            }



            Image<Gray, byte> imggray =  img.Convert<Gray, byte>();

            CvInvoke.MedianBlur(imggray, imggray, 3);

            pictureBox1.Image = imggray.Bitmap;

        }
    }
}
