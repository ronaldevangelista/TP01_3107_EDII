using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_3107_EDII
{
    internal class Vendedores
    {
        //ATRIBUTOS
        private Vendedor[] osVendedores = new Vendedor[10];
        private int qtde = 0;
        private const int max = 10;

        //METODOS PROPRIEDADES (GET E SET)
        internal Vendedor[] OsVendedores { get => osVendedores; set => osVendedores = value; }
        public int Qtde { get => qtde; set => qtde = value; }

        //CONSTRUTORES
        public Vendedores() 
        {
            for(int i = 0; i < max; i++)
            {
                OsVendedores[i] = new Vendedor();
            }
        }

        public Vendedores(Vendedor[] osVendedores)
        {
            OsVendedores = osVendedores;
        }

        //METODOS

        //Adiciona/Substitue o Vendedor
        public bool addVendedor(Vendedor v)
        {
            int i = -1;

            do
            {
                i++;
            } while (i < 9 && (osVendedores[i].Nome != "" && osVendedores[i].Nome != v.Nome));

            if (osVendedores[i].Nome != "")
            {
                return false;
            } else
            {
                osVendedores[i] = v;
                return true;
            }
        }

        public bool delVendedor(Vendedor v)
        {
            int i = -1;

            do
            {
                i++;
            } while (i < 9 && osVendedores[i].Nome != v.Nome);


            if (osVendedores[i].Nome != v.Nome)
            {
                return false;
            }
            //Se achado, verifica se houve venda
            else
            {
                //Se não houve, faz a exclusão
                if (OsVendedores[i].valorVendas() == 0)
                {
                    OsVendedores[i].Nome = "";
                    osVendedores[i].PercComissao = 0;
                    return true;
                }
                //Se houve, retorna falso
                else
                {
                    return false;
                }
            }
        }

        //PROCURA E RETORNA O OBJ VENDEDOR
        public Vendedor searchVendedor(Vendedor v)
        {
            int i = 0;
            //Procura pelo nome em todo array
            while (i < max && OsVendedores[i].Equals(v) == false)
            {
                i++;
            }

            //Se não for achado, retorna um obj com atributo nome = "Não Encontrado"
            if (OsVendedores[i].Equals(v) == false)
            {
                v.Nome = "Não encontrado";
                return v;
            }
            //Se achado, retorna o obj vendedor
            else
            {
                return OsVendedores[i];
            }
        }
        public double valorVendas()
        {

            double valorVendas = 0;
            foreach (Vendedor v in osVendedores)
            {
                valorVendas += v.valorVendas();
            }
            return valorVendas;
        }

        public double valorComissao()
        {
            double valorComissao = 0;
            foreach (Vendedor v in osVendedores)
            {
                valorComissao += v.valorComissao();
            }
            return valorComissao;
        }
    }
}
