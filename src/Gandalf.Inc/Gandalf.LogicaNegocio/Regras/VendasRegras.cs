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


        private bool ValidarVenda()
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
            var arquivo = DateTime.Now.ToString("yyyyMMdd_HHmmss")+ ".txt";

            if (ValidarVenda())
            {
                if (!Directory.Exists(caminho))
                {
                    Directory.CreateDirectory(caminho);
                }

                File.WriteAllText($"{caminho}{arquivo}", Venda.ToString());
            }
        }
    }
}
