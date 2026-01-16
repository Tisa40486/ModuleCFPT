using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serie13
{
    public partial class FrmVehicules : Form
    {
        /// <summary>
        /// Liste contenant toutes les instances de Parc de l'application
        /// </summary>
        List<Parc> parcs;
        /// <summary>
        /// Le parc actuellement selectionné sur la liste des parcs et celui dont les véhicules sont affichés
        /// </summary>
        Parc currentParc;
        /// <summary>
        /// L'année actuelele à fournir au calcul des statistiques
        /// </summary>
        const int ANNEE_ACTUELLE = 2022;

        public FrmVehicules()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Au load du formulaire, desactive tous les boutons du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVehicules_Load(object sender, EventArgs e)
        {
            //boutons inactivés à l'état initial en utilisant la méthode fournie BtnSetState(Button btn, bool state)
        }
        /// <summary>
        /// Set l'état du button passé en paramètre et change sa couleur selon si le bouton est actif ou pas
        /// </summary>
        /// <param name="btn">Le bouton dont </param>
        /// <param name="state">bool - true si le bouton doit être activé ; false si non</param>
        private void BtnSetState(Button btn, bool state)
        {
            btn.Enabled = state;
            if (!state)
            {
                btn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            }
            else
            {
                btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
        }

        /// <summary>
        /// Vide le Group box fourni en paramètre et desactive le bouton. 
        /// Utilisée pour vider le groupe box de la voiture ou de l'avion une fois que le véhicule est instancié
        /// </summary>
        /// <param name="group">Le groupe box à vider</param>
        private void ClearGroupBox(GroupBox group)
        {
            foreach (Control item in group.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 0;
                }
                if (item is Button)
                {
                    BtnSetState((Button)item, false);
                }
            }
        }
    }
}
