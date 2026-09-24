namespace PF_Linq
{
    public class Exercice1
    {
        public void EnMaj(List<string> listeMessage)
        {
            foreach (var item in listeMessage)
                Console.Write(item.ToUpper());
        }
        public List<int> AuCarré(List<int> entiers)
        {
            return entiers.Select(x => x * x).ToList();
        }

        public List<string> IndexListVersion1(List<string> liste)
        {
            Console.WriteLine("Version 1");
            List<string> words = liste.Select((x, index) => index + ")" + x).ToList();
            return words;
        }

        public List<string> IndexListVersion2(List<string> liste)
        {
            Console.WriteLine("Version 2 (Avec la longueur)");
            return liste.Select((x, index) => index + ")" + x.Length).ToList();
        }

        public List<string> ListHtml(List<HtmlExercice> Liste)
        {
            return  Liste.Select(x => $"<{x.Balise}>{x.Texte}</{x.Balise}").ToList();
        }

        public List<string> ListReplace(string[] words)
        {
            return words.Select(x => x.Replace("ea", "*")).ToList();
        }

        public List<string> ListEmployeesName(List<Employee> employees)
        {
            return employees.Select(e => e.Name ?? "").ToList();
        }

        public List<string> ListEmployeesNameAndSalary(List<Employee> employees)
        {
            return employees.Select(e => $"{e.Name} : {e.Salary}").ToList();
        }

        public List<string> ListEmployeesIdNameAndDept(List<Employee> employees)
        {
            return employees.Select((e, id) => $"{id}: {e.Name} : {e.Department}").ToList();
        }
    }
}