using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;

namespace Cignium.SearchFight.Tests.Core
{
    [TestFixture]
    public class ReportManagerTest
    {
        #region Attributes

        private IReportManager _reportManager;

        #endregion

        #region Constructors

        public ReportManagerTest()
        {
            _reportManager = new ReportManager();
        }

        #endregion

        #region Tests

        [Test]
        public void GetSearchResultsReport_Null_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportManager.GetSearchResultsReport(null));
        }

        [Test]
        public void GetSearchResultsReport_Empty_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportManager.GetSearchResultsReport(new List<Search>()));
        }

        [Test]
        public void GetSearchResultsReport_Success()
        {
            IList<string> winnersReport = _reportManager.GetSearchResultsReport(GenerateTestSearchData());

            Assert.NotNull(winnersReport);
            Assert.AreNotEqual(0, winnersReport.Count);
        }

        [Test]
        public void GetWinnersReport_Null_Terms_ArgumentException()
        {            
            Assert.Throws<ArgumentException>(() => _reportManager.GetWinnersReport(null));
        }

        [Test]
        public void GetSearchResult_Empty_Terms_ArgumentException()
        {            
            Assert.Throws<ArgumentException>(() => _reportManager.GetWinnersReport(new List<SearchEngineWinner>()));
        }

        [Test]
        public void GetWinnersReport_Success()
        {
            IList<string> winnersReport = _reportManager.GetWinnersReport(GetTestSearchEngineWinners());

            Assert.NotNull(winnersReport);
            Assert.AreNotEqual(0, winnersReport.Count);
        }

        [Test]
        public void GetGrandWinnerReport_Null_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportManager.GetGrandWinnerReport(null));
        }

        [Test]
        public void GetGrandWinnerReport_Success()
        {
            string grandWinnerReport = _reportManager.GetGrandWinnerReport(GetTestGrandWinner());

            Assert.NotNull(grandWinnerReport);
            Assert.IsNotEmpty(grandWinnerReport);
        }

        #endregion

        #region Utility Methods

        public SearchEngineWinner GetTestGrandWinner()
        {
            return new SearchEngineWinner { Engine = "Google", Term = ".NET" };
        }

        public IList<SearchEngineWinner> GetTestSearchEngineWinners()
        {
            return new List<SearchEngineWinner>
            {
                new SearchEngineWinner { Engine = "Google", Term = ".NET" },
                new SearchEngineWinner { Engine = "Bing", Term = "Python" }
            };
        }

        private List<Search> GenerateTestSearchData()
        {
            List<Search> testData = new List<Search>
            {
                new Search { SearchEngine = "Google", Term = ".NET", Results = 10340401L },
                new Search { SearchEngine = "Bing", Term = ".NET", Results = 98493849L },

                new Search { SearchEngine = "Google", Term = "Java", Results = 13419851L },
                new Search { SearchEngine = "Bing", Term = "Java", Results = 31091305L },

                new Search { SearchEngine = "Google", Term = "Java script", Results = 31048304L },
                new Search { SearchEngine = "Bing", Term = "Java script", Results = 13048139L },

                new Search { SearchEngine = "Google", Term = "python", Results = 39408158L },
                new Search { SearchEngine = "Bing", Term = "python", Results = 31048984L }
            };

            return testData;
        }

        #endregion
    }
}
