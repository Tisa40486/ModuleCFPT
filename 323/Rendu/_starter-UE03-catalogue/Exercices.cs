// Zones de travail de l'UE03. Aucun operateur LINQ dans ce fichier.
public static class Exercices
{
    // ---------------------------------------------------------------
    // Exercice 1 : l'inventaire remis a plat (palier C1A)
    // ---------------------------------------------------------------

    // Version de secours si vous n'avez pas votre Inventorier de l'UE02.
    public static void Inventorier(
        List<Voiture> catalogue,
        Predicate<Voiture> critere,
        Action<Voiture> quandTrouve,
        Action quandTermine)
    {
        foreach (Voiture v in catalogue)
        {
            if (critere(v))
            {
                quandTrouve(v);
            }
        }

        quandTermine();
    }

    public static (int Nombre, int Somme) Inventaire(
        List<Voiture> catalogue,
        Predicate<Voiture> critere)
    {
        // A COMPLETER exercice 1
        // Indice : deux variables locales, une boucle, un seul return. Aucun affichage ici.
        throw new NotImplementedException();
    }

    // ---------------------------------------------------------------
    // Exercice 2 : chasser les effets de bord (palier A1B)
    // Les quatre fonctions ci-dessous vous sont livrees telles quelles.
    // ---------------------------------------------------------------

    public static double margeGlobale = 0.15;

    // Fonction 1 : pure ou impure ? Purifiez-la si necessaire.
    public static double PrixVente(Voiture v)
    {
        return v.Prix * (1 + margeGlobale);
    }
    public static double PrixVentePurifier(Voiture v, double marge)
    {
        return v.Prix * (1 + marge);
    }

    // Fonction 2 : pure ou impure ? Purifiez-la si necessaire.
    // pure
    public static List<Voiture> AvecTva(List<Voiture> source)
    {
        for (int i = 0; i < source.Count; i++)
        {
            var s = source[i];
            source[i] = new Voiture(
                s.Marque,
                s.Modele,
                (int)(s.Prix * 1.081),
                s.Carburant,
                s.Kilometrage,
                s.Annee);
        }
        return source;
    }
    public static List<Voiture> AvecTvaPur(List<Voiture> source)
    {
        var result = new List<Voiture>();

        foreach (Voiture s in source)
        {
            result.Add(new Voiture(
                s.Marque,
                s.Modele,
                (int)(s.Prix * 1.081),
                s.Carburant,
                s.Kilometrage,
                s.Annee ));
        }

        return result;
    }

    // Fonction 3 : pure ou impure ? Purifiez-la si necessaire.

    public static int Age(Voiture v)
    {
        return DateTime.Now.Year - v.Annee;
    }
    public static int AgePur(Voiture v, int year)
    {
        return year - v.Annee;
    } 

    // Fonction 4 : question de l'extension. Pure ou impure ? Justifiez.
    // Deja Pur
    public static int KilometrageTotal(List<Voiture> catalogue)
    {
        int total = 0;
        foreach (Voiture v in catalogue)
        {
            total = total + v.Kilometrage;
        }

        return total;
    }

    // A COMPLETER exercice 2
    // Indice : ecrivez ici les versions purifiees, avec un nom suffixe Pur.

    // ---------------------------------------------------------------
    // Exercice 3 : le catalogue que personne ne modifie (palier A1I)
    // ---------------------------------------------------------------

    public static List<Voiture> AvecRemise(List<Voiture> catalogue, double taux)
    {
        // A COMPLETER exercice 3
        // Indice : une liste resultat, puis Add de v with { Prix = ... }. Ne touchez pas a catalogue.
        List<Voiture> result = new List<Voiture>();
        foreach (Voiture voiture in catalogue)
        {
            result.Add(voiture with { Prix = (int)(voiture.Prix * (1 - taux)) });
        }

        return result;
    }

    public static List<Voiture> Trier(List<Voiture> catalogue, Comparison<Voiture> comparaison)
    {
        // A COMPLETER extension exercice 3
        // Indice : une nouvelle liste construite a partir de catalogue, puis Sort sur cette nouvelle liste seulement.
        catalogue.Sort((a, b) => a.Prix - b.Prix);
        return catalogue;
    }
}
