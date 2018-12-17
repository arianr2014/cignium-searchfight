using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Services.Impl;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Tests.Services
{
    [TestFixture]
    public class GoogleSearchTest
    {
        private ISearchEngine SearchEngine => new GoogleSearch();

        [Test]
        public async Task Google_Search_Engine_Query_Success()
        {            
            var result = await SearchEngine.GetTotalResultsAsync("java");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }
    }
}
