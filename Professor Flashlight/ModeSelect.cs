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
    public partial class ModeSelect : Form
    {
        public ModeSelect()
        {
            InitializeComponent();
        }
        Label normalmode = new Label();
        Label survivalmode = new Label();
        Label gamemode = new Label();
        PictureBox back = new PictureBox();
        


        string resourcesPath = Application.StartupPath + "\\Resources\\" ;
        WindowsMediaPlayer normalsound = new WindowsMediaPlayer() ;

        private void ModeSelect_Load(object sender, EventArgs e)
        {




            normalmode.Text = "NORMAL MODE";
            normalmode.BackColor = Color.Transparent;
            normalmode.Width = this.ClientSize.Width / 2;
            normalmode.Height = this.ClientSize.Height / 3;
            normalmode.Top = this.ClientSize.Height - this.ClientSize.Height * 70 / 100;
            normalmode.Left = this.ClientSize.Width - this.ClientSize.Width * 95 / 100;
            normalmode.Font = new Font("Arial", this.ClientSize.Height / 10);
            normalmode.ForeColor = Color.White;
            normalmode.TextAlign = ContentAlignment.MiddleCenter;

            survivalmode.Text = "SURVIVAL MODE";
            survivalmode.BackColor = Color.Transparent;
            survivalmode.Width = this.ClientSize.Width / 2;
            survivalmode.Height = this.ClientSize.Height / 3;
            survivalmode.Top = this.ClientSize.Height - this.ClientSize.Height * 70 / 100;
            survivalmode.Left = this.ClientSize.Width - this.ClientSize.Width * 52 / 100;
            survivalmode.Font = new Font("Arial", this.ClientSize.Height / 10);
            survivalmode.ForeColor = Color.White;
            survivalmode.TextAlign = ContentAlignment.MiddleCenter;


            gamemode.Text = "GAME MODES";
            gamemode.BackColor = Color.Transparent;
            gamemode.Width = this.ClientSize.Width;
            gamemode.Height = this.ClientSize.Height / 7;
            gamemode.Top = this.ClientSize.Height / 100;
            gamemode.Left = this.ClientSize.Width / 2 - (gamemode.Width / 4);
            gamemode.Font = new Font("Arial", this.ClientSize.Height / 10);
            gamemode.ForeColor = Color.White;
         

            back.Image = Properties.Resources.back;
            back.SizeMode = PictureBoxSizeMode.StretchImage;
            back.BackColor = Color.Transparent;
            back.Top = this.ClientSize.Height - this.ClientSize.Height * 98 / 100;
            back.Left = this.ClientSize.Width - this.ClientSize.Width * 98 / 100;
            back.Width = this.ClientSize.Width / 7;
            back.Height = this.ClientSize.Height / 8;

           


            this.Controls.Add(normalmode);
            this.Controls.Add(survivalmode);
            this.Controls.Add(gamemode);
            this.Controls.Add(back);
            

            back.Click += new
           System.EventHandler(back_Click);

            normalmode.Click += new
            System.EventHandler(normalmode_Click);

            survivalmode.Click += new
            System.EventHandler(survivalmode_Click);

          

                

        }

        private void back_Click(object sender ,EventArgs e )
        {
            normalsound.URL = resourcesPath + "select.mp3";
            this.Close();
            this.Dispose();

        }

        private void normalmode_Click (object sender, EventArgs e)
        {
            normalsound.URL = resourcesPath + "select.mp3";
            Story story = new Story();
            story.Owner = this;
            this.Close();
            story.ShowDialog();
            
        }

        private void survivalmode_Click (object sender , EventArgs e)
        {
            normalsound.URL = resourcesPath + "select.mp3";
            Form1 form1 = new Form1();
            form1.Owner = this;
            form1.Show();
        }
        
    


    }
}
