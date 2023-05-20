using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gandalf.LogicaNegocio.Modelo
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataHora { get; set; }
        public Utilizador Utilizador { get; set; }
        public List<Item> Itens { get; set; }
        public decimal ValorTotalVenda => Itens.Sum(x => x.ValorTotal);



        public override string ToString()
        {
            var fatura = new StringBuilder();
            fatura.AppendLine("------------------------------");
            fatura.AppendLine($"Identificação: {Id}");
            fatura.AppendLine($"Data e hora: {DataHora}");
            fatura.AppendLine($"Vendedor: {Utilizador.Nome}");
            fatura.AppendLine($"Cliente: {Cliente.Nome} \tNIF: {Cliente.NumeroIdentificacaoFiscal} \t Morada: {Cliente.Morada?.Cidade}");
            fatura.AppendLine("------------------------------");
            fatura.AppendLine("Produto \t|Quantidade \t|Preço Unitário \t|Preço Total");
            foreach ( var item in Itens ) {
                fatura.AppendLine($"{item.Produto.Nome} \t|{item.Quantidade} \t|{item.ValorUnitario} \t|{item.ValorTotal}");
            }
            fatura.AppendLine("------------------------------");
            fatura.AppendLine($"Valor da Venda: {ValorTotalVenda}");


            return fatura.ToString();
        }
    }
}