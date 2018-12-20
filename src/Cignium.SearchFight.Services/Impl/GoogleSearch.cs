using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cignium.SearchFight.Shared.Helpers;
using Cignium.SearchFight.Services.Models;
using Cignium.SearchFight.Services.Interfaces;
using Cignium.SearchFight.Services.Models.Config;

namespace Cignium.SearchFight.Services.Impl
{
    public class GoogleSearch : ISearchEngine
    {
        #region Settings

        public string Name => "Google";        
        private HttpClient _client { get; }

        #endregion

        #region Constructors

        public GoogleSearch()
        {
            _client = new HttpClient();
        }

        #endregion

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = GoogleConfig.BaseUrl.Replace("{Key}", GoogleConfig.ApiKey)
                .Replace("{Context}", GoogleConfig.ContextId)
                .Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");

                GoogleResponse results = JsonHelper.Deserialize<GoogleResponse>(await response.Content.ReadAsStringAsync());
                return long.Parse(results.SearchInformation.TotalResults);
            }
        }
    }
}
