namespace Soil_moisture_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.conBTN = new System.Windows.Forms.Button();
            this.disconBTN = new System.Windows.Forms.Button();
            this.caliBTN = new System.Windows.Forms.Button();
            this.comPort_comboBox = new System.Windows.Forms.ComboBox();
            this.sendBTN = new System.Windows.Forms.Button();
            this.txtReceiveBox = new System.Windows.Forms.TextBox();
            this.txtDataSendBox = new System.Windows.Forms.TextBox();
            this.groupBoxActiveNode = new System.Windows.Forms.GroupBox();
            this.pictureBoxErrorSensor = new System.Windows.Forms.PictureBox();
            this.progressBarActiveNode = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxMoisLab = new System.Windows.Forms.Label();
            this.minMoisLab = new System.Windows.Forms.Label();
            this.moisLab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rssiLab = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timerErrorRssi = new System.Windows.Forms.Timer(this.components);
            this.progressBarRSSI = new System.Windows.Forms.ProgressBar();
            this.timerErrorSensor = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxRssi = new System.Windows.Forms.PictureBox();
            this.versionLab = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxActiveNode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRssi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // conBTN
            // 
            this.conBTN.Location = new System.Drawing.Point(6, 32);
            this.conBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.conBTN.Name = "conBTN";
            this.conBTN.Size = new System.Drawing.Size(58, 30);
            this.conBTN.TabIndex = 0;
            this.conBTN.Text = "Connect";
            this.conBTN.UseVisualStyleBackColor = true;
            this.conBTN.Click += new System.EventHandler(this.conBTN_Click);
            // 
            // disconBTN
            // 
            this.disconBTN.Location = new System.Drawing.Point(67, 32);
            this.disconBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.disconBTN.Name = "disconBTN";
            this.disconBTN.Size = new System.Drawing.Size(78, 30);
            this.disconBTN.TabIndex = 1;
            this.disconBTN.Text = "Disconnect";
            this.disconBTN.UseVisualStyleBackColor = true;
            this.disconBTN.Click += new System.EventHandler(this.disconBTN_Click);
            // 
            // caliBTN
            // 
            this.caliBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.17801F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caliBTN.Location = new System.Drawing.Point(6, 66);
            this.caliBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.caliBTN.Name = "caliBTN";
            this.caliBTN.Size = new System.Drawing.Size(138, 49);
            this.caliBTN.TabIndex = 2;
            this.caliBTN.Text = "Calibrate";
            this.caliBTN.UseVisualStyleBackColor = true;
            this.caliBTN.Click += new System.EventHandler(this.caliBTN_Click);
            // 
            // comPort_comboBox
            // 
            this.comPort_comboBox.FormattingEnabled = true;
            this.comPort_comboBox.Location = new System.Drawing.Point(6, 6);
            this.comPort_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comPort_comboBox.Name = "comPort_comboBox";
            this.comPort_comboBox.Size = new System.Drawing.Size(140, 21);
            this.comPort_comboBox.TabIndex = 3;
            this.comPort_comboBox.DropDown += new System.EventHandler(this.comPort_comboBox_DropDown);
            this.comPort_comboBox.SelectedIndexChanged += new System.EventHandler(this.comPort_comboBox_SelectedIndexChanged);
            // 
            // sendBTN
            // 
            this.sendBTN.Location = new System.Drawing.Point(246, 706);
            this.sendBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendBTN.Name = "sendBTN";
            this.sendBTN.Size = new System.Drawing.Size(96, 16);
            this.sendBTN.TabIndex = 4;
            this.sendBTN.Text = "SEND test ";
            this.sendBTN.UseVisualStyleBackColor = true;
            this.sendBTN.Click += new System.EventHandler(this.sendBTN_Click);
            // 
            // txtReceiveBox
            // 
            this.txtReceiveBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReceiveBox.Font = new System.Drawing.Font("Consolas", 7.916231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveBox.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtReceiveBox.Location = new System.Drawing.Point(6, 616);
            this.txtReceiveBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceiveBox.Multiline = true;
            this.txtReceiveBox.Name = "txtReceiveBox";
            this.txtReceiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveBox.Size = new System.Drawing.Size(339, 88);
            this.txtReceiveBox.TabIndex = 5;
            // 
            // txtDataSendBox
            // 
            this.txtDataSendBox.Location = new System.Drawing.Point(6, 706);
            this.txtDataSendBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDataSendBox.Name = "txtDataSendBox";
            this.txtDataSendBox.Size = new System.Drawing.Size(240, 20);
            this.txtDataSendBox.TabIndex = 6;
            // 
            // groupBoxActiveNode
            // 
            this.groupBoxActiveNode.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxActiveNode.Controls.Add(this.pictureBoxErrorSensor);
            this.groupBoxActiveNode.Controls.Add(this.progressBarActiveNode);
            this.groupBoxActiveNode.Controls.Add(this.label4);
            this.groupBoxActiveNode.Controls.Add(this.label3);
            this.groupBoxActiveNode.Controls.Add(this.label1);
            this.groupBoxActiveNode.Controls.Add(this.maxMoisLab);
            this.groupBoxActiveNode.Controls.Add(this.minMoisLab);
            this.groupBoxActiveNode.Controls.Add(this.moisLab);
            this.groupBoxActiveNode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxActiveNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06283F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActiveNode.Location = new System.Drawing.Point(6, 180);
            this.groupBoxActiveNode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxActiveNode.Name = "groupBoxActiveNode";
            this.groupBoxActiveNode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxActiveNode.Size = new System.Drawing.Size(138, 165);
            this.groupBoxActiveNode.TabIndex = 7;
            this.groupBoxActiveNode.TabStop = false;
            this.groupBoxActiveNode.Text = "Node00";
            this.groupBoxActiveNode.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pictureBoxErrorSensor
            // 
            this.pictureBoxErrorSensor.Image = global::Soil_moisture_App.Properties.Resources.warning;
            this.pictureBoxErrorSensor.Location = new System.Drawing.Point(9, 22);
            this.pictureBoxErrorSensor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxErrorSensor.Name = "pictureBoxErrorSensor";
            this.pictureBoxErrorSensor.Size = new System.Drawing.Size(42, 36);
            this.pictureBoxErrorSensor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxErrorSensor.TabIndex = 17;
            this.pictureBoxErrorSensor.TabStop = false;
            // 
            // progressBarActiveNode
            // 
            this.progressBarActiveNode.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBarActiveNode.Location = new System.Drawing.Point(0, 101);
            this.progressBarActiveNode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarActiveNode.Name = "progressBarActiveNode";
            this.progressBarActiveNode.RightToLeftLayout = true;
            this.progressBarActiveNode.Size = new System.Drawing.Size(138, 11);
            this.progressBarActiveNode.Step = 1;
            this.progressBarActiveNode.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "min:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "moist";
            // 
            // maxMoisLab
            // 
            this.maxMoisLab.AutoSize = true;
            this.maxMoisLab.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxMoisLab.Location = new System.Drawing.Point(96, 85);
            this.maxMoisLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxMoisLab.Name = "maxMoisLab";
            this.maxMoisLab.Size = new System.Drawing.Size(26, 17);
            this.maxMoisLab.TabIndex = 0;
            this.maxMoisLab.Text = "00 ";
            // 
            // minMoisLab
            // 
            this.minMoisLab.AutoSize = true;
            this.minMoisLab.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minMoisLab.Location = new System.Drawing.Point(38, 85);
            this.minMoisLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minMoisLab.Name = "minMoisLab";
            this.minMoisLab.Size = new System.Drawing.Size(22, 17);
            this.minMoisLab.TabIndex = 0;
            this.minMoisLab.Text = "00";
            // 
            // moisLab
            // 
            this.moisLab.Font = new System.Drawing.Font("Segoe Print", 24.12566F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moisLab.Location = new System.Drawing.Point(3, 17);
            this.moisLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.moisLab.Name = "moisLab";
            this.moisLab.Size = new System.Drawing.Size(132, 62);
            this.moisLab.TabIndex = 0;
            this.moisLab.Text = "--";
            this.moisLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 314);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "rssi";
            // 
            // rssiLab
            // 
            this.rssiLab.Font = new System.Drawing.Font("Segoe Print", 18.09424F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssiLab.Location = new System.Drawing.Point(28, 294);
            this.rssiLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rssiLab.Name = "rssiLab";
            this.rssiLab.Size = new System.Drawing.Size(116, 42);
            this.rssiLab.TabIndex = 0;
            this.rssiLab.Text = "--";
            this.rssiLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 361);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "CMD_TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 386);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "RUN/PAUSE UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 446);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 22);
            this.button3.TabIndex = 10;
            this.button3.Text = "DRY";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(78, 446);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 22);
            this.button4.TabIndex = 10;
            this.button4.Text = "WET";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 483);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 22);
            this.button5.TabIndex = 1;
            this.button5.Text = "min";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(78, 483);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 22);
            this.button6.TabIndex = 1;
            this.button6.Text = "max";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 157);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "expert mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "set";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 467);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "get";
            // 
            // timerErrorRssi
            // 
            this.timerErrorRssi.Interval = 3000;
            this.timerErrorRssi.Tick += new System.EventHandler(this.timerErrorRssi_Tick);
            // 
            // progressBarRSSI
            // 
            this.progressBarRSSI.Location = new System.Drawing.Point(6, 337);
            this.progressBarRSSI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarRSSI.Name = "progressBarRSSI";
            this.progressBarRSSI.Size = new System.Drawing.Size(138, 8);
            this.progressBarRSSI.TabIndex = 16;
            // 
            // timerErrorSensor
            // 
            this.timerErrorSensor.Interval = 3000;
            this.timerErrorSensor.Tick += new System.EventHandler(this.timerErrorSensor_Tick);
            // 
            // pictureBoxRssi
            // 
            this.pictureBoxRssi.Image = global::Soil_moisture_App.Properties.Resources.wifi_0;
            this.pictureBoxRssi.Location = new System.Drawing.Point(110, 153);
            this.pictureBoxRssi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxRssi.Name = "pictureBoxRssi";
            this.pictureBoxRssi.Size = new System.Drawing.Size(32, 31);
            this.pictureBoxRssi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRssi.TabIndex = 14;
            this.pictureBoxRssi.TabStop = false;
            this.pictureBoxRssi.Visible = false;
            this.pictureBoxRssi.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // versionLab
            // 
            this.versionLab.Location = new System.Drawing.Point(48, 348);
            this.versionLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionLab.Name = "versionLab";
            this.versionLab.Size = new System.Drawing.Size(96, 12);
            this.versionLab.TabIndex = 17;
            this.versionLab.Text = "Version";
            this.versionLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(18, 518);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(113, 45);
            this.trackBar1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 547);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "label7";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(19, 568);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(105, 45);
            this.trackBar2.TabIndex = 20;
            this.trackBar2.Value = 80;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 602);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "label8";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 119);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(135, 30);
            this.button8.TabIndex = 23;
            this.button8.Text = "LogFile";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 753);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.versionLab);
            this.Controls.Add(this.progressBarRSSI);
            this.Controls.Add(this.pictureBoxRssi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rssiLab);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxActiveNode);
            this.Controls.Add(this.txtDataSendBox);
            this.Controls.Add(this.txtReceiveBox);
            this.Controls.Add(this.sendBTN);
            this.Controls.Add(this.comPort_comboBox);
            this.Controls.Add(this.caliBTN);
            this.Controls.Add(this.disconBTN);
            this.Controls.Add(this.conBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Soil moisture App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxActiveNode.ResumeLayout(false);
            this.groupBoxActiveNode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRssi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button conBTN;
        private System.Windows.Forms.Button disconBTN;
        private System.Windows.Forms.Button caliBTN;
        private System.Windows.Forms.ComboBox comPort_comboBox;
        private System.Windows.Forms.Button sendBTN;
        private System.Windows.Forms.TextBox txtReceiveBox;
        private System.Windows.Forms.TextBox txtDataSendBox;
        private System.Windows.Forms.GroupBox groupBoxActiveNode;
        private System.Windows.Forms.Label moisLab;
        private System.Windows.Forms.Label maxMoisLab;
        private System.Windows.Forms.Label minMoisLab;
        private System.Windows.Forms.Label rssiLab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ProgressBar progressBarActiveNode;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerErrorRssi;
        private System.Windows.Forms.PictureBox pictureBoxRssi;
        private System.Windows.Forms.ProgressBar progressBarRSSI;
        private System.Windows.Forms.Timer timerErrorSensor;
        private System.Windows.Forms.PictureBox pictureBoxErrorSensor;
        private System.Windows.Forms.Label versionLab;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

