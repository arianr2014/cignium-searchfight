using System.Threading.Tasks;
using System.Collections.Generic;
using Cignium.SearchFight.Services.Impl;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Core
{
    public class SearchContest
    {
        private List<ISearchEngine> _searchEngines;

        public SearchContest()
        {
            _searchEngines = new List<ISearchEngine>() { new GoogleSearch(), new BingSearch() };
        }

        public async Task<IList<Search>> GetSearchResults(IList<string> terms)
        {
            IList<Search> results = new List<Search>();

            foreach (ISearchEngine engine in _searchEngines)
            {
                foreach (string term in terms)
                {
                    results.Add(new Search {
                        SearchEngine = engine.Name,
                        Term = term,
                        Results = await engine.GetTotalResultsAsync(term)
                    });
                }
            }

            return results;
        }
    }
}
