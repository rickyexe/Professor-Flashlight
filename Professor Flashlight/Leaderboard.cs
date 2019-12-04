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
using System.IO;


namespace Professor_Flashlight
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }
        PictureBox back = new PictureBox();
        Label leaderboard = new Label();
        Label normalmode = new Label();
        Label survivalmode = new Label();
        Label number1 = new Label();
        Label number2 = new Label();
        Label number3 = new Label();
        Label number4 = new Label();
        Label number5 = new Label();
        Label number1survival = new Label();
        Label number2survival = new Label();
        Label number3survival = new Label();
        Label number4survival = new Label();
        Label number5survival = new Label();

        Label normal1 = new Label();
        Label normal2 = new Label();
        Label normal3 = new Label();
        Label normal4 = new Label();
        Label normal5 = new Label();
        Label survival1 = new Label();
        Label survival2 = new Label();
        Label survival3 = new Label();
        Label survival4 = new Label();
        Label survival5 = new Label();


        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer();

        private void totalSecondToMinutesAndSecond(out int minutes,out int seconds,int totalSecond)
        {
            minutes = totalSecond/60;
            seconds = totalSecond % 60;

        }
        private void Leaderboard_Load(object sender, EventArgs e)
        {

            //meload highscore dari file TXT
            StreamReader sr = new StreamReader(Application.StartupPath + "/Highscore.txt");
            List<int> listOfHighScore = new List<int>();
            //membaca line
            string line = sr.ReadLine();

            //baca sampe akhir
            while (line != null)
            {
                //masukan line ke dalam list
                listOfHighScore.Add(int.Parse(line));
                //lanjut ke line berikutnya
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            listOfHighScore.Sort();
            listOfHighScore.Reverse();

            //UNTUK HIGHSCORE SURVIVAL
            int second=0,minutes=0;
            StreamReader sr2 = new StreamReader(Application.StartupPath + "/HighscoreSurvival.txt");
            List<int> listOfHighScoreSurvival = new List<int>();
            //membaca line
            string line2 = sr2.ReadLine();

            //baca sampe akhir
            while (line2 != null)
            {
                //masukan line ke dalam list
                listOfHighScoreSurvival.Add(int.Parse(line2));
                //lanjut ke line berikutnya
                line2 = sr2.ReadLine();
            }
            //close the file
            sr2.Close();
            listOfHighScoreSurvival.Sort();
            listOfHighScoreSurvival.Reverse();
            
            
            this.BackgroundImage = Properties.Resources.howtoplaybackground;

            leaderboard.Text = "LEADERBOARD";
            leaderboard.BackColor = Color.Transparent;
            leaderboard.Width = this.ClientSize.Width / 2;
            leaderboard.Height = this.ClientSize.Height / 7;
            leaderboard.Top = this.ClientSize.Height / 100;
            leaderboard.Left = this.ClientSize.Width / 2 - (leaderboard.Width / 3);
            leaderboard.Font = new Font("Arial", this.ClientSize.Height / 15);
            leaderboard.ForeColor = Color.White;


            back.Image = Properties.Resources.back;
            back.SizeMode = PictureBoxSizeMode.StretchImage;
            back.BackColor = Color.Transparent;
            back.Top = this.ClientSize.Height - this.ClientSize.Height * 98 / 100;
            back.Left = this.ClientSize.Width - this.ClientSize.Width * 98 / 100;
            back.Width = this.ClientSize.Width / 7;
            back.Height = this.ClientSize.Height / 8;

            normalmode.Text = "NORMAL MODE";
            normalmode.BackColor = Color.Transparent;
            normalmode.Width = this.ClientSize.Width / 3;
            normalmode.Height = this.ClientSize.Height / 4;
            normalmode.Top = this.ClientSize.Height - this.ClientSize.Height * 70 / 100;
            normalmode.Left = this.ClientSize.Width - this.ClientSize.Width * 95 / 100;
             normalmode.Font = new Font("Arial", this.ClientSize.Height / 15);
            normalmode.ForeColor = Color.White;
            normalmode.TextAlign = ContentAlignment.MiddleCenter;

            survivalmode.Text = "SURVIVAL MODE";
            survivalmode.BackColor = Color.Transparent;
            survivalmode.Width = this.ClientSize.Width / 3;
            survivalmode.Height = this.ClientSize.Height / 4;
            survivalmode.Top = this.ClientSize.Height - this.ClientSize.Height * 70 / 100;
            survivalmode.Left = this.ClientSize.Width - this.ClientSize.Width * 52 / 100;
            survivalmode.Font = new Font("Arial", this.ClientSize.Height / 15);
            survivalmode.ForeColor = Color.White;
            survivalmode.TextAlign = ContentAlignment.MiddleCenter;

            number1.Text = "1.";
            number1.BackColor = Color.Transparent;
            number1.Top = this.ClientSize.Height - this.ClientSize.Height * 45 / 100;
            number1.Left = this.ClientSize.Width - this.ClientSize.Width * 90 / 100;
            number1.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number1.Width = this.ClientSize.Width / 11;
            number1.Font = new Font("Arial", this.ClientSize.Height / 25);
            number1.ForeColor = Color.White;

            normal1.Text = listOfHighScore[0].ToString();
            normal1.BackColor = Color.Transparent;
            normal1.Top = this.ClientSize.Height - this.ClientSize.Height * 45 / 100;
            normal1.Left = this.ClientSize.Width - this.ClientSize.Width * 80 / 100;
            normal1.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            normal1.Width = this.ClientSize.Width / 11;
            normal1.Font = new Font("Arial", this.ClientSize.Height / 25);
            normal1.ForeColor = Color.White;


            number1survival.Text = "1.";
            number1survival.BackColor = Color.Transparent;
            number1survival.Top = this.ClientSize.Height - this.ClientSize.Height * 45 / 100;
            number1survival.Left = this.ClientSize.Width - this.ClientSize.Width * 45 / 100;
            number1survival.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number1survival.Width = this.ClientSize.Width / 11;
            number1survival.Font = new Font("Arial", this.ClientSize.Height / 25);
            number1survival.ForeColor = Color.White;

            totalSecondToMinutesAndSecond(out minutes, out second, listOfHighScoreSurvival[0]);
            survival1.Text = minutes + " : " + second;
            survival1.BackColor = Color.Transparent;
            survival1.Top = this.ClientSize.Height - this.ClientSize.Height * 45 / 100;
            survival1.Left = this.ClientSize.Width - this.ClientSize.Width * 35 / 100;
            survival1.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            survival1.Width = this.ClientSize.Width / 11;
            survival1.Font = new Font("Arial", this.ClientSize.Height / 25);
            survival1.ForeColor = Color.White;

            number2.Text = "2.";
            number2.BackColor = Color.Transparent;
            number2.Top = this.ClientSize.Height - this.ClientSize.Height * 38 / 100;
            number2.Left = this.ClientSize.Width - this.ClientSize.Width * 90 / 100;
            number2.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number2.Width = this.ClientSize.Width / 11;
            number2.Font = new Font("Arial", this.ClientSize.Height / 25);
            number2.ForeColor = Color.White;

            normal2.Text = listOfHighScore[1].ToString();
            normal2.BackColor = Color.Transparent;
            normal2.Top = this.ClientSize.Height - this.ClientSize.Height * 38 / 100;
            normal2.Left = this.ClientSize.Width - this.ClientSize.Width * 80 / 100;
            normal2.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            normal2.Width = this.ClientSize.Width / 11;
            normal2.Font = new Font("Arial", this.ClientSize.Height / 25);
            normal2.ForeColor = Color.White;

            number2survival.Text = "2.";
            number2survival.BackColor = Color.Transparent;
            number2survival.Top = this.ClientSize.Height - this.ClientSize.Height * 38 / 100;
            number2survival.Left = this.ClientSize.Width - this.ClientSize.Width * 45 / 100;
            number2survival.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number2survival.Width = this.ClientSize.Width / 11;
            number2survival.Font = new Font("Arial", this.ClientSize.Height / 25);
            number2survival.ForeColor = Color.White;

            totalSecondToMinutesAndSecond(out minutes, out second, listOfHighScoreSurvival[1]);
            survival2.Text = minutes + " : " + second;
            survival2.BackColor = Color.Transparent;
            survival2.Top = this.ClientSize.Height - this.ClientSize.Height * 38 / 100;
            survival2.Left = this.ClientSize.Width - this.ClientSize.Width * 35 / 100;
            survival2.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            survival2.Width = this.ClientSize.Width / 11;
            survival2.Font = new Font("Arial", this.ClientSize.Height / 25);
            survival2.ForeColor = Color.White;



            number3.Text = "3.";
            number3.BackColor = Color.Transparent;
            number3.Top = this.ClientSize.Height - this.ClientSize.Height * 31 / 100;
            number3.Left = this.ClientSize.Width - this.ClientSize.Width * 90 / 100;
            number3.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number3.Width = this.ClientSize.Width / 11;
            number3.Font = new Font("Arial", this.ClientSize.Height / 25);
            number3.ForeColor = Color.White;

            normal3.Text = listOfHighScore[2].ToString();
            normal3.BackColor = Color.Transparent;
            normal3.Top = this.ClientSize.Height - this.ClientSize.Height * 31 / 100;
            normal3.Left = this.ClientSize.Width - this.ClientSize.Width * 80 / 100;
            normal3.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            normal3.Width = this.ClientSize.Width / 11;
            normal3.Font = new Font("Arial", this.ClientSize.Height / 25);
            normal3.ForeColor = Color.White;



            number3survival.Text = "3.";
            number3survival.BackColor = Color.Transparent;
            number3survival.Top = this.ClientSize.Height - this.ClientSize.Height * 31 / 100;
            number3survival.Left = this.ClientSize.Width - this.ClientSize.Width * 45 / 100;
            number3survival.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number3survival.Width = this.ClientSize.Width / 11;
            number3survival.Font = new Font("Arial", this.ClientSize.Height / 25);
            number3survival.ForeColor = Color.White;

            totalSecondToMinutesAndSecond(out minutes, out second, listOfHighScoreSurvival[2]);
            survival3.Text = minutes + " : " + second;
            survival3.BackColor = Color.Transparent;
            survival3.Top = this.ClientSize.Height - this.ClientSize.Height * 31 / 100;
            survival3.Left = this.ClientSize.Width - this.ClientSize.Width * 35 / 100;
            survival3.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            survival3.Width = this.ClientSize.Width / 11;
            survival3.Font = new Font("Arial", this.ClientSize.Height / 25);
            survival3.ForeColor = Color.White;

            number4.Text = "4.";
            number4.BackColor = Color.Transparent;
            number4.Top = this.ClientSize.Height - this.ClientSize.Height * 24 / 100;
            number4.Left = this.ClientSize.Width - this.ClientSize.Width * 90 / 100;
            number4.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number4.Width = this.ClientSize.Width / 11;
            number4.Font = new Font("Arial", this.ClientSize.Height / 25);
            number4.ForeColor = Color.White;

            normal4.Text = listOfHighScore[4].ToString();
            normal4.BackColor = Color.Transparent;
            normal4.Top = this.ClientSize.Height - this.ClientSize.Height * 24 / 100;
            normal4.Left = this.ClientSize.Width - this.ClientSize.Width * 80 / 100;
            normal4.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            normal4.Width = this.ClientSize.Width / 11;
            normal4.Font = new Font("Arial", this.ClientSize.Height / 25);
            normal4.ForeColor = Color.White;



            number4survival.Text = "4.";
            number4survival.BackColor = Color.Transparent;
            number4survival.Top = this.ClientSize.Height - this.ClientSize.Height * 24 / 100;
            number4survival.Left = this.ClientSize.Width - this.ClientSize.Width * 45 / 100;
            number4survival.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number4survival.Width = this.ClientSize.Width / 11;
            number4survival.Font = new Font("Arial", this.ClientSize.Height / 25);
            number4survival.ForeColor = Color.White;

            totalSecondToMinutesAndSecond(out minutes, out second, listOfHighScoreSurvival[3]);
            survival4.Text = minutes + " : " + second;
            survival4.BackColor = Color.Transparent;
            survival4.Top = this.ClientSize.Height - this.ClientSize.Height * 24 / 100;
            survival4.Left = this.ClientSize.Width - this.ClientSize.Width * 35 / 100;
            survival4.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            survival4.Width = this.ClientSize.Width / 11;
            survival4.Font = new Font("Arial", this.ClientSize.Height / 25);
            survival4.ForeColor = Color.White;

            number5.Text = "5.";
            number5.BackColor = Color.Transparent;
            number5.Top = this.ClientSize.Height - this.ClientSize.Height * 17 / 100;
            number5.Left = this.ClientSize.Width - this.ClientSize.Width * 90 / 100;
            number5.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number5.Width = this.ClientSize.Width / 11;
            number5.Font = new Font("Arial", this.ClientSize.Height / 25);
            number5.ForeColor = Color.White;

            normal5.Text = listOfHighScore[4].ToString();
            normal5.BackColor = Color.Transparent;
            normal5.Top = this.ClientSize.Height - this.ClientSize.Height * 17 / 100;
            normal5.Left = this.ClientSize.Width - this.ClientSize.Width * 80 / 100;
            normal5.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            normal5.Width = this.ClientSize.Width / 11;
            normal5.Font = new Font("Arial", this.ClientSize.Height / 25);
            normal5.ForeColor = Color.White;



            number5survival.Text = "5.";
            number5survival.BackColor = Color.Transparent;
            number5survival.Top = this.ClientSize.Height - this.ClientSize.Height * 17 / 100;
            number5survival.Left = this.ClientSize.Width - this.ClientSize.Width * 45 / 100;
            number5survival.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            number5survival.Width = this.ClientSize.Width / 11;
            number5survival.Font = new Font("Arial", this.ClientSize.Height / 25);
            number5survival.ForeColor = Color.White;

            totalSecondToMinutesAndSecond(out minutes, out second, listOfHighScoreSurvival[4]);
            survival5.Text = minutes + " : " + second;
            survival5.BackColor = Color.Transparent;
            survival5.Top = this.ClientSize.Height - this.ClientSize.Height * 17 / 100;
            survival5.Left = this.ClientSize.Width - this.ClientSize.Width * 35 / 100;
            survival5.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            survival5.Width = this.ClientSize.Width / 11;
            survival5.Font = new Font("Arial", this.ClientSize.Height / 25);
            survival5.ForeColor = Color.White;
            


            this.Controls.Add(number1);
            this.Controls.Add(number1survival);
            this.Controls.Add(normal1);
            this.Controls.Add(survival1);
            this.Controls.Add(number2);
            this.Controls.Add(number2survival);
            this.Controls.Add(normal2);
            this.Controls.Add(survival2);
            this.Controls.Add(number3);
            this.Controls.Add(number3survival);
            this.Controls.Add(normal3);
            this.Controls.Add(survival3);
            this.Controls.Add(number4);
            this.Controls.Add(number4survival);
            this.Controls.Add(normal4);
            this.Controls.Add(survival4);
            this.Controls.Add(number5);
            this.Controls.Add(number5survival);
            this.Controls.Add(normal5);
            this.Controls.Add(survival5);
            this.Controls.Add(leaderboard);
            this.Controls.Add(back);
            this.Controls.Add(normalmode);
            this.Controls.Add(survivalmode);

            back.Click += new
          System.EventHandler(back_Click);

        }

        private void back_Click(object sender , EventArgs e)
        {
            normalsound.URL = resourcesPath + "select.mp3";
            this.Close();
            this.Dispose();
        }
    }

}
