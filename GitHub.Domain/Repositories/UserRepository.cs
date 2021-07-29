using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces;
using GitHub.Domain.Models;

namespace GitHub.Domain.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private const string BaseUrl = "https://api.github.com";
        private const string Endpoint = "users";

        public async Task<User> GetUserByUsername(string username)
        {
            var url = $"{BaseUrl}/{Endpoint}/{username}";

            var headers = new Dictionary<string, string>()
            {
                {"user-agent", "asp.net"}
            };

            return await GetAsync<User>(url, headers);
        }
    }
}
