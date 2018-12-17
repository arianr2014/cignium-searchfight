using System.Threading.Tasks;

namespace Cignium.SearchFight.Services.Interfaces
{
    public interface ISearchEngine
    {
        /// <summary>
        /// Search engine name for identification purposes.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get total result count from implemented search engine.
        /// </summary>
        /// <param name="query">Search term for the engine.</param>
        /// <returns>Results count for the specified query on the search engine.</returns>
        Task<long> GetTotalResultsAsync(string query);
    }
}
