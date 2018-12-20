using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Services.Impl;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Core.Impl
{
    public class SearchManager : ISearchManager
    {
        #region Attributes
        
        private List<ISearchEngine> _searchEngines;

        #endregion

        #region Constructors
                
        public SearchManager()
        {
            _searchEngines = new List<ISearchEngine>() { new GoogleSearch(), new BingSearch() };
        }

        #endregion

        #region Public Methods

        public async Task<IList<Search>> GetSearchResults(IList<string> terms)
        {
            if (terms == null || terms.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(terms));

            IList<Search> results = new List<Search>();

            foreach (ISearchEngine engine in _searchEngines)
            {
                foreach (string term in terms)
                {
                    results.Add(new Search
                    {
                        SearchEngine = engine.Name,
                        Term = term,
                        Results = await engine.GetTotalResultsAsync(term)
                    });
                }
            }

            return results;
        }

        #endregion
    }
}
