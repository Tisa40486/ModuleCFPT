namespace serie6_sol_kms
{
    /// <summary>
    /// Projet  : M320 - série 6
    /// Détails : Formulaire de l'exercice 2 : crée et affiche un Chien
    /// Auteur  : K. Mota
    /// Date    : 19.03.2023
    /// </summary>
    public partial class FrmEx2 : Form
    {
        // Le chien est déclaré globalement (en dehors d'une méthode) pour pouvoir être utilisé partout dans la classe
        // C'est un exemple d'association de type composition :
        //     - l'objet chien est privé au formulaire et jamais retourné par une méthode
        //          - il est dégtruit quand le formulaire est détruit
        // TODO A DECOMMENTER UNE FOIS LA CLASSE CHIEN CREEE
        //private Chien _monChien;

        /// <summary>
        /// Initialise les composants du formulaire et desactive le bouton "Créer"
        /// </summary>
        public FrmEx2()
        {
            InitializeComponent();
            // TODO On désactive le bouton Créer
        }

        /// <summary>
        /// Crée un chien et affiche ses informations dans les labels correspondants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreer_Click(object sender, EventArgs e)
        {
            // TODO On initialise la variable _monChien avec une nouvelle instance créée avec les données saisies dans les textbox
            // TODO On affiche les données du chien dans les labels correspondants
            // TODO On affiche l'aboiement du chien dans le label correspondant
        }

        /// <summary>
        /// Affiche l'aboiement du chien dans le label correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboyer_Click(object sender, EventArgs e)
        {
            // TODO On affiche l'aboiement du chien dans le label correspondant
        }

        /// <summary>
        /// Vérifie la taille du texte saisi et active le bouton Créer uniquement si la taille du text est > 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            // TODO On vérifie la taille du texte saisi et on active le bouton Créer uniquement si la taille du text est > 0
        }
    }
}

