namespace ExempleVoiture
{
    public class Person
    {
        private string? _name;
        private double _height;
        private int _age;

        public Person (string name)
        {
            _name = name;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public double Height
        { 
            get => _height; 
            set => _height = value; 
        }

        public int Age 
        { 
            get => _age; 
            set => _age = value; 
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}