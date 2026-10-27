// M323, examen final, partie 2 : corrigé exécutable. Usage enseignante, ne pas copier sur le disque d'examen.
public static class Examen
{
    // ------------------------------------------------------------------
    // Q5 : Les vélos les plus sollicités (4 points, palier C2I)
    // L'atelier classe son parc du plus grand nombre de sorties au plus petit et veut le tarif cumulé
    // des n premiers vélos de ce classement.
    // Écrivez TarifDesPlusSollicites : un seul enchaînement LINQ, sans boucle, qui ne modifie pas la liste reçue.
    // Test fourni : TarifDesPlusSollicites_TroisVelosDeuxDemandes_AdditionneLesDeuxPlusSollicites
    // ------------------------------------------------------------------

    /// <summary>
    /// Calcule le tarif cumulé des n vélos les plus sollicités dans la liste de vélos.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <param name="n">Le nombre de vélos les plus sollicités à considérer.</param>
    /// <returns>Le tarif cumulé des n vélos les plus sollicités.</returns>
    public static int TarifDesPlusSollicites(List<Velo> velos, int n)
    {
        return velos
            .OrderByDescending(v => v.Sorties)
            .Take(n)
            .Sum(v => v.Tarif);
    }


    // ------------------------------------------------------------------
    // Q6 : Les sorties type par type (4 points, palier C2I)
    // L'atelier veut savoir où se tiennent les sorties de chaque type de vélo.
    // Écrivez SortiesParType : elle rend une ligne par type, avec le nombre de vélos du type
    // et leur nombre moyen de sorties en entier (partie entière de la moyenne), les types classés
    // de la meilleure moyenne à la moins bonne.
    // Une ligne se présente ainsi, les valeurs étant fictives :   pliant : 4 vélos, 18 sorties en moyenne
    // Un seul enchaînement LINQ, sans boucle.
    // Tests fournis : SortiesParType_DeuxTypes_ClasseLaMeilleureMoyenneEnPremier,
    //                 SortiesParType_MoyenneNonEntiere_GardeLaPartieEntiere
    // ------------------------------------------------------------------
    /// <summary>
    /// Regroupe les vélos par type et calcule le nombre de vélos et la moyenne des sorties pour chaque type.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <returns>Une liste de chaînes décrivant le nombre de vélos et la moyenne des sorties pour chaque type.</returns>
    public static List<string> SortiesParType(List<Velo> velos)
    {
        return velos
            .GroupBy(v => v.Type)
            .Select(g => new { Type = g.Key, Nombre = g.Count(), Moyenne = g.Average(v => v.Sorties) })
            .OrderByDescending(l => l.Moyenne)
            .Select(l => l.Type + " : " + l.Nombre + " vélos, " + (int)l.Moyenne + " sorties en moyenne")
            .ToList();
    }


    // ------------------------------------------------------------------
    // Q7 : Filtre et classement sur mesure (3 points, palier C2A)
    // L'atelier change d'avis chaque semaine sur ce qu'il veut voir et dans quel ordre. Plutôt que
    // d'écrire une fonction par demande, écrivez-en une seule qui reçoit les deux comportements :
    // NomsRetenus rend les noms des vélos qui respectent le critère reçu, classés selon
    // la clé reçue, de la plus petite valeur à la plus grande.
    // Un seul enchaînement LINQ, sans boucle. Les deux comportements s'utilisent tels quels.
    // Tests fournis : NomsRetenus_CritereSortiesCleTarif_GardeLesSollicitesDuMoinsCherAuPlusCher,
    //                 NomsRetenus_CritereTypeCleSorties_UnSeulVelo
    // ------------------------------------------------------------------
    /// <summary>
    /// Filtre les vélos selon un critère donné et les classe selon une clé donnée, puis retourne les noms des vélos retenus.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <param name="critere">Le critère de filtrage des vélos.</param>
    /// <param name="cle">La clé de classement des vélos.</param>
    /// <returns>Une liste des noms des vélos retenus.</returns>
    public static List<string> NomsRetenus(List<Velo> velos, Func<Velo, bool> critere, Func<Velo, int> cle)
    {
        return velos
            .Where(critere)
            .OrderBy(cle)
            .Select(v => v.Nom)
            .ToList();
    }


    // ------------------------------------------------------------------
    // Q8 : Deux questions fermées (3 points, palier B1I)
    // L'atelier pose deux questions auxquelles on répond par oui ou par non.
    // Écrivez deux fonctions qui rendent chacune un booléen, sans boucle et sans compter :
    // - TousSollicites : tous les vélos du parc sont-ils sortis au moins sorties fois ?
    // - ExisteDansLeType : existe-t-il, dans le type type, un vélo dont le tarif est inférieur à tarifMax ?
    // Tests fournis : TousSollicites_SeuilSousLePlusFaible_RendVrai, TousSollicites_SeuilAuDessusDUnVelo_RendFaux,
    //                 ExisteDansLeType_UnVeloMoinsCher_RendVrai, ExisteDansLeType_TarifEgalAuMaximumDansLeType_RendFaux,
    //                 ExisteDansLeType_PlafondEgalAuPlusBasTarifDuType_RendFaux
    // ------------------------------------------------------------------

