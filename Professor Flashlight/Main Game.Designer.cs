namespace Professor_Flashlight
{
    partial class Form1
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
            this.timerEnemy1Generator = new System.Windows.Forms.Timer(this.components);
            this.timerEnemy2Generator = new System.Windows.Forms.Timer(this.components);
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.timerLaserMove = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerEnemy1Generator
            // 
            this.timerEnemy1Generator.Enabled = true;
            this.timerEnemy1Generator.Interval = 4500;
            this.timerEnemy1Generator.Tick += new System.EventHandler(this.timerEnemy1Generator_Tick);
            // 
            // timerEnemy2Generator
            // 
            this.timerEnemy2Generator.Enabled = true;
            this.timerEnemy2Generator.Interval = 4000;
            this.timerEnemy2Generator.Tick += new System.EventHandler(this.timerEnemy2Generator_Tick);
            // 
            // timerGame
            // 
            this.timerGame.Enabled = true;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // timerLaserMove
            // 
            this.timerLaserMove.Interval = 5;
            this.timerLaserMove.Tick += new System.EventHandler(this.timerLaserMove_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(481, 377);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerEnemy1Generator;
        private System.Windows.Forms.Timer timerEnemy2Generator;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Timer timerLaserMove;
    }
}

