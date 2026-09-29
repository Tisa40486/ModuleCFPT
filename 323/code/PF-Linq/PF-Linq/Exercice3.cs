namespace PF_Linq
{
    public class Exercice3
    {
        public int SumList(List<int> nb)
        {
            return nb.Aggregate(10,(sum, x) => sum + x);
        }
        public int Factorielle(List<int> nb)
        {
            return nb.Aggregate(1, (fac, x) => fac * x);
        }

        public string JoinList(List<string> words)
        {
            return words.Aggregate((chaine, mot) => $"{chaine},{mot}");
        }

        public int SumSalaries(List<EmployeeExercice3> employees)
        {
            return employees.Select(x => x.Salary).Aggregate((acc, x) => acc + x);
        }
        public int SumLengthName(List<EmployeeExercice3> employees)
        {
            return employees.Select(x => x.Name).Aggregate(0,(int acc, string x) => acc + x.Length);
        }

    }
}