namespace PF_Linq
{
    public class Exercice2
    {
        public List<int> Nmbpair(List<int> nb)
        {
            return nb.Where(x => x % 2 == 0).ToList();
        }


    }
}
