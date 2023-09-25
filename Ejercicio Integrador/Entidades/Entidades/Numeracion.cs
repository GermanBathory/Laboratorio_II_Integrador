using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numeracion
    {
        public enum ESistema { Decimal, Binario };
        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema
        {
            get
            {
                return sistema;
            }
        }
        public string Valor
        {
            get
            {
                return this.valorNumerico.ToString();
            }
        }

        private double BinarioADecimal(string valor)
        {
            double aux;
            double.TryParse(valor, out aux);
            int resto;
            int potencia = 0;
            double acumulador = 0;

            do
            {
                resto = (int)aux % 10;
                aux = aux / 10;
                aux = Math.Floor(aux);
                acumulador += (double)(resto * Math.Pow(2, potencia));
                potencia++;

            } while (aux != 0);

            return acumulador;
        }

        private static string DecimalABinario(int valor)
        {
            string retornoDecimalBinario = string.Empty;

            while (valor != 0)
            {
                if (valor % 2 == 0)
                {
                    retornoDecimalBinario = "0" + retornoDecimalBinario;
                }
                else
                {
                    retornoDecimalBinario = "1" + retornoDecimalBinario;
                }
                valor /= 2;

            }
            return retornoDecimalBinario;
        }
        private string DecimalABinario(string valor)
        {
            if (int.TryParse(valor, out int val))
            {
                return Numeracion.DecimalABinario(val);
            }
            return "Error";
        }

        private bool EsBinario(string valor)
        {
            foreach (var item in valor)
            {
                if (!(item == '0' || item == '1'))
                {
                    return false;
                }
            }
            return true;
        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            double val;
            if (EsBinario(valor))
            {
                val = BinarioADecimal(valor);
                this.valorNumerico = val;
            }
            else if (!(double.TryParse(valor, out val)))
            {
                this.valorNumerico = double.MinValue;
            }
            else
            {
                this.valorNumerico = val;
            }
            this.sistema = sistema;
        }

        public Numeracion(double valor, ESistema sistema)
        {
            this.sistema = sistema;
            this.valorNumerico = valor;
        }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        /* public string ConvertirA(ESistema sistema)
         {

         }*/
        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return !(sistema == numeracion.sistema);
        }
        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return (sistema == numeracion.sistema);
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }
        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return (n1 == n2);
        }

        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            return n1 - n2;
        }
        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            return n1 * n2;
        }
        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            return n1 / n2;
        }
        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            return n1 + n2;
        }
    }
}
