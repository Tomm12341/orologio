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


            Graphics g = this.CreateGraphics();


            Pen p = new Pen(Color.Black);

            // prendiamo heigh perche cosi resta nel form agevolmente, con width uscirebbe percge l'altezza sarebbe troppo grande (width>height)
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

            //Disegno lancette
            DateTime t = new DateTime();
            t = DateTime.Now;

            Graphics d = this.CreateGraphics();
            Pen lancetta = new Pen(Color.Black);
            int oraOrologio = t.Hour;
            if (t.Hour > 12)
            {
                oraOrologio = oraOrologio - 12;


            }


                double xp = xc+raggio * Math.Cos(oraOrologio * (Math.PI / 6))+(Math.PI/2);
                double yp = yc-raggio * Math.Sin(oraOrologio * (Math.PI / 6))+(Math.PI / 2);
                d.DrawLine(lancetta, xc, yc, (float)xp+208, (float)yp+208);




            }
        }
    
}
