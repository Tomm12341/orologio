using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Graphics ee= this.CreateGraphics();
            g.DrawEllipse(p, x, y, diametro-3, diametro-3);
            const double angolo = (5.0d / 4.0d) * Math.PI;
            for (int i = 0; i < 11; i++)
            {
                float x1 = (float)Math.Cos(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 195.0f + 200.0f;
                float y1 = (float)Math.Abs(Math.Sin(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 195.0f - 200.0f);
                float x2 = (float)Math.Cos(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 180.0f + 200.0f;
                float y2 = (float)Math.Abs(Math.Sin(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 180.0f - 200.0f);
                ee.DrawLine(p, x1, y1, x2, y2);

                float x3 = (float)Math.Cos(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 215.0f + 200.0f + pictureBox1.Location.X;
                float y3 = (float)Math.Abs(Math.Sin(angolo - ((3.0d / 2.0d) * Math.PI / 10.0d) * i) * 215.0f - 200.0f) + pictureBox1.Location.Y;
            }

                //APPUNTI per operazioni matematiche : 

                //( 2PI*((x-10)/2) )/12  è la lunghezza dell'arco che forma ogni "minuto"

                //l'angolo che forma è (2PI*(( 2PI*((x-10)/2) )/12) ) / ( PI*((x-10)/2) )/12)^2)
                // l'angolo aumenta andando in senso orario 

            }
    }
}
