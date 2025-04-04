using System;
using System.Collections.Generic;

    //Flyweight: Chứa các trạng thái chung được lặp lại (repeatingState)
    public class Flyweight
    {
        private string repeatingState;// Kiểu loại xe

        public Flyweight(string repeatingState)
        {
            this.repeatingState = repeatingState;
        }

        public void Operation(string uniqueState)
        {
            Console.WriteLine($"Flyweight: Hiển thị trạng thái chung '{repeatingState}' và trạng thái riêng '{uniqueState}'");
        }
    }

    //FlyweightFactory: Lưu trữ và quản lý các Flyweight
    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> cache = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string repeatingState)
        {
            if (!cache.ContainsKey(repeatingState))
            {
                Console.WriteLine($"FlyweightFactory: Tạo mới Flyweight với trạng thái '{repeatingState}'");
                cache[repeatingState] = new Flyweight(repeatingState);
            }
            else
            {
                Console.WriteLine($"FlyweightFactory: Dùng lại Flyweight với trạng thái '{repeatingState}'");
            }

            return cache[repeatingState];
        }

        public void ListFlyweights()
        {
            Console.WriteLine($"\nFlyweightFactory: Đang quản lý {cache.Count} Flyweights:");
            foreach (var key in cache.Keys)
            {
                Console.WriteLine($"- {key}");
            }
        }
    }

    //Context: Hiển thị của 1 object khi chưa dùng Flyweight
    //Chứa trạng thái duy nhất (uniqueState) và tham chiếu Flyweight
    public class ContextDPFlyweight
    {
        private string uniqueState; 
        private Flyweight flyweight;

        public ContextDPFlyweight(FlyweightFactory factory, string category, string company, string uniqueState)
        {
            string repeatingState = $"{category}_{company}"; 
            this.uniqueState = uniqueState;
            this.flyweight = factory.GetFlyweight(repeatingState);
        }

        public void Operation()
        {
            flyweight.Operation(uniqueState);
        }
    }
