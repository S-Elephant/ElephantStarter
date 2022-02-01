namespace ElephantStarter.UI
{
    partial class AppButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnMain
            // 
            this.BtnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnMain.Location = new System.Drawing.Point(0, 0);
            this.BtnMain.Name = "BtnMain";
            this.BtnMain.Size = new System.Drawing.Size(150, 150);
            this.BtnMain.TabIndex = 0;
            this.BtnMain.Text = "button1";
            this.BtnMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMain.UseVisualStyleBackColor = true;
            // 
            // AppButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnMain);
            this.Name = "AppButton";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnMain;
    }
}
