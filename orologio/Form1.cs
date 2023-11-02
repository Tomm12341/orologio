using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace orologio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();


            Pen p = new Pen(Color.Black);

            // prendiamo heigh perche cosi resta nel form agevolmente, con width uscirebbe perche l'altezza sarebbe troppo grande (width>height)
            int diametro = ClientSize.Height;
            int raggio = diametro / 2;


            int x = this.ClientSize.Width / 2 - raggio;
            int y = this.ClientSize.Height / 2 - raggio;

            // Graphics ee= this.CreateGraphics();
            g.DrawEllipse(p, x, y, diametro - 3, diametro - 3);

            //Coordinate centro circonferenza
            int xc = this.ClientSize.Width / 2;
            int yc = this.ClientSize.Height / 2;
            g.FillEllipse(Brushes.Black, xc, yc, 8, 8);

            //Disegno lancette ore
            DateTime t = new DateTime();
            t = DateTime.Now;

            Graphics d = this.CreateGraphics();
            Pen lancetta = new Pen(Color.Black);
            int oraOrologio = t.Hour;
            if (t.Hour > 12)
            {
                oraOrologio = oraOrologio - 13;


            }

            double xp = xc + (raggio - 15) * Math.Cos((Math.PI / 2) - oraOrologio * (Math.PI / 6));
            double yp = yc - (raggio - 15) * Math.Sin((Math.PI / 2) - oraOrologio * (Math.PI / 6));
            d.DrawLine(lancetta, xc, yc, (float)xp, (float)yp);

            // lancette minuti 

            double angolo_minuti = 2 * Math.PI / 60 * t.Second;
            xp = xc + (raggio - 30) * Math.Cos((Math.PI / 2) - angolo_minuti);
            yp = yc - (raggio - 30) * Math.Sin((Math.PI / 2) - angolo_minuti);
            d.DrawLine(lancetta, xc, yc, (float)xp, (float)yp);

            for (int i = 0; i < 12; i++)
            {
                // 30 gradi perche 360/12 e calcolo l'angolo

                double angolo = i * (Math.PI / 6);
                // punto di partenza, usiamo UNA PARTE(88%) del raggio come lunghezza delle tacchette, xc e yc li  usiamo  per traslare le tacchette al centro dell'orologio
                double xt = xc + (raggio * 0.88) * Math.Cos(angolo);
                double yt = yc - (raggio * 0.88) * Math.Sin(angolo);
                // punto di arrivo delle tacchette
                double xt1 = xc + (raggio) * Math.Cos(angolo);
                double yt1 = yc - (raggio) * Math.Sin(angolo);


                g.DrawLine(p, (float)xt, (float)yt, (float)xt1, (float)yt1);

            }



            Pen q = new Pen(Color.BlueViolet);

            // 11 sono le tacchette tra ogni ora(5,10,15,20....55) moltiplicati per 15 per far si che ce ne siano 11 tra ogni ora
            for (int i = 0; i < 11 * 15; i++)
            {

                double angolominuti = i * ((Math.PI / 6) / 12);

                double xtm = xc + (raggio * 0.96) * Math.Cos(angolominuti);
                double ytm = yc - (raggio * 0.96) * Math.Sin(angolominuti);

                double xt1m = xc + raggio * Math.Cos(angolominuti);
                double yt1m = yc - raggio * Math.Sin(angolominuti);


                g.DrawLine(q, (float)xtm, (float)ytm, (float)xt1m, (float)yt1m);
            }

        }
    

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Refresh();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }

}

