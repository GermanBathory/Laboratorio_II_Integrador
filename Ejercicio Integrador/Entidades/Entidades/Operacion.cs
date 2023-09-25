namespace Entidades
{
    public class Operacion

    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

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

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }

        public Numeracion Operar(char operador)
        {
                   
        }
    }
}