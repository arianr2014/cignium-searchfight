using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Services.Impl;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Tests.Services
{
    [TestFixture]
    public class BingSearchTest
    {
        #region Attributes

        private ISearchEngine _searchEngine;

        #endregion

        #region Constructors

        public BingSearchTest()
        {
            _searchEngine = new BingSearch();
        }

        #endregion

        #region Tests

        [Test]
        public void GetResultsFromBing_Null_Query_ArgumentException()
        {            
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(null));
        }

        [Test]
        public void GetResultsFromBing_Empty_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [Test]
        public async Task GetResultsFromBing_Success()
        {
            var result = await _searchEngine.GetTotalResultsAsync("java");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }

        #endregion
    }
}
