namespace PID_CONTROL
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
            this.PbStart = new System.Windows.Forms.Button();
            this.PbConect = new System.Windows.Forms.Button();
            this.txtKP = new System.Windows.Forms.TextBox();
            this.txtKD = new System.Windows.Forms.TextBox();
            this.txtKI = new System.Windows.Forms.TextBox();
            this.Cbcom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Pbdown = new System.Windows.Forms.Button();
            this.Pbup = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbss = new System.Windows.Forms.Label();
            this.COM = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.RESULT = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.RESULT.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbStart
            // 
            this.PbStart.BackColor = System.Drawing.Color.Yellow;
            this.PbStart.Location = new System.Drawing.Point(13, 46);
            this.PbStart.Name = "PbStart";
            this.PbStart.Size = new System.Drawing.Size(84, 28);
            this.PbStart.TabIndex = 0;
            this.PbStart.Text = "START";
            this.PbStart.UseVisualStyleBackColor = false;
            this.PbStart.Click += new System.EventHandler(this.PbStart_Click);
            // 
            // PbConect
            // 
            this.PbConect.BackColor = System.Drawing.Color.Red;
            this.PbConect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PbConect.Location = new System.Drawing.Point(26, 63);
            this.PbConect.Name = "PbConect";
            this.PbConect.Size = new System.Drawing.Size(98, 31);
            this.PbConect.TabIndex = 1;
            this.PbConect.Text = "CONECT";
            this.PbConect.UseVisualStyleBackColor = false;
            this.PbConect.Click += new System.EventHandler(this.PbConect_Click);
            // 
            // txtKP
            // 
            this.txtKP.Location = new System.Drawing.Point(14, 143);
            this.txtKP.Name = "txtKP";
            this.txtKP.Size = new System.Drawing.Size(83, 27);
            this.txtKP.TabIndex = 3;
            // 
            // txtKD
            // 
            this.txtKD.Location = new System.Drawing.Point(265, 143);
            this.txtKD.Name = "txtKD";
            this.txtKD.Size = new System.Drawing.Size(83, 27);
            this.txtKD.TabIndex = 4;
            // 
            // txtKI
            // 
            this.txtKI.Location = new System.Drawing.Point(138, 143);
            this.txtKI.Name = "txtKI";
            this.txtKI.Size = new System.Drawing.Size(83, 27);
            this.txtKI.TabIndex = 5;
            // 
            // Cbcom
            // 
            this.Cbcom.FormattingEnabled = true;
            this.Cbcom.Location = new System.Drawing.Point(16, 20);
            this.Cbcom.Name = "Cbcom";
            this.Cbcom.Size = new System.Drawing.Size(121, 28);
            this.Cbcom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(40, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "KP";
            // 
            // KI
            // 
            this.KI.AutoSize = true;
            this.KI.BackColor = System.Drawing.Color.Green;
            this.KI.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KI.Location = new System.Drawing.Point(165, 112);
            this.KI.Name = "KI";
            this.KI.Size = new System.Drawing.Size(28, 22);
            this.KI.TabIndex = 8;
            this.KI.Text = "KI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "KD";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pbdown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.KI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Pbup);
            this.groupBox1.Controls.Add(this.txtKI);
            this.groupBox1.Controls.Add(this.txtKD);
            this.groupBox1.Controls.Add(this.txtSpeed);
            this.groupBox1.Controls.Add(this.Speed);
            this.groupBox1.Controls.Add(this.txtKP);
            this.groupBox1.Controls.Add(this.PbStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(176, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 179);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HE SO";
            // 
            // Pbdown
            // 
            this.Pbdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Pbdown.Location = new System.Drawing.Point(297, 67);
            this.Pbdown.Name = "Pbdown";
            this.Pbdown.Size = new System.Drawing.Size(24, 22);
            this.Pbdown.TabIndex = 17;
            this.Pbdown.Text = "-";
            this.Pbdown.UseVisualStyleBackColor = false;
            this.Pbdown.Click += new System.EventHandler(this.Pbdown_Click);
            // 
            // Pbup
            // 
            this.Pbup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Pbup.Location = new System.Drawing.Point(297, 46);
            this.Pbup.Name = "Pbup";
            this.Pbup.Size = new System.Drawing.Size(24, 22);
            this.Pbup.TabIndex = 16;
            this.Pbup.Text = "+";
            this.Pbup.UseVisualStyleBackColor = false;
            this.Pbup.Click += new System.EventHandler(this.Pbup_Click);
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(162, 69);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(87, 27);
            this.txtSpeed.TabIndex = 12;
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.BackColor = System.Drawing.Color.Red;
            this.Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed.Location = new System.Drawing.Point(144, 28);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(138, 22);
            this.Speed.TabIndex = 13;
            this.Speed.Text = "Speed Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lbss);
            this.groupBox2.Controls.Add(this.Cbcom);
            this.groupBox2.Controls.Add(this.PbConect);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 143);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM PORT";
            // 
            // Lbss
            // 
            this.Lbss.AutoSize = true;
            this.Lbss.Location = new System.Drawing.Point(28, 97);
            this.Lbss.Name = "Lbss";
            this.Lbss.Size = new System.Drawing.Size(99, 22);
            this.Lbss.TabIndex = 14;
            this.Lbss.Text = "Disconnect";
            // 
            // COM
            // 
            this.COM.DtrEnable = true;
            this.COM.ReadTimeout = 500;
            this.COM.RtsEnable = true;
            this.COM.WriteTimeout = 500;
            this.COM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ONCOM);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "SPEED";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(44, 61);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(83, 27);
            this.txtResult.TabIndex = 12;
            // 
            // RESULT
            // 
            this.RESULT.BackColor = System.Drawing.Color.YellowGreen;
            this.RESULT.Controls.Add(this.label3);
            this.RESULT.Controls.Add(this.txtResult);
            this.RESULT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESULT.Location = new System.Drawing.Point(10, 176);
            this.RESULT.Name = "RESULT";
            this.RESULT.Size = new System.Drawing.Size(160, 107);
            this.RESULT.TabIndex = 15;
            this.RESULT.TabStop = false;
            this.RESULT.Text = "RESULT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 308);
            this.Controls.Add(this.RESULT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.RESULT.ResumeLayout(false);
            this.RESULT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PbStart;
        private System.Windows.Forms.Button PbConect;
        private System.Windows.Forms.TextBox txtKP;
        private System.Windows.Forms.TextBox txtKD;
        private System.Windows.Forms.TextBox txtKI;
        private System.Windows.Forms.ComboBox Cbcom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label KI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.IO.Ports.SerialPort COM;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label Lbss;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox RESULT;
        private System.Windows.Forms.Button Pbup;
        private System.Windows.Forms.Button Pbdown;
    }
}

