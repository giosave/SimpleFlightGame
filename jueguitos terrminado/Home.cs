using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jueguitos_terrminado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            over.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            enemy(gamespeed);
            gameover();
            coins(gamespeed);
            coincollection();
        }
        int collection = 0;
        Random r = new Random();
        int x;
        void enemy(int speed) {
            if (enemy1.Top >= 550)
            { 
                x = r.Next(0, 300);

                enemy1.Location = new Point(x, 0);
            }
            else { enemy1.Top += speed; }

            if (enemy2.Top >= 550)
            {
                x = r.Next(0, 400);

                enemy2.Location = new Point(x, 0);
            }
            else { enemy2.Top += speed; }

            if (enemy3.Top >= 500)
            {
                x = r.Next(200, 350);

                enemy3.Location = new Point(x, 0);
            }
            else { enemy3.Top += speed; }





            /*

            if (car.Right < 150) car.Left += r.Next(0, 150);
            if (car.Left < 150) car.Left += -r.Next(0, 150);
            */
        }
        void coins(int speed)//puntos
        {
            if (coin1.Top >= 550)
            {
                x = r.Next(0, 300);

                coin1.Location = new Point(x, 0);
            }
            else { coin1.Top += speed; }

            if (coin2.Top >= 550)
            {
                x = r.Next(0, 300);

                coin2.Location = new Point(x, 0);
            }
            else { coin2.Top += speed; }

            if (coin3.Top >= 550)
            {
                x = r.Next(0, 300);

                coin3.Location = new Point(x, 0);
            }
            else { coin3.Top += speed; }

        }
        void gameover() {//chocar es perder
            if (car.Bounds.IntersectsWith(enemy1.Bounds)) 
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
        }
        void moveline(int speed) {
          
            //lineas
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else { pictureBox1.Top += speed; }
            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else { pictureBox2.Top += speed; }
            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else { pictureBox3.Top += speed; }
        }
        void coincollection() {//recoleccion y suma
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collection++;
                label1.Text = "Coin" + collection.ToString();
                x = r.Next(50, 300);
                coin1.Location = new Point(x, 0);  
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collection++;
                label1.Text = "Coin" + collection.ToString();
                x = r.Next(50, 300);
                coin2.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collection++;
                label1.Text = "Coin" + collection.ToString();
                x = r.Next(50, 300);
                coin3.Location = new Point(x, 0);
            }
        }
        int gamespeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)//movimiento
        {
            ///MOVIMIENTO CON TENCLAS
              if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 0) car.Left += -r.Next(20, 150); ;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Right <380) car.Left += r.Next(20, 50);
            }
            
            if (e.KeyCode == Keys.Up) if (gamespeed < 21) { gamespeed++; }
            if (e.KeyCode == Keys.Down) if (gamespeed > 0) { gamespeed--; }
        }

        private void Form1_Load(object sender, EventArgs e)//imagen movimiento
        {
            car.Image = SimpleFlightGame.Properties.Resources.paso1;
            car.SizeMode = PictureBoxSizeMode.StretchImage;
            Timer tm = new Timer();
            tm.Interval = 5;
            tm.Tick += new EventHandler(changeImage);
            tm.Start();
        }
        private void changeImage(object sender, EventArgs e)//imagen movimiento
        {
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(SimpleFlightGame.Properties.Resources.paso1);
            b1.Add(SimpleFlightGame.Properties.Resources.paso2);
            b1.Add(SimpleFlightGame.Properties.Resources.paso3);
            b1.Add(SimpleFlightGame.Properties.Resources.paso4);
            int index = DateTime.Now.Second % b1.Count;
            car.Image = b1[index];


        }
    }
}
