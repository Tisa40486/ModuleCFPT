using System.Diagnostics;

// Exercice 3 : la meme somme, sur tous les coeurs.
public static class Parallele
{
    // Indice d'etat de l'UE05, sans son compteur : fonction pure et volontairement lente. Ne pas modifier.
    public static int IndiceEtat(Voiture v)
    {
        int somme = 0;
        for (int i = 0; i < 4_000_000; i++)
        {
            somme = (somme + v.Kilometrage % 7) % 1000;
        }
        return 100 - v.Kilometrage / 10000 + somme % 3;
    }

    public static int SommeIndices(List<Voiture> catalogue)
    {
        // A COMPLETER etape 1 : la somme des indices, un pipeline LINQ ordinaire
        throw new NotImplementedException();
    }

    public static int SommeIndicesParallele(List<Voiture> catalogue)
    {
        // A COMPLETER etape 2 : le meme pipeline, parallele
        throw new NotImplementedException();
    }

    public static string ModelesDansLOrdre(List<Voiture> catalogue)
    {
        // A COMPLETER etape 4 : les modeles separes par ", ", dans l'ordre du catalogue, malgre le parallele
        throw new NotImplementedException();
    }

    // Fourni : mesure une version de la somme, en millisecondes.
    public static long Mesurer(Func<List<Voiture>, int> version, List<Voiture> catalogue)
    {
        Stopwatch chrono = Stopwatch.StartNew();
        version(catalogue);
        chrono.Stop();
        return chrono.ElapsedMilliseconds;
    }
}
