using System;
using System.Windows.Forms;

namespace ELECKIT
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar splash screen de forma modal (bloquea hasta cerrar)
            using (var splash = new splashscreen())
            {
                splash.ShowDialog();
            }

            // Después de cerrar la splash, abrir login (ventana principal)
            Application.Run(new login());
        }
    }
}
