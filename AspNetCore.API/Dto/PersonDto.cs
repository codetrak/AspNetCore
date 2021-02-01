namespace AspNetCore.API.Dto
{
    public class PersonDto
    {
        public int EntityID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}