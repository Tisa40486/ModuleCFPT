// Les trois fonctions de la facture, livrees par un collegue. Vous les testez, vous ne les modifiez pas (sauf pour les casser a l'etape 5 de l'exercice 1).
// Ces trois fonctions sont pures : elles ne modifient rien et n'affichent rien.
public static class Facturation
{
    // Les voitures de plus de 60 000 km. Six sur le catalogue complet.
    public static IEnumerable<Voiture> VoituresFacturables(List<Voiture> catalogue)
    {
        return catalogue.Where(v => v.Kilometrage > 60000);
    }

    // Pour chaque voiture facturable ayant des revisions : son modele et le cout total.
    // Jointure interne : une voiture sans revision ne produit aucune ligne.
    public static IEnumerable<(string Modele, int Cout)> AvecRevisions(
        List<Voiture> catalogue, List<Revision> revisions)
    {
        return VoituresFacturables(catalogue)
            .Join(revisions, v => v.Modele, r => r.Modele, (v, r) => (v.Modele, r.Cout))
            .GroupBy(l => l.Modele)
            .Select(g => (g.Key, g.Sum(l => l.Cout)));
    }

    // Le montant de la facture : 3 135 CHF sur le catalogue complet.
    public static int Total(List<Voiture> catalogue, List<Revision> revisions)
    {
        return AvecRevisions(catalogue, revisions).Aggregate(0, (acc, l) => acc + l.Cout);
    }
}