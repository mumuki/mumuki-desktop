namespace MumukiLoader
{
    partial class LoaderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaderForm));
			this.lblPleaseWait = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.txtShell = new System.Windows.Forms.TextBox();
			this.prgProgress = new System.Windows.Forms.ProgressBar();
			this.tmrFakeProgress = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// lblPleaseWait
			// 
			this.lblPleaseWait.AutoSize = true;
			this.lblPleaseWait.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPleaseWait.Location = new System.Drawing.Point(12, 9);
			this.lblPleaseWait.Name = "lblPleaseWait";
			this.lblPleaseWait.Size = new System.Drawing.Size(0, 16);
			this.lblPleaseWait.TabIndex = 0;
			// 
			// lblState
			// 
			this.lblState.Location = new System.Drawing.Point(13, 54);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(458, 17);
			this.lblState.TabIndex = 1;
			// 
			// txtShell
			// 
			this.txtShell.BackColor = System.Drawing.Color.Black;
			this.txtShell.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtShell.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShell.ForeColor = System.Drawing.Color.LightGray;
			this.txtShell.Location = new System.Drawing.Point(16, 74);
			this.txtShell.Multiline = true;
			this.txtShell.Name = "txtShell";
			this.txtShell.ReadOnly = true;
			this.txtShell.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtShell.Size = new System.Drawing.Size(455, 132);
			this.txtShell.TabIndex = 3;
			this.txtShell.TextChanged += new System.EventHandler(this.txtShell_TextChanged);
			// 
			// prgProgress
			// 
			this.prgProgress.Location = new System.Drawing.Point(15, 28);
			this.prgProgress.Name = "prgProgress";
			this.prgProgress.Size = new System.Drawing.Size(456, 23);
			this.prgProgress.TabIndex = 2;
			// 
			// tmrFakeProgress
			// 
			this.tmrFakeProgress.Enabled = true;
			this.tmrFakeProgress.Tick += new System.EventHandler(this.tmrFakeProgress_Tick);
			// 
			// LoaderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 218);
			this.Controls.Add(this.txtShell);
			this.Controls.Add(this.prgProgress);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.lblPleaseWait);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoaderForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mumuki";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoaderForm_FormClosing);
			this.Shown += new System.EventHandler(this.LoaderForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lblPleaseWait;
		private System.Windows.Forms.Label lblState;
		private System.Windows.Forms.TextBox txtShell;
		private System.Windows.Forms.ProgressBar prgProgress;
		private System.Windows.Forms.Timer tmrFakeProgress;
	}
}

