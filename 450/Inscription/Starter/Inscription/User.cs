namespace Inscription
{
    // Première brique livrée par le client : la classe User.
    //
    // Ce que le client attend :
    // - une adresse e-mail, un mot de passe, un état actif ou non, lisibles de l'extérieur ;
    // - un constructeur qui refuse un e-mail vide, un e-mail sans @ et un mot de passe vide,
    //   en levant ArgumentException. Une condition et un message en français par règle ;
    // - un nouvel utilisateur n'est pas actif ;
    // - Activate() le rend actif, Deactivate() le rend inactif.
    //
    // Convention de l'école : champ privé et propriété explicite, jamais de propriété automatique.
    // Supprimez chaque TODO une fois fait.
    public class User
    {
        private string _email;

        public string Email
        {
            get { return _email; }
        }

        // TODO exercice 3 : ajoutez sur le même modèle _password avec Password, et _isActive avec IsActive.

        public User(string email, string password)
        {
            // TODO exercice 3 : trois règles, trois conditions, trois messages en français.
            _email = email;
        }

        // TODO exercice 3 : Activate() et Deactivate()
    }
}
