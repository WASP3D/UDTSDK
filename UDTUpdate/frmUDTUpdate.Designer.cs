namespace UDTUpdate
{
    partial class frmUDTUpdate
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOffAir = new System.Windows.Forms.Button();
            this.btnOnAir = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.txtSceneName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblSceneName = new System.Windows.Forms.Label();
            this.cmbxServers = new System.Windows.Forms.ComboBox();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.btnLoadScene = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlUdtUpdate = new UDTUpdate.ctrlUdtUpdate();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOffAir);
            this.groupBox2.Controls.Add(this.btnOnAir);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.btnPlay);
            this.groupBox2.Location = new System.Drawing.Point(3, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 146);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller";
            // 
            // btnOffAir
            // 
            this.btnOffAir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffAir.Location = new System.Drawing.Point(210, 60);
            this.btnOffAir.Name = "btnOffAir";
            this.btnOffAir.Size = new System.Drawing.Size(218, 32);
            this.btnOffAir.TabIndex = 7;
            this.btnOffAir.Text = "OffAir";
            this.btnOffAir.UseVisualStyleBackColor = true;
            this.btnOffAir.Click += new System.EventHandler(this.btnOffAir_Click_1);
            // 
            // btnOnAir
            // 
            this.btnOnAir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnAir.Location = new System.Drawing.Point(210, 19);
            this.btnOnAir.Name = "btnOnAir";
            this.btnOnAir.Size = new System.Drawing.Size(218, 31);
            this.btnOnAir.TabIndex = 6;
            this.btnOnAir.Text = "OnAir";
            this.btnOnAir.UseVisualStyleBackColor = true;
            this.btnOnAir.Click += new System.EventHandler(this.btnOnAir_Click_1);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(6, 98);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(191, 32);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // btnPause
            // 
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(6, 60);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(191, 32);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click_1);
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(6, 19);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(191, 31);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click_1);
            // 
            // btnPreview
            // 
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(6, 60);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(215, 32);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click_1);
            // 
            // btnProgram
            // 
            this.btnProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgram.Location = new System.Drawing.Point(6, 19);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(215, 33);
            this.btnProgram.TabIndex = 8;
            this.btnProgram.Text = "Program";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click_1);
            // 
            // txtSceneName
            // 
            this.txtSceneName.Location = new System.Drawing.Point(81, 3);
            this.txtSceneName.Name = "txtSceneName";
            this.txtSceneName.Size = new System.Drawing.Size(187, 20);
            this.txtSceneName.TabIndex = 5;
            this.txtSceneName.Text = "..\\Scenes\\Ticker with UDT.wspx";
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(290, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // lblSceneName
            // 
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Location = new System.Drawing.Point(14, 8);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(66, 13);
            this.lblSceneName.TabIndex = 1;
            this.lblSceneName.Text = "SceneName";
            // 
            // cmbxServers
            // 
            this.cmbxServers.Location = new System.Drawing.Point(81, 3);
            this.cmbxServers.Name = "cmbxServers";
            this.cmbxServers.Size = new System.Drawing.Size(187, 21);
            this.cmbxServers.TabIndex = 3;
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(14, 6);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(47, 13);
            this.lblServerIp.TabIndex = 0;
            this.lblServerIp.Text = "ServerIp";
            // 
            // btnLoadScene
            // 
            this.btnLoadScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadScene.Location = new System.Drawing.Point(290, 38);
            this.btnLoadScene.Name = "btnLoadScene";
            this.btnLoadScene.Size = new System.Drawing.Size(92, 28);
            this.btnLoadScene.TabIndex = 4;
            this.btnLoadScene.Text = "LoadScene";
            this.btnLoadScene.UseVisualStyleBackColor = true;
            this.btnLoadScene.Click += new System.EventHandler(this.btnLoadScene_Click_1);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblServerIp);
            this.panel1.Controls.Add(this.cmbxServers);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 28);
            this.panel1.TabIndex = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSceneName);
            this.panel2.Controls.Add(this.txtSceneName);
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 28);
            this.panel2.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProgram);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Location = new System.Drawing.Point(446, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 146);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Render Mode";
            // 
            // ctrlUdtUpdate
            // 
            this.ctrlUdtUpdate.Location = new System.Drawing.Point(3, 239);
            this.ctrlUdtUpdate.Name = "ctrlUdtUpdate";
            this.ctrlUdtUpdate.Size = new System.Drawing.Size(670, 206);
            this.ctrlUdtUpdate.TabIndex = 63;
            this.ctrlUdtUpdate.Load += new System.EventHandler(this.ctrlUdtUpdate1_Load);
            // 
            // frmUDTUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 457);
            this.Controls.Add(this.ctrlUdtUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnLoadScene);
            this.Name = "frmUDTUpdate";
            this.Text = "UDT Update";
            this.Load += new System.EventHandler(this.frmUDTUpdate_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Button btnOffAir;
        private System.Windows.Forms.Button btnOnAir;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtSceneName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblSceneName;
        //private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.Button btnLoadScene;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbxServers;
        private ctrlUdtUpdate ctrlUdtUpdate;
    }
}

