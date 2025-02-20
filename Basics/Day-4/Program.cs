using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

class Program
{
    public static async Task Main()
    {
        Program p = new Program();
        await p.HouseWork();
    }
    public async Task HouseWork()
    {
        //Task.Run() ensures tasks run on different threads in the ThreadPool,
        //making them truly parallel.
        Console.WriteLine("Task started ");
        Task task1 = Task.Run(() => WashDryClothes());
        Task task2 = Task.Run(() => CookFood());
        Task task3 = Task.Run(() => CleanHouse());


        //Task.WhenAll() allows all three operations to run at the same time.
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("Task Completed");
        
    }

    public async Task WashDryClothes()
    {
        Console.WriteLine("Washing clothes");
        await Task.Delay(2000);
        Console.WriteLine("Completed Washing");
        await Task.Delay(1000);
        Console.WriteLine("Completed Drying Clothes");
    }

    public async Task CookFood()
    {
        Console.WriteLine("Cooking Food");
        await Task.Delay(2000);
        Console.WriteLine("Completed Cooking");
      
    }

    public async Task CleanHouse()
    {
        Console.WriteLine("Cleaning House");
        await Task.Delay(3000);
        Console.WriteLine("Completed Cleaning House");
    }
}
