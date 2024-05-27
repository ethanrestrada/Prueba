using System;
using System.Drawing;
using System.Windows.Forms;

namespace mat
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private ECGDrawer ecgDrawer;
        private int[] data; // Datos simulados del ECG

        public Form1()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // Configurar el formulario
            this.Text = "Electrocardiograma";
            this.ClientSize = new Size(800, 400);

            // Configurar el temporizador
            timer = new Timer();
            timer.Interval = 10; // Intervalo de actualización en milisegundos
            timer.Tick += Timer_Tick;

            // Simular datos del ECG
            data = new int[800];
            Random rnd = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rnd.Next(50) + 100; // Valores entre 100 y 150
            }

            // Inicializar el ECGDrawer
            ecgDrawer = new ECGDrawer(data);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Redibujar el gráfico
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar el ECG
            ecgDrawer.DrawECG(e.Graphics, this.ClientRectangle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }

}