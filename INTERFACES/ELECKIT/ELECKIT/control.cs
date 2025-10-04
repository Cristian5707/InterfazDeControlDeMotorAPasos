using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace ELECKIT
{
    public partial class control : Form
    {
        private string direccion = "";
        private bool motorEncendido = false;
        private SerialPort serialPort;

        public control()
        {
            InitializeComponent();
            this.Load += control_Load;

            // Inicializa SerialPort (ajusta el puerto y la velocidad según tu configuración)
            serialPort = new SerialPort("COM5", 9600);
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
             
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir puerto serial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Configurar timerHora para mostrar la hora actual
            timerHora.Interval = 1000; // 1 segundo
            timerHora.Tick += timerHora_Tick;
            timerHora.Start();
        }

        private void control_Load(object sender, EventArgs e)
        {
            // Configura botones con imágenes y estilos
            btnInicio.BackgroundImage = Properties.Resources.inicio;
            btnInicio.BackgroundImageLayout = ImageLayout.Zoom;
            btnInicio.Text = "";
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.BackColor = Color.Transparent;
            btnInicio.Size = new Size(100, 100);

            btnDetener.BackgroundImage = Properties.Resources.detener;
            btnDetener.BackgroundImageLayout = ImageLayout.Zoom;
            btnDetener.Text = "";
            btnDetener.FlatStyle = FlatStyle.Flat;
            btnDetener.FlatAppearance.BorderSize = 0;
            btnDetener.BackColor = Color.Transparent;
            btnDetener.Size = new Size(100, 100);

            btnEmergencia.BackgroundImage = Properties.Resources.emergencia;
            btnEmergencia.BackgroundImageLayout = ImageLayout.Zoom;
            btnEmergencia.Text = "";
            btnEmergencia.FlatStyle = FlatStyle.Flat;
            btnEmergencia.FlatAppearance.BorderSize = 0;
            // No cambies tamaño ni color botón emergencia

            btnIzquierda.BackgroundImage = Properties.Resources.left;
            btnIzquierda.BackgroundImageLayout = ImageLayout.Zoom;
            btnIzquierda.Text = "";
            btnIzquierda.FlatStyle = FlatStyle.Flat;
            btnIzquierda.FlatAppearance.BorderSize = 0;
            btnIzquierda.BackColor = Color.Transparent;
            btnIzquierda.Size = new Size(80, 80);

            btnDerecha.BackgroundImage = Properties.Resources.right;
            btnDerecha.BackgroundImageLayout = ImageLayout.Zoom;
            btnDerecha.Text = "";
            btnDerecha.FlatStyle = FlatStyle.Flat;
            btnDerecha.FlatAppearance.BorderSize = 0;
            btnDerecha.BackColor = Color.Transparent;
            btnDerecha.Size = new Size(80, 80);

            btnRegresar.BackgroundImage = Properties.Resources.regresar;
            btnRegresar.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegresar.Text = "";
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.BackColor = Color.Transparent;
            btnRegresar.Size = new Size(80, 80);

            // Configura rango del TrackBar velocidad
            trkVelocidad.Minimum = 100;   // Máximo delay (motor lento)
            trkVelocidad.Maximum = 2000;  // Mínimo delay (motor rápido)
            trkVelocidad.Value = 1000;    // Valor inicial medio

            // Inicialmente habilitar botones de dirección y velocidad
            btnIzquierda.Enabled = true;
            btnDerecha.Enabled = true;
            trkVelocidad.Enabled = true;

            // Actualizar rpm inicial
            ActualizarRPM(trkVelocidad.Value);
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (!motorEncendido)
            {
                direccion = "izquierda";
                MessageBox.Show("Dirección: Izquierda seleccionada");
                if (serialPort.IsOpen)
                    serialPort.WriteLine("DIR IZQ");
            }
            else
            {
                MessageBox.Show("No puedes cambiar la dirección mientras el motor está encendido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (!motorEncendido)
            {
                direccion = "derecha";
                MessageBox.Show("Dirección: Derecha seleccionada");
                if (serialPort.IsOpen)
                    serialPort.WriteLine("DIR DER");
            }
            else
            {
                MessageBox.Show("No puedes cambiar la dirección mientras el motor está encendido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Debes seleccionar una dirección antes de iniciar el motor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            motorEncendido = true;
            btnIzquierda.Enabled = false;
            btnDerecha.Enabled = false;

            MessageBox.Show($"Motor iniciado hacia {direccion}");

            if (serialPort.IsOpen)
                serialPort.WriteLine("INICIO");
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (!motorEncendido)
            {
                MessageBox.Show("El motor ya está detenido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            motorEncendido = false;
            btnIzquierda.Enabled = true;
            btnDerecha.Enabled = true;

            MessageBox.Show("Motor detenido");

            if (serialPort.IsOpen)
                serialPort.WriteLine("DETENER");
        }

        private void btnEmergencia_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
                serialPort.WriteLine("EMERGENCIA");

            MessageBox.Show("¡Todos los procesos se han detenido! Debes volver a iniciar sesión.", "Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();

            login loginForm = new login();
            loginForm.ShowDialog();

            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Regresando al inicio de sesion");

            // Crear y mostrar el formulario login
            login loginForm = new login();
            loginForm.Show();

            // Cerrar el formulario actual (control)
            this.Hide();
        }

        private void trkVelocidad_Scroll(object sender, EventArgs e)
        {
            ActualizarRPM(trkVelocidad.Value);
        }

        private void ActualizarRPM(int trackValue)
        {
            // Invertir valor para que al mover a la derecha sea más rápido (menos delay)
            int delayMicroseconds = trkVelocidad.Maximum - (trackValue - trkVelocidad.Minimum);

            if (delayMicroseconds <= 0) delayMicroseconds = 1; // evitar división por cero

            int stepsPerRevolution = 200;
            int delayPorPaso = delayMicroseconds * 2; // porque el ciclo de paso es HIGH + LOW

            double rpm = (60_000_000.0) / (stepsPerRevolution * delayPorPaso);
            int rpmInt = (int)Math.Round(rpm);

            lblRPM.Text = $"RPM: {rpmInt}";

            if (serialPort.IsOpen)
                serialPort.WriteLine($"VEL {delayMicroseconds}");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // No hacer nada
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // No hacer nada
        }
        private void lblHora_Click(object sender, EventArgs e)
        {
            // No hacer nada
        }

        // Opcional: liberar puerto al cerrar la aplicación
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                serialPort.Dispose();
            }
            base.OnFormClosing(e);

            // Cierra toda la aplicación al cerrar este formulario
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
