using System;

namespace DesignPatternsLab
{
    // Базовий обробник
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public void SetNext(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract bool HandleRequest(string request);
    }

    // Рівень 1: Автовідповідач
    public class BotSupport : SupportHandler
    {
        public override bool HandleRequest(string request)
        {
            if (request == "1")
            {
                Console.WriteLine("Бот: Ваш баланс становить 100 грн. Дякуємо за звернення!");
                return true;
            }
            return _nextHandler?.HandleRequest(request) ?? false;
        }
    }

    // Рівень 2: Оператор
    public class GeneralOperatorSupport : SupportHandler
    {
        public override bool HandleRequest(string request)
        {
            if (request == "2")
            {
                Console.WriteLine("Оператор: Тарифний план змінено. Чим ще можу допомогти?");
                return true;
            }
            return _nextHandler?.HandleRequest(request) ?? false;
        }
    }

    // Рівень 3: Технічна підтримка
    public class TechSupport : SupportHandler
    {
        public override bool HandleRequest(string request)
        {
            if (request == "3")
            {
                Console.WriteLine("Техпідтримка: Перезавантажте роутер. Проблема вирішена!");
                return true;
            }
            return _nextHandler?.HandleRequest(request) ?? false;
        }
    }

    // Рівень 4: Менеджер
    public class ManagerSupport : SupportHandler
    {
        public override bool HandleRequest(string request)
        {
            if (request == "4")
            {
                Console.WriteLine("Менеджер: Просимо вибачення за незручності, ось ваш бонус.");
                return true;
            }
            return _nextHandler?.HandleRequest(request) ?? false;
        }
    }

    // Клас для запуску Завдання 1
    public class Task1Runner
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 1: Ланцюжок відповідальностей ---");
            
            var bot = new BotSupport();
            var operatorSupport = new GeneralOperatorSupport();
            var techSupport = new TechSupport();
            var manager = new ManagerSupport();

            // Будуємо ланцюжок
            bot.SetNext(operatorSupport);
            operatorSupport.SetNext(techSupport);
            techSupport.SetNext(manager);

            bool isResolved = false;
            while (!isResolved)
            {
                Console.WriteLine("\nГоловне меню підтримки:");
                Console.WriteLine("1 - Дізнатися баланс (Бот)");
                Console.WriteLine("2 - Змінити тариф (Оператор)");
                Console.WriteLine("3 - Немає інтернету (Техпідтримка)");
                Console.WriteLine("4 - Подати скаргу (Менеджер)");
                Console.WriteLine("5 - Невідомий запит (Тест повторення)");
                Console.Write("Ваш вибір: ");
                
                string choice = Console.ReadLine();
                
                isResolved = bot.HandleRequest(choice);
                
                if (!isResolved)
                {
                    Console.WriteLine("Система: Запит не розпізнано. Спробуйте ще раз.\n");
                }
            }
        }
    }
}