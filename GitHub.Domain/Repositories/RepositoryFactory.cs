using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces;

namespace GitHub.Domain.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {

        public RepositoryFactory(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }
    }
}
