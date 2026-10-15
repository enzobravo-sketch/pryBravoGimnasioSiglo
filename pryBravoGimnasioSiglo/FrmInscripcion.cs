using System.Drawing.Text;

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
            txtEdad.MaxLength = 2;
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int edad = int.Parse(txtEdad.Text);
            int mes = int.Parse(txtMes.Text);

            decimal precioMensual = 0m;
            decimal porcentajeDescuento = 0m;
            decimal porcentajeAjustePago = 0m;
            decimal total = 0m;
            decimal valorCuota = 0m;

            int Edad = int.Parse(txtEdad.Text);
            int Mes = int.Parse(txtMes.Text);

            const int EDAD_MINIMA = 14;

            if (Edad < EDAD_MINIMA)
            {
                MessageBox.Show("La edad mínima para inscribirse es de 14 años.");
                return;
            }

            if (Mes < 1 || Mes > 12)
            {
                MessageBox.Show("El mes debe estar entre 1 y 12.");
                return;
            }

            string planSeleccionado = cmbPlan.SelectedItem?.ToString();
            decimal precioMes = 0m;

            switch(planSeleccionado)
            {
                case "Plan Musculacion":
                    precioMes = 15000;
                    break;
                case "Plan Funcional":
                    precioMes = 18000;
                    break;
                case "Plan Natación":
                    precioMes = 22000;
                    break;

                default:
                    MessageBox.Show("Plan inválido.");
                    break;
            }


            string horarioTurno = "";

            
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtEdad.Text) &&
                !string.IsNullOrWhiteSpace(txtMes.Text))
            {
                btnCalcular.Enabled = true;
            }
            else
            {
                btnCalcular.Enabled = false;
            }
        }
}
