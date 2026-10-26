using System.Drawing.Text;

namespace pryBravoGimnasioSiglo
{
    


    public struct SOCIO
    {
        public string Nombre;
        public int Edad;
        public string Plan;
        public string Turno;
        public int Meses;
        public bool Casillero;
        public bool Estudiante;
        public string FormaPago;
        public decimal Total;
        public decimal ValorCuota;
            
    }
    public partial class FrmInscripcion : Form
    {
        private SOCIO[] vectorSocios = new SOCIO[100];
        private int indiceSocio = 0;

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
        const int DESCUENTO_ESTUDIANTE = 15;

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
            rbtEfectivo.Checked = false;


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

            ValidarCampos(sender, e);
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

            //EDAD
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
            //PLANES
            string planSeleccionado = cmbPlan.SelectedItem?.ToString();
            

            switch (planSeleccionado)
            {
                case "Musculacion":
                    precioMensual = 15000;
                    break;
                case "Funcional":
                    precioMensual = 18000;
                    break;
                case "Natacion":
                    precioMensual = 22000;
                    break;

                default:
                    MessageBox.Show("Plan inválido.");
                    break;
            }


            string horarioTurno = "";
            //TURNOS
            switch (cmbTurno.SelectedIndex)
            {
                case 0:
                    horarioTurno = "Mañana";
                    break;
                case 1:
                    horarioTurno = "Tarde";
                    break;
                case 2:
                    horarioTurno = "Noche";
                    break;
                default:
                    MessageBox.Show("Turno inválido.");
                    break;
            }
            //CASILLERO 

            if (chkCasillero.Checked) precioMensual += CASILLERO;

            //DESCUENTOS

            if (edad < 18)
            {
                porcentajeDescuento = MENOR_DIECIOCHO;
            }
            else
            {
                if (edad >= 65)
                {
                    porcentajeDescuento = DESCUENTO_MAYOR_EDAD;
                }
                else
                {
                    if (chkEstudiante.Checked)
                    {
                        porcentajeDescuento = DESCUENTO_ESTUDIANTE;
                    }
                    else
                    {
                        porcentajeDescuento = 0;
                    }
                }
            }
            decimal subtotal = precioMensual * mes;
            decimal montoConDescuento = subtotal - (subtotal * porcentajeDescuento / 100);

            //FORMA DE PAGO EFECTIVO

            if (rbtEfectivo.Checked)
            {
                porcentajeAjustePago = DESCUENTO_EFECTIVO;
            }
            else
            {
                int cuotas = int.Parse(cboCuotas.SelectedItem.ToString());
                if (cuotas == 1)
                {
                    porcentajeAjustePago = UNA_CUOTA;
                }
                else if (cuotas == 3)
                {
                    porcentajeAjustePago = TRES_CUOTAS;
                }
                else if (cuotas == 6)
                {
                    porcentajeAjustePago = SEIS_CUOTAS;
                }
            
            }
            if (rbtTarjeta.Checked)
            {
                total = montoConDescuento + (montoConDescuento * porcentajeAjustePago / 100);
            }
            else
            {
                total = montoConDescuento - (montoConDescuento * porcentajeAjustePago / 100);
            }
            //total = montoConDescuento + (montoConDescuento * porcentajeAjustePago / 100);
            //total = total + (total * porcentajeAjustePago / 100);

            //MENOR O MAYOR
            string categoriaSocio = (edad < 18) ? "Menor" : "Mayor";

            //22 TEXTO FORMA DE PAGO

            string textoFormaPago = rbtEfectivo.Checked ? "Efectivo" : $"Tarjeta en {cboCuotas.SelectedItem} cuotas";

            valorCuota = rbtEfectivo.Checked ? total : total / int.Parse(cboCuotas.SelectedItem.ToString());

            // MENSAJE
            SOCIO unSocio = new SOCIO();
            unSocio.Nombre = nombre;
            unSocio.Edad = edad;
            unSocio.Plan = planSeleccionado;
            unSocio.Turno = horarioTurno;
            unSocio.Meses = mes;
            unSocio.FormaPago = textoFormaPago;
            unSocio.Total = total;
            unSocio.ValorCuota = valorCuota;

            if (indiceSocio < vectorSocios.Length)
            {
                vectorSocios[indiceSocio] = unSocio;
                indiceSocio++;
            }
            else
            {
                MessageBox.Show("El vector está lleno.");
            }

            
            MessageBox.Show(
                $"Nombre: {unSocio.Nombre}\n" +
                $"Edad: {unSocio.Edad}\n" +
                $"Plan: {unSocio.Plan}\n" +
                $"Turno: {unSocio.Turno}\n" +
                $"Meses: {unSocio.Meses}\n" +
                $"Forma de Pago: {unSocio.FormaPago}\n" +
                $"Total a Pagar: ${unSocio.Total}\n" +
                $"Valor de la Cuota: ${unSocio.ValorCuota}");
            
            indiceSocio += 1;
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
            ValidarCampos(sender, e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);
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

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTarjeta.Checked)
            {
                cboCuotas.Enabled = true;
                cboCuotas.SelectedIndex = 0;
            }
            else
            {
                cboCuotas.Enabled = false;
                cboCuotas.SelectedIndex = -1;
            }
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtTarjeta.Checked)
            {
                ValidarCampos(sender, e);
            }
        }
    }
}
