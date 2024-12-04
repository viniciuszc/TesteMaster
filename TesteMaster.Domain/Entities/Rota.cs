using System.Text.Json.Serialization;

namespace TesteMaster.Domain.Entities
{
    public class Rota
    {
        public int Id { get; set; }
        public Localizacao Origem { get; set; }
        public Localizacao Destino { get; set; }
        public decimal Valor { get; set; }
        [JsonIgnore]
        public List<Viagem> Viagens { get; } = [];
    }
}
