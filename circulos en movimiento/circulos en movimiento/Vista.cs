using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace circulos_en_movimiento
{
    class Vista
    {

        private Graphics g;
        private int anchura, altura;
        private Pen Lapiz;
        public Color ColorLapiz { get; set; }
        public Vista(Panel panel1)
        {
            g = panel1.CreateGraphics();
            anchura = panel1.Width;
            altura = panel1.Height;
        }

        public void mostrar_Rectangulo(Rectangulo r)
        {
            Lapiz = new Pen(ColorLapiz, 3);
            g.DrawRectangle(Lapiz, r.P1.X, r.P1.Y, r.ancho(), r.alto());

        }

        public void mostrar_circulo(Circulo c)
        {
            g.DrawEllipse(new Pen(ColorLapiz, 3), c.centro.X, c.centro.Y, c.radio, c.radio);

        }

        public void borrar()
        {

            SolidBrush fondo = new SolidBrush(Color.LightSteelBlue);
            Rectangle rec = new Rectangle(0, 0, anchura, altura);
            g.FillRectangle(fondo, rec);

        }



    }//fin del namespace 
}//fin de la clase 
