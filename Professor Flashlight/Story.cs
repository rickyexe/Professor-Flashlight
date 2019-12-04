using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Professor_Flashlight
{
    public partial class Story : Form
    {
        public Story()
        {
            InitializeComponent();
        }
        Label story1 = new Label();
        Label story2 = new Label();
        Label story3 = new Label();
        Label warning = new Label();

        PictureBox pictureBoxPlayer = new PictureBox();
        PictureBox next = new PictureBox();

        int counter = 0;

        List<PictureBox> listOfLaser = new List<PictureBox>();

        private void Story_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.howtoplaybackground;


            story1.Text = "It's the year 2025\nThere's a smart scientist that invented a flashlight that can shoot laser\nHe test and improve his special flashlight by fighting the crimes.\nSo everybody called him Professor Flashlight since that day\nHe became a hero and save a lot of peoples";
            story1.BackColor = Color.Transparent;
            story1.Top = this.ClientSize.Height - this.ClientSize.Height * 90 / 100;
            story1.Left =0;
            story1.Height = this.ClientSize.Height * 55 / 100;
            story1.Width = this.ClientSize.Width;
            story1.Font = new Font("Bradley", this.ClientSize.Height / 15);
            story1.ForeColor = Color.White;
            story1.TextAlign = ContentAlignment.MiddleCenter;


            pictureBoxPlayer.Top = (this.ClientSize.Height - this.ClientSize.Height * 90 / 100) + story1.Height ;
            pictureBoxPlayer.Left = 0;
            pictureBoxPlayer.Width = this.ClientSize.Width * 5 / 100;
            pictureBoxPlayer.Height = this.ClientSize.Height * 10 / 100;
            pictureBoxPlayer.Image = Properties.Resources.playerRight1;
            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPlayer.BackColor = Color.Transparent;

            this.Controls.Add(pictureBoxPlayer);

          story2.Text = "But one day a zombie outbreak begin\nand\nHe need to protect the city";
            story2.BackColor = Color.Transparent;
            story2.Top = this.ClientSize.Height - this.ClientSize.Height * 90 / 100;
            story2.Left = 0;
            story2.Height = this.ClientSize.Height - this.ClientSize.Height * 55 / 100;
            story2.Width = this.ClientSize.Width;
            story2.Font = new Font("Bradley", this.ClientSize.Height / 15);
            story2.ForeColor = Color.White;
            story2.TextAlign = ContentAlignment.MiddleCenter;

            story3.Text = "He is the legend itself \nPlay as him \nFight till the end \nSave the humanity";
            story3.BackColor = Color.Transparent;
            story3.Top = this.ClientSize.Height - this.ClientSize.Height * 90 / 100;
            story3.Left = 0;
            story3.Height = this.ClientSize.Height - this.ClientSize.Height * 55 / 100;
            story3.Width = this.ClientSize.Width;
            story3.Font = new Font("Bradley", this.ClientSize.Height / 15);
            story3.ForeColor = Color.White;
            story3.TextAlign = ContentAlignment.MiddleCenter;

            next.Image = Properties.Resources.arrow;
            next.SizeMode = PictureBoxSizeMode.StretchImage;
            next.BackColor = Color.Transparent;
            next.Top = this.ClientSize.Height - this.ClientSize.Height * 15/ 100;
            next.Left = this.ClientSize.Width - this.ClientSize.Width * 15 / 100;
            next.Width = this.ClientSize.Width / 7;
            next.Height = this.ClientSize.Height / 8;

            warning.Text = "Press enter to skip";
            warning.BackColor = Color.Transparent;
            warning.Top = this.ClientSize.Height - this.ClientSize.Height * 10/100;
            warning.Left = 0;
            warning.Height = this.ClientSize.Height - this.ClientSize.Height * 55 / 100;
            warning.Width = this.ClientSize.Width - this.ClientSize.Width * 60 / 100;
            warning.Font = new Font("Arial", this.ClientSize.Width / 30);
            warning.ForeColor = Color.White;
            

            this.Controls.Add(story1);
            this.Controls.Add(warning);
            this.Controls.Add(next);

            next.Click += new
            System.EventHandler(next_Click);

            this.KeyDown += new KeyEventHandler(OnKeyDown);


        }
        int jeda = 0;
        int cnt = 0;
        private void timerLaserMove_Tick(object sender, EventArgs e)
        {
            

            if (jeda==0)
            {
                tembakLaserKanan();
            }
            else
            {
                for (int i = 0; i < listOfLaser.Count; i++)
                {
                    listOfLaser[i].Left += (int)listOfLaser[i].Tag;
                }
                if (jeda==25)
                {
                    cnt++;
                    if (cnt==0)
                    {
                        pictureBoxPlayer.Image = Properties.Resources.playerRight1;
                            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else if (cnt==1)
                    {
                        pictureBoxPlayer.Image = Properties.Resources.playerright2;
                        pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else if (cnt == 2)
                    {
                        pictureBoxPlayer.Image = Properties.Resources.playerright3;
                        pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                        cnt = -1;
                    }
                    jeda = -1;
                }
            }
            jeda++;
        }

        private void tembakLaserKanan()
        {

            PictureBox pictureLaser = new PictureBox();
            pictureLaser.Image = Properties.Resources.laserright;
            pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLaser.BackColor = Color.Transparent;


            pictureLaser.Top = pictureBoxPlayer.Top + 30;
            pictureLaser.Left = pictureBoxPlayer.Left + pictureBoxPlayer.Width;
            pictureLaser.Width = 70;
            pictureLaser.Height = 30;
            pictureLaser.Tag = 20;

            listOfLaser.Add(pictureLaser);

            for (int i = 0; i < listOfLaser.Count; i++)
            {
                this.Controls.Add(listOfLaser[i]);
            }
            
           
        }

        private void next_Click(object sender , EventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                story1.Hide();
                story2.Show();
                story3.Hide();
            }
            else if (counter == 2)
            {
                story1.Hide();
                story2.Hide();
                story3.Show();
            }
            else if (counter == 3)
            {
                Mission_Mode missionmode = new Mission_Mode();
                missionmode.Owner = this;
                missionmode.Show();

            }
            this.Controls.Add(story2);
            this.Controls.Add(story3);
        }

         public void OnKeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
             {
                 Mission_Mode missionmode = new Mission_Mode();
                 missionmode.Owner = this;
                 this.Close();
                 missionmode.ShowDialog();
                
             }
        }
    }
}
