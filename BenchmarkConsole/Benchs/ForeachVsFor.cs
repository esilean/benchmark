using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace BenchmarkConsole.Benchs
{
    public class ForeachVsFor
    {

        [Benchmark]
        public int GetAllBanksForEach()
        {
            var banks = GetBanks();
            var total = 0;
            foreach (var b in banks)
            {
                total += b.Number;
            }

            return total;
        }

        [Benchmark]
        public int GetAllBanksFor()
        {
            var banks = GetBanks();
            var total = 0;
            for (int i = 0; i < banks.Count; i++)
            {
                total += banks[i].Number;
            }

            return total;
        }

        private List<Bank> GetBanks()
        {
            //var newList = new List<Bank>();
            var newList = new List<Bank>(1_000_000);
            for (int i = 0; i < 1_000_000; i++)
                newList.Add(new Bank { Number = i });

            return newList;
        }

    }

    public class Bank
    {
        public int Number { get; set; }
    }
}
