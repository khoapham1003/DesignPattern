using System;
using System.Collections.Generic;

namespace DesignPatterns.Strategy
{

    // Interface định nghĩa thuật toán (Strategy)
    public interface ISortStrategy
    {
        List<string> Sort(List<string> data);
    }

    // Strategy 1: Sắp xếp tăng dần
    public class AscendingSortStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> data)
        {
            data.Sort();
            return data;
        }
    }

    // Strategy 2: Sắp xếp giảm dần
    public class DescendingSortStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> data)
        {
            data.Sort();
            data.Reverse();
            return data;
        }
    }

    // Context: sử dụng chiến lược được truyền vào
    public class SortContext
    {
        private ISortStrategy _strategy;

        public SortContext(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy(List<string> items)
        {
            Console.WriteLine("Thực hiện sắp xếp với chiến lược hiện tại...");
            var sorted = _strategy.Sort(items);
            Console.WriteLine(string.Join(", ", sorted));
        }
    }
}