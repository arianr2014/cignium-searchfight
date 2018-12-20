using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface ISearchManager
    {
        /// <summary>
        /// Get results from search engines for the specified term.
        /// </summary>
        /// <param name="terms">Search term to query for in the engines.</param>
        /// <returns>A Search entity with the results from the enabled search engines.</returns>
        Task<IList<Search>> GetSearchResults(IList<string> terms);
    }
}
