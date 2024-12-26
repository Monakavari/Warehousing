using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class UserRepository : BaseRepository<ApplicationUsers>, IUserRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        private readonly UserManager<ApplicationUsers> _userManager;
        public UserRepository(WarehousingDbContext context,
                              UserManager<ApplicationUsers> userManager) : base(context)
        {
            _dbContext = context;
            _userManager = userManager;
        }
        #endregion Constructor
        public async Task<bool> IsExistUserName(string userName, string nationalCode, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                                       .Where(x => x.UserName == userName ||
                                                   x.NationalCode == nationalCode)
                                       .AnyAsync(cancellationToken);
        }
        public async Task AddRoleToUser(ApplicationUsers user)
        {
            if (user.UserType == 1)
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "user");
            }
        }
    }
}

