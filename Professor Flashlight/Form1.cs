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
    public partial class Form1 : Form
    {
        PictureBox pictureBoxPlayer = new PictureBox();
        List<PictureBox> listOfEnemy1 = new List<PictureBox>();
        List<PictureBox> listOfEnemy2 = new List<PictureBox>();
        List<PictureBox> listOfLaser = new List<PictureBox>();
        List<PictureBox> listOfHeart = new List<PictureBox>();
        PictureBox pictureSavior = new PictureBox();

        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int cntForMove=0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            imageMoveDown();
            pictureBoxPlayer.Top = 500;
            pictureBoxPlayer.Left = 100;
            pictureBoxPlayer.Width = 70;
            pictureBoxPlayer.Height = 100;
            pictureBoxPlayer.Tag = 10;

            this.Controls.Add(pictureBoxPlayer);

            PictureBox listofheart = new PictureBox();
            //listofheart.Image = Properties.Resources.

            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.DoubleBuffered = true;


        }
        bool atas=false, bawah=true, kiri=false, kanan=false;
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.W)
            {
                if ( pictureBoxPlayer.Top >150)
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
                if (pictureBoxPlayer.Top < this.ClientSize.Height-100)
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
                if (pictureBoxPlayer.Left < this.ClientSize.Width-70)
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
                //MessageBox.Show("Test");
                if (atas==true)
                {
                    timerLaserMove.Enabled = true;
                    tembakLaserAtas();
                }
                else if(bawah==true)
                {
                    timerLaserMove.Enabled = true;
                    tembakLaserBawah();
                }
                else if (kanan==true)
                {
                    timerLaserMove.Enabled = true;
                    tembakLaserKanan();
                }
                else if (kiri==true)
                {
                    timerLaserMove.Enabled = true;
                    tembakLaserKiri();
                }
            }
        }
        bool canShoot = true;
        List<string> directionShoot = new List<string>();

        public void tembakLaserKiri()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 
                if (listOfLaser.Count > 2)
                {
                    canShoot = false;
                }
                else
                {
                    PictureBox pictureLaser = new PictureBox();
                    pictureLaser.Image = Properties.Resources.laserleft;
                    pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureLaser.BackColor = Color.Transparent;

                    pictureLaser.Top = pictureBoxPlayer.Top + 50;
                    pictureLaser.Left = pictureBoxPlayer.Left-70;
                    pictureLaser.Width = 70;
                    pictureLaser.Height = 30;
                    pictureLaser.Tag = 20;

                    listOfLaser.Add(pictureLaser);

                    this.Controls.Add(pictureLaser);
                    directionShoot.Add("kiri");
                    canShoot = true;
                }
            }
        }
        public void tembakLaserBawah()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 
                if (listOfLaser.Count > 2)
                {
                    canShoot = false;
                }
                else
                {
                    PictureBox pictureLaser = new PictureBox();
                    pictureLaser.Image = Properties.Resources.laserdown;
                    pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureLaser.BackColor = Color.Transparent;


                    pictureLaser.Top = pictureBoxPlayer.Top + pictureBoxPlayer.Height;
                    pictureLaser.Left = pictureBoxPlayer.Left + (pictureBoxPlayer.Width / 4);
                    pictureLaser.Width = 30;
                    pictureLaser.Height = 70;
                    pictureLaser.Tag = 20;

                    listOfLaser.Add(pictureLaser);

                    this.Controls.Add(pictureLaser);
                    directionShoot.Add("bawah");
                    canShoot = true;
                }
            }
        }

        public void tembakLaserAtas()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 
                if (listOfLaser.Count > 2)
                {
                    canShoot = false;
                }
                else
                {
                    PictureBox pictureLaser = new PictureBox();
                    pictureLaser.Image = Properties.Resources.laser;
                    pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureLaser.BackColor = Color.Transparent;

                    pictureLaser.Top = pictureBoxPlayer.Top - 70;
                    pictureLaser.Left = pictureBoxPlayer.Left + (pictureBoxPlayer.Width / 4);
                    pictureLaser.Width = 30;
                    pictureLaser.Height = 70;
                    pictureLaser.Tag = 20;

                    listOfLaser.Add(pictureLaser);

                    this.Controls.Add(pictureLaser);
                    directionShoot.Add("atas");
                    canShoot = true;
                }
            }
        }

        public void tembakLaserKanan()
        {
            if (canShoot == true)
            {
                //mengecek laser yang ada di layar 
                if (listOfLaser.Count > 2)
                {
                    canShoot = false;
                }
                else
                {
                    PictureBox pictureLaser = new PictureBox();
                    pictureLaser.Image = Properties.Resources.laserright;
                    pictureLaser.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureLaser.BackColor = Color.Transparent;

                    pictureLaser.Top = pictureBoxPlayer.Top + 50;
                    pictureLaser.Left = pictureBoxPlayer.Left + pictureBoxPlayer.Width;
                    pictureLaser.Width = 70;
                    pictureLaser.Height = 30;
                    pictureLaser.Tag = 20;


                    listOfLaser.Add(pictureLaser);
                    this.Controls.Add(pictureLaser);

                    directionShoot.Add("kanan");
                    canShoot = true;
                }
            }
        }

        


        public void imageMoveUp()
        {
            cntForMove++;
            if (cntForMove==1)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp1;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if(cntForMove==2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerUp3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
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
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerdown2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerdown3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
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
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerright2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerright3;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
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
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 2)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerleft2;
                pictureBoxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxPlayer.BackColor = Color.Transparent;
            }
            else if (cntForMove == 3)
            {
                pictureBoxPlayer.Image = Properties.Resources.playerleft3;
            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxPlayer.BackColor = Color.Transparent;
                cntForMove = 0;
            }
            
        }
       
        private void makeSavior()
        {
            pictureSavior.Image = Properties.Resources.playerUp1;
            pictureSavior.SizeMode = PictureBoxSizeMode.Zoom;
            //rnd.Next(0, 10)
            pictureSavior.Top = rnd.Next(0, 9) * 100 + 150;
            int rol = rnd.Next(0, 1);
            if (rol == 0)
            {
                pictureSavior.Left = 0;
                pictureSavior.Tag = 20;
            }
            else
            {
                pictureSavior.Left = this.ClientSize.Width;
                pictureSavior.Tag = -20;
            }
            pictureSavior.Width = 70;
            pictureSavior.Height = 100;

            this.Controls.Add(pictureSavior);

        }

        bool saviorOnScreen = false;
        int cnt = 0;
        bool horison = false;
       

        private void timerEnemy1Generator_Tick(object sender, EventArgs e)
        {
            PictureBox pictureEnemy1 = new PictureBox();
            pictureEnemy1.Image = Properties.Resources.enemyleft1;
            pictureEnemy1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureEnemy1.BackColor = Color.Transparent;
            //rnd.Next(0, 10)
            pictureEnemy1.Top = rnd.Next(0, 9) * 100 + 150;
            pictureEnemy1.Left = this.ClientSize.Width + 70;
            pictureEnemy1.Width = 70;
            pictureEnemy1.Height = 100;
            pictureEnemy1.Tag = 0;

            listOfEnemy1.Add(pictureEnemy1);
            this.Controls.Add(pictureEnemy1);
            // pictureEnemy1.Click += new System.EventHandler(pictureEnemy1_Click);

            if (listOfEnemy1.Count > 10)
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
            //rnd.Next(0, 10)
            pictureEnemy2.Top = rnd.Next(0, 9) * 100 + 150;
            pictureEnemy2.Left = -70;
            pictureEnemy2.Width = 70;
            pictureEnemy2.Height = 100;
            pictureEnemy2.Tag = 0;

            listOfEnemy2.Add(pictureEnemy2);
            this.Controls.Add(pictureEnemy2);
            // pictureEnemy1.Click += new System.EventHandler(pictureEnemy1_Click);

            if (listOfEnemy2.Count > 10)
            {
                timerEnemy1Generator.Enabled = false;
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            //bool collision = false;
            //bool onTheScreen = true;
            cnt++;
            int savior = rnd.Next(52) + 1;
            //chance savior muncul
            if (cnt == 60)
            {

                cnt = 0;
                //rnd.Next(52)

                //MessageBox.Show(savior.ToString());
                if ((savior == 30 || savior == 40 || savior == 20 || savior == 10 || savior == 50 || savior == 51 || savior == 52) && saviorOnScreen == false)
                {
                    //MessageBox.Show("Savior muncul");
                    saviorOnScreen = true;
                    makeSavior();
                }


            }


            //jalannya savior
            if (saviorOnScreen == true)
            {
                
                //batas jalan 
                if (horison == false)
                {
                   
                }
                
                

                //savior tabrak enemy
                if (horison == false)
                {
                    if (cnt > 10)
                    {
                        for (int i = 0; i < listOfEnemy1.Count; i++)
                        {
                            if (pictureSavior.Bounds.IntersectsWith(listOfEnemy1[i].Bounds))
                            {
                                horison = true;
                                cnt = 0;
                                break;
                            }
                        }
                        for (int i = 0; i < listOfEnemy2.Count; i++)
                        {
                            if (pictureSavior.Bounds.IntersectsWith(listOfEnemy2[i].Bounds))
                            {
                                horison = true;
                                cnt = 0;
                                break;
                            }
                        }
                    }
                    
                }
                else if (horison == true)
                {
                    if (cnt>10)
                    {
                        for (int i = 0; i < listOfEnemy1.Count; i++)
                        {
                            if (pictureSavior.Bounds.IntersectsWith(listOfEnemy1[i].Bounds))
                            {
                                horison = false;
                                cnt = 0;
                                break;
                            }
                        }
                        for (int i = 0; i < listOfEnemy2.Count; i++)
                        {
                            if (pictureSavior.Bounds.IntersectsWith(listOfEnemy2[i].Bounds))
                            {
                                horison = false;
                                cnt = 0;
                                break;
                            }
                        }
                    }
                    
                }
                
                if (horison == false)
                {
                    if (pictureSavior.Left > this.ClientSize.Width - 70)
                    {
                        pictureSavior.Tag = -20;
                    }
                    else if (pictureSavior.Left < 0)
                    {
                        pictureSavior.Tag = 20;
                    }
                }
                else if (horison == true)
                {
                    //if (pictureSavior.Top == 0 || pictureSavior.Top == 1 * 100 + 150 || pictureSavior.Top == 2 * 100 + 150 || pictureSavior.Top == 3 * 100 + 150 || pictureSavior.Top == 4 * 100 + 150
                     //  || pictureSavior.Top == 5 * 100 + 150 || pictureSavior.Top == 6 * 100 + 150 || pictureSavior.Top == 7 * 100 + 150 || pictureSavior.Top == 8 * 100 + 150 || pictureSavior.Top == 9 * 100 + 150)
                    if (pictureSavior.Top>=this.ClientSize.Height-100)
                    {

                        pictureSavior.Tag = -20;
                        
                    }
                    else if (pictureSavior.Top <= 150)
                    {
                        pictureSavior.Tag = 20;
                    }
                  
                    
                }
                //kanan kiri dana tas bawah
                if (horison == false)
                {
                    pictureSavior.Left += (int)pictureSavior.Tag;
                    this.Refresh();
                }
                else if (horison == true)
                {
                    
                   // if (pictureSavior.Top == 0 || pictureSavior.Top == 1 * 100 + 150 || pictureSavior.Top == 2 * 100 + 150 || pictureSavior.Top == 3 * 100 + 150 || pictureSavior.Top == 4 * 100 + 150
                   //     || pictureSavior.Top == 5 * 100 + 150 || pictureSavior.Top == 6 * 100 + 150 || pictureSavior.Top == 7 * 100 + 150 || pictureSavior.Top == 8 * 100 + 150 || pictureSavior.Top == 9 * 100 + 150)

                    pictureSavior.Top += (int)pictureSavior.Tag;
                    this.Refresh();
                }
                

            }

            //jalannya musuh1
            for (int i = 0; i < listOfEnemy1.Count; i++)
            {
                enemyGoLeft(i);
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
        private void enemyGoLeft(int i)
        {
            listOfEnemy1[i].Left -= 10;
            int cntEnemyMove = (int)listOfEnemy1[i].Tag;
            cntEnemyMove++;
            if (cntEnemyMove==1)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft1;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy1[i].BackColor = Color.Transparent;
            }
            else if (cntEnemyMove==2)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft2;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy1[i].BackColor = Color.Transparent;
            }
            else if (cntEnemyMove == 3)
            {
                listOfEnemy1[i].Image = Properties.Resources.enemyleft3;
                listOfEnemy1[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy1[i].BackColor = Color.Transparent;
                cntEnemyMove = 0;
            }
            listOfEnemy1[i].Tag = cntEnemyMove;
        }

        private void enemyGoRight(int i)
        {
            listOfEnemy2[i].Left += 10;
            int cntEnemyMove = (int)listOfEnemy2[i].Tag;
            cntEnemyMove++;
            if (cntEnemyMove == 1)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright1;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy2[i].BackColor = Color.Transparent;
            }
            else if (cntEnemyMove == 2)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright2;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy2[i].BackColor = Color.Transparent;
            }
            else if (cntEnemyMove == 3)
            {
                listOfEnemy2[i].Image = Properties.Resources.enemyright3;
                listOfEnemy2[i].SizeMode = PictureBoxSizeMode.Zoom;
                listOfEnemy2[i].BackColor = Color.Transparent;
                cntEnemyMove = 0;
            }
            listOfEnemy2[i].Tag = cntEnemyMove;
        }
        
        private void timerLaserMove_Tick(object sender, EventArgs e)
        {
            //jalannya laser
            for (int i = 0; i < listOfLaser.Count; i++)
            {
                //direction shoot
                if (directionShoot[i]=="atas")
	            {
		             LaserGoUp(i);
	            }
                else if (directionShoot[i]=="bawah")
	            {
                    LaserGoDown(i);
	            }
                else if (directionShoot[i]=="kanan")
	            {
		            LaserGoRight(i);
	            }
                else if (directionShoot[i]=="kiri")
	            {
                    LaserGoLeft(i);
	            }

                //menghilangkan object saat melewati batas
                if (listOfLaser[i].Top <150)
                {
                    listOfLaser[i].Dispose();
                    listOfLaser.RemoveAt(i);

                    canShoot = true;
                    directionShoot.RemoveAt(i);
                }
                else if (listOfLaser[i].Top > this.ClientSize.Height)
                {
                    listOfLaser[i].Dispose();
                    listOfLaser.RemoveAt(i);

                    canShoot = true;
                    directionShoot.RemoveAt(i);
                }
                else if (listOfLaser[i].Left > this.ClientSize.Width)
                {
                    listOfLaser[i].Dispose();
                    listOfLaser.RemoveAt(i);

                    canShoot = true;
                    directionShoot.RemoveAt(i);
                }
                else if (listOfLaser[i].Left < 0)
                {
                    listOfLaser[i].Dispose();
                    listOfLaser.RemoveAt(i);

                    canShoot = true;
                    directionShoot.RemoveAt(i);
                }
                else
                {
                    listOfLaser[i].Refresh();
                }
            }
        }

        private void LaserGoUp(int i)
        {
            listOfLaser[i].Top -= (int)listOfLaser[i].Tag;
        }

        private void LaserGoRight(int i)
        {
            listOfLaser[i].Left += (int)listOfLaser[i].Tag;
        }

        private void LaserGoDown(int i)
        {
            listOfLaser[i].Top += (int)listOfLaser[i].Tag;
        }
        private void LaserGoLeft(int i)
        {
            listOfLaser[i].Left -= (int)listOfLaser[i].Tag;
        }
    }
}

  