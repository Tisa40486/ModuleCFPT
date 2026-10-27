using Xunit;

// M323, examen final, partie 2 : tests fournis. Ne modifiez pas ce fichier.
// Chaque test valide une fonction de Examen.cs sur un petit jeu de données, jamais sur le parc.
// Lancez-les depuis Visual Studio : menu Test, Exécuter tous les tests.
// Un test rouge nomme la fonction à revoir ; une fonction non écrite laisse son test rouge.
public class ExamenTests
{
    // Jeu de données commun : trois vélos, choisis pour que chaque fonction donne un résultat calculable de tête.
    private static List<Velo> Trois()
    {
        return new List<Velo>
        {
            new("Faucon", "VTT", 2023, 30, 20),
            new("Pie", "ville", 2022, 45, 6),
            new("Cerf", "VTT", 2021, 20, 25)
        };
    }

    // ---------------------------------------------------------------- Q5
    /// <summary>
    /// Given : le jeu commun, Faucon (30 francs, 20 sorties), Pie (45 francs, 6 sorties) et Cerf (20 francs, 25 sorties).
    /// When : on additionne les tarifs des 2 vélos les plus sollicités.
    /// Then : le résultat vaut 50, le tarif de Cerf (20) plus celui de Faucon (30).
    /// </summary>
    [Fact]
    public void TarifDesPlusSollicites_TroisVelosDeuxDemandes_AdditionneLesDeuxPlusSollicites()
    {
        // Arrange : Cerf (25 sorties) et Faucon (20 sorties) passent devant Pie (6 sorties)
        List<Velo> trois = Trois();

        // Act
        int resultat = Examen.TarifDesPlusSollicites(trois, 2);

        // Assert : 20 + 30
        Assert.Equal(50, resultat);
    }

    // ---------------------------------------------------------------- Q6
    /// <summary>
    /// Given : quatre vélos, deux VTT (40 et 50 sorties) et deux vélos de ville (10 et 22 sorties).
    /// When : on résume les sorties par type.
    /// Then : deux lignes, VTT (45 sorties en moyenne) avant ville (16 sorties en moyenne).
    /// </summary>
    [Fact]
    public void SortiesParType_DeuxTypes_ClasseLaMeilleureMoyenneEnPremier()
    {
        // Arrange : VTT 40 et 50 sorties (moyenne 45), ville 10 et 22 sorties (moyenne 16)
        List<Velo> quatre = new List<Velo>
        {
            new("Tilleul", "ville", 2024, 25, 10),
            new("Orme", "VTT", 2024, 35, 40),
            new("Saule", "ville", 2023, 21, 22),
            new("Frêne", "VTT", 2022, 39, 50)
        };

        // Act
        List<string> resultat = Examen.SortiesParType(quatre);

        // Assert
        Assert.Equal(new List<string>
        {
            "VTT : 2 vélos, 45 sorties en moyenne",
            "ville : 2 vélos, 16 sorties en moyenne"
        }, resultat);
    }

    /// <summary>
    /// Given : deux vélos de ville, sortis 10 et 25 fois (moyenne 17,5).
    /// When : on résume les sorties par type.
    /// Then : une seule ligne, "ville : 2 vélos, 17 sorties en moyenne" : la moyenne garde sa partie entière.
    /// </summary>
    [Fact]
    public void SortiesParType_MoyenneNonEntiere_GardeLaPartieEntiere()
    {
        // Arrange : 10 et 25 sorties, moyenne 17,5 : la partie entière est 17
        List<Velo> deux = new List<Velo>
        {
            new("Tilleul", "ville", 2024, 25, 10),
            new("Saule", "ville", 2023, 21, 25)
        };

        // Act
        List<string> resultat = Examen.SortiesParType(deux);

        // Assert
        Assert.Equal(new List<string> { "ville : 2 vélos, 17 sorties en moyenne" }, resultat);
    }

