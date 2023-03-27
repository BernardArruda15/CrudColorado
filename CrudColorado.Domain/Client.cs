namespace CrudColorado.Domain
{
    public class Client
    {
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public DateTime DtInsertion { get; set; }
    }
}
