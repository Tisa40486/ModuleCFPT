// Fil rouge du module M323 : le catalogue de douze voitures d'un garage.
// Ce record est immuable : ses proprietes ne peuvent pas etre modifiees apres construction.
public record Voiture(
    string Marque,
    string Modele,
    int Prix,
    string Carburant,
    int Kilometrage,
    int Annee);
