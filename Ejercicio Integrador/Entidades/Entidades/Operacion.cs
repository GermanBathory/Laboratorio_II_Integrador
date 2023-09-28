namespace Entidades
{
    public class Operacion

    {
        //CAMPOS
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        //PROPIEDADES
        public Numeracion PrimerOperando
        {
            get
            {
                return primerOperando;
            }
            set
            {
                primerOperando = value;
            }
        }
        public Numeracion SegundoOperando
        {
            get
            {
                return segundoOperando;
            }
            set
            {
                segundoOperando = value;
            }
        }

        //CONSTRUCTOR
        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }

        //METODOS

        /// <summary>
        /// Realiza una operación, según el operador que se le indique, con los dos operandos de la clase
        /// </summary>
        /// <param name="operador">Caracter que indica el tipo de operacion a realizar</param>
        /// <returns>El resultado de la operación que corresponda</returns>
        public Numeracion Operar(char operador)
        {
            switch (operador)
            {
                case '-':
                    return primerOperando - segundoOperando;
                case '*':
                    return primerOperando * segundoOperando;
                case '/':
                    if (segundoOperando.Valor != "0")
                    {
                        return primerOperando / segundoOperando;
                    }
                    return new Numeracion (double.NaN, Numeracion.ESistema.Decimal);
                    
                default:
                    return primerOperando + segundoOperando;
            }
        }
    }
}