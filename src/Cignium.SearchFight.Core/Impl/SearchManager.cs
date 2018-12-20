using System;
using System.Linq;
using System.Reflection;
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
        
        private IList<ISearchEngine> _searchEngines;

        #endregion

        #region Constructors
                
        public SearchManager()
        {
            _searchEngines = GetImplementedSearchEngines();
        }

        #endregion

        #region Private Methods

        private IList<ISearchEngine> GetImplementedSearchEngines()
        {            
            IEnumerable<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("Cignium.SearchFight"));

            return loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchEngine).ToList();
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
