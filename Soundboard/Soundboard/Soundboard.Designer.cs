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
            this.cboxOutputDevices = new System.Windows.Forms.ComboBox();
            this.lblDeviceSelection = new System.Windows.Forms.Label();
            this.cboxGroups = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbarVolume = new System.Windows.Forms.TrackBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboxInputDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.btnSaveRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).BeginInit();
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
            this.lviewSounds.Location = new System.Drawing.Point(22, 104);
            this.lviewSounds.Name = "lviewSounds";
            this.lviewSounds.Size = new System.Drawing.Size(242, 202);
            this.lviewSounds.TabIndex = 1;
            this.lviewSounds.UseCompatibleStateImageBehavior = false;
            this.lviewSounds.View = System.Windows.Forms.View.Details;
            this.lviewSounds.SelectedIndexChanged += new System.EventHandler(this.lviewSounds_SelectedIndexChanged);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 130;
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
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cboxOutputDevices
            // 
            this.cboxOutputDevices.FormattingEnabled = true;
            this.cboxOutputDevices.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboxOutputDevices.Location = new System.Drawing.Point(307, 172);
            this.cboxOutputDevices.Name = "cboxOutputDevices";
            this.cboxOutputDevices.Size = new System.Drawing.Size(299, 21);
            this.cboxOutputDevices.TabIndex = 3;
            // 
            // lblDeviceSelection
            // 
            this.lblDeviceSelection.AutoSize = true;
            this.lblDeviceSelection.Location = new System.Drawing.Point(390, 156);
            this.lblDeviceSelection.Name = "lblDeviceSelection";
            this.lblDeviceSelection.Size = new System.Drawing.Size(132, 13);
            this.lblDeviceSelection.TabIndex = 4;
            this.lblDeviceSelection.Text = "Output Device Selection : ";
            // 
            // cboxGroups
            // 
            this.cboxGroups.FormattingEnabled = true;
            this.cboxGroups.Location = new System.Drawing.Point(100, 77);
            this.cboxGroups.Name = "cboxGroups";
            this.cboxGroups.Size = new System.Drawing.Size(121, 21);
            this.cboxGroups.TabIndex = 5;
            this.cboxGroups.SelectedIndexChanged += new System.EventHandler(this.cboxGroups_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group :";
            // 
            // tbarVolume
            // 
            this.tbarVolume.Location = new System.Drawing.Point(316, 2);
            this.tbarVolume.Maximum = 100;
            this.tbarVolume.Name = "tbarVolume";
            this.tbarVolume.Size = new System.Drawing.Size(121, 45);
            this.tbarVolume.TabIndex = 8;
            this.tbarVolume.Scroll += new System.EventHandler(this.tbarVolume_Scroll);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(220, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboxInputDevices
            // 
            this.cboxInputDevices.FormattingEnabled = true;
            this.cboxInputDevices.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboxInputDevices.Location = new System.Drawing.Point(307, 235);
            this.cboxInputDevices.Name = "cboxInputDevices";
            this.cboxInputDevices.Size = new System.Drawing.Size(299, 21);
            this.cboxInputDevices.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Input Device Selection : ";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(332, 119);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 12;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnPlayback
            // 
            this.btnPlayback.Enabled = false;
            this.btnPlayback.Location = new System.Drawing.Point(421, 119);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(75, 23);
            this.btnPlayback.TabIndex = 13;
            this.btnPlayback.Text = "Playback";
            this.btnPlayback.UseVisualStyleBackColor = true;
            this.btnPlayback.Click += new System.EventHandler(this.btnPlayback_Click);
            // 
            // btnSaveRec
            // 
            this.btnSaveRec.Enabled = false;
            this.btnSaveRec.Location = new System.Drawing.Point(502, 119);
            this.btnSaveRec.Name = "btnSaveRec";
            this.btnSaveRec.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRec.TabIndex = 14;
            this.btnSaveRec.Text = "Save";
            this.btnSaveRec.UseVisualStyleBackColor = true;
            this.btnSaveRec.Click += new System.EventHandler(this.btnSaveRec_Click);
            // 
            // frmSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 333);
            this.Controls.Add(this.btnSaveRec);
            this.Controls.Add(this.btnPlayback);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxInputDevices);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbarVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxGroups);
            this.Controls.Add(this.lblDeviceSelection);
            this.Controls.Add(this.cboxOutputDevices);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lviewSounds);
            this.Controls.Add(this.btnPlay);
            this.Name = "frmSound";
            this.Text = "Soundboard";
            this.Load += new System.EventHandler(this.frmSound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ListView lviewSounds;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmLength;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cboxOutputDevices;
        private System.Windows.Forms.Label lblDeviceSelection;
        private System.Windows.Forms.ComboBox cboxGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbarVolume;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboxInputDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnPlayback;
        private System.Windows.Forms.Button btnSaveRec;
    }
}

