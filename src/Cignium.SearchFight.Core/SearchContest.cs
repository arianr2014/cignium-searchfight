using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Interfaces;

namespace Cignium.SearchFight.Core
{
    public class SearchContest
    {
        #region Attributes

        private ISearchManager _searchManager;
        private IWinnerManager _winnerManager;
        private IReportManager _reportManager;

        #endregion

        #region Constructors

        public SearchContest()
        {
            _searchManager = new SearchManager();
            _winnerManager = new WinnerManager();
            _reportManager = new ReportManager();
        }        

        #endregion
    }
}
