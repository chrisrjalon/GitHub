using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Services.Interfaces;

namespace GitHub.Services.Concrete
{
    public class ServiceFactory : IServiceFactory
    {
        public ServiceFactory(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }
    }
}
