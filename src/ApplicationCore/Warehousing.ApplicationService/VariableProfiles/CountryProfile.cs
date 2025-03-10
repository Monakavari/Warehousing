﻿using Azure.Core;
using MediatR;
using Warehousing.ApplicationService.Features.Countries.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class CountryProfile
    {
        public static GetCountryResponseVM Map(Country country)
        {
            return new GetCountryResponseVM
            {
                Id = country.Id,
                Name = country.CountryName
            };
        }
      
    }
}


