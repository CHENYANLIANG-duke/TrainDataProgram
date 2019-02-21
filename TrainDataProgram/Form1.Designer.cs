namespace TrainDataProgram
{
    partial class btnharrtrf
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGetCount = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTrainingData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSaveClass = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAutocombine = new System.Windows.Forms.Button();
            this.btnresize = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBrigtness = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnallnoisy = new System.Windows.Forms.Button();
            this.btnDetectTRF = new System.Windows.Forms.Button();
            this.btnHaardetectTRF = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnhaarauto = new System.Windows.Forms.Button();
            this.btnpre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnfolder = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.radallmodel = new System.Windows.Forms.RadioButton();
            this.radsinglemodel = new System.Windows.Forms.RadioButton();
            this.BtnHaarHsv = new System.Windows.Forms.Button();
            this.txtmaxsize = new System.Windows.Forms.TextBox();
            this.txtminsize = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnreadhsv = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtwidth = new System.Windows.Forms.TextBox();
            this.txtheight = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.btnthreehaar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtxmove = new System.Windows.Forms.TextBox();
            this.txtymove = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(16, 15);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(101, 48);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "LoadImage";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(125, 28);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(325, 25);
            this.txtPath.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(1049, 491);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(117, 64);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnGetCount);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTrainingData);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(703, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(481, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(185, 40);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "label13";
            // 
            // btnGetCount
            // 
            this.btnGetCount.Location = new System.Drawing.Point(372, 122);
            this.btnGetCount.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetCount.Name = "btnGetCount";
            this.btnGetCount.Size = new System.Drawing.Size(91, 42);
            this.btnGetCount.TabIndex = 37;
            this.btnGetCount.Text = "GetCount";
            this.btnGetCount.UseVisualStyleBackColor = true;
            this.btnGetCount.Click += new System.EventHandler(this.BtnGetCount_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 36);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 23);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(380, 36);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "count++";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(231, 231);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 15F);
            this.label10.Location = new System.Drawing.Point(173, 228);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(123, 231);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 15F);
            this.label8.Location = new System.Drawing.Point(21, 228);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "Image :";
            // 
            // txtTrainingData
            // 
            this.txtTrainingData.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTrainingData.Location = new System.Drawing.Point(8, 172);
            this.txtTrainingData.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrainingData.Multiline = true;
            this.txtTrainingData.Name = "txtTrainingData";
            this.txtTrainingData.Size = new System.Drawing.Size(464, 42);
            this.txtTrainingData.TabIndex = 5;
            this.txtTrainingData.Text = "[category number] [object center in X] [object center in Y] [object width in X] [" +
    "object width in Y]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(185, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "point";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(309, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "point";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15F);
            this.label6.Location = new System.Drawing.Point(36, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "PointCenter :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(225, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Point2 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(120, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "point";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(33, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Point1 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F);
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(16, 69);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 625);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(703, 289);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(417, 35);
            this.textBox1.TabIndex = 14;
            // 
            // btnSaveClass
            // 
            this.btnSaveClass.Location = new System.Drawing.Point(1129, 289);
            this.btnSaveClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveClass.Name = "btnSaveClass";
            this.btnSaveClass.Size = new System.Drawing.Size(69, 36);
            this.btnSaveClass.TabIndex = 15;
            this.btnSaveClass.Text = "save";
            this.btnSaveClass.UseVisualStyleBackColor = true;
            this.btnSaveClass.Click += new System.EventHandler(this.BtnSaveClass_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox2.Location = new System.Drawing.Point(691, 394);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 188);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnAutocombine
            // 
            this.btnAutocombine.Location = new System.Drawing.Point(691, 598);
            this.btnAutocombine.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutocombine.Name = "btnAutocombine";
            this.btnAutocombine.Size = new System.Drawing.Size(107, 62);
            this.btnAutocombine.TabIndex = 28;
            this.btnAutocombine.Text = "Autocombine";
            this.btnAutocombine.UseVisualStyleBackColor = true;
            this.btnAutocombine.Click += new System.EventHandler(this.BtnAutocombine_Click);
            // 
            // btnresize
            // 
            this.btnresize.Location = new System.Drawing.Point(691, 668);
            this.btnresize.Margin = new System.Windows.Forms.Padding(4);
            this.btnresize.Name = "btnresize";
            this.btnresize.Size = new System.Drawing.Size(107, 62);
            this.btnresize.TabIndex = 29;
            this.btnresize.Text = "resize";
            this.btnresize.UseVisualStyleBackColor = true;
            this.btnresize.Click += new System.EventHandler(this.Btnresize_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 701);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(667, 29);
            this.progressBar1.TabIndex = 30;
            // 
            // btnBrigtness
            // 
            this.btnBrigtness.Location = new System.Drawing.Point(920, 666);
            this.btnBrigtness.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrigtness.Name = "btnBrigtness";
            this.btnBrigtness.Size = new System.Drawing.Size(107, 62);
            this.btnBrigtness.TabIndex = 31;
            this.btnBrigtness.Text = "Brigtness";
            this.btnBrigtness.UseVisualStyleBackColor = true;
            this.btnBrigtness.Click += new System.EventHandler(this.BtnBrigtness_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1150, 711);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(89, 19);
            this.checkBox3.TabIndex = 35;
            this.checkBox3.Text = "blacknoisy";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btnallnoisy
            // 
            this.btnallnoisy.Location = new System.Drawing.Point(1035, 668);
            this.btnallnoisy.Margin = new System.Windows.Forms.Padding(4);
            this.btnallnoisy.Name = "btnallnoisy";
            this.btnallnoisy.Size = new System.Drawing.Size(107, 62);
            this.btnallnoisy.TabIndex = 36;
            this.btnallnoisy.Text = "all";
            this.btnallnoisy.UseVisualStyleBackColor = true;
            this.btnallnoisy.Click += new System.EventHandler(this.Btnallnoisy_Click);
            // 
            // btnDetectTRF
            // 
            this.btnDetectTRF.Location = new System.Drawing.Point(691, 342);
            this.btnDetectTRF.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetectTRF.Name = "btnDetectTRF";
            this.btnDetectTRF.Size = new System.Drawing.Size(91, 42);
            this.btnDetectTRF.TabIndex = 38;
            this.btnDetectTRF.Text = "DetectTRF_Hsv";
            this.btnDetectTRF.UseVisualStyleBackColor = true;
            this.btnDetectTRF.Click += new System.EventHandler(this.BtnDetectTRF_Click);
            // 
            // btnHaardetectTRF
            // 
            this.btnHaardetectTRF.Location = new System.Drawing.Point(888, 342);
            this.btnHaardetectTRF.Margin = new System.Windows.Forms.Padding(4);
            this.btnHaardetectTRF.Name = "btnHaardetectTRF";
            this.btnHaardetectTRF.Size = new System.Drawing.Size(91, 42);
            this.btnHaardetectTRF.TabIndex = 39;
            this.btnHaardetectTRF.Text = "HarrDetectTRF";
            this.btnHaardetectTRF.UseVisualStyleBackColor = true;
            this.btnHaardetectTRF.Click += new System.EventHandler(this.Button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(59, 34);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(208, 23);
            this.comboBox2.TabIndex = 38;
            // 
            // btnhaarauto
            // 
            this.btnhaarauto.Location = new System.Drawing.Point(987, 342);
            this.btnhaarauto.Margin = new System.Windows.Forms.Padding(4);
            this.btnhaarauto.Name = "btnhaarauto";
            this.btnhaarauto.Size = new System.Drawing.Size(91, 42);
            this.btnhaarauto.TabIndex = 40;
            this.btnhaarauto.Text = "HarrDetectAuto";
            this.btnhaarauto.UseVisualStyleBackColor = true;
            this.btnhaarauto.Click += new System.EventHandler(this.Btnhaarauto_Click);
            // 
            // btnpre
            // 
            this.btnpre.Location = new System.Drawing.Point(533, 18);
            this.btnpre.Margin = new System.Windows.Forms.Padding(4);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(71, 42);
            this.btnpre.TabIndex = 41;
            this.btnpre.Text = "<";
            this.btnpre.UseVisualStyleBackColor = true;
            this.btnpre.Click += new System.EventHandler(this.Btnpre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(612, 18);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(71, 42);
            this.btnNext.TabIndex = 42;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnfolder
            // 
            this.btnfolder.Location = new System.Drawing.Point(460, 15);
            this.btnfolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnfolder.Name = "btnfolder";
            this.btnfolder.Size = new System.Drawing.Size(65, 48);
            this.btnfolder.TabIndex = 43;
            this.btnfolder.Text = "folder";
            this.btnfolder.UseVisualStyleBackColor = true;
            this.btnfolder.Click += new System.EventHandler(this.Btnfolder_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox5);
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(1215, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(283, 188);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "haar model_1";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(59, 142);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(208, 23);
            this.comboBox5.TabIndex = 44;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(59, 106);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(208, 23);
            this.comboBox4.TabIndex = 43;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(59, 70);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(208, 23);
            this.comboBox3.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 12F);
            this.label16.Location = new System.Drawing.Point(19, 142);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 20);
            this.label16.TabIndex = 41;
            this.label16.Text = "3 :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 12F);
            this.label15.Location = new System.Drawing.Point(19, 106);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 20);
            this.label15.TabIndex = 40;
            this.label15.Text = "2 :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 12F);
            this.label14.Location = new System.Drawing.Point(19, 70);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 20);
            this.label14.TabIndex = 39;
            this.label14.Text = "1 :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 12F);
            this.label12.Location = new System.Drawing.Point(19, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 20);
            this.label12.TabIndex = 38;
            this.label12.Text = "0 :";
            // 
            // radallmodel
            // 
            this.radallmodel.AutoSize = true;
            this.radallmodel.Checked = true;
            this.radallmodel.Location = new System.Drawing.Point(1085, 342);
            this.radallmodel.Margin = new System.Windows.Forms.Padding(4);
            this.radallmodel.Name = "radallmodel";
            this.radallmodel.Size = new System.Drawing.Size(81, 19);
            this.radallmodel.TabIndex = 45;
            this.radallmodel.TabStop = true;
            this.radallmodel.Text = "Allmodel";
            this.radallmodel.UseVisualStyleBackColor = true;
            // 
            // radsinglemodel
            // 
            this.radsinglemodel.AutoSize = true;
            this.radsinglemodel.Location = new System.Drawing.Point(1085, 365);
            this.radsinglemodel.Margin = new System.Windows.Forms.Padding(4);
            this.radsinglemodel.Name = "radsinglemodel";
            this.radsinglemodel.Size = new System.Drawing.Size(103, 19);
            this.radsinglemodel.TabIndex = 46;
            this.radsinglemodel.Text = "Single model";
            this.radsinglemodel.UseVisualStyleBackColor = true;
            // 
            // BtnHaarHsv
            // 
            this.BtnHaarHsv.Location = new System.Drawing.Point(920, 409);
            this.BtnHaarHsv.Margin = new System.Windows.Forms.Padding(4);
            this.BtnHaarHsv.Name = "BtnHaarHsv";
            this.BtnHaarHsv.Size = new System.Drawing.Size(107, 62);
            this.BtnHaarHsv.TabIndex = 47;
            this.BtnHaarHsv.Text = "Haar_Hsv";
            this.BtnHaarHsv.UseVisualStyleBackColor = true;
            this.BtnHaarHsv.Click += new System.EventHandler(this.BtnHaarHsv_Click);
            // 
            // txtmaxsize
            // 
            this.txtmaxsize.Location = new System.Drawing.Point(864, 632);
            this.txtmaxsize.Margin = new System.Windows.Forms.Padding(4);
            this.txtmaxsize.Name = "txtmaxsize";
            this.txtmaxsize.Size = new System.Drawing.Size(47, 25);
            this.txtmaxsize.TabIndex = 48;
            this.txtmaxsize.Text = "5";
            this.txtmaxsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtminsize
            // 
            this.txtminsize.Location = new System.Drawing.Point(864, 598);
            this.txtminsize.Margin = new System.Windows.Forms.Padding(4);
            this.txtminsize.Name = "txtminsize";
            this.txtminsize.Size = new System.Drawing.Size(47, 25);
            this.txtminsize.TabIndex = 49;
            this.txtminsize.Text = "2";
            this.txtminsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 12F);
            this.label17.Location = new System.Drawing.Point(808, 598);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "min :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("新細明體", 12F);
            this.label18.Location = new System.Drawing.Point(808, 632);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 20);
            this.label18.TabIndex = 50;
            this.label18.Text = "max :";
            // 
            // btnreadhsv
            // 
            this.btnreadhsv.Location = new System.Drawing.Point(789, 342);
            this.btnreadhsv.Margin = new System.Windows.Forms.Padding(4);
            this.btnreadhsv.Name = "btnreadhsv";
            this.btnreadhsv.Size = new System.Drawing.Size(91, 42);
            this.btnreadhsv.TabIndex = 51;
            this.btnreadhsv.Text = "Read_Hsv";
            this.btnreadhsv.UseVisualStyleBackColor = true;
            this.btnreadhsv.Click += new System.EventHandler(this.btnreadhsv_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("新細明體", 12F);
            this.label19.Location = new System.Drawing.Point(808, 701);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 20);
            this.label19.TabIndex = 55;
            this.label19.Text = "H :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("新細明體", 12F);
            this.label20.Location = new System.Drawing.Point(808, 666);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 20);
            this.label20.TabIndex = 52;
            this.label20.Text = "w :";
            // 
            // txtwidth
            // 
            this.txtwidth.Location = new System.Drawing.Point(864, 666);
            this.txtwidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(47, 25);
            this.txtwidth.TabIndex = 54;
            this.txtwidth.Text = "50";
            this.txtwidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtheight
            // 
            this.txtheight.Location = new System.Drawing.Point(864, 701);
            this.txtheight.Margin = new System.Windows.Forms.Padding(4);
            this.txtheight.Name = "txtheight";
            this.txtheight.Size = new System.Drawing.Size(47, 25);
            this.txtheight.TabIndex = 53;
            this.txtheight.Text = "50";
            this.txtheight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox6);
            this.groupBox3.Controls.Add(this.comboBox7);
            this.groupBox3.Controls.Add(this.comboBox8);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.comboBox9);
            this.groupBox3.Location = new System.Drawing.Point(1215, 246);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(283, 188);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "haar model_2";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(59, 142);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(208, 23);
            this.comboBox6.TabIndex = 44;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(59, 106);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(208, 23);
            this.comboBox7.TabIndex = 43;
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(59, 70);
            this.comboBox8.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(208, 23);
            this.comboBox8.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("新細明體", 12F);
            this.label21.Location = new System.Drawing.Point(19, 142);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 20);
            this.label21.TabIndex = 41;
            this.label21.Text = "3 :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("新細明體", 12F);
            this.label22.Location = new System.Drawing.Point(19, 106);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 20);
            this.label22.TabIndex = 40;
            this.label22.Text = "2 :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("新細明體", 12F);
            this.label23.Location = new System.Drawing.Point(19, 70);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 20);
            this.label23.TabIndex = 39;
            this.label23.Text = "1 :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("新細明體", 12F);
            this.label24.Location = new System.Drawing.Point(19, 34);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 20);
            this.label24.TabIndex = 38;
            this.label24.Text = "0 :";
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(59, 34);
            this.comboBox9.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(208, 23);
            this.comboBox9.TabIndex = 38;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox10);
            this.groupBox4.Controls.Add(this.comboBox11);
            this.groupBox4.Controls.Add(this.comboBox12);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.comboBox13);
            this.groupBox4.Location = new System.Drawing.Point(1215, 465);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(283, 188);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "haar model_3";
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(59, 142);
            this.comboBox10.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(208, 23);
            this.comboBox10.TabIndex = 44;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(59, 106);
            this.comboBox11.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(208, 23);
            this.comboBox11.TabIndex = 43;
            // 
            // comboBox12
            // 
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(59, 70);
            this.comboBox12.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(208, 23);
            this.comboBox12.TabIndex = 42;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("新細明體", 12F);
            this.label25.Location = new System.Drawing.Point(19, 142);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 20);
            this.label25.TabIndex = 41;
            this.label25.Text = "3 :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("新細明體", 12F);
            this.label26.Location = new System.Drawing.Point(19, 106);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 20);
            this.label26.TabIndex = 40;
            this.label26.Text = "2 :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("新細明體", 12F);
            this.label27.Location = new System.Drawing.Point(19, 70);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 20);
            this.label27.TabIndex = 39;
            this.label27.Text = "1 :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("新細明體", 12F);
            this.label28.Location = new System.Drawing.Point(19, 34);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 20);
            this.label28.TabIndex = 38;
            this.label28.Text = "0 :";
            // 
            // comboBox13
            // 
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Location = new System.Drawing.Point(59, 34);
            this.comboBox13.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(208, 23);
            this.comboBox13.TabIndex = 38;
            // 
            // btnthreehaar
            // 
            this.btnthreehaar.Location = new System.Drawing.Point(920, 479);
            this.btnthreehaar.Margin = new System.Windows.Forms.Padding(4);
            this.btnthreehaar.Name = "btnthreehaar";
            this.btnthreehaar.Size = new System.Drawing.Size(107, 62);
            this.btnthreehaar.TabIndex = 56;
            this.btnthreehaar.Text = "Three Haar";
            this.btnthreehaar.UseVisualStyleBackColor = true;
            this.btnthreehaar.Click += new System.EventHandler(this.btnthreehaar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1075, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("新細明體", 12F);
            this.label29.Location = new System.Drawing.Point(919, 597);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 20);
            this.label29.TabIndex = 58;
            this.label29.Text = "minmove :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("新細明體", 12F);
            this.label30.Location = new System.Drawing.Point(919, 631);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 20);
            this.label30.TabIndex = 59;
            this.label30.Text = "maxmove :";
            // 
            // txtxmove
            // 
            this.txtxmove.Location = new System.Drawing.Point(1016, 597);
            this.txtxmove.Margin = new System.Windows.Forms.Padding(4);
            this.txtxmove.Name = "txtxmove";
            this.txtxmove.Size = new System.Drawing.Size(47, 25);
            this.txtxmove.TabIndex = 60;
            this.txtxmove.Text = "4";
            this.txtxmove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtymove
            // 
            this.txtymove.Location = new System.Drawing.Point(1015, 631);
            this.txtymove.Margin = new System.Windows.Forms.Padding(4);
            this.txtymove.Name = "txtymove";
            this.txtymove.Size = new System.Drawing.Size(47, 25);
            this.txtymove.TabIndex = 61;
            this.txtymove.Text = "6";
            this.txtymove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnharrtrf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1532, 736);
            this.Controls.Add(this.txtymove);
            this.Controls.Add(this.txtxmove);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnthreehaar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtwidth);
            this.Controls.Add(this.txtheight);
            this.Controls.Add(this.btnreadhsv);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtminsize);
            this.Controls.Add(this.txtmaxsize);
            this.Controls.Add(this.BtnHaarHsv);
            this.Controls.Add(this.radsinglemodel);
            this.Controls.Add(this.radallmodel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnfolder);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnpre);
            this.Controls.Add(this.btnhaarauto);
            this.Controls.Add(this.btnHaardetectTRF);
            this.Controls.Add(this.btnDetectTRF);
            this.Controls.Add(this.btnallnoisy);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.btnBrigtness);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnresize);
            this.Controls.Add(this.btnAutocombine);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnLoadImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "btnharrtrf";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTrainingData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSaveClass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAutocombine;
        private System.Windows.Forms.Button btnresize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnBrigtness;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btnallnoisy;
        private System.Windows.Forms.Button btnGetCount;
        private System.Windows.Forms.Button btnDetectTRF;
        private System.Windows.Forms.Button btnHaardetectTRF;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnhaarauto;
        private System.Windows.Forms.Button btnpre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnfolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radallmodel;
        private System.Windows.Forms.RadioButton radsinglemodel;
        private System.Windows.Forms.Button BtnHaarHsv;
        private System.Windows.Forms.TextBox txtmaxsize;
        private System.Windows.Forms.TextBox txtminsize;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnreadhsv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtwidth;
        private System.Windows.Forms.TextBox txtheight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.Button btnthreehaar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtxmove;
        private System.Windows.Forms.TextBox txtymove;
    }
}

