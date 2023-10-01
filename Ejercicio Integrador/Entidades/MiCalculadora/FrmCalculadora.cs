using Entidades;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        private Operacion? calculadora;
        private Numeracion? primerOperando;
        private Numeracion? segundoOperando;
        private Numeracion? resultado;
        private Numeracion.ESistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrimerOperador.Clear();
            txtSegundoOperador.Clear();
            cmbOperacion.SelectedIndex = 0;
            this.resultado = null;
            lblResultado.Text = "Resultado:";
            rdbDecimal.Checked = true;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPrimerOperador.Text, out double primerOperador) || !(double.TryParse(txtSegundoOperador.Text, out double segundoOperador)))
            {
                MessageBox.Show("Ingrese números válidos", "Aceptar", MessageBoxButtons.OK);
                this.resultado = null;
            }
            else if (primerOperando is not null && segundoOperando is not null)
            {
                char.TryParse(cmbOperacion.SelectedItem.ToString(), out char operador);
                this.calculadora = new Operacion(primerOperando, segundoOperando);
                this.resultado = calculadora.Operar(operador);
                SetResultado();
            }
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperacion.SelectedIndex = 0;
            rdbDecimal.Checked = true;
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cerrar la calculadora?", "Cierre",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked)
            {
                this.sistema = Numeracion.ESistema.Binario;
                SetResultado();

            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked)
            {
                this.sistema = Numeracion.ESistema.Decimal;
                SetResultado();
            }
        }

        private void SetResultado()
        {
            if (resultado is not null)
            {
                lblResultado.Text = "Resultado: " + resultado.ConvertirA(sistema);
                if ((string)cmbOperacion.SelectedItem == "/" && txtSegundoOperador.Text == "0")
                {
                    lblResultado.Text = "Resultado: NaN";
                }
            }
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            primerOperando = new Numeracion(txtPrimerOperador.Text, Numeracion.ESistema.Decimal);
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            segundoOperando = new Numeracion(txtSegundoOperador.Text, Numeracion.ESistema.Decimal);

        }

        private void lblOperacion_Click(object sender, EventArgs e)
        {
        }
    }
}