using System.Collections.Generic;

namespace Gandalf.LogicaNegocio.Modelo
{
    public class Estoque
    {
        public Estoque()
        {
            Disponibilidade = new Dictionary<Produto, int>();
        }
        public Dictionary<Produto, int> Disponibilidade { get; set; }
    }
}