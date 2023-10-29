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

          
            g.DrawEllipse(p, x, y, diametro, diametro);
       

            //APPUNTI per operazioni matematiche : 

            //( 2PI*((x-10)/2) )/12  è la lunghezza dell'arco che forma ogni "minuto"

            //l'angolo che forma è (2PI*(( 2PI*((x-10)/2) )/12) ) / ( PI*((x-10)/2) )/12)^2)
            // l'angolo aumenta andando in senso orario 

        }
    }
}
