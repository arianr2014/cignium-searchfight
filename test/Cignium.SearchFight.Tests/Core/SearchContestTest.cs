using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Core;
using System.Collections.Generic;

namespace Cignium.SearchFight.Tests.Core
{
    [TestFixture]
    public class SearchContestTest
    {
        [Test]
        public async Task GetSearchResults_Success()
        {
            SearchContest searchContest = new SearchContest();
            var asd = await searchContest.GetSearchResults(new List<string>() { "java", ".net" });
        }
    }
}
