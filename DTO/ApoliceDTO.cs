namespace DTO
{
    public class ApoliceDTO
    {
        public int ID { get; set; }
        public int NumeroApolice { get; set; }
        public long CpfCnpj { get; set; }
        public string PlacaVeiculo { get; set; }
        public double ValorPremio { get; set; }
        public ApoliceDTO()
        {

        }

        public ApoliceDTO(int id, int numeroApolice)
        {
            this.ID = id;
            this.NumeroApolice = numeroApolice;
        }        
    }
}
