using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHub.Domain.Repositories.API
{
    public abstract class ApiClient
    {

        protected static HttpClient Client = new HttpClient();

        /// <summary>
        /// Perform a Get operation on the specified Url.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null)
        {
            return await Request<T>(url, HttpMethod.Get, null, headers);
        }

        /// <summary>
        /// Execute the actual request to the Url.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<T> Request<T>(string url, HttpMethod method, string data, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(method, url);

            if (data != null)
            {
                // TODO: Write code here for adding data to the request content
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await Client.SendAsync(request);
            var jsonContent = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(jsonContent);

            return content;
        }

        /// <summary>
        /// Method to parse a URL and retrieve the value of a known parameter.
        /// </summary>
        /// <param name="url">The whole URL.</param>
        /// <param name="parameterName">Parameter name whose value will be retrieved.</param>
        /// <returns></returns>
        protected string GetParameter(string url, string parameterName)
        {
            var parameterLookup = GetParameters(url);
            if (!parameterLookup.Any() || !parameterLookup.ContainsKey(parameterName))
                return null;

            return parameterLookup[parameterName];
        }

        /// <summary>
        /// Extract all parameter from a URL.
        /// </summary>
        /// <param name="url">The whole URL.</param>
        /// <returns></returns>
        protected Dictionary<string, string> GetParameters(string url)
        {
            var matches = Regex.Matches(url, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var keyValues = new Dictionary<string, string>(matches.Count);
            foreach (Match m in matches)
                keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));

            return keyValues;
        }

    }
}
