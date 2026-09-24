// Zones de travail des exercices 1 et 2 de l'UE04.
public static class Exercices
{
    // ---------------------------------------------------------------
    // Exercice 1 : trois ecritures, un resultat (paliers A1A et C2A)
    // ---------------------------------------------------------------

    // Version de secours de votre Inventaire de l'UE03.
    public static (int Nombre, int Somme) Inventaire(
        List<Voiture> catalogue,
        Predicate<Voiture> critere)
    {
        int nombre = 0;
        int somme = 0;

        foreach (Voiture v in catalogue)
        {
            if (critere(v))
            {
                nombre = nombre + 1;
                somme = somme + v.Prix;
            }
        }

        return (nombre, somme);
    }

    public static (int Nombre, int Somme) VersionProcedurale(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 1, etape 1
        // Indice : une seule boucle, deux compteurs, la condition ecrite en dur.
        int nombre = 0;
        int somme = 0;
        foreach (Voiture v in catalogue)
        {
            if (v.Carburant == "électrique")
            {
                nombre++;
                somme += v.Prix;
            }
        }
        return (nombre, somme);
    }
    public static Predicate<Voiture> DeCarburant(string carburant)
    {
        // A COMPLETER exercice 1, etape 3
        // Indice : renvoyez une lambda, ne testez aucune voiture ici.
        return predicate => predicate.Carburant == carburant;
    }

    // ---------------------------------------------------------------
    // Exercice 2 : les trois operations isolees (palier B1B)
    // Ecrivez un pipeline d'une ligne par methode. Aucune boucle.
    // ---------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Ce meme catalogue avec les voitures de moins de 20000CHF</returns>
    public static IEnumerable<Voiture> MoinsDe20000(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, filter
        // Indice : Where garde les elements, il ne change pas leur type.
        return catalogue.Where(voiture => voiture.Prix < 20000);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Ce meme catalogue avec les voitures de moins de 2018</returns>
    public static IEnumerable<Voiture> AvantDeuxMilleDixHuit(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, filter
        return catalogue.Where(voiture => voiture.Annee < 2018);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Une collection de string avec tout les modeles du catalogue</returns>
    public static IEnumerable<string> Modeles(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, map
        // Indice : Select change le type des elements, jamais leur nombre.
        return catalogue.Select(voiture => voiture.Modele);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Une collection de double avec tout les prix avec le taux a 8.1 ajouté</returns>
    public static IEnumerable<double> PrixTtc(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, map : taux de 8,1 pour cent
        return catalogue.Select(voiture => voiture.Prix * 8.1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Le total des prix du catalogue de voiture avec une graine de type int</returns>
    public static int TotalDesPrix(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, reduce : graine de type int, resultat attendu 303400
        // Indice : Aggregate(graine, (acc, v) => ...).
        return catalogue.Aggregate(0, (acc, voiture) => acc + voiture.Prix);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="catalogue">Le catalogue de toutes les voitures</param>
    /// <returns>Une chaine listant les modeles avec une graine de type string</returns>
    public static string ChaineDesModeles(List<Voiture> catalogue)
    {
        // A COMPLETER exercice 2, reduce : graine de type string
        return catalogue.Aggregate("", (acc, voiture) => acc + voiture.Modele + " ");
    }
}


