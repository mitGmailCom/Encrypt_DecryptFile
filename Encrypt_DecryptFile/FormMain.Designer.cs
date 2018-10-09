namespace Encrypt_DecryptFile
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.btnStartProc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnDecrypt = new System.Windows.Forms.RadioButton();
            this.radioBtnCrypt = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.trackBarSelectNumberSymb = new System.Windows.Forms.TrackBar();
            this.btnKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSelectNumberSymb)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.Location = new System.Drawing.Point(12, 226);
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(260, 23);
            this.progressBarProcess.TabIndex = 0;
            // 
            // btnStartProc
            // 
            this.btnStartProc.Location = new System.Drawing.Point(146, 197);
            this.btnStartProc.Name = "btnStartProc";
            this.btnStartProc.Size = new System.Drawing.Size(126, 23);
            this.btnStartProc.TabIndex = 1;
            this.btnStartProc.Text = "Go";
            this.btnStartProc.UseVisualStyleBackColor = true;
            this.btnStartProc.Click += new System.EventHandler(this.btnStartProc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnDecrypt);
            this.groupBox1.Controls.Add(this.radioBtnCrypt);
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select one";
            // 
            // radioBtnDecrypt
            // 
            this.radioBtnDecrypt.AutoSize = true;
            this.radioBtnDecrypt.Location = new System.Drawing.Point(177, 19);
            this.radioBtnDecrypt.Name = "radioBtnDecrypt";
            this.radioBtnDecrypt.Size = new System.Drawing.Size(62, 17);
            this.radioBtnDecrypt.TabIndex = 1;
            this.radioBtnDecrypt.TabStop = true;
            this.radioBtnDecrypt.Text = "Decrypt";
            this.radioBtnDecrypt.UseVisualStyleBackColor = true;
            this.radioBtnDecrypt.CheckedChanged += new System.EventHandler(this.radioBtnDecrypt_CheckedChanged);
            // 
            // radioBtnCrypt
            // 
            this.radioBtnCrypt.AutoSize = true;
            this.radioBtnCrypt.Location = new System.Drawing.Point(45, 19);
            this.radioBtnCrypt.Name = "radioBtnCrypt";
            this.radioBtnCrypt.Size = new System.Drawing.Size(49, 17);
            this.radioBtnCrypt.TabIndex = 0;
            this.radioBtnCrypt.TabStop = true;
            this.radioBtnCrypt.Text = "Crypt";
            this.radioBtnCrypt.UseVisualStyleBackColor = true;
            this.radioBtnCrypt.CheckedChanged += new System.EventHandler(this.radioBtnCrypt_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Choosed document:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "file";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(187, 14);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 35);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // trackBarSelectNumberSymb
            // 
            this.trackBarSelectNumberSymb.Location = new System.Drawing.Point(12, 147);
            this.trackBarSelectNumberSymb.Minimum = 6;
            this.trackBarSelectNumberSymb.Name = "trackBarSelectNumberSymb";
            this.trackBarSelectNumberSymb.Size = new System.Drawing.Size(260, 45);
            this.trackBarSelectNumberSymb.TabIndex = 7;
            this.trackBarSelectNumberSymb.Value = 6;
            this.trackBarSelectNumberSymb.Scroll += new System.EventHandler(this.trackBarSelectNumberSymb_Scroll);
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(12, 197);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(126, 23);
            this.btnKey.TabIndex = 9;
            this.btnKey.Text = "InputKey";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "val";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Current val:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.trackBarSelectNumberSymb);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartProc);
            this.Controls.Add(this.progressBarProcess);
            this.Name = "FormMain";
            this.Text = "Manage File";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSelectNumberSymb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarProcess;
        private System.Windows.Forms.Button btnStartProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnDecrypt;
        private System.Windows.Forms.RadioButton radioBtnCrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TrackBar trackBarSelectNumberSymb;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

