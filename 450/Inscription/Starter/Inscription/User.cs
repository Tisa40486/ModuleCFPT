namespace Inscription
{
    // Première brique livrée par le client : la classe User.
    //
    // Ce que le client attend :
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
        private string _password;
        private bool _isActive;
        public string Email 
        {
            get { return _email; }
        }

        public string Password
        {
            get { return _password; }
        }
        public bool IsActive
        {
            get { return _isActive; }
        }

        // TODO exercice 3 : ajoutez sur le même modèle _password avec Password, et _isActive avec IsActive.

        public User(string email, string password)
        {
            // TODO exercice 3 : trois règles, trois conditions, trois messages en français.
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Un email ne peut pas être vide");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Un mot de passe ne peut pas être vide");

            _email = email;
            _password = password;
        }

        // TODO exercice 3 : Activate() et Deactivate()
    }
}
