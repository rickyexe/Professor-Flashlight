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
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        PictureBox pictureBoxPlayer = new PictureBox();
        PictureBox pictureSavior = new PictureBox();
        PictureBox pictureBoxlaser = new PictureBox();
        PictureBox listofheart = new PictureBox();
        List<PictureBox> listOfEnemy1 = new List<PictureBox>();
        List<PictureBox> listOfEnemy2 = new List<PictureBox>();
        PictureBox pictureBoom = new PictureBox();
        PictureBox pause = new PictureBox();
      


        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer();

        Label titikdua = new Label();
        Label score = new Label();
        Label labelSeconds = new Label();
        Label labelMinutes = new Label();
        Label point = new Label();
               
        int life = 3;
        int pointscore = 0;
        int cntForMove = 0;
        int cntSaviorMove = 0;
        int cnt = 0;
        int cntHero = 0;
        int jedaBelokSuvivor = 0;
        int seconds = 0;
        int minutes=0;
        int counterForSeconds = 0;
        int counter = 0;
        int cntBoom = 0;

        bool atas = false, bawah = true, kiri = false, kanan = false;
        bool canShoot = true;
        bool saviorOnScreen = false;
        bool horison = false;
        bool invisible = false;
        bool boomOnScreen = false;
        bool berhenti = false;
        bool laserOnScreen = false;
        bool kalah = true;

        string directionShoot = "";
        string directionSavior = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.parkbackground;

            imageMoveDown();

            makePlayer1();
             
            
            score.Text = "Score";
            score.BackColor = Color.Transparent;
            score.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            score.Left = this.ClientSize.Width / 3;
            score.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            score.Width = this.ClientSize.Width / 11;
            score.Font = new Font("Arial", 30);
            score.ForeColor = Color.White;
            this.Controls.Add(score);

            
            labelMinutes.Text = "00";
            labelMinutes.BackColor = Color.Transparent;
            labelMinutes.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            labelMinutes.Left = this.ClientSize.Width - this.ClientSize.Width * 41 / 100;
            labelMinutes.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            labelMinutes.Width = this.ClientSize.Width / 30;
            labelMinutes.Font = new Font("Arial", 30);
            labelMinutes.ForeColor = Color.White;
            this.Controls.Add(labelMinutes);

            
            labelSeconds.Text = "00";
            labelSeconds.BackColor = Color.Transparent;
            labelSeconds.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            labelSeconds.Left = this.ClientSize.Width - this.ClientSize.Width * 36 / 100;
            labelSeconds.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            labelSeconds.Width = this.ClientSize.Width / 30;
            labelSeconds.Font = new Font("Arial", 30);
            labelSeconds.ForeColor = Color.White;
            this.Controls.Add(labelSeconds);

            
            titikdua.Text = ":";
            titikdua.BackColor = Color.Transparent;
            titikdua.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            titikdua.Left = this.ClientSize.Width - this.ClientSize.Width * 38 / 100;
            titikdua.Height = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            titikdua.Width = this.ClientSize.Width / 11;
            titikdua.Font = new Font("Arial", 30);
            titikdua.ForeColor = Color.White;
            this.Controls.Add(titikdua);

            point.Text =  pointscore.ToString();
            point.BackColor = Color.Transparent;
            point.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            point.Left = this.ClientSize.Width - this.ClientSize.Width * 55/100;
            point.Height = this.ClientSize.Height - this.ClientSize.Height * 90 / 100;
            point.Width = this.ClientSize.Width / 3;
            point.Font = new Font("Arial", 30);
            point.BackColor = Color.Transparent;
            point.ForeColor = Color.White;
            
            
            listofheart.Image = Properties.Resources._3_life;
            listofheart.Top = this.ClientSize.Height - this.ClientSize.Height * 95 / 100;
            listofheart.Left = this.ClientSize.Width / 5;
            listofheart.Height = this.ClientSize.Height - this.ClientSize.Height * 90 / 100;
            listofheart.Width = this.ClientSize.Width / 4;
            listofheart.BackColor = Color.Transparent;

            pause.Image = Properties.Resources.pause;
            pause.SizeMode = PictureBoxSizeMode.StretchImage;
            pause.Top = 0;
            pause.Left = 0;
            pause.Width = this.ClientSize.Width / 12;
            pause.Height = this.ClientSize.Height / 7;
            pause.BackColor = Color.Transparent;

            
            this.Controls.Add(listofheart);
            this.Controls.Add(point);
            this.Controls.Add(pictureBoxPlayer);
            this.Controls.Add(pause);
       
                

            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.DoubleBuffered = true;

            pause.Click += new
             System.EventHandler(pause_Click);

          


        }
        private void exit_Click(object sender , EventArgs e)
        {
            DialogResult userSelected = MessageBox.Show("Are You Sure", "Warning", MessageBoxButtons.YesNo);

            if (userSelected == DialogResult.Yes)
            {
                Main_Menu mainmenu = new Main_Menu();
                mainmenu.Owner = this;
                mainmenu.Show();
                this.Close();
                this.Dispose();
            }


        }

        private void pause_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                timerEnemy1Generator.Enabled = false;
                timerEnemy2Generator.Enabled = false;
                timerLaserMove.Enabled = false;
                timerGame.Enabled = false;
                canShoot = false;
                berhenti = true;
                pause.Image = Properties.Resources.play;
                DialogResult userselected = MessageBox.Show("Quit Game?", "Attention", MessageBoxButtons.YesNo);

                if (userselected == DialogResult.Yes)
                {
                    this.Close();

                }
                else if (userselected == DialogResult.No)
                {
                    timerEnemy1Generator.Enabled = true;
                    timerEnemy2Generator.Enabled = true;
                    timerLaserMove.Enabled = true;
                    timerGame.Enabled = true;
                    if (laserOnScreen == false)
                    {
                        canShoot = true;
                    }
                    else
                    {
                        canShoot = false;
                    }

                    berhenti = false;
                    pause.Image = Properties.Resources.pause;



                }
                counter = 0;

            }
        }
        
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (berhenti == false)
            {
                if (e.KeyCode == Keys.W)
                {
                    if (pictureBoxPlayer.Top > this.ClientSize.Height * 20 / 100)
                    {
                        pictureBoxPlayer.Top -= (int)pictureBoxPlayer.Tag;
                        atas = true;
                        bawah = false;
                        kiri = false;
                        kanan = false;
                        imageMoveUp();

                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (pictureBoxPlayer.Left > 0)
                    {
                        pictureBoxPlayer.Left -= (int)pictureBoxPlayer.Tag;
                        atas = false;
                        bawah = false;
                        kiri = true;
                        kanan = false;
                        imageMoveLeft();
                    }

                }
                else if (e.KeyCode == Keys.S)
                {
                    if (pictureBoxPlayer.Top < this.ClientSize.Height - 100)
                    {
                        pictureBoxPlayer.Top += (int)pictureBoxPlayer.Tag;
                        atas = false;
                        bawah = true;
                        kiri = false;
                        kanan = false;
                        imageMoveDown();
                    }
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (pictureBoxPlayer.Left < this.ClientSize.Width - 70)
                    {
                        pictureBoxPlayer.Left += (int)pictureBoxPlayer.Tag;
                        atas = false;
                        bawah = false;
                        kiri = false;
                        kanan = true;
                        imageMoveRight();
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    normalsound.URL = resourcesPath + "laser.mp3";

                    if (atas == true)
                    {
                        timerLaserMove.Enabled = true;
                        tembakLaserAtas();
                    }
                    else if (bawah == true)
                    {
                        timerLaserMove.Enabled = true;
                        tembakLaserBawah();
                    }
                    else if (kanan == true)
                    {
                        timerLaserMove.Enabled = true;
                        tembakLaserKanan();
                    }
                    else if (kiri == true)
                    {
                        timerLaserMove.Enabled = true;
                        tembakLaserKiri();
                    }
                }

                //player ambil item
                if (boomOnScreen == true)
                {
                    //item boom digunakan
                    if (pictureBoxPlayer.Bounds.IntersectsWith(pictureBoom.Bounds))
                    {
                        normalsound.URL = resourcesPath + "explosion.mp3";

                        for (int i = 0; i < listOfEnemy1.Count; i++)
                        {
                            listOfEnemy1[i].Dispose();
                            listOfEnemy1.RemoveAt(i);

                            timerEnemy1Generator.Enabled = true;
                            pointscore += 100;
                            loadImageScore();
                            this.Refresh();
                        }
                        for (int i = 0; i < listOfEnemy2.Count; i++)
                        {
                            listOfEnemy2[i].Dispose();
                            listOfEnemy2.RemoveAt(i);

                            timerEnemy2Generator.Enabled = true;
                            pointscore += 100;
                            loadImageScore();
                            this.Refresh();
                        }
                        this.Controls.Remove(pictureBoom);
                        
                        boomOnScreen = false;
                        cntBoom = 0;
                        this.Refresh();

                    }
                }
            }
           
        }
        

        private void timerEnemy1Generator_Tick(object sender, EventArgs e)
        {
            PictureBox pictureEnemy1 = new PictureBox();
            pictureEnemy1.Image = Properties.Resources.enemyleft1;
            pictureEnemy1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureEnemy1.BackColor = Color.Transparent;
           
            pictureEnemy1.Top = (rnd.Next(0, 8) * (this.ClientSize.Height * 10 / 100)) + (this.ClientSize.Height * 20 / 100);
            pictureEnemy1.Left = this.ClientSize.Width + 70;
            pictureEnemy1.Width = this.ClientSize.Width * 5 / 100;
            pictureEnemy1.Height = this.ClientSize.Height * 10 / 100;
            pictureEnemy1.Tag = 0;

            listOfEnemy1.Add(pictureEnemy1);
            this.Controls.Add(pictureEnemy1);

            if (listOfEnemy1.Count > 3)
            {
                timerEnemy1Generator.Enabled = false;
            }
        }

        private void timerEnemy2Generator_Tick(object sender, EventArgs e)
        {
            PictureBox pictureEnemy2 = new PictureBox();
            pictureEnemy2.Image = Properties.Resources.enemyright1;
            pictureEnemy2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureEnemy2.BackColor = Color.Transparent;
          
            pictureEnemy2.Top = (rnd.Next(0, 8) * (this.ClientSize.Height * 10 / 100)) + (this.ClientSize.Height * 20 / 100);
            pictureEnemy2.Left = -this.ClientSize.Width * 5 / 100;
            pictureEnemy2.Width = this.ClientSize.Width * 5 / 100;
            pictureEnemy2.Height = this.ClientSize.Height * 10 / 100;
            pictureEnemy2.Tag = 0;

            listOfEnemy2.Add(pictureEnemy2);
            this.Controls.Add(pictureEnemy2);

            if (listOfEnemy2.Count > 3)
            {
                timerEnemy1Generator.Enabled = false;
            }
        }
       
        private void timerGame_Tick(object sender, EventArgs e)
        {
            counterForSeconds++;
            if (counterForSeconds==10)
            {
                counterForSeconds = 0;
                seconds++;
                if (seconds==60)
                {
                    seconds = 0;
                    minutes++;

                    labelMinutes.Text = minutes.ToString();
                }
                labelSeconds.Text = seconds.ToString();
                this.Refresh();
            }


            if (invisible==true)
            {
                cntHero++;
                if (cntHero>10){
                    cntHero = 0;
                    invisible = false;
                }
                
            }
            cnt++;
            cntBoom++;
            int itemRespawn = rnd.Next(30) + 1;
            if (cntBoom>60)
            {
                if ( boomOnScreen==false)
                {
                    if (itemRespawn == 1 || itemRespawn == 2|| itemRespawn == 3 || itemRespawn == 4 || itemRespawn == 5 || itemRespawn == 6
                        || itemRespawn == 7 || itemRespawn == 8 || itemRespawn == 9 || itemRespawn == 10 || itemRespawn == 11 || itemRespawn == 12 || itemRespawn == 13 || itemRespawn == 14 || itemRespawn == 15
                        || itemRespawn == 16 || itemRespawn == 17 || itemRespawn == 18 || itemRespawn == 19 || itemRespawn == 20 || itemRespawn == 21 || itemRespawn == 22 )
                    {
                        
                        boomOnScreen = true;
                        makeBoom();
                    }
                }
                else if ( boomOnScreen==true)
                {
                    if (cntBoom==80)
                    {
                        boomOnScreen = false;
                        this.Controls.Remove(pictureBoom);
                        cntBoom = 0;
                        this.Refresh();
                    }
                }
                
                
            }

            
            int savior = rnd.Next(52) + 1;

            if (cnt == 60)
            {
                cnt = 0;
                if ((savior == 30 || savior == 40 || savior == 20 || savior == 10 || savior == 50 || savior == 51 || savior == 52) && saviorOnScreen == false)
                {
                    
                    saviorOnScreen = true;
                    normalsound.URL = resourcesPath + "appear.mp3";
                    makeSavior();
                }
            }

            
            //ubah arah ketika nabrak zombie
            if (saviorOnScreen == true)
            {

                //batas jalan 
                if (horison == false)
                {
                    if (pictureSavior.Left > this.ClientSize.Width - (this.ClientSize.Width * 2 / 100))
                    {
                        directionSavior = "kiri";
                    }
                    else if (pictureSavior.Left <= 0)
                    {
                        directionSavior = "kanan";
                    }
                }
                else if (horison == true)
                {
                    if (pictureSavior.Top >= this.ClientSize.Height - (this.ClientSize.Height * 6 / 100))
                    {
                        directionSavior = "atas";
                    }
                    else if (pictureSavior.Top <= this.ClientSize.Height * 20 / 100)
                    {
                        directionSavior = "bawah";
                    }
                }


                for (int i = 0; i < listOfEnemy1.Count; i++)
                {
                    if (listOfEnemy1[i].Bounds.IntersectsWith(pictureSavior.Bounds))
                    {
                        if (cnt>10)
                        {
                            if (horison == false)
                            {
                                directionSavior = "atas";
                                horison = true;
                                cnt = 0;
                            }
                            else if (horison == true)
                            {
                                directionSavior = "kiri";
                                horison = false;
                                cnt = 0;
                            }
                        }
                        
                    }
                }
                for (int i = 0; i < listOfEnemy2.Count; i++)
                {
                    if (listOfEnemy2[i].Bounds.IntersectsWith(pictureSavior.Bounds))
                    {
                        if (cnt > 10)
                        {
                            if (horison == false)
                            {
                                directionSavior = "bawah";
                                horison = true;
                                cnt = 0;
                            }
                            else if (horison == true)
                            {
                                directionSavior = "kanan";
                                horison = false;
                                cnt = 0;
                            }
                        }
                    }
                }

                if (pictureBoxPlayer.Bounds.IntersectsWith(pictureSavior.Bounds))
                {
                    saviorOnScreen = false;
                    pictureSavior.Dispose();
                    pointscore += 500;
                    loadImageScore();
                    cnt = 0;
                    this.Refresh();
                }

                jedaBelokSuvivor++;
                if (jedaBelokSuvivor > 60)
                {
                    if (savior == 30 || savior == 40 || savior == 20 ||savior==2)
                    {
                        if (horison == false)
                        {
                            directionSavior = "bawah";
                            horison = true;
                            jedaBelokSuvivor = 0;
                        }
                        else if (horison == true)
                        {
                            directionSavior = "kanan";
                            horison = false;
                            jedaBelokSuvivor = 0;
                        }
                    }
                    else if (savior == 10 || savior == 50 || savior == 51 ||savior ==3)
                    {
                        if (horison == false)
                        {
                            directionSavior = "atas";
                            horison = true;
                            jedaBelokSuvivor = 0;
                        }
                        else if (horison == true)
                        {
                            directionSavior = "kiri";
                            horison = false;
                            jedaBelokSuvivor = 0;
                        }
                    }
                }


                //kanan kiri dana tas bawah
                if (horison == false)
                {
                    if (directionSavior=="kanan")
                    {
                        saviorRight();
                    }
                    else if (directionSavior == "kiri")
                    {
                        saviorLeft();
                    }
                    
                }
                else if (horison == true)
                {
                    if (directionSavior == "bawah")
                    {
                        saviorBottom();
                    }
                    else if (directionSavior == "atas")
                    {
                        saviorUp();
                    }
                }
            }

            //jalannya musuh1
            for (int i = 0; i < listOfEnemy1.Count; i++)
            {
                enemyGoLeft(i);

                //pengecekan menabrak player
                if (listOfEnemy1[i].Bounds.IntersectsWith(pictureBoxPlayer.Bounds))
                {
                      
                    if (invisible==false)
                    {
                        normalsound.URL = resourcesPath + "hurt.mp3";
                        invisible = true;
                        
                        life--;

                        pengecekanLife();
                       
                    }
                }

                if (listOfEnemy1[i].Left < -70)
                {
                    listOfEnemy1[i].Dispose();
                    listOfEnemy1.RemoveAt(i);

                    timerEnemy1Generator.Enabled = true;
                }
                else
                {
                    listOfEnemy1[i].Refresh();
                }


            }

            //jalannya musuh 2
            for (int i = 0; i < listOfEnemy2.Count; i++)
            {
                enemyGoRight(i);

                //pengecekan menabrak player
                if (listOfEnemy2[i].Bounds.IntersectsWith(pictureBoxPlayer.Bounds))
                {
                    if (invisible == false)
                    {
                        normalsound.URL = resourcesPath + "hurt.mp3";
                        invisible = true;
                        
                        life--;

                        pengecekanLife();
                    }
                }

                if (listOfEnemy2[i].Left > this.ClientSize.Width)
                {
                    listOfEnemy2[i].Dispose();
                    listOfEnemy2.RemoveAt(i);

                    timerEnemy2Generator.Enabled = true;
                }
                else
                {
                    listOfEnemy2[i].Refresh();
                }

            }
        }
       
        private void timerLaserMove_Tick(object sender, EventArgs e)
        {
            //jalannya laser
            jalanLaser();
            pengecekanMelewatiBatas();
            kenaTembakEnemy1();
            kenaTembakEnemy2();
        }

        private void kenaTembakEnemy2()
        {
            for (int j = 0; j < listOfEnemy2.Count; j++)
            {
                if (pictureBoxlaser.Bounds.IntersectsWith(listOfEnemy2[j].Bounds))
                {
                    pointscore += 100;
                    loadImageScore();
                    normalsound.URL = resourcesPath + "hit.mp3";
                    listOfEnemy2[j].Dispose();
                    listOfEnemy2.RemoveAt(j);
                    pictureBoxlaser.Dispose();

                    canShoot = true;
                    directionShoot="";
                    laserOnScreen = false;

                    timerEnemy2Generator.Enabled = true;

                    this.Refresh();
                    break;
                }
                else
                {
                    this.Refresh();
                }
                
            }
        }

        private void loadImageScore()
        {
            point.Text = pointscore.ToString();
            this.Refresh();
        }

        private void kenaTembakEnemy1()
        {
            
            for (int i = 0; i < listOfEnemy1.Count; i++)
            {
                if (pictureBoxlaser.Bounds.IntersectsWith(listOfEnemy1[i].Bounds))
                {
                    pointscore += 100;
                    loadImageScore();
                    normalsound.URL = resourcesPath + "hit.mp3";
                    listOfEnemy1[i].Dispose();
                    listOfEnemy1.RemoveAt(i);
                    pictureBoxlaser.Dispose();
                        
                    canShoot = true;
                    directionShoot="";
                    laserOnScreen = false;

                    timerEnemy1Generator.Enabled = true;

                    this.Refresh();
                    break;
                }
                else
                {
                    this.Refresh();
                }
                
            }
        }

        private void jalanLaser()
        {
            
            //direction shoot
            if (directionShoot == "atas")
            {
                LaserGoUp();
            }
            else if (directionShoot == "bawah")
            {
                LaserGoDown();
            }
            else if (directionShoot == "kanan")
            {
                LaserGoRight();
            }
            else if (directionShoot == "kiri")
            {
                LaserGoLeft();
            }
            
        }

        private void pengecekanMelewatiBatas()
        {
            //menghilangkan object saat melewati batas
            
            if (pictureBoxlaser.Top < this.ClientSize.Height * 20 / 100)
            {
                pictureBoxlaser.Dispose();
                    
                canShoot = true;
                directionShoot="";
                laserOnScreen = false;
            }
            else if (pictureBoxlaser.Top > this.ClientSize.Height)
            {
                pictureBoxlaser.Dispose();
                    
                canShoot = true;
                directionShoot="";
                laserOnScreen = false;
            }
            else if (pictureBoxlaser.Left > this.ClientSize.Width)
            {
                pictureBoxlaser.Dispose();
                    
                canShoot = true;
                directionShoot="";
                laserOnScreen = false;
            }
            else if (pictureBoxlaser.Left < 0)
            {
                pictureBoxlaser.Dispose();
                    
                canShoot = true;
                directionShoot="";
                laserOnScreen = false;
            }
            

        }
         
        private void LaserGoUp()
        {
            pictureBoxlaser.Top -= (int)pictureBoxlaser.Tag;
        }

        private void LaserGoRight()
        {
            pictureBoxlaser.Left += (int)pictureBoxlaser.Tag;
        }

        private void LaserGoDown()
        {
            pictureBoxlaser.Top += (int)pictureBoxlaser.Tag;
        }
        private void LaserGoLeft()
        {
            pictureBoxlaser.Left -= (int)pictureBoxlaser.Tag;
        }

        private void pengecekanLife()
        {
            if (life == 3)
            {
                listofheart.Image = Properties.Resources._3_life;

                this.Refresh();
            }
            else if (life == 2)
            {
                listofheart.Image = Properties.Resources._2life;

                this.Refresh();
            }
            else if (life == 1)
            {
                listofheart.Image = Properties.Resources._1life;

                this.Refresh();

            }
            else if(life==0)
            {
                listofheart.Hide();
                timerEnemy1Generator.Enabled = false;
                timerEnemy2Generator.Enabled = false;
                timerLaserMove.Enabled = false;
                timerGame.Enabled = false;
                this.Refresh();
                DialogResult userSelection = MessageBox.Show("You have survived for : " + minutes + " Minutes " + " and " + seconds + " Seconds " + "\nBack to mode select", "\t" +"Game Over", MessageBoxButtons.OK);


                List<int> listOfHighScore = new List<int>();
                StreamReader sr = new StreamReader(Application.StartupPath + "/HighscoreSurvival.txt");

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
                sr.Close();
                int totalSecond = 60 * minutes + seconds;

                listOfHighScore.Add(totalSecond);
                listOfHighScore.Sort();
                listOfHighScore.Reverse();

                //menulis score ke dalam txt files
                StreamWriter sw;
                sw = new StreamWriter(Application.StartupPath + "/HighscoreSurvival.txt");
                for (int i = 0; i < listOfHighScore.Count - 1; i++)
                {
                    sw.WriteLine(listOfHighScore[i].ToString());
                }
                sw.Close();

                if (userSelection == DialogResult.OK)
                {
                    Main_Menu mainmenu = new Main_Menu();
                    mainmenu.Owner = this;
                    mainmenu.Show();
                    this.Close();
                    this.Dispose();
                }
            }
        }
        public void tembakLaserKiri()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 

                PictureBox pictureLaser = new PictureBox();
                pictureLaser.Image = Properties.Resources.laserleft;
                pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                pictureLaser.BackColor = Color.Transparent;

                pictureLaser.Top = pictureBoxPlayer.Top + 30;
                pictureLaser.Left = pictureBoxPlayer.Left - 70;
                pictureLaser.Width = 70;
                pictureLaser.Height = 30;
                pictureLaser.Tag = 80;

                this.Controls.Add(pictureLaser);
                pictureBoxlaser = pictureLaser;
                directionShoot = "kiri";
                canShoot = false;
                laserOnScreen = true;

            }
        }
        public void tembakLaserBawah()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 

                PictureBox pictureLaser = new PictureBox();
                pictureLaser.Image = Properties.Resources.laserdown;
                pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                pictureLaser.BackColor = Color.Transparent;



                pictureLaser.Top = pictureBoxPlayer.Top + pictureBoxPlayer.Height;
                pictureLaser.Left = pictureBoxPlayer.Left + (pictureBoxPlayer.Width / 4);
                pictureLaser.Width = 30;
                pictureLaser.Height = 70;
                pictureLaser.Tag = 80;


                this.Controls.Add(pictureLaser);
                pictureBoxlaser = pictureLaser;
                directionShoot = "bawah";
                canShoot = false;
                laserOnScreen = true;

            }
        }

        public void tembakLaserAtas()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 
                PictureBox pictureLaser = new PictureBox();
                pictureLaser.Image = Properties.Resources.laser;
                pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                pictureLaser.BackColor = Color.Transparent;

                pictureLaser.Top = pictureBoxPlayer.Top - 70;
                pictureLaser.Left = pictureBoxPlayer.Left + (pictureBoxPlayer.Width / 4);
                pictureLaser.Width = 30;
                pictureLaser.Height = 70;
                pictureLaser.Tag = 20;


                this.Controls.Add(pictureLaser);
                pictureBoxlaser = pictureLaser;
                directionShoot = "atas";
                canShoot = false;
                laserOnScreen = true;


            }
        }

        public void tembakLaserKanan()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 

                PictureBox pictureLaser = new PictureBox();
                pictureLaser.Image = Properties.Resources.laserright;
                pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                pictureLaser.BackColor = Color.Transparent;


                pictureLaser.Top = pictureBoxPlayer.Top + 30;
                pictureLaser.Left = pictureBoxPlayer.Left + pictureBoxPlayer.Width;
                pictureLaser.Width = 70;
                pictureLaser.Height = 30;
                pictureLaser.Tag = 20;



                this.Controls.Add(pictureLaser);
                pictureBoxlaser = pictureLaser;
                directionShoot = "kanan";
                canShoot = false;
                laserOnScreen = true;

            }
        }

        public void imageMoveUp()
        {
            cntForMove++;
            if (cntForMove == 1)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp1;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                cntForMove = 0;
            }
        }

        public void imageMoveDown()
        {
            cntForMove++;
            if (cntForMove == 1)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerdown1;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerdown2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerdown3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                cntForMove = 0;
            }
        }

        public void imageMoveRight()
        {
            cntForMove++;
            if (cntForMove == 1)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerRight1;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerright2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerright3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                cntForMove = 0;
            }
        }

        public void imageMoveLeft()
        {
            cntForMove++;
            if (cntForMove == 1)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerleft1;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerleft2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerleft3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
                cntForMove = 0;
            }

        }

        private void makePlayer1()
        {
            pictureBoxPlayer.Top = 500;
            pictureBoxPlayer.Left = 100;
            pictureBoxPlayer.Width = this.ClientSize.Width * 5 / 100;
            pictureBoxPlayer.Height = this.ClientSize.Height * 10 / 100;
            pictureBoxPlayer.Tag = 10;
            pictureBoxPlayer.BackColor = Color.Transparent;
        }

        private void makeBoom()
        {
            pictureBoom.Image = Properties.Resources.bombspray;
            pictureBoom.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoom.BackColor = Color.Transparent;

            pictureBoom.Width = this.ClientSize.Width * 3 / 100;
            pictureBoom.Height = this.ClientSize.Height * 8 / 100;
            pictureBoom.Top = rnd.Next((this.ClientSize.Height * 20 / 100), (this.ClientSize.Height - (this.ClientSize.Height * 8 / 100)));
            pictureBoom.Left = rnd.Next(0, this.ClientSize.Width - (this.ClientSize.Width * 3 / 100));
          

            this.Controls.Add(pictureBoom);
            this.Refresh();
            normalsound.URL = resourcesPath + "appear.mp3";
        }

        private void makeSavior()
        {
            pictureSavior.Image = Properties.Resources.survivordown1;
            pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            pictureSavior.BackColor = Color.Transparent;

            pictureSavior.Width = this.ClientSize.Width * 3 / 100;
            pictureSavior.Height = this.ClientSize.Height * 8 / 100;
            pictureSavior.Top = rnd.Next(0, 9) * 100 + 150;
            int rol = rnd.Next(0, 1);
            if (rol == 0)
            {
                pictureSavior.Left = 0;
                pictureSavior.Tag = 30;
            }
            else
            {
                pictureSavior.Left = this.ClientSize.Width;
                pictureSavior.Tag = -30;
            }
            

            this.Controls.Add(pictureSavior);

        }

        private void saviorBottom()
        {
            pictureSavior.Top += 30;
            cntSaviorMove++;
            if (cntSaviorMove == 1)
            {
                pictureSavior.Image = Properties.Resources.survivordown1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 2)
            {
                pictureSavior.Image = Properties.Resources.survivordown2;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 3)
            {
                pictureSavior.Image = Properties.Resources.survivordown3;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
                cntSaviorMove = 0;
            }
            this.Refresh();
        }

        private void saviorUp()
        {
            pictureSavior.Top -= 30;
            cntSaviorMove++;
            if (cntSaviorMove == 1)
            {
                pictureSavior.Image = Properties.Resources.survivorup1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 2)
            {
                pictureSavior.Image = Properties.Resources.survivorup1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 3)
            {
                pictureSavior.Image = Properties.Resources.survivorup1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
                cntSaviorMove = 0;
            }
            this.Refresh();
        }

        private void saviorLeft()
        {
            pictureSavior.Left -= 30;
            cntSaviorMove++;
            if (cntSaviorMove == 1)
            {
                pictureSavior.Image = Properties.Resources.survivorleft1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 2)
            {
                pictureSavior.Image = Properties.Resources.survivorleft2;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 3)
            {
                pictureSavior.Image = Properties.Resources.survivorleft3;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
                cntSaviorMove = 0;
            }
            this.Refresh();
        }

        private void saviorRight()
        {
            pictureSavior.Left += 30;
            cntSaviorMove++;
            if (cntSaviorMove == 1)
            {
                pictureSavior.Image = Properties.Resources.survivorright1;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 2)
            {
                pictureSavior.Image = Properties.Resources.survivorright2;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (cntSaviorMove == 3)
            {
                pictureSavior.Image = Properties.Resources.survivorright3;
                pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
                cntSaviorMove = 0;
            } 
            
            this.Refresh();
        }

        private void enemyGoLeft(int i)
        {
            listOfEnemy1[i].Left -= 50;
            int cntEnemyMove = (int)listOfEnemy1[i].Tag;
            cntEnemyMove++;
            if (cntEnemyMove == 1)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft1;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (cntEnemyMove == 2)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft2;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (cntEnemyMove == 3)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft3;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;

                cntEnemyMove = 0;
            }
            listOfEnemy1[i].Tag = cntEnemyMove;
        }

        private void enemyGoRight(int i)
        {
            listOfEnemy2[i].Left += 50;
            int cntEnemyMove = (int)listOfEnemy2[i].Tag;
            cntEnemyMove++;
            if (cntEnemyMove == 1)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright1;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (cntEnemyMove == 2)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright2;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (cntEnemyMove == 3)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright3;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;

                cntEnemyMove = 0;
            }
            listOfEnemy2[i].Tag = cntEnemyMove;
        }
    }
}
  