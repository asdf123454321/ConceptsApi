namespace ConceptsApi.address.models
{
    public class Address
    {
        public int? AddressID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int? StateID { get; set; }
        public string ZipCode { get; set; }
    }
}
