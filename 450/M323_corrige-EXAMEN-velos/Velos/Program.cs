// Point d'entrée. Ne modifiez pas ce fichier.
// Vos essais vont dans Essais.cs, méthode Executer.
List<Velo> velos = Donnees.ChargerVelos();
Console.WriteLine(velos.Count + " velos charges.");
Essais.Executer(velos);
