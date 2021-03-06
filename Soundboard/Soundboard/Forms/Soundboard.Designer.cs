﻿namespace Soundboard.Forms
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSoundShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBasicKeybinds = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetShortcut = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnSingleMulti = new System.Windows.Forms.Button();
            this.clmShortcut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(33, 47);
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
            this.clmLength,
            this.clmShortcut});
            this.lviewSounds.HideSelection = false;
            this.lviewSounds.Location = new System.Drawing.Point(26, 138);
            this.lviewSounds.Name = "lviewSounds";
            this.lviewSounds.Size = new System.Drawing.Size(271, 202);
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
            this.btnStop.Location = new System.Drawing.Point(127, 47);
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
            this.cboxOutputDevices.Location = new System.Drawing.Point(321, 207);
            this.cboxOutputDevices.Name = "cboxOutputDevices";
            this.cboxOutputDevices.Size = new System.Drawing.Size(299, 21);
            this.cboxOutputDevices.TabIndex = 3;
            // 
            // lblDeviceSelection
            // 
            this.lblDeviceSelection.AutoSize = true;
            this.lblDeviceSelection.Location = new System.Drawing.Point(404, 191);
            this.lblDeviceSelection.Name = "lblDeviceSelection";
            this.lblDeviceSelection.Size = new System.Drawing.Size(132, 13);
            this.lblDeviceSelection.TabIndex = 4;
            this.lblDeviceSelection.Text = "Output Device Selection : ";
            // 
            // cboxGroups
            // 
            this.cboxGroups.FormattingEnabled = true;
            this.cboxGroups.Location = new System.Drawing.Point(102, 111);
            this.cboxGroups.Name = "cboxGroups";
            this.cboxGroups.Size = new System.Drawing.Size(121, 21);
            this.cboxGroups.TabIndex = 5;
            this.cboxGroups.SelectedIndexChanged += new System.EventHandler(this.cboxGroups_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group :";
            // 
            // tbarVolume
            // 
            this.tbarVolume.Location = new System.Drawing.Point(389, 55);
            this.tbarVolume.Maximum = 100;
            this.tbarVolume.Name = "tbarVolume";
            this.tbarVolume.Size = new System.Drawing.Size(121, 45);
            this.tbarVolume.TabIndex = 8;
            this.tbarVolume.Scroll += new System.EventHandler(this.tbarVolume_Scroll);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(222, 47);
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
            this.cboxInputDevices.Location = new System.Drawing.Point(321, 270);
            this.cboxInputDevices.Name = "cboxInputDevices";
            this.cboxInputDevices.Size = new System.Drawing.Size(299, 21);
            this.cboxInputDevices.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Input Device Selection : ";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(346, 154);
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
            this.btnPlayback.Location = new System.Drawing.Point(431, 154);
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
            this.btnSaveRec.Location = new System.Drawing.Point(516, 154);
            this.btnSaveRec.Name = "btnSaveRec";
            this.btnSaveRec.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRec.TabIndex = 14;
            this.btnSaveRec.Text = "Save";
            this.btnSaveRec.UseVisualStyleBackColor = true;
            this.btnSaveRec.Click += new System.EventHandler(this.btnSaveRec_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSoundShortcuts,
            this.tsmiBasicKeybinds});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // tsmiSoundShortcuts
            // 
            this.tsmiSoundShortcuts.Name = "tsmiSoundShortcuts";
            this.tsmiSoundShortcuts.Size = new System.Drawing.Size(161, 22);
            this.tsmiSoundShortcuts.Text = "Sound Shortcuts";
            this.tsmiSoundShortcuts.Click += new System.EventHandler(this.tsmiSoundShortcuts_Click);
            // 
            // tsmiBasicKeybinds
            // 
            this.tsmiBasicKeybinds.Name = "tsmiBasicKeybinds";
            this.tsmiBasicKeybinds.Size = new System.Drawing.Size(161, 22);
            this.tsmiBasicKeybinds.Text = "Basic Keybinds";
            this.tsmiBasicKeybinds.Click += new System.EventHandler(this.tsmiBasicKeybinds_Click);
            // 
            // btnSetShortcut
            // 
            this.btnSetShortcut.Location = new System.Drawing.Point(222, 77);
            this.btnSetShortcut.Name = "btnSetShortcut";
            this.btnSetShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnSetShortcut.TabIndex = 16;
            this.btnSetShortcut.Text = "Set Shortcut";
            this.btnSetShortcut.UseVisualStyleBackColor = true;
            this.btnSetShortcut.Click += new System.EventHandler(this.btnSetShortcut_Click);
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnMute.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMute.Location = new System.Drawing.Point(516, 66);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(44, 23);
            this.btnMute.TabIndex = 17;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnSingleMulti
            // 
            this.btnSingleMulti.Location = new System.Drawing.Point(26, 76);
            this.btnSingleMulti.Name = "btnSingleMulti";
            this.btnSingleMulti.Size = new System.Drawing.Size(89, 23);
            this.btnSingleMulti.TabIndex = 18;
            this.btnSingleMulti.Text = "Mode : Multi";
            this.btnSingleMulti.UseVisualStyleBackColor = true;
            this.btnSingleMulti.Click += new System.EventHandler(this.btnSingleMulti_Click);
            // 
            // clmShortcut
            // 
            this.clmShortcut.Text = "Shortcut";
            // 
            // frmSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 382);
            this.Controls.Add(this.btnSingleMulti);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnSetShortcut);
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
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSound";
            this.Text = "Soundboard";
            this.Load += new System.EventHandler(this.frmSound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnSetShortcut;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSoundShortcuts;
        private System.Windows.Forms.ToolStripMenuItem tsmiBasicKeybinds;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnSingleMulti;
        private System.Windows.Forms.ColumnHeader clmShortcut;
    }
}