    /// <summary>
    /// Cherche si tous les vélos de la liste ont été sortis au moins un certain nombre de fois.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <param name="sorties">Le nombre minimum de sorties.</param>
    /// <returns>Vrai si tous les vélos ont été sortis au moins sorties fois, sinon faux.</returns>
    public static bool TousSollicites(List<Velo> velos, int sorties)
    {
        return velos.All(v => v.Sorties >= sorties);
    }

    /// <summary>
    /// Cherche s'il existe dans la liste de vélos un vélo d'un certain type dont le tarif est inférieur à un maximum donné.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <param name="type">Le type de vélo recherché.</param>
    /// <param name="tarifMax">Le tarif maximum.</param>
    /// <returns>Vrai si un vélo du type donné a un tarif inférieur à tarifMax, sinon faux.</returns>
    public static bool ExisteDansLeType(List<Velo> velos, string type, int tarifMax)
    {
        return velos.Any(v => v.Type == type && v.Tarif < tarifMax);
    }


    // ------------------------------------------------------------------
    // Q9 : Les réparations de l'atelier (4 points, palier C2I)
    // L'atelier veut la liste des réparations faites sur les vélos, avec le type de chaque vélo réparé.
    // La fonction reçoit le parc et la liste des réparations ; une réparation ne connaît le vélo que par
    // son nom. Donnees.ChargerReparations() ne sert qu'à vos essais.
    // Écrivez ReparationsDetaillees : elle rend une ligne par réparation dont le vélo est au parc,
    // de la réparation la plus chère à la moins chère.
    // Une ligne se présente ainsi, les valeurs étant fictives :   Moineau (pliant) : pneu, 25 francs
    // Un seul enchaînement LINQ, sans boucle.
    // Tests fournis : ReparationsDetaillees_TroisReparations_DeLaPlusChereALaMoinsChere,
    //                 ReparationsDetaillees_VeloAbsentDuParc_NApparaitPas
    // ------------------------------------------------------------------
    /// <summary>
    /// Join les vélos et les réparations pour obtenir une liste détaillée des réparations effectuées 
    /// sur les vélos présents dans le parc puis les trie par coût décroissant, formate les informations pour chaque réparation
    /// et renvoie la liste des textes formatés.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <param name="reparations">La liste des réparations.</param>
    /// <returns>Une liste de chaînes décrivant chaque réparation.</returns>
    public static List<string> ReparationsDetaillees(List<Velo> velos, List<Reparation> reparations)
    {
        return velos
            .Join(reparations,
                  v => v.Nom,
                  r => r.Nom,
                  (v, r) => new { v.Nom, v.Type, r.Piece, r.Cout }
                 )
            .OrderByDescending(velo => velo.Cout)
            .Select(velo => velo.Nom + " (" + velo.Type + ") : " + velo.Piece + ", " + velo.Cout + " francs")
            .ToList();
    }


    // ------------------------------------------------------------------
    // Q10 : Sur tous les cœurs (2 points, palier D1I)
    // IndiceUsure, fournie plus bas, est pure et volontairement lente. Écrivez avec PLINQ deux fonctions :
    // 1- SommeIndicesParallele : la somme des indices d'usure des vélos ;
    // 2- IndicesDansLOrdre : les indices d'usure, dans l'ordre de la liste reçue.
    // Les tests ne vérifient pas le parallélisme : une fonction écrite sans AsParallel() vaut 0, même si son test est vert.
    // Tests fournis : SommeIndicesParallele_TroisVelos_MemeSommeQueSequentiel,
    //                 IndicesDansLOrdre_TroisVelos_GardeLOrdreDeLaListe
    // ------------------------------------------------------------------
    /// <summary>
    /// Calcule en parallele la somme des indices d'usure des vélos dans la liste.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <returns>La somme des indices d'usure.</returns>
    public static int SommeIndicesParallele(List<Velo> velos)
    {
        return velos.AsParallel().Select(IndiceUsure).Sum();
    }

    /// <summary>
    /// Calcule en parallele les indices d'usure des vélos dans la liste, en conservant l'ordre de la liste reçue.
    /// </summary>
    /// <param name="velos">La liste des vélos.</param>
    /// <returns>Une liste des indices d'usure dans l'ordre de la liste reçue.</returns>
    public static List<int> IndicesDansLOrdre(List<Velo> velos)
    {
        return velos.AsParallel().AsOrdered().Select(IndiceUsure).ToList();
    }


    // Fonction pure et volontairement lente, fournie. Interdit de modifier.

    /// <summary>
    /// Calcule un indice d'usure pour un vélo donné. Cette fonction est volontairement lente 
    /// et ne doit pas être modifiée.
    /// </summary>
    /// <param name="v">Le vélo pour lequel calculer l'indice d'usure.</param>
    /// <returns>L'indice d'usure du vélo.</returns>
    public static int IndiceUsure(Velo v)
    {
        int somme = 0;
        for (int i = 0; i < 20_000_000; i++)
        {
            somme = (somme + v.Sorties % 7) % 1000;
        }

        return v.Sorties / 2 + v.Tarif + somme % 3;
    }
}
