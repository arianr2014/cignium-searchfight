using System.Threading.Tasks;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;


namespace Cignium.SearchFight.Core
{
    public static class SearchFightKernel
    {
        #region Attributes

        public static List<string> Reports { get; private set; }

        #endregion

        #region Services

        static ISearchManager SearchManager;
        static IWinnerManager WinnerManager;
        static IReportManager ReportManager;

        #endregion

        #region Constructors

        static SearchFightKernel()
        {
            // Initialize all our service dependencies
            SearchManager = new SearchManager();
            WinnerManager = new WinnerManager();
            ReportManager = new ReportManager();

            // Initialize our results attribute
            Reports = new List<string>();
        }

        #endregion

        #region Public Methods

        public static async Task ExecuteSearchFight(IList<string> terms)
        {
            IList<Search> searchData = await SearchManager.GetSearchResults(terms);
            IEnumerable<SearchEngineWinner> searchEngineWinners = WinnerManager.GetSearchEngineWinners(searchData);
            SearchEngineWinner grandWinner = WinnerManager.GetGrandWinner(searchData);

            Reports.AddRange(ReportManager.GetSearchResultsReport(searchData));
            Reports.AddRange(ReportManager.GetWinnersReport(searchEngineWinners));
            Reports.Add(ReportManager.GetGrandWinnerReport(grandWinner));
        }

        #endregion
    }
}
