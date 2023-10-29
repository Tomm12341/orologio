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
           
                Graphics quadrante = this.CreateGraphics();

                float x = ClientSize.Width;
                float y = ClientSize.Height ;

                Pen p = new Pen(Color.Black, 3);
                quadrante.DrawEllipse(p, 5, 5, x - 10, y - 10);

            //( 2PI*((x-10)/2) )/12  è la lunghezza dell'arco che forma ogni "minuto"

            //l'angolo che forma è (2PI*(( 2PI*((x-10)/2) )/12) ) / ( PI*((x-10)/2) )/12)^2)
            // l'angolo aumenta andando in senso orario 

        }
    }
}
