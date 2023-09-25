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
            if (valor >= 0)
            {
                do
                {
                    retornoDecimalBinario = (valor % 2) + retornoDecimalBinario;
                    valor /= 2;
                }
                while (valor >= 2);
                retornoDecimalBinario = valor + retornoDecimalBinario;

                return retornoDecimalBinario;
            }
            else
            {
                return "Numero invalido";
            }
        }
        private string DecimalABinario(string valor)
        {
            if (!(int.TryParse(valor, out int val) && val < 0))
            {
                return Numeracion.DecimalABinario(val);
            }
            return "Numero invalido";
        }

        private bool EsBinario(string valor)
        {
            foreach (char item in valor)
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
            if (EsBinario(valor) && sistema == ESistema.Binario)
            {
                this.valorNumerico = BinarioADecimal(valor);
            }
            else if (!(double.TryParse(valor, out valorNumerico)))
            {
                this.valorNumerico = double.MinValue;
            }
            this.sistema = sistema;
        }

        public Numeracion(double valor, ESistema sistema)
        : this(valor.ToString(), sistema)
        {
        }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        public string ConvertirA(ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                return this.valorNumerico.ToString();
            }
            else
            {
                return this.DecimalABinario(valorNumerico.ToString());
            }
        }
        
        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return (sistema == numeracion.sistema);
        }
        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return !(sistema == numeracion);
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return (n1.sistema == n2.sistema);
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }

        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            return new Numeracion(n1.valorNumerico - n2.valorNumerico, ESistema.Decimal);
        }
        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            return new Numeracion(n1.valorNumerico * n2.valorNumerico, ESistema.Decimal);
        }
        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            return new Numeracion(n1.valorNumerico / n2.valorNumerico, ESistema.Decimal);
        }
        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            return new Numeracion(n1.valorNumerico + n2.valorNumerico, ESistema.Decimal);
        }
    }
}
