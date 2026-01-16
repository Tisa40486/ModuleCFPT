namespace CalculArea
{
    public class Rectangle : Shape
    {

        private double _largeur;
        private double _hauteur;

        public Rectangle(double largeur, double hauteur)
        {
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public double Largeur { get => _largeur; set => _largeur = value; }
        public double Hauteur { get => _hauteur; set => _hauteur = value; }

        public override double GetArea()
        {
            var calc = _largeur * _hauteur;

            return calc;
        }
    }
}
