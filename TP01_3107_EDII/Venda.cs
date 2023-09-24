using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_3107_EDII
{
    internal class Venda
    {
        //ATRIBUTOS
        private int qtde;
        private double valor = 0;

        //CONSTRUTORES
        public Venda() { }
        public Venda(int qtde, double valor)
        {
            Qtde = qtde;
            Valor = valor;
        }

        //METODOS PROPRIEDADES (SET E GET)
        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }

        //RETORNA VALOR MEDIO (CASO QTDE NÃO EXPRESSA, RETORNA APENAS O VALOR DA VENDA)
        public double valorMedio()
        {
            if(Qtde < 1)
            {
                return Valor;
            }
            else
            {
                return Valor/Qtde;
            }
        }
    }
}
