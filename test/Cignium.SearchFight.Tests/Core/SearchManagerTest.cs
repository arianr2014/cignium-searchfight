using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Cignium.SearchFight.Core;
using Cignium.SearchFight.Core.Impl;
using Cignium.SearchFight.Core.Interfaces;

namespace Cignium.SearchFight.Tests.Core
{
    [TestFixture]
    public class SearchManagerTest
    {
        #region Attributes
        
        private ISearchManager _searchManager;

        #endregion

        #region Constructors

        public SearchManagerTest()
        {
            _searchManager = new SearchManager();
        }

        #endregion

        #region Tests

        [Test]
        public void GetSearchResult_Null_Terms_ArgumentException()
        {
            List<string> terms = null;
            Assert.ThrowsAsync<ArgumentException>(() => _searchManager.GetSearchResults(terms));
        }

        [Test]
        public void GetSearchResult_Empty_Terms_ArgumentException()
        {
            List<string> terms = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => _searchManager.GetSearchResults(terms));
        }

        [Test]
        public async Task GetSearchResults_Success()
        {
            List<string> terms = new List<string> { ".NET", "Java", "java script", "phyton" };
            IList<Search> searchResults = await _searchManager.GetSearchResults(terms);

            Assert.IsNotNull(searchResults);
            Assert.IsNotEmpty(searchResults);
        }

        #endregion
    }
}
