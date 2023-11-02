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


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);


            // prendiamo heigh perche cosi resta nel form agevolmente, con width uscirebbe perche l'altezza sarebbe troppo grande (width>height)
            int diametro = ClientSize.Height;
            int raggio = diametro / 2;


            // coordinate in alto a sinistra del rettangolo circoscritto all'orologio
            int x = this.ClientSize.Width / 2 - raggio;
            int y = this.ClientSize.Height / 2 - raggio;


            //Coordinate centro circonferenza
            int xc = this.ClientSize.Width / 2;
            int yc = this.ClientSize.Height / 2;


            //Disegna punto al centro dell'orologio
            g.FillEllipse(Brushes.Black, xc-4, yc-4,8,8);


            //Disegna circongerenza esterna
            g.DrawEllipse(p, x, y, diametro - 3, diametro - 3);


            //Disegna le tacche delle ore
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

            p.Color = Color.BlueViolet;


            // 11 sono le tacchette tra ogni ora(5,10,15,20....55) moltiplicati per 15 per far si che ce ne siano 11 tra ogni ora
            for (int i = 0; i < 11 * 15; i++)
            {

                double angolominuti = i * ((Math.PI / 6) / 12);

                double xtm = xc + (raggio * 0.96) * Math.Cos(angolominuti);
                double ytm = yc - (raggio * 0.96) * Math.Sin(angolominuti);

                double xt1m = xc + raggio * Math.Cos(angolominuti);
                double yt1m = yc - raggio * Math.Sin(angolominuti);


                g.DrawLine(p, (float)xtm, (float)ytm, (float)xt1m, (float)yt1m);
            }

            p.Color = Color.Black;


            //Creo una variabile DateTime per prendere l'ora
            DateTime t = new DateTime();
            t = DateTime.Now;

        
            // lancette secondi 
            double angolo_secondi = 2 * Math.PI / 60 * t.Second;
            double xp = xc + (raggio - 30) * Math.Cos((Math.PI / 2) - angolo_secondi);
            double yp = yc - (raggio - 30) * Math.Sin((Math.PI / 2) - angolo_secondi);
            
            g.DrawLine(p, xc, yc, (float)xp, (float)yp);


            // lancette minuti 
            double angolo_minuti = 2 * Math.PI / 60 * t.Minute;
            xp = xc + (raggio - 40) * Math.Cos((Math.PI / 2) - angolo_minuti);
            yp = yc - (raggio - 40) * Math.Sin((Math.PI / 2) - angolo_minuti);

            p.Width = 2;
            g.DrawLine(p, xc, yc, (float)xp, (float)yp);

            
            //Converto l'ora in un formato da 12 ore e disegno la lancetta delle ore
            double angolo_ore = Math.PI / 6 * (t.Hour % 12);
            xp = xc + (raggio - 70) * Math.Cos((Math.PI / 2) - angolo_ore);
            yp = yc - (raggio - 70) * Math.Sin((Math.PI / 2) - angolo_ore);
            
            p.Width = 3;
            g.DrawLine(p, xc, yc, (float)xp, (float)yp);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Ridisegna l'orologio ogni secondo
            this.Invalidate(false);
            this.Refresh();
        }

    }

}

