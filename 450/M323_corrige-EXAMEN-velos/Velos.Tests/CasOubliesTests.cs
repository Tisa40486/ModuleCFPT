using Xunit;

namespace Velos.Tests
{
    public class CasOubliesTests
    {
        private static List<Velo> Trois()
        {
            return new List<Velo>
            {
                new("Faucon", "VTT", 2023, 30, 20),
                new("Pie", "ville", 2022, 45, 6),
                new("Cerf", "VTT", 2021, 20, 25)
            };
        }
        [Fact]
        public void TarifDesPlusSollicites_PlusDemandesQueDisponibles_AdditionneTous()
        {
            // Arrange : Cerf (25 sorties) et Faucon (20 sorties) passent devant Pie (6 sorties)
            List<Velo> trois = Trois();

            // Act
            int resultat = Examen.TarifDesPlusSollicites(trois, 5);

            // Assert : 20 + 30
            Assert.Equal(95, resultat);
        }

        [Fact]
        public void TarifDesPlusSollicites_ListVide_AdditionneTous()
        {
            // Arrange : Cerf (25 sorties) et Faucon (20 sorties) passent devant Pie (6 sorties)
            List<Velo> vide = new List<Velo>();

            // Act
            int resultat = Examen.TarifDesPlusSollicites(vide, 5);

            // Assert : 20 + 30
            Assert.Equal(0, resultat);
        }
    }
}