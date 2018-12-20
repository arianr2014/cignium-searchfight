using System;
using System.Linq;
using System.Threading.Tasks;
using Cignium.SearchFight.Core;

namespace Cignium.SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            await SearchFightKernel.ExecuteSearchFight(args.ToList());
            SearchFightKernel.Reports.ForEach(report => Console.WriteLine(report));
            Console.ReadLine();
        }
    }
}