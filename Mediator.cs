using System;

namespace DesignPatternsLab
{
    // Інтерфейс посередника
    public interface ICommandCentre
    {
        bool RequestLanding(Aircraft aircraft);
        void RegisterRunway(Runway runway);
    }

    // Конкретний посередник
    public class CommandCentre : ICommandCentre
    {
        private Runway _runway;

        public void RegisterRunway(Runway runway)
        {
            _runway = runway;
        }

        public bool RequestLanding(Aircraft aircraft)
        {
            if (_runway != null && _runway.IsFree)
            {
                Console.WriteLine($"Командний центр: Дозвіл на посадку надано борту {aircraft.Name}.");
                _runway.IsFree = false;
                return true;
            }
            Console.WriteLine($"Командний центр: Посадка заборонена борту {aircraft.Name}. Смуга зайнята!");
            return false;
        }
    }

    // Колега 1
    public class Aircraft
    {
        public string Name { get; }
        private readonly ICommandCentre _commandCentre;

        public Aircraft(string name, ICommandCentre commandCentre)
        {
            Name = name;
            _commandCentre = commandCentre;
        }

        public void Land()
        {
            Console.WriteLine($"Борт {Name} запитує посадку...");
            if (_commandCentre.RequestLanding(this))
            {
                Console.WriteLine($"Борт {Name} успішно приземлився.");
            }
            else
            {
                Console.WriteLine($"Борт {Name} йде на друге коло.");
            }
        }
    }

    // Колега 2
    public class Runway
    {
        public bool IsFree { get; set; } = true;

        public void Clear()
        {
            IsFree = true;
            Console.WriteLine("Злітна смуга вільна.");
        }
    }

    // Клас для запуску Завдання 2
    public class Task2Runner
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 2: Посередник ---");
            var commandCentre = new CommandCentre();
            var runway = new Runway();
            commandCentre.RegisterRunway(runway);

            var aircraft1 = new Aircraft("Boeing-737", commandCentre);
            var aircraft2 = new Aircraft("Airbus-A320", commandCentre);

            aircraft1.Land(); // Смуга вільна
            aircraft2.Land(); // Смуга зайнята

            runway.Clear();   // Звільняємо смугу
            aircraft2.Land(); // Тепер сяде
        }
    }
}