namespace CustomerInfo.UI.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public DateTime InstallationDate { get; set; }
    }
}
