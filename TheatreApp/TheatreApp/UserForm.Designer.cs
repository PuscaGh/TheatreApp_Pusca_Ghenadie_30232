﻿namespace TheatreApp
{
    partial class UserForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewSpectaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.Button();
            this.exportTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSpectaclesToolStripMenuItem,
            this.addTicketToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewSpectaclesToolStripMenuItem
            // 
            this.viewSpectaclesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTicketsToolStripMenuItem});
            this.viewSpectaclesToolStripMenuItem.Name = "viewSpectaclesToolStripMenuItem";
            this.viewSpectaclesToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.viewSpectaclesToolStripMenuItem.Text = "View Spectacles";
            this.viewSpectaclesToolStripMenuItem.Click += new System.EventHandler(this.viewSpectaclesToolStripMenuItem_Click);
            // 
            // addTicketToolStripMenuItem
            // 
            this.addTicketToolStripMenuItem.Name = "addTicketToolStripMenuItem";
            this.addTicketToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.addTicketToolStripMenuItem.Text = "Add Ticket";
            this.addTicketToolStripMenuItem.Click += new System.EventHandler(this.addTicketToolStripMenuItem_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.SystemColors.Control;
            this.Logout.Location = new System.Drawing.Point(506, 0);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // exportTicketsToolStripMenuItem
            // 
            this.exportTicketsToolStripMenuItem.Name = "exportTicketsToolStripMenuItem";
            this.exportTicketsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportTicketsToolStripMenuItem.Text = "Export tickets";
            this.exportTicketsToolStripMenuItem.Click += new System.EventHandler(this.exportTicketsToolStripMenuItem_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(590, 493);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.Text = "User";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewSpectaclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTicketToolStripMenuItem;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.ToolStripMenuItem exportTicketsToolStripMenuItem;
    }
}