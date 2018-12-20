using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Services.Impl;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Tests.Services
{
    [TestFixture]
    public class GoogleSearchTest
    {
        #region Attributes

        private ISearchEngine _searchEngine;

        #endregion

        #region Constructors

        public GoogleSearchTest()
        {
            _searchEngine = new GoogleSearch();
        }

        #endregion

        #region Tests

        [Test]
        public void GetResultsFromGoogle_Null_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(null));
        }

        [Test]
        public void GetResultsFromGoogle_Empty_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [Test]
        public async Task GetResultsFromGoogle_Success()
        {
            var result = await _searchEngine.GetTotalResultsAsync("java");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }

        #endregion
    }
}
