namespace pryBravoGimnasioSiglo
{
    public partial class FrmInscripcion : Form
    {
        const int MUSCULACION = 15000;
        const int FUNCIONAL = 18000;
        const int NATACION = 22000;

        const string MANANA = "Mañana";
        const string TARDE = "Tarde";
        const string NOCHE = "Noche";

        const int EDAD_MINIMA = 14;

        const int CASILLERO = 3000;

        const int MENOR_DIECIOCHO = 25;
        const int DESCUENTO_MAYOR_EDAD = 30;
        const int DESCUENTO_ESTUDIANTE = 25;

        const int DESCUENTO_EFECTIVO = 10;

        const int UNA_CUOTA = 0;
        const int TRES_CUOTAS = 10;
        const int SEIS_CUOTAS = 20;




        public FrmInscripcion()
        {
            InitializeComponent();
        }

        private void EstadoInicial()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            chkEstudiante.Checked = false;

            cmbPlan.SelectedIndex = -1;
            cmbTurno.SelectedIndex = -1;
            txtMes.Text = "1";
            chkCasillero.Checked = false;



        }

        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMes_TextChanged(object sender, EventArgs e)
        {
            int num = int.Parse(txtMes.Text);
            if (num > 12 || num < 1)
            {
                MessageBox.Show("Mes invalido");
                return;
            }
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar == (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }
    }
}
