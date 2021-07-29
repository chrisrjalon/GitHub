using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces;
using GitHub.Domain.Models;
using GitHub.Services.Interfaces;

namespace GitHub.Services.Concrete
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public UserService(IRepositoryFactory repositoryFactory) : base(repositoryFactory.UserRepository)
        {
            _repositoryFactory = repositoryFactory;
        }

        #region IUserService Members

        public async Task<ICollection<User>> GetUsersByUsernames(string[] usernames)
        {
            var uniqueUsernames = usernames.Select(u => u.ToLowerInvariant());
            var users = new List<User>();
            foreach (var username in uniqueUsernames)
            {
                var user = await _repositoryFactory.UserRepository.GetUserByUsername(username);
                users.Add(user);
            }

            return users.OrderBy(u => u.Name).ToList();
        }

        #endregion

    }
}
