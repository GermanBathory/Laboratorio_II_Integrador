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
            if (!(double.TryParse(txtPrimerOperador.Text, out double primerOperador)) || !(double.TryParse(txtSegundoOperador.Text, out double segundoOperador)))
            {
                MessageBox.Show("Ingrese números válidos", "Aceptar", MessageBoxButtons.OK);
                this.resultado = null;
            }
            else if (primerOperando is not null && segundoOperando is not null)
            {
                this.calculadora = new Operacion(primerOperando, segundoOperando);
                this.resultado = calculadora.Operar(cmbOperacion.Text[0]);
                SetResultado();
            }
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperacion.SelectedIndex = 0;
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
                sistema = Numeracion.ESistema.Binario;
                SetResultado();
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked)
            {
                sistema = Numeracion.ESistema.Decimal;
                SetResultado();
            }
        }

        private void SetResultado()
        {
            if (this.resultado is not null)
            {
                lblResultado.Text = "Resultado: " + this.resultado.ConvertirA(sistema);
            }

        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            primerOperando = new(txtPrimerOperador.Text, Numeracion.ESistema.Decimal);
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            segundoOperando = new(txtSegundoOperador.Text, Numeracion.ESistema.Decimal);

        }
    }
}