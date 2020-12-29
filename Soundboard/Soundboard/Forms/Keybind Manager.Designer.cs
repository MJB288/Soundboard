namespace Soundboard.Forms
{
    partial class frmKeybind
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
            this.txtStop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRebindStop = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRebindPlay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRebindRec = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPlayback = new System.Windows.Forms.Label();
            this.txtPlayback = new System.Windows.Forms.TextBox();
            this.lviewKeybind = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKeybind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRebind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStop
            // 
            this.txtStop.Location = new System.Drawing.Point(129, 25);
            this.txtStop.Name = "txtStop";
            this.txtStop.ReadOnly = true;
            this.txtStop.Size = new System.Drawing.Size(100, 20);
            this.txtStop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stop :";
            // 
            // btnRebindStop
            // 
            this.btnRebindStop.Location = new System.Drawing.Point(235, 25);
            this.btnRebindStop.Name = "btnRebindStop";
            this.btnRebindStop.Size = new System.Drawing.Size(24, 20);
            this.btnRebindStop.TabIndex = 2;
            this.btnRebindStop.Text = "...";
            this.btnRebindStop.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(48, 412);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "Defaults";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(129, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(210, 412);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRebindPlay
            // 
            this.btnRebindPlay.Location = new System.Drawing.Point(235, 51);
            this.btnRebindPlay.Name = "btnRebindPlay";
            this.btnRebindPlay.Size = new System.Drawing.Size(24, 20);
            this.btnRebindPlay.TabIndex = 8;
            this.btnRebindPlay.Text = "...";
            this.btnRebindPlay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Play :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // btnRebindRec
            // 
            this.btnRebindRec.Location = new System.Drawing.Point(235, 77);
            this.btnRebindRec.Name = "btnRebindRec";
            this.btnRebindRec.Size = new System.Drawing.Size(24, 20);
            this.btnRebindRec.TabIndex = 11;
            this.btnRebindRec.Text = "...";
            this.btnRebindRec.UseVisualStyleBackColor = true;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(46, 77);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(77, 20);
            this.lblRecord.TabIndex = 10;
            this.lblRecord.Text = "Record :";
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(129, 77);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(100, 20);
            this.txtRecord.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 20);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblPlayback
            // 
            this.lblPlayback.AutoSize = true;
            this.lblPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayback.Location = new System.Drawing.Point(33, 101);
            this.lblPlayback.Name = "lblPlayback";
            this.lblPlayback.Size = new System.Drawing.Size(90, 20);
            this.lblPlayback.TabIndex = 13;
            this.lblPlayback.Text = "Playback :";
            // 
            // txtPlayback
            // 
            this.txtPlayback.Location = new System.Drawing.Point(129, 103);
            this.txtPlayback.Name = "txtPlayback";
            this.txtPlayback.ReadOnly = true;
            this.txtPlayback.Size = new System.Drawing.Size(100, 20);
            this.txtPlayback.TabIndex = 12;
            // 
            // lviewKeybind
            // 
            this.lviewKeybind.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmKeybind});
            this.lviewKeybind.HideSelection = false;
            this.lviewKeybind.Location = new System.Drawing.Point(37, 150);
            this.lviewKeybind.Name = "lviewKeybind";
            this.lviewKeybind.Size = new System.Drawing.Size(235, 167);
            this.lviewKeybind.TabIndex = 15;
            this.lviewKeybind.UseCompatibleStateImageBehavior = false;
            this.lviewKeybind.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 120;
            // 
            // clmKeybind
            // 
            this.clmKeybind.Text = "Keybind";
            this.clmKeybind.Width = 100;
            // 
            // btnRebind
            // 
            this.btnRebind.Location = new System.Drawing.Point(116, 324);
            this.btnRebind.Name = "btnRebind";
            this.btnRebind.Size = new System.Drawing.Size(75, 23);
            this.btnRebind.TabIndex = 16;
            this.btnRebind.Text = "Rebind";
            this.btnRebind.UseVisualStyleBackColor = true;
            // 
            // frmKeybind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 454);
            this.Controls.Add(this.btnRebind);
            this.Controls.Add(this.lviewKeybind);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPlayback);
            this.Controls.Add(this.txtPlayback);
            this.Controls.Add(this.btnRebindRec);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.btnRebindPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnRebindStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStop);
            this.Name = "frmKeybind";
            this.Text = "Keybind";
            this.Load += new System.EventHandler(this.frmKeybind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRebindStop;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRebindPlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnRebindRec;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPlayback;
        private System.Windows.Forms.TextBox txtPlayback;
        private System.Windows.Forms.ListView lviewKeybind;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmKeybind;
        private System.Windows.Forms.Button btnRebind;
    }
}