using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_3107_EDII
{
    internal class Viewer
    {
        static void Main(string[] args)
        {
            bool key = false;
            Console.WriteLine("Seja bem-vindo ao nosso sisteminha fuleiro de controle de vendas");
            int id = 1;
            Vendedores loja = new Vendedores();

            do
            {
                Console.WriteLine("Menu Principal\n--- $ --- $ --- $ ---");
                Console.WriteLine("0. Sair\n1. Cadastrar Vendedor\n2. Consultar Vendedor\n3. Excluir Vendedor\n4. Registrar Venda\n5. Listar Vendedores");
                Console.Write("Selecione a sua opção: ");
                int opt = Int16.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Obrigado por usar o nosso sisteminha fuleiro de controle de vendas"); 
                        key = true;
                        break;
                    case 1:
                        Console.Write("Insira o nome do vendedor: ");
                        string nome = Console.ReadLine();
                        Console.Write("Insira o percentual de comissão: ");
                        double percComissao = Double.Parse(Console.ReadLine());
                        Vendedor vendedor = new Vendedor(id, nome, percComissao);
                        bool verify = loja.addVendedor(vendedor);

                        if (verify)
                        {
                            Console.WriteLine("Vendedor adicionado com sucesso");
                            id++;
                        }
                        else if(loja.Qtde == 10)
                        {
                            Console.WriteLine("A loja já contém a quantidade máxima de vendedores!!!\n Por favor, exclua pelo menos um!");
                        }
                        else
                        {
                            Console.WriteLine("Erro desconhecido ao adicionar vendedor");
                        }
                        Console.WriteLine("------------\n\n");
                        break;
                    case 2:
                        Console.Write("Insira o nome do vendedor: ");
                        nome = Console.ReadLine();
                        Vendedor vendedor2 = new Vendedor();
                        vendedor2.Nome = nome;
                        vendedor2 = loja.searchVendedor(vendedor2);
                        if (vendedor2.Nome != "Não encontrado")
                        {
                            Console.WriteLine("INFORMAÇÕES SOBRE O VENDEDOR:\n ID: " + vendedor2.Id);
                            Console.WriteLine("Nome: " + vendedor2.Nome);
                            Console.WriteLine("Valor de Vendas: R$" + vendedor2.valorVendas());
                            Console.WriteLine("Valor de comissão: R$" + vendedor2.valorComissao());
                            Console.WriteLine("Média diária: R$" + vendedor2.mediaVenda());
                        }
                        else { Console.WriteLine("Vendedor não encontrado"); };
                        Console.WriteLine("------------\n\n");
                        break;
                    case 3:
                        Console.Write("Insira o nome do vendedor que deseja excluir: ");
                        nome = Console.ReadLine();
                        Vendedor vendedor3 = new Vendedor();
                        vendedor3.Nome = nome;
                        if(loja.searchVendedor(vendedor3).valorVendas() > 0)
                        {
                            Console.WriteLine("Impossível apagar um vendedor que já tenha realizado uma venda!");
                        }
                        else
                        {
                            verify = loja.delVendedor(vendedor3);
                            if (verify)
                            {
                                Console.WriteLine("Deletado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Erro ao deletar, por favor contacte o suporte.");
                            }
                        }
                        Console.WriteLine("------------\n\n");
                        break;
                    case 4:
                        Console.Write("Insira o nome do vendedor: ");
                        nome = Console.ReadLine();
                        Vendedor vendedor4 = new Vendedor();
                        vendedor4.Nome = nome;
                        if (loja.searchVendedor(vendedor4).Nome == "Não encontrado")
                        {
                            Console.WriteLine("Vendedor não encontrado");
                            break;
                        }

                        Console.Write("Insira o dia em que foi vendido: ");
                        int dia = Int16.Parse(Console.ReadLine());
                        Console.Write("Insira a quantidade de produtos vendidos: ");
                        int qtde = Int16.Parse(Console.ReadLine());
                        Console.Write("Insira o valor dos produtos vendidos: R$");
                        double valor = Int16.Parse(Console.ReadLine());
                        Venda venda = new Venda(qtde, valor);
                        vendedor4 = loja.searchVendedor(vendedor4);
                        vendedor4.registarVenda(dia, venda);
                        if (loja.addVendedor(vendedor4))
                        {
                            Console.WriteLine("Venda registrada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao registrar venda");
                        }
                        break;
                    case 5:
                        Vendedor[] osVendedores = loja.OsVendedores;
                        foreach (Vendedor vendedor5 in osVendedores)
                        {
                            Console.WriteLine("INFORMAÇÕES SOBRE O VENDEDOR:\nID: " + vendedor5.Id);
                            Console.WriteLine("Nome: " + vendedor5.Nome);
                            Console.WriteLine("Valor de Vendas: R$" + vendedor5.valorVendas());
                            Console.WriteLine("Valor de comissão: R$" + vendedor5.valorComissao());
                        }
                        Console.WriteLine("\n---- VALORES DA LOJA ----");
                        Console.WriteLine("Total de Vendas: R$" + loja.valorVendas());
                        Console.WriteLine("Total de Comissões: R$" + loja.valorComissao());
                        break;
                    default: Console.WriteLine("Opção inválida"); break;
                }

            } while (key == false);
        }
    }
}
