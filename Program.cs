using System;

namespace DesignPatternsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Викликаємо виконання завдань
            Task1Runner.Run();
            
            Console.WriteLine("\nНатисніть Enter для переходу до наступного завдання...");
            Console.ReadLine();

            Task2Runner.Run();
            
            Console.WriteLine("\nНатисніть Enter для переходу до наступного завдання...");
            Console.ReadLine();

            Task5Runner.Run();

            Console.WriteLine("\nВсі завдання завершено. Натисніть Enter для виходу.");
            Console.ReadLine();
        }
    }
}