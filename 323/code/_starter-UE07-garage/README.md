# Starter UE07 : solution à deux projets

Solution C# .NET 8 : un projet de code et un projet de test xUnit. Elle compile telle quelle.

## Mise en route

1. Copiez le dossier `_starter-UE07-garage` dans votre espace de travail.
2. Renommez la copie `M323-UE07-VotreNomUtilisateur`.
3. Ouvrez `GarageSolution.sln` dans Visual Studio, ou placez-vous dans le dossier et lancez :

```
dotnet restore
dotnet test
```

4. La sortie attendue est : `Passed!  - Failed: 0, Passed: 1, Skipped: 0, Total: 1`.
5. `dotnet run --project Garage` affiche le nombre de voitures, vos coeurs et `Total facture : 3135 CHF`.

## Contenu

| Chemin | Rôle |
|---|---|
| `Garage/Voiture.cs` et `Garage/Revision.cs` | les deux `record` du fil rouge. Ne pas modifier |
| `Garage/Donnees.cs` | les douze voitures et les dix révisions. Ne pas modifier |
| `Garage/Facturation.cs` | les trois fonctions pures à tester, fournies. Ne pas modifier, sauf pour la casser à l'étape 5 de l'exercice 1 |
| `Garage.Tests/FacturationTests.cs` | exercices 1 et 2, vos tests |
| `Garage/Parallele.cs` | exercice 3, la somme des indices |
| `Garage/Program.cs` | vos appels de l'exercice 3 |

Le projet `Garage.Tests` référence `Garage`. L'inverse n'existe jamais. Le guide `UE07-guide-projet-test.md` explique comment cette solution a été construite, pas à pas.

Valeurs de contrôle : `Facturation.Total` vaut 3 135 CHF sur le catalogue complet, 0 sur un catalogue vide.
Six voitures dépassent 60 000 km.
