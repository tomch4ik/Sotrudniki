namespace bookinglist
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Жанр: {Type}, Год: {Year}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Book> books = new LinkedList<Book>();

            AddBookToEnd(books, "1984", "Джордж Оруэлл", "Утопия", 1949);
            AddBookToEnd(books, "Убийство Пересмешника", "Харпер Ли", "Новелла", 1960);
            AddBookToBeginning(books, "Гордость и Предубеждение", "Джейн Остин", "Роман", 1813);
            InsertBookAtPosition(books, 2, "Великий Гетсби", "Фрэнсис Скотт Фицджеральд", "Новелла", 1925);
            Console.WriteLine("Список книг:");
            DisplayBooks(books);
            SearchBooks(books, "Оруэлл");
            RemoveBookFromEnd(books);
            RemoveBookFromBeginning(books);
            RemoveBookAtPosition(books, 1);
            Console.WriteLine("Список книг после изменений:");
            DisplayBooks(books);
        }
        static void AddBookToBeginning(LinkedList<Book> books, string title, string author, string type, int year)
        {
            books.AddFirst(new Book { Title = title, Author = author, Type = type, Year = year });
            Console.WriteLine($"Книга {title} добавлена в начало списка");
        }
        static void AddBookToEnd(LinkedList<Book> books, string title, string author, string type, int year)
        {
            books.AddLast(new Book { Title = title, Author = author, Type = type, Year = year });
            Console.WriteLine($"Книга {title} добавлена в конец списка");
        }
        static void InsertBookAtPosition(LinkedList<Book> books, int position, string title, string author, string type, int year)
        {
            if (position < 0 || position > books.Count)
            {
                Console.WriteLine("Некорректная позиция");
                return;
            }
            var newBook = new Book { Title = title, Author = author, Type = type, Year = year };
            if (position == 0)
            {
                AddBookToBeginning(books, title, author, type, year);
            }
            else if (position == books.Count)
            {
                AddBookToEnd(books, title, author, type, year);
            }
            else
            {
                var current = books.First;
                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }
                books.AddAfter(current, newBook);
                Console.WriteLine($"Книга {title} вставлена на позицию {position}");
            }
        }
        static void RemoveBookFromBeginning(LinkedList<Book> books)
        {
            if (books.Count > 0)
            {
                Console.WriteLine($"Книга {books.First.Value.Title} удалена из начала списка");
                books.RemoveFirst();
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }
        static void RemoveBookFromEnd(LinkedList<Book> books)
        {
            if (books.Count > 0)
            {
                Console.WriteLine($"Книга {books.Last.Value.Title} удалена из конца списка");
                books.RemoveLast();
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }
        static void RemoveBookAtPosition(LinkedList<Book> books, int position)
        {
            if (position < 0 || position >= books.Count)
            {
                Console.WriteLine("Некорректная позиция");
                return;
            }

            var current = books.First;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            Console.WriteLine($"Книга {current.Value.Title} удалена с позиции {position}");
            books.Remove(current);
        }
        static void DisplayBooks(LinkedList<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        static void SearchBooks(LinkedList<Book> books, string find_book)
        {
            Console.WriteLine($"Результаты поиска по запросу {find_book}:");
            foreach (var book in books)
            {
                if (book.Title.Contains(find_book, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(find_book, StringComparison.OrdinalIgnoreCase) ||
                    book.Type.Contains(find_book, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
