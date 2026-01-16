namespace ExempleVoiture
{
    /// <summary>
    /// Projet : Exemple intro c#
    /// Details : Modelise une voiture conduite
    /// par une personne et transportant de 1 a 5
    /// Auteur : Mattis Lefranc-Adam
    /// Date : 07/11/25
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {

            Person person1 = new Person("Mattis");
            person1.Height = 180.2;
            person1.Age = 15;

            Person person2 = new Person("Sayan");
            person2.Height = 189.15;
            person2.Age = 23;

            Car car = new Car("Ford");
            car.Color = "Red";
            
            car.Roule(person1);
            car.Transport(person2);
        }
    } 
}