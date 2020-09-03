namespace Soundboard
{
    partial class frmSound
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.lviewSounds = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.cboxSoundDevices = new System.Windows.Forms.ComboBox();
            this.lblDeviceSelection = new System.Windows.Forms.Label();
            this.cboxGroups = new System.Windows.Forms.ComboBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(31, 13);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lviewSounds
            // 
            this.lviewSounds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmLength});
            this.lviewSounds.HideSelection = false;
            this.lviewSounds.Location = new System.Drawing.Point(31, 42);
            this.lviewSounds.Name = "lviewSounds";
            this.lviewSounds.Size = new System.Drawing.Size(169, 202);
            this.lviewSounds.TabIndex = 1;
            this.lviewSounds.UseCompatibleStateImageBehavior = false;
            this.lviewSounds.View = System.Windows.Forms.View.Details;
            this.lviewSounds.SelectedIndexChanged += new System.EventHandler(this.lviewSounds_SelectedIndexChanged);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            // 
            // clmLength
            // 
            this.clmLength.Text = "Length";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(125, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // cboxSoundDevices
            // 
            this.cboxSoundDevices.FormattingEnabled = true;
            this.cboxSoundDevices.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboxSoundDevices.Location = new System.Drawing.Point(362, 58);
            this.cboxSoundDevices.Name = "cboxSoundDevices";
            this.cboxSoundDevices.Size = new System.Drawing.Size(299, 21);
            this.cboxSoundDevices.TabIndex = 3;
            // 
            // lblDeviceSelection
            // 
            this.lblDeviceSelection.AutoSize = true;
            this.lblDeviceSelection.Location = new System.Drawing.Point(463, 42);
            this.lblDeviceSelection.Name = "lblDeviceSelection";
            this.lblDeviceSelection.Size = new System.Drawing.Size(132, 13);
            this.lblDeviceSelection.TabIndex = 4;
            this.lblDeviceSelection.Text = "Output Device Selection : ";
            // 
            // cboxGroups
            // 
            this.cboxGroups.FormattingEnabled = true;
            this.cboxGroups.Location = new System.Drawing.Point(229, 223);
            this.cboxGroups.Name = "cboxGroups";
            this.cboxGroups.Size = new System.Drawing.Size(121, 21);
            this.cboxGroups.TabIndex = 5;
            this.cboxGroups.SelectedIndexChanged += new System.EventHandler(this.cboxGroups_SelectedIndexChanged);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(438, 129);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(28, 13);
            this.lblTest.TabIndex = 6;
            this.lblTest.Text = "Test";
            // 
            // frmSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.cboxGroups);
            this.Controls.Add(this.lblDeviceSelection);
            this.Controls.Add(this.cboxSoundDevices);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lviewSounds);
            this.Controls.Add(this.btnPlay);
            this.Name = "frmSound";
            this.Text = "Soundboard";
            this.Load += new System.EventHandler(this.frmSound_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ListView lviewSounds;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmLength;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cboxSoundDevices;
        private System.Windows.Forms.Label lblDeviceSelection;
        private System.Windows.Forms.ComboBox cboxGroups;
        private System.Windows.Forms.Label lblTest;
    }
}

