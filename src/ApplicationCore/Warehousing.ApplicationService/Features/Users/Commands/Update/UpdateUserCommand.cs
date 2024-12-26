using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<ApiResponse>
    {
        // کاربری که اطلاعاتش در حال ویرایش است
        public string UserIdInWarehouse { get; set; }
        public List<int> UserWarehouseId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
