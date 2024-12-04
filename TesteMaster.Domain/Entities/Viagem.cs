namespace TesteMaster.Domain.Entities
{
    public class Viagem
    {
        public int Id { get; set; }
        public List<Rota> Rotas { get; set; } = new List<Rota>();
        public decimal ValorTotal { get; set; }
    }
}
