//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Warehousing.Common.Utilities.Extensions;
//using Warehousing.Domain.Entities;

//namespace Warehousing.DataAccess.EF.Configurations
//{
//    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUsers>
//    {
//        public void Configure(EntityTypeBuilder<ApplicationUsers> builder)
//        {
//            var hasher = new PasswordHasher<ApplicationUsers>();

//            builder.HasData(new ApplicationUsers
//            {
//                Id = "171d6590-f077-4b83-a515-784bda3717b5",
//                Email = "admin@localhost.com",
//                NormalizedEmail = "ADMIN@LOCALHOST.COM",
//                FirstName = "Admin",
//                LastName = "Adminian",
//                NationalCode = "1990303161",
//                PersonalCode = "10100",
//                UserImage="default.jpg",
//                UserType=1,
//                Gender = true,
//                UserName = "Admin@localhost.com",
//                NormalizedUserName = "ADMIN@LOCALHOST.COM",
//                PasswordHash = hasher.HashPassword(null, "Password@*"),
//                EmailConfirmed = true
//            });

//            builder.HasData(new ApplicationUsers
//            {
//                Id = "810510ff-c06a-455d-bd7c-9b8bb641bec9",
//                Email = "user@localhost.com",
//                NormalizedEmail = "USER@LOCALHOST.COM",
//                FirstName = "System",
//                LastName = "User",
//                NationalCode = "1990303162",
//                PersonalCode = "10101",
//                UserImage = "default1.jpg",
//                UserType = 2,
//                Gender = true,
//                UserName = "user@localhost.com",
//                NormalizedUserName = "USER@LOCALHOST.COM",
//                PasswordHash = hasher.HashPassword(null, "Password@*"),
//                EmailConfirmed = true
//            });
//        }
//    }
//}
