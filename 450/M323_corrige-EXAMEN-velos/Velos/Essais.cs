// Essais du corrigé, version du 11.10.2026 (reconstitué le 12.10.2026) : affiche les valeurs de contrôle du parc.
// Usage enseignante. Ne pas copier ce fichier sur le disque d'examen.
public static class Essais
{
    public static void Executer(List<Velo> velos)
    {
        List<Reparation> reparations = Donnees.ChargerReparations();
        Console.WriteLine("Q5, n = 3 : " + Examen.TarifDesPlusSollicites(velos, 3));
        Console.WriteLine("Q6 :");
        Examen.SortiesParType(velos).ForEach(l => Console.WriteLine("  " + l));
        Console.WriteLine("Q7, sorties >= 40 par tarif : "
            + string.Join(", ", Examen.NomsRetenus(velos, v => v.Sorties >= 40, v => v.Tarif)));
        Console.WriteLine("Q8, TousSollicites(17) : " + Examen.TousSollicites(velos, 17)
            + " ; TousSollicites(18) : " + Examen.TousSollicites(velos, 18));
        Console.WriteLine("Q8, ExisteDansLeType(VTT, 23) : " + Examen.ExisteDansLeType(velos, "VTT", 23)
            + " ; ExisteDansLeType(VTT, 22) : " + Examen.ExisteDansLeType(velos, "VTT", 22));
        Console.WriteLine("Q9 :");
        Examen.ReparationsDetaillees(velos, reparations).ForEach(l => Console.WriteLine("  " + l));
        Console.WriteLine("Q10, somme : " + Examen.SommeIndicesParallele(velos));
        Console.WriteLine("Q10, dans l'ordre : " + string.Join(", ", Examen.IndicesDansLOrdre(velos)));
    }
}
