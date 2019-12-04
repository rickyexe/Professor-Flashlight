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
    public partial class Main_Menu : Form
    {
        PictureBox Title = new PictureBox();

        
        Label NewGame = new Label();
        Label HowToPlay = new Label();
        Label About = new Label();
        Label Exit = new Label();
        Label leaderboard = new Label();

       
        public Main_Menu()
        {
            InitializeComponent();
        }
        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer();
        WindowsMediaPlayer clicksound = new WindowsMediaPlayer();


        private void Main_Menu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.back1;
            normalsound.URL = resourcesPath + "creepymusic.mp3";
            normalsound.settings.setMode("loop", true);

            Title.Image = Properties.Resources.title;
            Title.SizeMode = PictureBoxSizeMode.StretchImage;
            Title.BackColor = Color.Transparent;
            Title.Width = this.ClientSize.Width / 2;
            Title.Height = this.ClientSize.Height / 3;
            Title.Top = this.ClientSize.Height /2 - Title.Height;
            Title.Left = 0;

     

            NewGame.Text = "NEW GAME";
            NewGame.BackColor = Color.Transparent;
            NewGame.Top = this.ClientSize.Height / 2 + this.ClientSize.Height/15;
            NewGame.Left = 0;
            NewGame.Height = this.ClientSize.Height/ 20;
            NewGame.Width = (this.ClientSize.Width / 10) + this.ClientSize.Width * NewGame.Text.Length / 70;
            NewGame.Font = new Font("Arial", this.ClientSize.Height / 25);
            NewGame.ForeColor = Color.White;

            HowToPlay.Text = "HOW TO PLAY";
            HowToPlay.BackColor = Color.Transparent;
            HowToPlay.Top = (this.ClientSize.Height / 2 + this.ClientSize.Height / 15) + NewGame.Height;
            HowToPlay.Left = 0;
            HowToPlay.Height = this.ClientSize.Height / 20;
            HowToPlay.Width = (this.ClientSize.Width / 10) + this.ClientSize.Width * HowToPlay.Text.Length / 70;
            HowToPlay.Font = new Font("Arial", this.ClientSize.Height / 25);
            HowToPlay.ForeColor = Color.White;

            About.Text = "ABOUT";
            About.BackColor = Color.Transparent;
            About.Top = (this.ClientSize.Height / 2 + this.ClientSize.Height / 15) + HowToPlay.Height + NewGame.Height;
            About.Left = 0;
            About.Height = this.ClientSize.Height / 20;
            About.Width = (this.ClientSize.Width / 10) + this.ClientSize.Width * About.Text.Length / 70;
            About.Font = new Font("Arial", this.ClientSize.Height / 25);
            About.ForeColor = Color.White;

            leaderboard.Text = "LEADERBOARD";
            leaderboard.BackColor = Color.Transparent;
            leaderboard.Top = (this.ClientSize.Height / 2 + this.ClientSize.Height / 15) + About.Height + HowToPlay.Height + NewGame.Height;
            leaderboard.Left = 0;
            leaderboard.Height = this.ClientSize.Height / 20;
            leaderboard.Width = (this.ClientSize.Width / 10) + this.ClientSize.Width * leaderboard.Text.Length / 70;
            leaderboard.Font = new Font("Arial", this.ClientSize.Height / 25);
            leaderboard.ForeColor = Color.White;

            Exit.Text = "EXIT";
            Exit.BackColor = Color.Transparent;
            Exit.Top = (this.ClientSize.Height / 2 + this.ClientSize.Height / 15) + About.Height + HowToPlay.Height + NewGame.Height + leaderboard.Height;
            Exit.Left = 0;
            Exit.Height = this.ClientSize.Height / 20;
            Exit.Width = (this.ClientSize.Width / 10) + this.ClientSize.Width * Exit.Text.Length / 70;
            Exit.Font = new Font("Arial", this.ClientSize.Height / 25);
            Exit.ForeColor = Color.White;


            this.Controls.Add(Title);
            this.Controls.Add(NewGame);
            this.Controls.Add(HowToPlay);
            this.Controls.Add(About);
            this.Controls.Add(Exit);
            this.Controls.Add(leaderboard);
            

            NewGame.Click += new
            System.EventHandler(NewGame_Click);

            HowToPlay.Click += new
                System.EventHandler(HowToPlay_Click);

            About.Click += new
                System.EventHandler(About_Click);

            Exit.Click += new
                System.EventHandler(Exit_Click);

            leaderboard.Click += new
            System.EventHandler(Leaderboard_Click);
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            clicksound.URL = resourcesPath + "select.mp3";
            ModeSelect modeselect = new ModeSelect();
            modeselect.Owner = this;
            modeselect.ShowDialog();
            
            
            
                 
        }

        private void Exit_Click(object sender , EventArgs e)
        {
            clicksound.URL = resourcesPath + "select.mp3";
            DialogResult dialogResult = MessageBox.Show("Exit The Game?", "Attention", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
                
        }

        private void HowToPlay_Click(object sender , EventArgs e)
        {
            clicksound.URL = resourcesPath + "select.mp3";
            How_To_Play howtoplay = new How_To_Play();
            howtoplay.Owner = this;
            howtoplay.Show();
           
            

        }

        private void About_Click(object sender, EventArgs e)
        {
            clicksound.URL = resourcesPath + "select.mp3";
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
           
        
        }

        private void Leaderboard_Click(object sender , EventArgs e)
        {
            clicksound.URL = resourcesPath + "select.mp3";
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Owner = this;
            leaderboard.Show();
        }
    }
}
