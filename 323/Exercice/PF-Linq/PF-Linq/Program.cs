namespace PF_Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Exercice 1 ----");
            Exercice1();
            Console.WriteLine("---- Exercice 2 ----");
            Exercice2();
        }

        private static void Exercice2()
        {
            Exercice2 exercice2 = new();
            List<int> listEntier = new List<int> { 2, 4, 5, 6, 25, 10, 35 };
            var etudiants = new List<Note>()
            {
                new Note { Name = "John",Mark = 2 },
                new Note { Name = "Jane", Mark = 6 },
                new Note { Name = "Bob", Mark = 3.5 },
                new Note { Name = "Sara", Mark = 4 },
                new Note { Name = "Tom", Mark = 4.3 },
                new Note { Name = "Sayan", Mark = 5.5 },
                new Note { Name = "Aleksa", Mark = 2 },
                new Note { Name = "Samantha", Mark = 3.5 },
                new Note { Name = "Elia", Mark = 5},
            };


            Console.WriteLine("-- Exercice 2.1 --");
            exercice2.Nmbpair(listEntier).ForEach(Console.WriteLine);

            Console.WriteLine("-- Exercice 2.2 --");

            Console.WriteLine("-- Exercice 2.3 --");
            
            Console.WriteLine("-- Exercice 2.4 --");
        }

        private static void Exercice1()
        {
            Exercice1 exercice1 = new();
            List<string> listeMessage = new List<string> { "bonjour", "les", "gars" };
            List<int> listEntier = new List<int> { 2, 4, 5, 6, 25, 10, 35 };
            var words = new List<string> { "sky", "cup", "loud", "war", "water" };
            var wordsToReplace = new[] { "near", "speak", "tonight", "weapon", "customer", "deal", "lawyer" };
            var liste = new List<HtmlExercice>()
            {
                new HtmlExercice {Balise="h1", Texte="Un titre"},
                new HtmlExercice {Balise="p", Texte="Un paragraphe"},
                new HtmlExercice {Balise="span", Texte="Un span"}
            };
            var employees = new List<Employee>()
            {
                new Employee { Name = "John", Department = "HR", Salary = 50000 },
                new Employee { Name = "Jane", Department = "IT", Salary = 60000 },
                new Employee { Name = "Bob", Department = "HR", Salary = 45000 },
                new Employee { Name = "Sara", Department = "IT", Salary = 55000 },
                new Employee { Name = "Tom", Department = "IT", Salary = 65000 }
            };

            Console.WriteLine("-- Exercice 1.1 --");
            exercice1.EnMaj(listeMessage);

            Console.WriteLine();

            Console.WriteLine("-- Exercice 1.2 --");
            var list_entier = exercice1.AuCarré(listEntier);
            list_entier.ForEach(Console.WriteLine);

            Console.WriteLine("-- Exercice 1.3 --");
            var list_words_01 = exercice1.IndexListVersion1(words);
            list_words_01.ForEach(Console.WriteLine);


            var list_words_02 = exercice1.IndexListVersion2(words);
            list_words_02.ForEach(Console.WriteLine);


            Console.WriteLine("-- Exercice 1.4 --");
            var Html = exercice1.ListHtml(liste);
            Html.ForEach(Console.WriteLine);

            Console.WriteLine("-- Exercice 1.5 --");
            var listReplaced = exercice1.ListReplace(wordsToReplace);
            listReplaced.ForEach(Console.WriteLine);


            Console.WriteLine("-- Exercice 1.5 --");
            var nameEmployees = exercice1.ListEmployeesName(employees);
            Console.WriteLine("Names:");
            nameEmployees.ForEach(Console.WriteLine);


            var nameAndSalaryEmployees = exercice1.ListEmployeesNameAndSalary(employees);
            Console.WriteLine("Names & Salary:");
            nameAndSalaryEmployees.ForEach(Console.WriteLine);


            var nameSalaryDeptEmployees = exercice1.ListEmployeesIdNameAndDept(employees);
            Console.WriteLine("Id / name / Dept:");
            nameSalaryDeptEmployees.ForEach(Console.WriteLine);

        }
    }
}

