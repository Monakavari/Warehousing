namespace Warehousing.ApplicationService.ViewModels
{
    public class GetUserResponseVM
    {
        public string Id { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public string BirthDate { get; set; }
        public bool Gender { get; set; }

        //Admin = 1
        //User = 2
        public byte UserType { get; set; }
    }
}
