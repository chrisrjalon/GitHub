using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Domain.Interfaces
{
    public interface IRepositoryFactory
    {
        IUserRepository UserRepository { get; }
    }
}