    // ---------------------------------------------------------------- Q7
    /// <summary>
    /// Given : le jeu commun, Faucon (20 sorties, 30 francs), Pie (6 sorties) et Cerf (25 sorties, 20 francs).
    /// When : on retient les vélos sortis au moins 20 fois, triés par tarif.
    /// Then : la liste vaut Cerf puis Faucon, du moins cher au plus cher ; Pie est exclu.
    /// </summary>
    [Fact]
    public void NomsRetenus_CritereSortiesCleTarif_GardeLesSollicitesDuMoinsCherAuPlusCher()
    {
        // Arrange : au moins 20 sorties : Faucon (30 francs) et Cerf (20 francs) ; Pie (6 sorties) est exclu
        List<Velo> trois = Trois();

        // Act : les deux comportements sont transmis à la fonction
        List<string> resultat = Examen.NomsRetenus(trois, v => v.Sorties >= 20, v => v.Tarif);

        // Assert : du moins cher au plus cher
        Assert.Equal(new List<string> { "Cerf", "Faucon" }, resultat);
    }

    /// <summary>
    /// Given : le jeu commun, où Pie est le seul vélo de ville.
    /// When : on retient les vélos de ville, triés par nombre de sorties.
    /// Then : la liste ne contient que Pie.
    /// </summary>
    [Fact]
    public void NomsRetenus_CritereTypeCleSorties_UnSeulVelo()
    {
        // Arrange : un seul vélo de ville
        List<Velo> trois = Trois();

        // Act
        List<string> resultat = Examen.NomsRetenus(trois, v => v.Type == "ville", v => v.Sorties);

        // Assert
        Assert.Equal(new List<string> { "Pie" }, resultat);
    }

    // ---------------------------------------------------------------- Q8
    /// <summary>
    /// Given : le jeu commun, où le vélo le moins sollicité, Pie, compte 6 sorties.
    /// When : on demande si tous les vélos atteignent le seuil de 6 sorties.
    /// Then : la réponse est vrai.
    /// </summary>
    [Fact]
    public void TousSollicites_SeuilSousLePlusFaible_RendVrai()
    {
        // Arrange : le plus petit nombre de sorties est 6
        List<Velo> trois = Trois();

        // Act
        bool resultat = Examen.TousSollicites(trois, 6);

        // Assert
        Assert.True(resultat);
    }

    /// <summary>
    /// Given : le jeu commun, où Pie n'est sorti que 6 fois.
    /// When : on demande si tous les vélos atteignent le seuil de 7 sorties.
    /// Then : la réponse est faux.
    /// </summary>
    [Fact]
    public void TousSollicites_SeuilAuDessusDUnVelo_RendFaux()
    {
        // Arrange : Pie n'est sorti que 6 fois
        List<Velo> trois = Trois();

        // Act
        bool resultat = Examen.TousSollicites(trois, 7);

        // Assert
        Assert.False(resultat);
    }

    /// <summary>
    /// Given : le jeu commun, où le VTT Cerf coûte 20 francs.
    /// When : on cherche un VTT dont le tarif est inférieur à 25 francs.
    /// Then : la réponse est vrai.
    /// </summary>
    [Fact]
    public void ExisteDansLeType_UnVeloMoinsCher_RendVrai()
    {
        // Arrange : en VTT, Cerf coûte 20 francs
        List<Velo> trois = Trois();

        // Act
        bool resultat = Examen.ExisteDansLeType(trois, "VTT", 25);

        // Assert
        Assert.True(resultat);
    }

    /// <summary>
    /// Given : le jeu commun, où Pie, seul vélo de ville, coûte exactement 45 francs.
    /// When : on cherche un vélo de ville dont le tarif est inférieur à 45 francs.
    /// Then : la réponse est faux : l'égalité ne suffit pas, et les VTT moins chers ne comptent pas.
    /// </summary>
    [Fact]
    public void ExisteDansLeType_TarifEgalAuMaximumDansLeType_RendFaux()
    {
        // Arrange : Pie, seul vélo de ville, coûte exactement 45 francs ; "inférieur à" exclut l'égalité,
        // et les VTT moins chers ne comptent pas
        List<Velo> trois = Trois();

        // Act
        bool resultat = Examen.ExisteDansLeType(trois, "ville", 45);

        // Assert
        Assert.False(resultat);
    }

