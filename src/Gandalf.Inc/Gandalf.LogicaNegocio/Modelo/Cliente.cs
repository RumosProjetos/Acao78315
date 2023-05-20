namespace Gandalf.LogicaNegocio.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroIdentificacaoFiscal { get; set; }      
        public string Nacionalidade { get; set; }        
        public string Telefone { get; set; }
        public Morada Morada { get; set; }
    }
}
