List<Voiture> catalogue = Donnees.ChargerCatalogue();
List<Revision> revisions = Donnees.ChargerRevisions();

Console.WriteLine(catalogue.Count + " voitures chargées, " + Environment.ProcessorCount + " coeurs.");
Console.WriteLine("Total facture : " + Facturation.Total(catalogue, revisions) + " CHF");

// ---------------------------------------------------------------
// Exercice 3 : les deux sommes, les deux mesures, la ligne dans l'ordre.
// A COMPLETER exercice 3
// ---------------------------------------------------------------
