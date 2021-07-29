using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHub.Domain.Models
{
    public class User
    {

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Company { get; set; }

        [JsonProperty]
        public int Followers { get; set; }

        [JsonProperty(PropertyName = "public_repos")]
        public int PublicRepos { get; set; }

        public decimal AverageFollowers => PublicRepos != 0 ? (decimal) Followers / PublicRepos : 0;
    }
}
