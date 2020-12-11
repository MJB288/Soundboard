namespace Soundboard.Forms
{
    partial class frmShortcutManager
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
            this.lviewShortcuts = new System.Windows.Forms.ListView();
            this.clmKeyBind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFullFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lviewShortcuts
            // 
            this.lviewShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmKeyBind,
            this.clmFileName,
            this.clmFullFilePath});
            this.lviewShortcuts.HideSelection = false;
            this.lviewShortcuts.Location = new System.Drawing.Point(120, 59);
            this.lviewShortcuts.Name = "lviewShortcuts";
            this.lviewShortcuts.Size = new System.Drawing.Size(445, 220);
            this.lviewShortcuts.TabIndex = 0;
            this.lviewShortcuts.UseCompatibleStateImageBehavior = false;
            this.lviewShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // clmKeyBind
            // 
            this.clmKeyBind.Text = "Key Bind";
            // 
            // clmFileName
            // 
            this.clmFileName.Text = "File Name";
            // 
            // clmFullFilePath
            // 
            this.clmFullFilePath.Text = "FilePath";
            this.clmFullFilePath.Width = 200;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(585, 196);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 29);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Remove All";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit Keybind";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmShortcutManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lviewShortcuts);
            this.Name = "frmShortcutManager";
            this.Text = "Shortcut Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lviewShortcuts;
        private System.Windows.Forms.ColumnHeader clmKeyBind;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFullFilePath;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}