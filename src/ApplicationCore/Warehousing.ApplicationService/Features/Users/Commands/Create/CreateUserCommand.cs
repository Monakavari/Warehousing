using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<ApiResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public bool Gender { get; set; }

        //Admin = 1
        //User = 2
        public byte UserType { get; set; }
        public List<int> UserWarehouseId { get; set; } = new();
    }
}
