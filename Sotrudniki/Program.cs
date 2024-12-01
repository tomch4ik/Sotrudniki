namespace Sotrudniki
{
    class Person
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string WorkEmail { get; set; }

        public override string ToString()
        {
            return $"ФИО: {FullName}, Должность: {Position}, Зарплата: {Salary}, Email: {WorkEmail}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>();
            AddPerson(person, "Иван Петров", "Менеджер", 50000, "petrov@mail.com");
            AddPerson(person, "Петр Иванов", "Разработчик", 70000, "ivanov@mail.com");
            AddPerson(person, "Александер Александров", "3-D Дизайнер", 40000, "aleksandrov@mail.com");
            RemovePerson(person, "Иван Петров");
            UpdatePerson(person, "Петр Иванов", "Петр Иванович", "Старший разработчик", 80000, "ivanovich@mail.com");
            SearchPerson(person, "Старший разработчик");
            SortPerson(person, "Salary");
        }
        static void AddPerson(List<Person> person, string name, string position, decimal salary, string workemail)
        {
            person.Add(new Person { FullName = name, Position = position, Salary = salary, WorkEmail = workemail });
            Console.WriteLine($"Сотрудник {name} добавлен");
        }

        static void RemovePerson(List<Person> person, string name)
        {
            var foundperson = person.Find(e => e.FullName == name);
            if (foundperson != null)
            {
                person.Remove(foundperson);
                Console.WriteLine($"Сотрудник {name} удален");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден");
            }
        }

        static void UpdatePerson(List<Person> person, string currentName, string newName, string newPosition, decimal newSalary, string newEmail)
        {
            var foundperson = person.Find(e => e.FullName == currentName);
            if (foundperson != null)
            {
                foundperson.FullName = newName;
                foundperson.Position = newPosition;
                foundperson.Salary = newSalary;
                foundperson.WorkEmail = newEmail;
                Console.WriteLine($"Информация о сотруднике {newName} обновлена");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден");
            }
        }

        static void SearchPerson(List<Person> person, string query)
        {
            foreach (var foundperson in person)
            {
                if (foundperson.FullName.Contains(query) || foundperson.Position.Contains(query) || foundperson.WorkEmail.Contains(query))
                {
                    Console.WriteLine(foundperson);
                }
            }
        }

        static void SortPerson(List<Person> person, string parameter)
        {
            if (parameter == "Salary")
            {
                person.Sort((a, b) => a.Salary.CompareTo(b.Salary));
            }
            else if (parameter == "FullName")
            {
                person.Sort((a, b) => a.FullName.CompareTo(b.FullName));
            }

            Console.WriteLine("Сотрудники отсортированы:");
            foreach (var foundperson in person)
            {
                Console.WriteLine(foundperson);
            }
        }
    }
}
