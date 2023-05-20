using Gandalf.LogicaNegocio.Modelo;
using Gandalf.LogicaNegocio.Regras;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gandalf.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Venda_EstoqueIgualAZero_GerarException()
        {
            //Não deve permitir uma venda se o estoque estiver igual a zero. 
            //Arrange
            Produto produtoIndiferente = new Produto();

            Estoque estoque = new Estoque();
            estoque.Disponibilidade.Add(produtoIndiferente, 0);

            Venda venda = new Venda { 
                Itens = new List<Item>(),
                Cliente = new Cliente(),
                Utilizador = new Utilizador()
            };
            venda.Itens.Add(new Item { Produto = produtoIndiferente, Quantidade = 1 });


            //Act
            VendasRegras vendasRegras = new VendasRegras(venda, estoque);
            bool resultadoVenda = vendasRegras.ValidarVenda();

            //Assert
            Assert.AreEqual(false, resultadoVenda);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Venda_QuantidadeItemsIgualAZero_GerarException()
        {
            //Arrange
            Produto produtoIndiferente = new Produto();
            Estoque estoque = new Estoque();
            estoque.Disponibilidade.Add(produtoIndiferente, 0);

            Venda venda = new Venda
            {
                Itens = new List<Item>(),
                Cliente = new Cliente(),
                Utilizador = new Utilizador()
            };

            //Act
            VendasRegras vendasRegras = new VendasRegras(venda, estoque);
            bool resultadoVenda = vendasRegras.ValidarVenda();

            //Assert
            Assert.AreEqual(false, resultadoVenda);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Venda_QuantidadeProdutoEmItemIgualOuMenorQueZero_GerarException()
        {
            //Arrange
            Produto produtoIndiferente = new Produto();
            Estoque estoque = new Estoque();
            estoque.Disponibilidade.Add(produtoIndiferente, 0);

            Venda venda = new Venda
            {
                Itens = new List<Item>(),
                Cliente = new Cliente(),
                Utilizador = new Utilizador()
            };
            venda.Itens.Add(new Item { Produto = produtoIndiferente, Quantidade = -1 });

            //Act
            VendasRegras vendasRegras = new VendasRegras(venda, estoque);
            bool resultadoVenda = vendasRegras.ValidarVenda();

            //Assert
            Assert.AreEqual(false, resultadoVenda);
        }
    }
}
