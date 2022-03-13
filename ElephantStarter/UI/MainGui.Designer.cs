namespace ElephantStarter.UI
{
    partial class MainGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGui));
            this.NiSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.CmsSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpenSettings = new System.Windows.Forms.Button();
            this.BtnConfigureStartup = new System.Windows.Forms.Button();
            this.BtnOpenShortcutsFolder = new System.Windows.Forms.Button();
            this.BtnRestartThisApplication = new System.Windows.Forms.Button();
            this.ButtonTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // NiSystemTray
            // 
            this.NiSystemTray.ContextMenuStrip = this.CmsSystemTray;
            this.NiSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiSystemTray.Icon")));
            this.NiSystemTray.Text = "notifyIcon1";
            this.NiSystemTray.Visible = true;
            // 
            // CmsSystemTray
            // 
            this.CmsSystemTray.Name = "contextMenuStrip1";
            this.CmsSystemTray.Size = new System.Drawing.Size(61, 4);
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.ColumnCount = 11;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.Location = new System.Drawing.Point(12, 31);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 10;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(935, 850);
            this.TableLayoutPanel.TabIndex = 2;
            // 
            // BtnOpenSettings
            // 
            this.BtnOpenSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnOpenSettings.Location = new System.Drawing.Point(12, 2);
            this.BtnOpenSettings.Name = "BtnOpenSettings";
            this.BtnOpenSettings.Size = new System.Drawing.Size(31, 23);
            this.BtnOpenSettings.TabIndex = 3;
            this.ButtonTooltip.SetToolTip(this.BtnOpenSettings, "Open settings file");
            this.BtnOpenSettings.UseVisualStyleBackColor = true;
            this.BtnOpenSettings.Click += new System.EventHandler(this.BtnOpenSettings_Click);
            // 
            // BtnConfigureStartup
            // 
            this.BtnConfigureStartup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnConfigureStartup.Location = new System.Drawing.Point(49, 2);
            this.BtnConfigureStartup.Name = "BtnConfigureStartup";
            this.BtnConfigureStartup.Size = new System.Drawing.Size(31, 23);
            this.BtnConfigureStartup.TabIndex = 4;
            this.ButtonTooltip.SetToolTip(this.BtnConfigureStartup, "Apply autostart setting");
            this.BtnConfigureStartup.UseVisualStyleBackColor = true;
            this.BtnConfigureStartup.Click += new System.EventHandler(this.BtnConfigureStartup_Click);
            // 
            // BtnOpenShortcutsFolder
            // 
            this.BtnOpenShortcutsFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnOpenShortcutsFolder.Location = new System.Drawing.Point(86, 2);
            this.BtnOpenShortcutsFolder.Name = "BtnOpenShortcutsFolder";
            this.BtnOpenShortcutsFolder.Size = new System.Drawing.Size(31, 23);
            this.BtnOpenShortcutsFolder.TabIndex = 5;
            this.ButtonTooltip.SetToolTip(this.BtnOpenShortcutsFolder, "Open shortcuts folder");
            this.BtnOpenShortcutsFolder.UseVisualStyleBackColor = true;
            this.BtnOpenShortcutsFolder.Click += new System.EventHandler(this.BtnOpenShortcutsFolder_Click);
            // 
            // BtnRestartThisApplication
            // 
            this.BtnRestartThisApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRestartThisApplication.Location = new System.Drawing.Point(123, 2);
            this.BtnRestartThisApplication.Name = "BtnRestartThisApplication";
            this.BtnRestartThisApplication.Size = new System.Drawing.Size(31, 23);
            this.BtnRestartThisApplication.TabIndex = 6;
            this.ButtonTooltip.SetToolTip(this.BtnRestartThisApplication, "Restart this application");
            this.BtnRestartThisApplication.UseVisualStyleBackColor = true;
            this.BtnRestartThisApplication.Click += new System.EventHandler(this.BtnRestartThisApplication_Click);
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(980, 661);
            this.Controls.Add(this.BtnRestartThisApplication);
            this.Controls.Add(this.BtnOpenShortcutsFolder);
            this.Controls.Add(this.BtnConfigureStartup);
            this.Controls.Add(this.BtnOpenSettings);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainGui";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elephant Starter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainGui_Load);
            this.Resize += new System.EventHandler(this.MainGui_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon NiSystemTray;
        private ContextMenuStrip CmsSystemTray;
        private TableLayoutPanel TableLayoutPanel;
        private Button BtnOpenSettings;
		private Button BtnConfigureStartup;
		private Button BtnOpenShortcutsFolder;
		private Button BtnRestartThisApplication;
		private ToolTip ButtonTooltip;
	}
}