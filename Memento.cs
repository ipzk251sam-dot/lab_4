using System;
using System.Collections.Generic;

namespace DesignPatternsLab
{
    // Memento
    public class DocumentMemento
    {
        public string Content { get; }
        public DateTime SavedAt { get; }

        public DocumentMemento(string content)
        {
            Content = content;
            SavedAt = DateTime.Now;
        }
    }

    // Originator
    public class TextDocument
    {
        public string Content { get; set; } = string.Empty;

        public void Type(string text)
        {
            Content += text;
        }

        public DocumentMemento Save()
        {
            Console.WriteLine($"[Документ]: Стан збережено.");
            return new DocumentMemento(Content);
        }

        public void Restore(DocumentMemento memento)
        {
            Content = memento.Content;
            Console.WriteLine($"[Документ]: Відновлено стан збережений о {memento.SavedAt.ToLongTimeString()}");
        }

        public void Print()
        {
            Console.WriteLine($"Поточний текст: \"{Content}\"");
        }
    }

    // Caretaker
    public class TextEditor
    {
        public TextDocument Document { get; } = new TextDocument();
        private readonly Stack<DocumentMemento> _history = new Stack<DocumentMemento>();

        public void SaveDocument()
        {
            _history.Push(Document.Save());
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var memento = _history.Pop();
                Document.Restore(memento);
            }
            else
            {
                Console.WriteLine("Немає збережених станів для відміни.");
            }
        }
    }

    // Клас для запуску Завдання 5
    public class Task5Runner
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 5: Мементо ---");
            var editor = new TextEditor();

            editor.Document.Type("Hello, ");
            editor.SaveDocument(); 
            editor.Document.Print();

            editor.Document.Type("world!");
            editor.SaveDocument(); 
            editor.Document.Print();

            editor.Document.Type(" Ой, помилка.");
            editor.Document.Print(); 

            Console.WriteLine("\nВідміняємо останню дію (Undo)...");
            editor.Undo(); 
            editor.Document.Print();

            Console.WriteLine("\nВідміняємо ще раз (Undo)...");
            editor.Undo(); 
            editor.Document.Print();
        }
    }
}