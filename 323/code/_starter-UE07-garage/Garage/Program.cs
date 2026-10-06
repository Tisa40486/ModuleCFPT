List<Voiture> catalogue = Donnees.ChargerCatalogue();
List<Revision> revisions = Donnees.ChargerRevisions();


Console.WriteLine(catalogue.Count + " voitures chargées, " + Environment.ProcessorCount + " coeurs.");
Console.WriteLine("Total facture : " + Facturation.Total(catalogue, revisions) + " CHF");

// ---------------------------------------------------------------
// Exercice 3 : les deux sommes, les deux mesures, la ligne dans l'ordre.
// A COMPLETER exercice 3
// ---------------------------------------------------------------

Console.WriteLine("------Exerice3------");

int sommesIndice = Parallele.SommeIndices(catalogue);
int sommesIndiceParallele = Parallele.SommeIndicesParallele(catalogue);

long mesurerSommesIndice = Parallele.Mesurer(Parallele.SommeIndices, catalogue); 
long mesurerSommesIndiceParallele = Parallele.Mesurer(Parallele.SommeIndicesParallele, catalogue);

bool isEqual = false;

if (sommesIndice == sommesIndiceParallele)
    isEqual = true;

string danslOrdre = Parallele.ModelesDansLOrdre(catalogue);

Console.WriteLine($"Somme des indices, séquentiel : {sommesIndice} en {mesurerSommesIndice} ms");
Console.WriteLine($"Somme des indices, parallèle  : {sommesIndiceParallele} en {mesurerSommesIndiceParallele} ms");
Console.WriteLine($"Même somme : {isEqual}");
Console.WriteLine($"Dans l'ordre: {danslOrdre}");
