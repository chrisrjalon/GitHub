using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Models;

namespace GitHub.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<ICollection<User>> GetUsersByUsernames(string[] usernames);
    }
}
