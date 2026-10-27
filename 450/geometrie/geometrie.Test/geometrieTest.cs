using Bibliotheque;
using Xunit;

public class geometrieTest
{
    [Fact]
    public void DureeRestante_PretDeQuatorzeJoursApresCinqJours_ResteNeufJours()
    {
        // Arrange
        Emprunt emprunt = new Emprunt(dureeEnJours: 14);

        // Act
        int restant = emprunt.DureeRestante(joursEcoules: 5);

        // Assert : 14 - 5
        Assert.Equal(9, restant);
    }
}
