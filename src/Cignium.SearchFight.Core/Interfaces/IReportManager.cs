using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface IReportManager
    {
        /// <summary>
        /// Generate the report with the search results by term.
        /// </summary>
        /// <param name="searchData">List with all the search data information.</param>
        /// <returns>A sring list with the search results report.</returns>
        IList<string> GetSearchResultsReport(IList<Search> searchData);

        /// <summary>
        /// Generate the report with the search engine winners.
        /// </summary>
        /// <param name="engineWinners">List with all the enabled search engine winner terms.</param>
        /// <returns>A string list with the winners report.</returns>
        IList<string> GetWinnersReport(IList<SearchEngineWinner> engineWinners);

        /// <summary>
        /// Generate the report with the grand winner.
        /// </summary>
        /// <param name="grandWinner">Search fight grand winner information.</param>
        /// <returns>A string with the grand winner report.</returns>
        string GetGrandWinnerReport(SearchEngineWinner grandWinner);
    }
}
