using System;
using System.Drawing;
using System.Windows.Forms;

namespace ELECKIT
{
    public partial class splashscreen : Form
    {
        Timer timer = new Timer();
        int progreso = 0;

        public splashscreen()
        {
            InitializeComponent();
            this.Load += splashscreen_Load;
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Color verde (puede variar según el sistema)
            progressBar1.ForeColor = Color.LimeGreen;

            timer.Interval = 40; // 100 pasos * 40ms = 4000 ms (4 segundos)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progreso < 100)
            {
                progreso++;
                progressBar1.Value = progreso;
            }
            else
            {
                timer.Stop();

                // Cierra la splashscreen para terminar ShowDialog o liberar el hilo principal
                this.Close();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Código opcional para clic en el logo
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Código opcional para clic en texto "Cargando..."
        }
    }
}
