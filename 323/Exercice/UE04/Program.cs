List<Voiture> catalogue = Donnees.ChargerCatalogue();
Console.WriteLine(catalogue.Count + " voitures chargées.");
static (int Nombre, int Somme) Afficher(List<Voiture> catalogue, Predicate<Voiture> critere)
{
    int Number = 0;
    int Sum = 0;
    foreach (Voiture v in catalogue)
    {
        if (critere(v))
        {
            Number++;
            Sum += v.Prix;
        }
    }
    return (Number, Sum);
}
// ---------------------------------------------------------------
// Exercice 1 : comparez les trois ecritures sur le meme besoin.
// A COMPLETER exercice 1
// Indice : les trois doivent afficher 3 voitures et 94000 CHF.
// ---------------------------------------------------------------
Console.WriteLine($"---Exercice 1 : trois ecritures, un resultat");

(int Nombre, int Somme) procedurale = Exercices.VersionProcedurale(catalogue);

Statistique statistique = new(catalogue);
int statsNumber = statistique.NombreVoitureParCarburant("électrique");
int statsSum = statistique.ValeurVoitureParCarburant("électrique");

Predicate<Voiture> critereElec = Exercices.DeCarburant("électrique");
Predicate<Voiture> critereDiesel = Exercices.DeCarburant("diesel");

(int Nombre, int Somme) fonctionelleElec = Afficher(catalogue, critereElec);
(int Nombre, int Somme) fonctionelleDiesel = Afficher(catalogue, critereDiesel);

Console.WriteLine($"Procedurale : {procedurale.Nombre} voiture. {procedurale.Somme} CHF");

Console.WriteLine($"Oriente Objet : {statsNumber} voiture. {statsSum} CHF");

Console.WriteLine($"Fonctionelle : {fonctionelleElec.Nombre} voiture. {fonctionelleElec.Somme} CHF");
Console.WriteLine($"Fonctionelle (Diesel) : {fonctionelleDiesel.Nombre} voiture. {fonctionelleDiesel.Somme} CHF");
// ---------------------------------------------------------------
// Exercice 2 : appelez vos six pipelines et notez type et nombre en sortie.
// A COMPLETER exercice 2
// ---------------------------------------------------------------
Console.WriteLine($"---Exercice 2");
IEnumerable<double> prixTtc = Exercices.PrixTtc(catalogue);
IEnumerable<string> modeles = Exercices.Modeles(catalogue);
foreach (double prix in prixTtc)
{
    Console.WriteLine($"Prix : {prix}");
}
Console.WriteLine();
foreach (string modele in modeles)
{
    Console.WriteLine($"Modele : {modele}");
}

Console.WriteLine();

Console.WriteLine($"TotalPrix : {Exercices.TotalDesPrix(catalogue)} CHF"); 
Console.WriteLine($"Modeles : {Exercices.ChaineDesModeles(catalogue)}"); 

// ---------------------------------------------------------------
// Exercice 3 : affichez les quatre rapports, puis reaffichez le total
// du catalogue pour prouver qu'il n'a pas change.
// A COMPLETER exercice 3
// ---------------------------------------------------------------

// le prix moyen des voitures électriques ;
// source : le catalogue; filtre : le carburant (électriques) ; trie : Prix; projection: Average des prix
// catalogue.Where(voiture => voiture.Carburant == "électrique").Select(voiture => voiture.Prix).Average();

// les modèles des voitures de plus de 100 000 km ;
// source : le catalogue; filtre: tout ceux qui ont plus 100k km; projection : Les modeles
// catalogue.Where(voiture => voiture.Kilometrage > 100000).Select(voiture => voiture.Modele);

// la valeur totale du stock hors voitures électriques ;
// source : le catalogue; filtre : tout ce qui n'est pas voiture elec; projection : la valeur; l'aggregat : la sommes des valeurs
//catalogue.Where(v => v.Carburant != "électrique").Select(v => v.Prix).Sum();

//une seule chaîne listant les modèles hybrides et leur année.
// source le catalogue; filtre :les voitures hybrides; projection : le modèle et l'année ; Agrégation : concaténer tous les résultats en une seule chaîne 
// catalogue.Where(v => v.Carburant == "hybride").Select(v => $"{v.Modele} - {v.Annee}").Aggregate((accumulateur, element) => $"{accumulateur}, {element}");
