using Gandalf.LogicaNegocio.Modelo;
using Gandalf.LogicaNegocio.Regras;
using System;
using System.Collections.Generic;

namespace Gandalf.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var televisao = new Produto
            {
                Categoria = "Televisao",
                Marca = "LG",
                Nome = "24 polegadas",
                Id = 1
            };

            var playstation = new Produto
            {
                Categoria = "Playstation",
                Marca = "SONY",
                Nome = "Playstation 5",
                Id = 2
            };

            var geladeira = new Produto
            {
                Categoria = "Geladeira",
                Marca = "LG",
                Nome = "Geladeira FrostFree",
                Id = 3
            };

            var estoque = new Estoque();
            estoque.Disponibilidade.Add(televisao, 10);
            estoque.Disponibilidade.Add(playstation, 5);
            estoque.Disponibilidade.Add(geladeira, 2);



            var venda1 = new Venda
            {
                Utilizador = new Utilizador { Nome = "Rui" },
                Cliente = new Cliente { Id = 1, Nome = "Joao" },
                DataHora = new DateTime(2023, 05, 19, 18, 05, 01),
                Itens = new List<Item>
                {
                    new Item { Produto = playstation, Quantidade = 1, ValorUnitario = 500 },
                    new Item { Produto = televisao, Quantidade = 2, ValorUnitario = 100 }
                }
            };

            var regraVendas = new VendasRegras(venda1, estoque);
            regraVendas.SalvarVenda();


            var venda2 = new Venda
            {
                Utilizador = new Utilizador { Nome = "Maria" },
                Cliente = new Cliente { Id = 2, Nome = "Nuno" },
                DataHora = new DateTime(2023, 05, 20, 11, 05, 01),
                Itens = new List<Item>
                {
                    new Item { Produto = televisao, Quantidade = 1, ValorUnitario = 100 },
                    new Item { Produto = geladeira, Quantidade = 1, ValorUnitario = 150 }
                }
            };
            regraVendas = new VendasRegras(venda2, estoque);
            regraVendas.SalvarVenda();
        }
    }
}
