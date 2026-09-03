List<Voiture> catalogue = Donnees.ChargerCatalogue();
Console.WriteLine(catalogue.Count + " voitures chargées.");

// ---------------------------------------------------------------
// Exercice 1 : appelez Inventaire et affichez le resultat ICI, pas dans la methode.
// A COMPLETER exercice 1
// Indice : var bilan = Exercices.Inventaire(catalogue, v => ...);
// ---------------------------------------------------------------

// ---------------------------------------------------------------
// Exercice 2 : appelez vos versions purifiees et comparez avec les originales.
// A COMPLETER exercice 2
// Indice : le meme argument doit toujours donner le meme resultat.
// ---------------------------------------------------------------

 double margeGlobale = 0.15;

//var voiture = new Voiture("Bmw", "M3", 50000, "diesel", 25000, 2020);

double prixVente = Exercices.PrixVentePurifier(catalogue[0], margeGlobale);

int age = Exercices.AgePur(catalogue[0], 2026);

int kmTotal = Exercices.KilometrageTotal(catalogue);
List<Voiture> tva = Exercices.AvecTva(catalogue);
List<Voiture> tvaPur = Exercices.AvecTvaPur(catalogue);


Console.WriteLine($"Prix Vente Pure : {prixVente} CHF");
Console.WriteLine($"Age Pur : {age} ans");
Console.WriteLine($"Prix original {catalogue[0].Modele} : {catalogue[0].Prix} CHF");
Console.WriteLine($"Prix avec Tva (Impure) : {tva[0].Modele} : {tva[0].Prix} CHF");
Console.WriteLine($"Prix avec Tva (Pure) {tvaPur[0].Modele} : {tvaPur[0].Prix} CHF");
Console.WriteLine($"Kilometrage total : {kmTotal} km ");





// ---------------------------------------------------------------
// Exercice 3 : reproduisez le defaut du catalogue partage, puis corrigez-le.
// A COMPLETER exercice 3
// Indice : commencez par List<Voiture> pourLeSite = catalogue; puis triez pourLeSite.
// ---------------------------------------------------------------
Console.WriteLine("============Exercice3============");
List<Voiture> site = catalogue;

site.Sort((a, b) => a.Prix - b.Prix);
Console.WriteLine($"Premier modele du catalogue original : {catalogue[0].Modele}") ;
Console.WriteLine($"Premier modele du site (adresse pointant sur le catalogue) : {site[0].Modele}");

int totOrigine = 0;
foreach (Voiture v in catalogue)
 totOrigine += v.Prix;

List<Voiture> soldes = Exercices.AvecRemise(catalogue, 0.10);

int totSolde = 0;
foreach (Voiture v in soldes)
 totSolde += v.Prix;
Console.WriteLine($"resultat TOT.Origine {totOrigine}");
Console.WriteLine($"resultat TOT.Solde {totSolde}");

//site = Exercices.Trier(site,)

// TODO