namespace Backend.Application.Dtos
{
    public class ProdutoDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
