namespace ExempleVoiture
{ 
    /// <summary>
    /// Modelise une voiture avec sa couleur 
    /// </summary>
    public class Car
    {
        private string? _brand;

        private string? _color;

        public string Color
        {
            get => _color ?? string.Empty;
            set => _color = value;
        }


        public Car(string marque)
        {
            _brand =  marque;
        }

        public void Roule(Person conducteur)
        {
            Console.WriteLine($"{conducteur.Name} est conducteur de la {_brand}");
        }

        public void Transport(Person passager)
        {
            Console.WriteLine($"{passager.Name} est passager de la {_brand}");
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"=> brand : {_brand}, color : {_color}";
        }
    }
}