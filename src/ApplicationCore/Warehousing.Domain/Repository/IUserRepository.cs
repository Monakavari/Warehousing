using System.Threading.Tasks;
using System.Threading;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<ApplicationUsers>
    {
        Task<bool> IsExistUserName(string userName, string nationalCode, CancellationToken cancellationToken);
        Task AddRoleToUser(ApplicationUsers user);
    }
}
