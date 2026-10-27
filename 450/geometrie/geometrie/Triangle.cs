using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometrie
{

    /// <summary>
    /// Classe un triangle d'après la longueur de ses trois côtés.
    /// Réponses possibles : "équilatéral", "isocèle", "scalène", "invalide".
    /// </summary>
    public class Triangle
    {
        public static string Classer(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return "invalide";
            }
            if (a == b && b == c)
            {
                return "équilatéral";
            }
            if (a == b || b == c || a == c)
            {
                return "isocèle";
            }
            return "scalène";
        }
    }
}
