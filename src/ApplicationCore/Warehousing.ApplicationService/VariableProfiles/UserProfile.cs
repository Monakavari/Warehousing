using Warehousing.ApplicationService.Features.Users.Commands.Create;
using Warehousing.ApplicationService.Features.Users.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class UserProfile
    {
        public static ApplicationUsers Map(CreateUserCommand command)
        {
            return new ApplicationUsers
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserImage = command.UserImage,
                NationalCode = command.NationalCode,
                PersonalCode = command.PersonalCode,
                BirthDate = PersianDate.ToMiladi(command.BirthDate),
                Gender = command.Gender,
                UserType = command.UserType,
                //WarehouseIds = new List<WarehouseId>()
            };
        }
        public static ApplicationUsers Map(UpdateUserCommand command)
        {
            return new ApplicationUsers
            {
                Id = command.UserIdInWarehouse,
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserImage = command.UserImage,
                NationalCode = command.NationalCode,
                PersonalCode = command.PersonalCode,
                BirthDate = PersianDate.ToMiladi(command.BirthDate),
                Gender = command.Gender,
                // ModifierUserId
            };
        }
        public static GetUserResponseVM Map(ApplicationUsers command)
        {
            return new GetUserResponseVM
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserImage = command.UserImage,
                NationalCode = command.NationalCode,
                PersonalCode = command.PersonalCode,
                BirthDate = PersianDate.ToShamsi(command.BirthDate),
                Gender = command.Gender,
                UserType = command.UserType,
            };
        }
    }
}

