using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Cignium.SearchFight.Core
{
    public class SearchContest
    {
        #region Attributes

        private ISearchManager _searchManager;
        private IWinnerManager _winnerManager;

        #endregion

        #region Constructors

        public SearchContest()
        {
            _searchManager = new SearchManager();
            _winnerManager = new WinnerManager();
        }

        #endregion
    }
}
