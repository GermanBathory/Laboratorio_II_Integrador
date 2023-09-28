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
        //CAMPOS
        public enum ESistema { Decimal, Binario };
        private ESistema sistema;
        private double valorNumerico;

        //PROPIEDADES
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

        //CONSTRUCTORES
        public Numeracion(double valor, ESistema sistema)
        : this(valor.ToString(), sistema) { }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        //METODOS

        /// <summary>
        /// Convierte un numero binario, ingresado como string, a un numero decimal
        /// </summary>
        /// <param name="valor">Cadena con numero binario ingresado</param> 
        /// <returns>Numero convertido a decimal</returns>
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

        /// <summary>
        /// Convierte un numero decimal, a un numero binario en formato string
        /// </summary>
        /// <param name="valor">Numero decimal ingresado</param>
        /// <returns>Cadena con numero convertido a binario</returns>
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

        /// <summary>
        /// Convierte un numero decimal, ingresado como string, a un numero binario en formato string
        /// </summary>
        /// <param name="valor">Cadena con numero en decimal</param>
        /// <returns>Cadena con numero convertido a binario</returns>
        private string DecimalABinario(string valor)
        {
            if (!(int.TryParse(valor, out int val) && val < 0))
            {
                return Numeracion.DecimalABinario(val);
            }
            return "Numero invalido";
        }

        /// <summary>
        /// Valida si un numero ingresado como string es binario o no
        /// </summary>
        /// <param name="valor">Cadena con numero binario ingresado</param>
        /// <returns>True si es binario o False si no lo es</returns>
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

        /// <summary>
        /// Inicializa los valores de los campos
        /// </summary>
        /// <param name="valor">Cadena con valor numerico decimal o binario</param>
        /// <param name="sistema">Tipo de sistema con el que trabaja (decimal o binario)</param>
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

        /// <summary>
        /// Convierte al sistema indicado, si es decimal lo deja por defecto, si es binario lo convierte
        /// </summary>
        /// <param name="sistema">Tipo de sistema con el que trabajará</param>
        /// <returns>Cadena con valor numérico en el sistema indicado</returns>
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

        //OPERADORES
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
