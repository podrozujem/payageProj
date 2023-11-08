namespace IntegrationLibrary.Core.Model
{
    public class BloodBank
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string ServerAddress { get; set; }
        public string ApiKey { get; set; }
    }
}