    /// <summary>
    /// Given : le jeu commun, où le VTT le moins cher, Cerf, coûte exactement 20 francs.
    /// When : on cherche un VTT dont le tarif est inférieur à 20 francs.
    /// Then : la réponse est faux : l'égalité ne suffit pas.
    /// </summary>
    [Fact]
    public void ExisteDansLeType_PlafondEgalAuPlusBasTarifDuType_RendFaux()
    {
        // Arrange : en VTT, le moins cher est Cerf, à exactement 20 francs ; "inférieur à" exclut l'égalité.
        // Une inégalité écrite dans l'autre sens (Tarif > tarifMax) trouverait Faucon et rendrait vrai
        List<Velo> trois = Trois();

        // Act
        bool resultat = Examen.ExisteDansLeType(trois, "VTT", 20);

        // Assert
        Assert.False(resultat);
    }

    // ---------------------------------------------------------------- Q9
    /// <summary>
    /// Given : le jeu commun et trois réparations dans le désordre : Cerf, selle, 30 francs ; Faucon, freins, 50 francs ; Faucon, chaîne, 90 francs.
    /// When : on détaille les réparations.
    /// Then : trois lignes avec le type du vélo, de la plus chère à la moins chère : Faucon chaîne, Faucon freins, Cerf selle.
    /// </summary>
    [Fact]
    public void ReparationsDetaillees_TroisReparations_DeLaPlusChereALaMoinsChere()
    {
        // Arrange : Faucon réparé deux fois, Cerf une fois ; Pie jamais réparé. Les coûts arrivent dans le désordre
        List<Velo> trois = Trois();
        List<Reparation> reparations = new List<Reparation>
        {
            new("Cerf", "selle", 30),
            new("Faucon", "freins", 50),
            new("Faucon", "chaîne", 90)
        };

        // Act
        List<string> resultat = Examen.ReparationsDetaillees(trois, reparations);

        // Assert
        Assert.Equal(new List<string>
        {
            "Faucon (VTT) : chaîne, 90 francs",
            "Faucon (VTT) : freins, 50 francs",
            "Cerf (VTT) : selle, 30 francs"
        }, resultat);
    }

    /// <summary>
    /// Given : le jeu commun, une réparation de Zébu, absent du parc (pneu, 110 francs), et une de Pie (freins, 40 francs).
    /// When : on détaille les réparations.
    /// Then : une seule ligne, "Pie (ville) : freins, 40 francs" ; Zébu n'apparaît pas.
    /// </summary>
    [Fact]
    public void ReparationsDetaillees_VeloAbsentDuParc_NApparaitPas()
    {
        // Arrange : Zébu n'est pas dans le parc
        List<Velo> trois = Trois();
        List<Reparation> reparations = new List<Reparation>
        {
            new("Zébu", "pneu", 110),
            new("Pie", "freins", 40)
        };

        // Act
        List<string> resultat = Examen.ReparationsDetaillees(trois, reparations);

        // Assert
        Assert.Equal(new List<string> { "Pie (ville) : freins, 40 francs" }, resultat);
    }

    // ---------------------------------------------------------------- Q10
    /// <summary>
    /// Given : le jeu commun et la somme de ses indices d'usure calculée en séquentiel.
    /// When : on calcule la somme des indices d'usure en parallèle.
    /// Then : le résultat est égal à la somme séquentielle.
    /// </summary>
    [Fact]
    public void SommeIndicesParallele_TroisVelos_MemeSommeQueSequentiel()
    {
        // Arrange : l'attendu vient de la version séquentielle, IndiceUsure est pure
        List<Velo> trois = Trois();
        int attendu = trois.Select(Examen.IndiceUsure).Sum();

        // Act
        int resultat = Examen.SommeIndicesParallele(trois);

        // Assert
        Assert.Equal(attendu, resultat);
    }

    /// <summary>
    /// Given : le jeu commun et ses indices d'usure calculés en séquentiel, dans l'ordre de la liste.
    /// When : on calcule les indices d'usure.
    /// Then : les indices sortent dans l'ordre de la liste : Faucon, Pie, Cerf.
    /// </summary>
    [Fact]
    public void IndicesDansLOrdre_TroisVelos_GardeLOrdreDeLaListe()
    {
        // Arrange
        List<Velo> trois = Trois();
        List<int> attendu = trois.Select(Examen.IndiceUsure).ToList();

        // Act
        List<int> resultat = Examen.IndicesDansLOrdre(trois);

        // Assert
        Assert.Equal(attendu, resultat);
    }
}
