namespace TheatreApp
{
    partial class AdminForm
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
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSpectaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSpectacleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSpectacleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataSource = typeof(Models.User.userRole);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.Control;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.spectaclesToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(559, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "MenuBar";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEmployeeToolStripMenuItem,
            this.viewEmployeesToolStripMenuItem});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // addNewEmployeeToolStripMenuItem
            // 
            this.addNewEmployeeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addNewEmployeeToolStripMenuItem.Name = "addNewEmployeeToolStripMenuItem";
            this.addNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addNewEmployeeToolStripMenuItem.Text = "Add new employee";
            this.addNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addNewEmployeeToolStripMenuItem_Click);
            // 
            // viewEmployeesToolStripMenuItem
            // 
            this.viewEmployeesToolStripMenuItem.Name = "viewEmployeesToolStripMenuItem";
            this.viewEmployeesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.viewEmployeesToolStripMenuItem.Text = "View employees";
            this.viewEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewEmployeesToolStripMenuItem_Click);
            // 
            // spectaclesToolStripMenuItem
            // 
            this.spectaclesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSpectaclesToolStripMenuItem,
            this.addNewSpectacleToolStripMenuItem,
            this.deleteSpectacleToolStripMenuItem});
            this.spectaclesToolStripMenuItem.Name = "spectaclesToolStripMenuItem";
            this.spectaclesToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.spectaclesToolStripMenuItem.Text = "Spectacles";
            // 
            // viewSpectaclesToolStripMenuItem
            // 
            this.viewSpectaclesToolStripMenuItem.Name = "viewSpectaclesToolStripMenuItem";
            this.viewSpectaclesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.viewSpectaclesToolStripMenuItem.Text = "View spectacles";
            this.viewSpectaclesToolStripMenuItem.Click += new System.EventHandler(this.viewSpectaclesToolStripMenuItem_Click);
            // 
            // addNewSpectacleToolStripMenuItem
            // 
            this.addNewSpectacleToolStripMenuItem.Name = "addNewSpectacleToolStripMenuItem";
            this.addNewSpectacleToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addNewSpectacleToolStripMenuItem.Text = "Add new spectacle";
            this.addNewSpectacleToolStripMenuItem.Click += new System.EventHandler(this.addNewSpectacleToolStripMenuItem_Click);
            // 
            // deleteSpectacleToolStripMenuItem
            // 
            this.deleteSpectacleToolStripMenuItem.Name = "deleteSpectacleToolStripMenuItem";
            this.deleteSpectacleToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteSpectacleToolStripMenuItem.Text = "Delete spectacle";
            this.deleteSpectacleToolStripMenuItem.Click += new System.EventHandler(this.deleteSpectacleToolStripMenuItem_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.SystemColors.Control;
            this.Logout.Location = new System.Drawing.Point(472, 0);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(559, 559);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "AdminForm";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource userRoleBindingSource;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectaclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSpectaclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSpectacleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSpectacleToolStripMenuItem;
        private System.Windows.Forms.Button Logout;
    }
}