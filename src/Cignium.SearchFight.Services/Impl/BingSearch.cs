using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Cignium.SearchFight.Services.Models;
using Cignium.SearchFight.Services.Interfaces;
using Cignium.SearchFight.Services.Models.Config;

namespace Cignium.SearchFight.Services.Impl
{
    public class BingSearch : ISearchEngine
    {
        #region Settings

        public string Name => "Bing";        
        private HttpClient _client { get; }
        private JavaScriptSerializer _serializer { get; }        

        #endregion

        #region Constructors

        public BingSearch()
        {
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", BingConfig.ApiKey } } };
            _serializer = new JavaScriptSerializer();
        }

        #endregion

        #region Interface Methods

        public async Task<long> GetTotalResultsAsync(string query)
        {
            string searchRequest = BingConfig.BaseUrl.Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");
                
                BingResponse results = _serializer.Deserialize<BingResponse>(await response.Content.ReadAsStringAsync());                
                return long.Parse(results.WebPages.TotalEstimatedMatches);
            }
        }

        #endregion
    }
}
