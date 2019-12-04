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
    public partial class How_To_Play : Form
    {

        PictureBox HowToPlay = new PictureBox();
        PictureBox WASD = new PictureBox();
        PictureBox Spacebar = new PictureBox();
        PictureBox move = new PictureBox();
        PictureBox shoot = new PictureBox();
        PictureBox back = new PictureBox();
        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer();
        
        public How_To_Play()
        {
            InitializeComponent();
        }

        private void How_To_Play_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.howtoplaybackground;
            


            HowToPlay.Image = Properties.Resources.how_to_play;
            HowToPlay.SizeMode = PictureBoxSizeMode.StretchImage;
            HowToPlay.BackColor = Color.Transparent;
            HowToPlay.Top = this.ClientSize.Height / 100;
            HowToPlay.Left = this.ClientSize.Width / 3;
            HowToPlay.Width = this.ClientSize.Width / 3;
            HowToPlay.Height = this.ClientSize.Height / 4;

            WASD.Image = Properties.Resources.wasd;
            WASD.SizeMode = PictureBoxSizeMode.StretchImage;
            WASD.BackColor = Color.Transparent;
            WASD.Top = this.ClientSize.Height / 3; 
            WASD.Left = this.ClientSize.Width / 5;
            WASD.Width = this.ClientSize.Width / 4;
            WASD.Height = this.ClientSize.Height / 5;

            Spacebar.Image = Properties.Resources.spacebar;
            Spacebar.SizeMode = PictureBoxSizeMode.StretchImage;
            Spacebar.BackColor = Color.Transparent;
            Spacebar.Top = this.ClientSize.Height / 3; 
            Spacebar.Left = this.ClientSize.Width / 2  + Spacebar.Width;
            Spacebar.Width = this.ClientSize.Width / 4;
            Spacebar.Height = this.ClientSize.Height / 5;

            move.Image = Properties.Resources.move;
            move.SizeMode = PictureBoxSizeMode.StretchImage;
           move.BackColor = Color.Transparent;
            move.Top = this.ClientSize.Height * 55 / 100;
                move.Left= this.ClientSize.Width * 22 / 100;
            move.Width = this.ClientSize.Width / 5;
            move.Height = this.ClientSize.Height / 6;

            shoot.Image = Properties.Resources.shoot;
            shoot.SizeMode = PictureBoxSizeMode.StretchImage;
            shoot.BackColor = Color.Transparent;
            shoot.Top = this.ClientSize.Height * 55/100;
            shoot.Left = this.ClientSize.Width * 60/100;
                shoot.Width = this.ClientSize.Width / 5;
            shoot.Height = this.ClientSize.Height / 6;

            back.Image = Properties.Resources.back;
            back.SizeMode = PictureBoxSizeMode.StretchImage;
            back.BackColor = Color.Transparent;
            back.Top = this.ClientSize.Height - this.ClientSize.Height  * 98 / 100;
            back.Left = this.ClientSize.Width - this.ClientSize.Width * 98 / 100;
            back.Width = this.ClientSize.Width / 7;
            back.Height = this.ClientSize.Height / 8;


            this.Controls.Add(HowToPlay);
            this.Controls.Add(WASD);
            this.Controls.Add(Spacebar);
            this.Controls.Add(move);
            this.Controls.Add(shoot);
            this.Controls.Add(back);


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
