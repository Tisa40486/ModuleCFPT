using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serie6_sol_kms
{
    /// <summary>
    /// Projet  : M320 - série 6
    /// Détails : Formulaire d'entrée de l'application
    /// Auteur  : K. Mota
    /// Date    : 19.03.2023
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialise les composants du formulaire avec deux boutons pour lancer les 2 exercices
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Au click du bouton, affiche le formulaire de l'exercice 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEx1_Click(object sender, EventArgs e)
        {
            new FrmEx1().ShowDialog();
        }
        /// <summary>
        /// Au click du bouton, affiche le formulaire de l'exercice 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEx2_Click(object sender, EventArgs e)
        {
            new FrmEx2().ShowDialog();
        }
    }
}
