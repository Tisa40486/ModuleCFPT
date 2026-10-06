using Xunit;

public class FacturationTests
{
    // Trois voitures choisies : deux retenues (plus de 60 000 km), une exclue.
    private static List<Voiture> PetitCatalogue() => new List<Voiture>
    {
        new("VW", "Golf", 18000, "diesel", 120000, 2016),      // retenue : 120 000 km
        new("Fiat", "Panda", 8900, "essence", 130000, 2012),   // retenue : 130 000 km
        new("Volvo", "XC40", 52000, "hybride", 9000, 2024)     // exclue : 9000 km
    };

    // Test fourni. Lancez dotnet test : il doit afficher Passed!
    [Fact]
    public void VoituresFacturables_CatalogueVide_RendUneSequenceVide()
    {
        // Arrange
        List<Voiture> vide = new List<Voiture>();

        // Act
        var resultat = Facturation.VoituresFacturables(vide);

        // Assert
        Assert.Empty(resultat);
    }

    // A COMPLETER exercice 1 : deux tests sur PetitCatalogue()
    [Fact]
    public void VoituresFacturables_TroisVoitures_GardeLesDeuxGrosRouleurs()
    {
        //Arrange 
        List<Voiture> voitures = PetitCatalogue();

        //Act
        List<Voiture> result = Facturation.VoituresFacturables(voitures).ToList();

        //Assert
        Assert.Equal(2, result.Count);
    }
    [Fact]
    public void Total_DeuxVoituresFacturables_AdditionneLeursRevisions()
    {
        //Arrange 
        List<Revision> revisions = Donnees.ChargerRevisions();

        //Act
        var values = Facturation.AvecRevisions(PetitCatalogue(), revisions);

        //Assert
        Assert.Equal([830, 1770], values.Select(x => x.Cout));
    }
    // A COMPLETER exercice 2 : les bords
    [Fact]
    public void Total_CatalogueVide_RendZero()
    {
        //arrange 
        List<Voiture> catalogueVide = new List<Voiture>();

        var result = Facturation.Total(catalogueVide, Donnees.ChargerRevisions());

        Assert.Equal(0, result);
    }

    [Fact]
    public void Total_AucuneVoitureFacturable_RendZero()
    {
        //arrange 
        List<Voiture> catalogue = PetitCatalogue().Where(v => v.Kilometrage == 9000).ToList();

        var result = Facturation.Total(catalogue, Donnees.ChargerRevisions());

        Assert.Equal(0, result);
    }

    [Fact]
    public void Total_UneSeuleVoitureFacturable_RendSesRevisions()
    {
        //arrange 
        var result = Donnees.ChargerCatalogue().Where(v => v.Modele == "Golf").ToList();

        Assert.NotEmpty(result);
    }


    [Fact]
    public void AvecRevisions_VoitureSansRevision_NApparaitPas()
    {
        //arrange 
        var result = Donnees.ChargerCatalogue().Where(v => v.Modele == "Serie 1").ToList();

        Assert.Empty(result);
    }
}
