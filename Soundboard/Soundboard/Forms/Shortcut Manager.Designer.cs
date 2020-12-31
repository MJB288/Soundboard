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
            this.clmGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFullFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnEditKey = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lviewShortcuts
            // 
            this.lviewShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmKeyBind,
            this.clmFileName,
            this.clmGroup,
            this.clmFullFilePath});
            this.lviewShortcuts.FullRowSelect = true;
            this.lviewShortcuts.HideSelection = false;
            this.lviewShortcuts.Location = new System.Drawing.Point(15, 21);
            this.lviewShortcuts.Name = "lviewShortcuts";
            this.lviewShortcuts.Size = new System.Drawing.Size(468, 220);
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
            this.clmFileName.Width = 140;
            // 
            // clmGroup
            // 
            this.clmGroup.Text = "Group";
            // 
            // clmFullFilePath
            // 
            this.clmFullFilePath.Text = "FilePath";
            this.clmFullFilePath.Width = 200;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(503, 107);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 29);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(503, 151);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(113, 29);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnEditKey
            // 
            this.btnEditKey.Location = new System.Drawing.Point(503, 63);
            this.btnEditKey.Name = "btnEditKey";
            this.btnEditKey.Size = new System.Drawing.Size(113, 29);
            this.btnEditKey.TabIndex = 3;
            this.btnEditKey.Text = "Edit Keybind";
            this.btnEditKey.UseVisualStyleBackColor = true;
            this.btnEditKey.Click += new System.EventHandler(this.btnEditKey_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(218, 247);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 37);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(339, 247);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShortcutManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 289);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnEditKey);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lviewShortcuts);
            this.Name = "frmShortcutManager";
            this.Text = "Shortcut Manager";
            this.Load += new System.EventHandler(this.frmShortcutManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lviewShortcuts;
        private System.Windows.Forms.ColumnHeader clmKeyBind;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFullFilePath;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnEditKey;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader clmGroup;
    }
}