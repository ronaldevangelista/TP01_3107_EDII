using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_3107_EDII
{
    internal class Vendedor
    {
        //ATRIBUTOS
        private int id = 0;
        private string nome = "";
        private double percComissao = 0;
        private Venda[] asVendas = new Venda[31];

        //CONSTRUTORES
        public Vendedor()
        {
            for (int i = 0; i < AsVendas.Length; i++)
            {
                AsVendas[i] = new Venda();
            }
        }
        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.Nome = nome;
            this.PercComissao = percComissao;
            for (int i = 0; i < AsVendas.Length; i++)
            {
                AsVendas[i] = new Venda();
            }
        }

        //METODOS PROPRIEDADES (GET E SET)
        //Id apenas get
        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; set => asVendas = value; }

        //METODOS

        //Registra/Substitue nova venda
        public void registarVenda(int dia, Venda venda)
        {
            AsVendas[dia] = venda;
        }

        //Retorna a soma das vendas do Vendedor
        public double valorVendas()
        {
            double valorVendas = 0;
            foreach (Venda v in AsVendas)
            {
                valorVendas += v.Valor;   
            }

            return valorVendas;
        }

        //Retorna a comissao do vendedor especifico
        public double valorComissao()
        {
            return valorVendas() * (PercComissao / 100);
        }

        //Verifica se o nome é o mesmo
        public override bool Equals(object v)
        {
            return this.Nome.Equals(((Vendedor)v).Nome);
        }

        //Conta quantos dias houve vendas e faz a media do valor das vendas
        public double mediaVenda()
        {
            int dias = 0;
            double valor = 0;
            foreach (Venda d in AsVendas)
            {
                if(d.Valor != 0)
                {
                    dias++;
                    valor += d.Valor;
                }
            }
            return valor / dias;
        }
    }
}
