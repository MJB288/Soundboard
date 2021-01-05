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
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lviewKeybind = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKeybind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRebind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(44, 225);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "Defaults";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(125, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(206, 225);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lviewKeybind
            // 
            this.lviewKeybind.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmKeybind});
            this.lviewKeybind.FullRowSelect = true;
            this.lviewKeybind.HideSelection = false;
            this.lviewKeybind.Location = new System.Drawing.Point(45, 12);
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
            this.btnRebind.Location = new System.Drawing.Point(125, 185);
            this.btnRebind.Name = "btnRebind";
            this.btnRebind.Size = new System.Drawing.Size(75, 23);
            this.btnRebind.TabIndex = 16;
            this.btnRebind.Text = "Rebind";
            this.btnRebind.UseVisualStyleBackColor = true;
            this.btnRebind.Click += new System.EventHandler(this.btnRebind_Click);
            // 
            // frmKeybind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 270);
            this.Controls.Add(this.btnRebind);
            this.Controls.Add(this.lviewKeybind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDefault);
            this.Name = "frmKeybind";
            this.Text = "Keybind";
            this.Load += new System.EventHandler(this.frmKeybind_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lviewKeybind;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmKeybind;
        private System.Windows.Forms.Button btnRebind;
    }
}