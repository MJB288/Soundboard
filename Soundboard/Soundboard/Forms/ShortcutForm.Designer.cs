﻿namespace Soundboard.Forms
{
    partial class frmShortcutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.lblDisplayKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Press new Shortcut Key :";
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 10000;
            // 
            // lblDisplayKey
            // 
            this.lblDisplayKey.AutoSize = true;
            this.lblDisplayKey.Location = new System.Drawing.Point(71, 48);
            this.lblDisplayKey.Name = "lblDisplayKey";
            this.lblDisplayKey.Size = new System.Drawing.Size(72, 13);
            this.lblDisplayKey.TabIndex = 2;
            this.lblDisplayKey.Text = "Pressed Key :";
            // 
            // frmShortcutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 80);
            this.Controls.Add(this.lblDisplayKey);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmShortcutForm";
            this.Text = "Assign Shortcut ";
            this.Load += new System.EventHandler(this.frmShortcutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.Label lblDisplayKey;
    }
}