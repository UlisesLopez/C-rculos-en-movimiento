using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace circulos_en_movimiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Random aleatorio = new Random();
                int r = aleatorio.Next(15, 50);
                Point punto = new Point(aleatorio.Next(r, panel1.Width * r), aleatorio.Next(r, panel1.Height));
                Circulo circulo = new Circulo(r, punto);
                Task tarea = new Task(() => AnimarCirculo(circulo, new Vista(panel1)));
                tarea.Start();

            }
            else
                MessageBox.Show("La casilla de movimiento no esta seleccionada");

        }


        private void AnimarCirculo(Circulo circulo, Vista vista)
        {

            vista.ColorLapiz = Color.DarkRed;
            vista.mostrar_circulo(circulo);
            bool sentido = true;
            while (true)
            {
                while (checkBox1.Checked)
                {
                    Thread.Sleep(500);
                    vista.ColorLapiz = Color.LightSteelBlue;
                    vista.mostrar_circulo(circulo);
                    if (sentido)
                    {
                        if (circulo.centro.X <= panel1.Width - 2 * circulo.radio)
                            circulo.centro = new Point(circulo.centro.X + circulo.radio, circulo.centro.Y);
                        else
                            sentido = false;
                    }
                    else
                    {

                        if (circulo.centro.X > circulo.radio)
                            circulo.centro = new Point(circulo.centro.X - circulo.radio, circulo.centro.Y);
                        else
                            sentido = true;


                    }
                    vista.ColorLapiz = Color.DarkRed;
                    vista.mostrar_circulo(circulo);
                }
            }

        }
    }
}
/* Rectangulo rec = new Rectangulo(new Point(50, 60), new Point(350, 200));
       Color colorPluma = Color.DarkGreen;
       Vista vista = new Vista(panel1);
       vista.mostrar_Rectangulo(rec);


       Circulo circulo = new Circulo(20, new Point(340, 50));
       vista.ColorLapiz = Color.Black;
       vista.mostrar_circulo(circulo);
       bool sentido = true;
       int i;
       while (checkBox1.Checked)
       {
           i = 50;
           while (i <= 180)
           {
               if (sentido)
                   circulo.centro = new Point(circulo.centro.X, circulo.centro.Y + 10);
               else
                   circulo.centro = new Point(circulo.centro.X, circulo.centro.Y - 10);

               Thread.Sleep(500);
               vista.borrar();
               vista.ColorLapiz = Color.DarkBlue;
               vista.mostrar_circulo(circulo);
               i += 10;


           }
           i = 0;
       }*/
