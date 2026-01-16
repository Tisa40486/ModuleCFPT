namespace Animfriends
{
    public class Refuge
    {
        private List<Animal> _animaux;

        public Refuge()
        {
            Animaux = new List<Animal>();
        }

        public List<Animal> Animaux { get => _animaux; set => _animaux = value; }


        public int AddAnimal(Animal animal)
        {
            Animaux.Add(animal);
            return Animaux.Count;
        }

        public override string? ToString()
        {
            string stAnimaux = string.Empty;
            foreach (var animal in Animaux)
            {
                stAnimaux += animal.ToString() + "\r\n";
            }

            return stAnimaux;
        }
    }
}
