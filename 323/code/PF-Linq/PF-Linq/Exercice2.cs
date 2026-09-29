namespace PF_Linq
{
    public class Exercice2
    {
        public List<int> Nmbpair(List<int> nb)
        {
            return nb.Where(x => x % 2 == 0).ToList();
        }
        public List<string> StudentMark(List<Note> marks, double lessThan, double greaterThan)
        {
            return marks.Where(x => x.Mark > lessThan && x.Mark < greaterThan).Select(x => x.Name).ToList();
        }

        public List<string> CheckQuantity(List<Stock> stocks)
        {
            return stocks.Where(x => x.Quantity <= 0).Select(x => x.Name).ToList();
        }

        public List<string> ExtractWord(List<string> words, char start, char end)
        {
            return words.Where(x => x.StartsWith(start) & x.EndsWith(end)).ToList();
        }
    }
}