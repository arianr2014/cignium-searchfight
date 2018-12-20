using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Cignium.SearchFight.Core;
using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Interfaces;

namespace Cignium.SearchFight.Tests.Core
{
    [TestFixture]
    public class WinnerManagerTest
    {
        #region Attributes

        private IWinnerManager _winnerManager;

        #endregion

        #region Constructors

        public WinnerManagerTest()
        {
            _winnerManager = new WinnerManager();
        }

        #endregion

        #region Tests

        [Test]
        public void GetSearchEngineWinners_Null_Terms_ArgumentException()
        {
            List<Search> searchData = null;
            Assert.Throws<ArgumentException>(() => _winnerManager.GetSearchEngineWinners(searchData));
        }

        [Test]
        public void GetSearchEngineWinners_Empty_Terms_ArgumentException()
        {
            List<Search> searchData = new List<Search>();
            Assert.Throws<ArgumentException>(() => _winnerManager.GetSearchEngineWinners(searchData));
        }

        [Test]
        public void GetSearchEngineWinners_Success()
        {
            IEnumerable<SearchEngineWinner> searchEngineWinners = _winnerManager.GetSearchEngineWinners(GenerateTestData());

            Assert.IsNotNull(searchEngineWinners);
            Assert.IsNotEmpty(searchEngineWinners);

            Assert.AreEqual("python", searchEngineWinners.First(x => x.Engine == "Google").Term);
            Assert.AreEqual(".NET", searchEngineWinners.First(x => x.Engine == "Bing").Term);            
        }

        [Test]
        public void GetGrandWinner_Null_Terms_ArgumentException()
        {
            List<Search> searchData = null;
            Assert.Throws<ArgumentException>(() => _winnerManager.GetGrandWinner(searchData));
        }

        [Test]
        public void GetGrandWinner_Empty_Terms_ArgumentException()
        {
            List<Search> searchData = new List<Search>();
            Assert.Throws<ArgumentException>(() => _winnerManager.GetGrandWinner(searchData));
        }

        [Test]
        public void GetGrandWinner_Success()
        {
            SearchEngineWinner grandWinner = _winnerManager.GetGrandWinner(GenerateTestData());

            Assert.IsNotNull(grandWinner);

            Assert.AreEqual("Bing", grandWinner.Engine);
            Assert.AreEqual(".NET", grandWinner.Term);
        }

        #endregion

        #region Utility Methods

        private List<Search> GenerateTestData()
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
