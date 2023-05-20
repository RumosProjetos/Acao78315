using Gandalf.LogicaNegocio.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.LogicaNegocio.Regras
{
    //VendasManager
    public class VendasRegras
    {
        private Venda Venda { get; set; }
        private Estoque Estoque { get; set; }


        public VendasRegras(Venda venda, Estoque estoque)
        {
            Venda = venda;
            Estoque = estoque;
        }


        public bool ValidarVenda()
        {
            var retorno = true;

            if (Venda == null)
            {
                retorno = false;
                throw new ArgumentException("Faltam dados para venda.");
            }

            if (Venda.Cliente == null)
            {
                retorno = false;
                throw new ArgumentException("Cliente não selecionado");
            }

            if (Venda.Utilizador == null)
            {
                retorno = false;
                throw new ArgumentException("Utilizador não selecionado");
            }

            if (Venda.Itens.Count <= 0)
            {
                retorno = false;
                throw new ArgumentException("Uma venda precisa ter pelo menos 1 ítem");
            }

            foreach (var item in Venda.Itens)
            {
                if(item.Quantidade <= 0)
                {
                    retorno = false;
                    throw new ArgumentException("Um ítem de venda precisa ter pelo menos 1 unidade");
                }
            }

            //Posso utilizar LINQ / LambdaExpression para facilitar
            //if (Venda.Itens.Any(x => x.Quantidade <= 0))
            //{
            //    retorno = false;
            //    throw new ArgumentException("Um ítem de venda precisa ter pelo menos 1 unidade");
            //}

            foreach (var item in Venda.Itens)
            {
                var quantidadeDisponivel = Estoque.Disponibilidade.FirstOrDefault(x => x.Key == item.Produto).Value;
                if (quantidadeDisponivel <= item.Quantidade)
                {
                    retorno = false;
                    throw new ArgumentException($"Só estão disponíveis {quantidadeDisponivel} do produto {item.Produto.Nome} no estoque");
                }
            }

            return retorno;
        }


        public void SalvarVenda()
        {
            var caminho = @"c:\temp\Vendas\"; //Deveria vir do App.Config
            var arquivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            if (ValidarVenda())
            {
                Console.WriteLine(Venda.ToString());


                //if (!Directory.Exists(caminho))
                //{
                //    Directory.CreateDirectory(caminho);
                //}

                //File.WriteAllText($"{caminho}{arquivo}", Venda.ToString());
            }
        }
    }
}
