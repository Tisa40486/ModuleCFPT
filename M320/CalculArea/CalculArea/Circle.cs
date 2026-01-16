namespace CalculArea
{
    public class Circle : Shape
    {
        private int _rayon;

        public Circle(int rayon)
        {
            Rayon = rayon;
        }

        public int Rayon { get => _rayon; set => _rayon = value; }

        public override double GetArea()
        {
            double calc = 3.14159 * (_rayon * _rayon);
            return calc;
        }
    }
}
