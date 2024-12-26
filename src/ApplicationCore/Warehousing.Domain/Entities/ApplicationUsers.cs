using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Warehousing.Domain.Entities
{
    public class ApplicationUsers : IdentityUser<string>
    {
        //public ApplicationUsers()
        //{
        //    UserWarehouses = new List<UserWarehouse>();
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }

        //Admin = 1
        //User = 2
        public byte UserType { get; set; }
        //public virtual ICollection<UserWarehouse> UserWarehouses { get; set; }
    }
}
