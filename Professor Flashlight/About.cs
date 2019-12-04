using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace Professor_Flashlight
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        PictureBox developed = new PictureBox();
        PictureBox back = new PictureBox();
        PictureBox ricky = new PictureBox();
        PictureBox tony = new PictureBox();
        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer();

        private void About_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.howtoplaybackground;
            

            developed.Image = Properties.Resources.developed;
            developed.SizeMode = PictureBoxSizeMode.StretchImage;
            developed.BackColor = Color.Transparent;
            developed.Top = this.ClientSize.Height / 100;
            developed.Left = this.ClientSize.Width / 3;
            developed.Width = this.ClientSize.Width / 3;
            developed.Height = this.ClientSize.Height / 4;

            back.Image = Properties.Resources.back;
            back.SizeMode = PictureBoxSizeMode.StretchImage;
            back.BackColor = Color.Transparent;
            back.Top = this.ClientSize.Height - this.ClientSize.Height * 98 / 100;
            back.Left = this.ClientSize.Width - this.ClientSize.Width  * 98/ 100;
            back.Width = this.ClientSize.Width / 7;
            back.Height = this.ClientSize.Height / 8;

            ricky.Image = Properties.Resources.ricky;
            ricky.SizeMode = PictureBoxSizeMode.StretchImage;
            ricky.BackColor = Color.Transparent;
            ricky.Top = this.ClientSize.Height - this.ClientSize.Height * 70 / 100;
            ricky.Left = this.ClientSize.Width - this.ClientSize.Width * 75 / 100;
            ricky.Width = this.ClientSize.Width / 2;
            ricky.Height = this.ClientSize.Height / 3;


            tony.Image = Properties.Resources.tony;
            tony.SizeMode = PictureBoxSizeMode.StretchImage;
            tony.BackColor = Color.Transparent;
            tony.Top = this.ClientSize.Height - this.ClientSize.Height * 42 / 100;
            tony.Left = this.ClientSize.Width - this.ClientSize.Width * 75 / 100;
            tony.Width = this.ClientSize.Width / 2;
            tony.Height = this.ClientSize.Height / 3;

            this.Controls.Add(developed);
            this.Controls.Add(back);
            this.Controls.Add(ricky);
            this.Controls.Add(tony);

            back.Click += new
            System.EventHandler(back_Click);

        }

        private void back_Click(object sender, EventArgs e)
        {
            normalsound.URL = resourcesPath + "select.mp3";
            this.Close();
            this.Dispose();
        }
        
    }
}
