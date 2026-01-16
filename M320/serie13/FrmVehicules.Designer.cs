
namespace serie13
{
    partial class FrmVehicules
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbVehicules = new System.Windows.Forms.GroupBox();
            this.lsVehicules = new System.Windows.Forms.ListBox();
            this.gbDetailsVehicule = new System.Windows.Forms.GroupBox();
            this.lblVehicule = new System.Windows.Forms.Label();
            this.nupPrixChange = new System.Windows.Forms.NumericUpDown();
            this.lblChangePrix = new System.Windows.Forms.Label();
            this.btnMoins = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnDelVehicule = new System.Windows.Forms.Button();
            this.gbParc = new System.Windows.Forms.GroupBox();
            this.lsParcs = new System.Windows.Forms.ListBox();
            this.txtPays = new System.Windows.Forms.TextBox();
            this.lblPays = new System.Windows.Forms.Label();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.lblVille = new System.Windows.Forms.Label();
            this.btnDelParc = new System.Windows.Forms.Button();
            this.btnParc = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.gbVoiture = new System.Windows.Forms.GroupBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblAnnee = new System.Windows.Forms.Label();
            this.nupPrixVoiture = new System.Windows.Forms.NumericUpDown();
            this.nupAnnee = new System.Windows.Forms.NumericUpDown();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.lblMarque = new System.Windows.Forms.Label();
            this.btnAddVoiture = new System.Windows.Forms.Button();
            this.nupPuissance = new System.Windows.Forms.NumericUpDown();
            this.nupCylindree = new System.Windows.Forms.NumericUpDown();
            this.nupKm = new System.Windows.Forms.NumericUpDown();
            this.nupNbPortes = new System.Windows.Forms.NumericUpDown();
            this.lblCylindree = new System.Windows.Forms.Label();
            this.lblKm = new System.Windows.Forms.Label();
            this.lblPuissance = new System.Windows.Forms.Label();
            this.lblNbPortes = new System.Windows.Forms.Label();
            this.gbAvion = new System.Windows.Forms.GroupBox();
            this.cbMoteur = new System.Windows.Forms.ComboBox();
            this.btnAddAvion = new System.Windows.Forms.Button();
            this.lblHeures = new System.Windows.Forms.Label();
            this.lblMoteur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nupHeures = new System.Windows.Forms.NumericUpDown();
            this.nupPrixAvion = new System.Windows.Forms.NumericUpDown();
            this.nupAnneeAvion = new System.Windows.Forms.NumericUpDown();
            this.txtMarqueAvion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbVehicules.SuspendLayout();
            this.gbDetailsVehicule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixChange)).BeginInit();
            this.gbParc.SuspendLayout();
            this.gbStats.SuspendLayout();
            this.gbVoiture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixVoiture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnnee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPuissance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCylindree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNbPortes)).BeginInit();
            this.gbAvion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixAvion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnneeAvion)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVehicules
            // 
            this.gbVehicules.BackColor = System.Drawing.SystemColors.Info;
            this.gbVehicules.Controls.Add(this.lsVehicules);
            this.gbVehicules.Controls.Add(this.gbDetailsVehicule);
            this.gbVehicules.Controls.Add(this.btnDelVehicule);
            this.gbVehicules.Location = new System.Drawing.Point(48, 339);
            this.gbVehicules.Name = "gbVehicules";
            this.gbVehicules.Size = new System.Drawing.Size(1150, 285);
            this.gbVehicules.TabIndex = 10;
            this.gbVehicules.TabStop = false;
            this.gbVehicules.Text = "Les Véhicules du parc selectionné";
            // 
            // lsVehicules
            // 
            this.lsVehicules.FormattingEnabled = true;
            this.lsVehicules.ItemHeight = 20;
            this.lsVehicules.Location = new System.Drawing.Point(19, 33);
            this.lsVehicules.Name = "lsVehicules";
            this.lsVehicules.Size = new System.Drawing.Size(236, 184);
            this.lsVehicules.TabIndex = 11;
            // 
            // gbDetailsVehicule
            // 
            this.gbDetailsVehicule.Controls.Add(this.lblVehicule);
            this.gbDetailsVehicule.Controls.Add(this.nupPrixChange);
            this.gbDetailsVehicule.Controls.Add(this.lblChangePrix);
            this.gbDetailsVehicule.Controls.Add(this.btnMoins);
            this.gbDetailsVehicule.Controls.Add(this.btnPlus);
            this.gbDetailsVehicule.Location = new System.Drawing.Point(269, 33);
            this.gbDetailsVehicule.Name = "gbDetailsVehicule";
            this.gbDetailsVehicule.Size = new System.Drawing.Size(862, 229);
            this.gbDetailsVehicule.TabIndex = 13;
            this.gbDetailsVehicule.TabStop = false;
            this.gbDetailsVehicule.Text = "Détails du véhicule selectionné";
            // 
            // lblVehicule
            // 
            this.lblVehicule.AutoSize = true;
            this.lblVehicule.Location = new System.Drawing.Point(11, 31);
            this.lblVehicule.Name = "lblVehicule";
            this.lblVehicule.Size = new System.Drawing.Size(187, 20);
            this.lblVehicule.TabIndex = 14;
            this.lblVehicule.Text = "Aucun véhicule sélectionné";
            // 
            // nupPrixChange
            // 
            this.nupPrixChange.DecimalPlaces = 2;
            this.nupPrixChange.Location = new System.Drawing.Point(150, 145);
            this.nupPrixChange.Name = "nupPrixChange";
            this.nupPrixChange.Size = new System.Drawing.Size(118, 27);
            this.nupPrixChange.TabIndex = 15;
            // 
            // lblChangePrix
            // 
            this.lblChangePrix.AutoSize = true;
            this.lblChangePrix.Location = new System.Drawing.Point(12, 147);
            this.lblChangePrix.Name = "lblChangePrix";
            this.lblChangePrix.Size = new System.Drawing.Size(132, 20);
            this.lblChangePrix.TabIndex = 16;
            this.lblChangePrix.Text = "Modifier le prix de";
            // 
            // btnMoins
            // 
            this.btnMoins.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoins.ForeColor = System.Drawing.Color.Red;
            this.btnMoins.Location = new System.Drawing.Point(231, 178);
            this.btnMoins.Name = "btnMoins";
            this.btnMoins.Size = new System.Drawing.Size(37, 39);
            this.btnMoins.TabIndex = 17;
            this.btnMoins.Text = "-";
            this.btnMoins.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlus.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnPlus.Location = new System.Drawing.Point(150, 178);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(42, 39);
            this.btnPlus.TabIndex = 18;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            // 
            // btnDelVehicule
            // 
            this.btnDelVehicule.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelVehicule.Location = new System.Drawing.Point(19, 233);
            this.btnDelVehicule.Name = "btnDelVehicule";
            this.btnDelVehicule.Size = new System.Drawing.Size(236, 29);
            this.btnDelVehicule.TabIndex = 12;
            this.btnDelVehicule.Text = "Supprimer";
            this.btnDelVehicule.UseVisualStyleBackColor = false;
            // 
            // gbParc
            // 
            this.gbParc.BackColor = System.Drawing.SystemColors.Info;
            this.gbParc.Controls.Add(this.lsParcs);
            this.gbParc.Controls.Add(this.txtPays);
            this.gbParc.Controls.Add(this.lblPays);
            this.gbParc.Controls.Add(this.txtVille);
            this.gbParc.Controls.Add(this.lblVille);
            this.gbParc.Controls.Add(this.btnDelParc);
            this.gbParc.Controls.Add(this.btnParc);
            this.gbParc.Location = new System.Drawing.Point(48, 65);
            this.gbParc.Name = "gbParc";
            this.gbParc.Size = new System.Drawing.Size(1150, 256);
            this.gbParc.TabIndex = 0;
            this.gbParc.TabStop = false;
            this.gbParc.Text = "Les parcs";
            // 
            // lsParcs
            // 
            this.lsParcs.FormattingEnabled = true;
            this.lsParcs.ItemHeight = 20;
            this.lsParcs.Location = new System.Drawing.Point(808, 17);
            this.lsParcs.Name = "lsParcs";
            this.lsParcs.Size = new System.Drawing.Size(323, 164);
            this.lsParcs.TabIndex = 5;
            // 
            // txtPays
            // 
            this.txtPays.Location = new System.Drawing.Point(147, 93);
            this.txtPays.Name = "txtPays";
            this.txtPays.Size = new System.Drawing.Size(390, 27);
            this.txtPays.TabIndex = 2;
            // 
            // lblPays
            // 
            this.lblPays.AutoSize = true;
            this.lblPays.Location = new System.Drawing.Point(30, 93);
            this.lblPays.Name = "lblPays";
            this.lblPays.Size = new System.Drawing.Size(37, 20);
            this.lblPays.TabIndex = 6;
            this.lblPays.Text = "Pays";
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(147, 48);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(390, 27);
            this.txtVille.TabIndex = 1;
            // 
            // lblVille
            // 
            this.lblVille.AutoSize = true;
            this.lblVille.Location = new System.Drawing.Point(30, 51);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(38, 20);
            this.lblVille.TabIndex = 2;
            this.lblVille.Text = "Ville";
            // 
            // btnDelParc
            // 
            this.btnDelParc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelParc.Location = new System.Drawing.Point(980, 196);
            this.btnDelParc.Name = "btnDelParc";
            this.btnDelParc.Size = new System.Drawing.Size(151, 29);
            this.btnDelParc.TabIndex = 5;
            this.btnDelParc.Text = "Supprimer";
            this.btnDelParc.UseVisualStyleBackColor = false;
            // 
            // btnParc
            // 
            this.btnParc.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnParc.Location = new System.Drawing.Point(269, 143);
            this.btnParc.Name = "btnParc";
            this.btnParc.Size = new System.Drawing.Size(268, 29);
            this.btnParc.TabIndex = 3;
            this.btnParc.Text = "Créer";
            this.btnParc.UseVisualStyleBackColor = false;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitre.Location = new System.Drawing.Point(298, 21);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(456, 41);
            this.lblTitre.TabIndex = 7;
            this.lblTitre.Text = "Gestion des Parcs des Véhicules";
            // 
            // gbStats
            // 
            this.gbStats.BackColor = System.Drawing.SystemColors.Info;
            this.gbStats.Controls.Add(this.lblStats);
            this.gbStats.Location = new System.Drawing.Point(48, 648);
            this.gbStats.Name = "gbStats";
            this.gbStats.Size = new System.Drawing.Size(1150, 229);
            this.gbStats.TabIndex = 50;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "Les résultats des statistiques";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(11, 31);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(196, 20);
            this.lblStats.TabIndex = 51;
            this.lblStats.Text = "Aucune statistique à afficher";
            // 
            // gbVoiture
            // 
            this.gbVoiture.BackColor = System.Drawing.SystemColors.Info;
            this.gbVoiture.Controls.Add(this.lblPrix);
            this.gbVoiture.Controls.Add(this.lblAnnee);
            this.gbVoiture.Controls.Add(this.nupPrixVoiture);
            this.gbVoiture.Controls.Add(this.nupAnnee);
            this.gbVoiture.Controls.Add(this.txtMarque);
            this.gbVoiture.Controls.Add(this.lblMarque);
            this.gbVoiture.Controls.Add(this.btnAddVoiture);
            this.gbVoiture.Controls.Add(this.nupPuissance);
            this.gbVoiture.Controls.Add(this.nupCylindree);
            this.gbVoiture.Controls.Add(this.nupKm);
            this.gbVoiture.Controls.Add(this.nupNbPortes);
            this.gbVoiture.Controls.Add(this.lblCylindree);
            this.gbVoiture.Controls.Add(this.lblKm);
            this.gbVoiture.Controls.Add(this.lblPuissance);
            this.gbVoiture.Controls.Add(this.lblNbPortes);
            this.gbVoiture.Location = new System.Drawing.Point(1219, 47);
            this.gbVoiture.Name = "gbVoiture";
            this.gbVoiture.Size = new System.Drawing.Size(419, 454);
            this.gbVoiture.TabIndex = 20;
            this.gbVoiture.TabStop = false;
            this.gbVoiture.Text = "Nouvelle Voiture";
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location = new System.Drawing.Point(10, 137);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPrix.TabIndex = 30;
            this.lblPrix.Text = "Prix de base : ";
            // 
            // lblAnnee
            // 
            this.lblAnnee.AutoSize = true;
            this.lblAnnee.Location = new System.Drawing.Point(12, 83);
            this.lblAnnee.Name = "lblAnnee";
            this.lblAnnee.Size = new System.Drawing.Size(114, 20);
            this.lblAnnee.TabIndex = 31;
            this.lblAnnee.Text = "Annee d\'achat : ";
            // 
            // nupPrixVoiture
            // 
            this.nupPrixVoiture.DecimalPlaces = 2;
            this.nupPrixVoiture.Location = new System.Drawing.Point(140, 130);
            this.nupPrixVoiture.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupPrixVoiture.Name = "nupPrixVoiture";
            this.nupPrixVoiture.Size = new System.Drawing.Size(266, 27);
            this.nupPrixVoiture.TabIndex = 23;
            // 
            // nupAnnee
            // 
            this.nupAnnee.Location = new System.Drawing.Point(140, 76);
            this.nupAnnee.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nupAnnee.Name = "nupAnnee";
            this.nupAnnee.Size = new System.Drawing.Size(266, 27);
            this.nupAnnee.TabIndex = 22;
            // 
            // txtMarque
            // 
            this.txtMarque.Location = new System.Drawing.Point(140, 26);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.Size = new System.Drawing.Size(268, 27);
            this.txtMarque.TabIndex = 21;
            // 
            // lblMarque
            // 
            this.lblMarque.AutoSize = true;
            this.lblMarque.Location = new System.Drawing.Point(12, 35);
            this.lblMarque.Name = "lblMarque";
            this.lblMarque.Size = new System.Drawing.Size(71, 20);
            this.lblMarque.TabIndex = 32;
            this.lblMarque.Text = "Marque : ";
            // 
            // btnAddVoiture
            // 
            this.btnAddVoiture.Location = new System.Drawing.Point(17, 379);
            this.btnAddVoiture.Name = "btnAddVoiture";
            this.btnAddVoiture.Size = new System.Drawing.Size(391, 48);
            this.btnAddVoiture.TabIndex = 28;
            this.btnAddVoiture.Text = "Ajouter la voiture au Parc ";
            this.btnAddVoiture.UseVisualStyleBackColor = true;
            // 
            // nupPuissance
            // 
            this.nupPuissance.DecimalPlaces = 2;
            this.nupPuissance.Location = new System.Drawing.Point(140, 274);
            this.nupPuissance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupPuissance.Name = "nupPuissance";
            this.nupPuissance.Size = new System.Drawing.Size(265, 27);
            this.nupPuissance.TabIndex = 26;
            // 
            // nupCylindree
            // 
            this.nupCylindree.DecimalPlaces = 2;
            this.nupCylindree.Location = new System.Drawing.Point(140, 176);
            this.nupCylindree.Name = "nupCylindree";
            this.nupCylindree.Size = new System.Drawing.Size(265, 27);
            this.nupCylindree.TabIndex = 24;
            // 
            // nupKm
            // 
            this.nupKm.Location = new System.Drawing.Point(140, 320);
            this.nupKm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupKm.Name = "nupKm";
            this.nupKm.Size = new System.Drawing.Size(265, 27);
            this.nupKm.TabIndex = 27;
            // 
            // nupNbPortes
            // 
            this.nupNbPortes.Location = new System.Drawing.Point(140, 222);
            this.nupNbPortes.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupNbPortes.Name = "nupNbPortes";
            this.nupNbPortes.Size = new System.Drawing.Size(265, 27);
            this.nupNbPortes.TabIndex = 25;
            // 
            // lblCylindree
            // 
            this.lblCylindree.AutoSize = true;
            this.lblCylindree.Location = new System.Drawing.Point(10, 183);
            this.lblCylindree.Name = "lblCylindree";
            this.lblCylindree.Size = new System.Drawing.Size(82, 20);
            this.lblCylindree.TabIndex = 48;
            this.lblCylindree.Text = "Cylindrée : ";
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Location = new System.Drawing.Point(6, 322);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(98, 20);
            this.lblKm.TabIndex = 47;
            this.lblKm.Text = "Kilométrage :";
            // 
            // lblPuissance
            // 
            this.lblPuissance.AutoSize = true;
            this.lblPuissance.Location = new System.Drawing.Point(6, 277);
            this.lblPuissance.Name = "lblPuissance";
            this.lblPuissance.Size = new System.Drawing.Size(79, 20);
            this.lblPuissance.TabIndex = 46;
            this.lblPuissance.Text = "Puissance :";
            // 
            // lblNbPortes
            // 
            this.lblNbPortes.AutoSize = true;
            this.lblNbPortes.Location = new System.Drawing.Point(6, 224);
            this.lblNbPortes.Name = "lblNbPortes";
            this.lblNbPortes.Size = new System.Drawing.Size(129, 20);
            this.lblNbPortes.TabIndex = 45;
            this.lblNbPortes.Text = "Nomre de portes :";
            // 
            // gbAvion
            // 
            this.gbAvion.BackColor = System.Drawing.SystemColors.Info;
            this.gbAvion.Controls.Add(this.cbMoteur);
            this.gbAvion.Controls.Add(this.btnAddAvion);
            this.gbAvion.Controls.Add(this.lblHeures);
            this.gbAvion.Controls.Add(this.lblMoteur);
            this.gbAvion.Controls.Add(this.label1);
            this.gbAvion.Controls.Add(this.label2);
            this.gbAvion.Controls.Add(this.nupHeures);
            this.gbAvion.Controls.Add(this.nupPrixAvion);
            this.gbAvion.Controls.Add(this.nupAnneeAvion);
            this.gbAvion.Controls.Add(this.txtMarqueAvion);
            this.gbAvion.Controls.Add(this.label3);
            this.gbAvion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbAvion.Location = new System.Drawing.Point(1225, 519);
            this.gbAvion.Name = "gbAvion";
            this.gbAvion.Size = new System.Drawing.Size(418, 358);
            this.gbAvion.TabIndex = 50;
            this.gbAvion.TabStop = false;
            this.gbAvion.Text = "Ajouter Avion";
            // 
            // cbMoteur
            // 
            this.cbMoteur.FormattingEnabled = true;
            this.cbMoteur.Items.AddRange(new object[] {
            "HELICES",
            "REACTION",
            "AUTRE"});
            this.cbMoteur.Location = new System.Drawing.Point(130, 185);
            this.cbMoteur.Name = "cbMoteur";
            this.cbMoteur.Size = new System.Drawing.Size(274, 28);
            this.cbMoteur.TabIndex = 54;
            // 
            // btnAddAvion
            // 
            this.btnAddAvion.Location = new System.Drawing.Point(11, 288);
            this.btnAddAvion.Name = "btnAddAvion";
            this.btnAddAvion.Size = new System.Drawing.Size(393, 51);
            this.btnAddAvion.TabIndex = 56;
            this.btnAddAvion.Text = "Ajouter l\'avion au Parc ";
            this.btnAddAvion.UseVisualStyleBackColor = true;
            // 
            // lblHeures
            // 
            this.lblHeures.AutoSize = true;
            this.lblHeures.Location = new System.Drawing.Point(11, 238);
            this.lblHeures.Name = "lblHeures";
            this.lblHeures.Size = new System.Drawing.Size(179, 20);
            this.lblHeures.TabIndex = 60;
            this.lblHeures.Text = "Nombre d\'heures de vol : ";
            // 
            // lblMoteur
            // 
            this.lblMoteur.AutoSize = true;
            this.lblMoteur.Location = new System.Drawing.Point(11, 192);
            this.lblMoteur.Name = "lblMoteur";
            this.lblMoteur.Size = new System.Drawing.Size(57, 20);
            this.lblMoteur.TabIndex = 61;
            this.lblMoteur.Text = "Moteur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "Prix de base : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 65;
            this.label2.Text = "Annee d\'achat : ";
            // 
            // nupHeures
            // 
            this.nupHeures.Location = new System.Drawing.Point(196, 231);
            this.nupHeures.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupHeures.Name = "nupHeures";
            this.nupHeures.Size = new System.Drawing.Size(208, 27);
            this.nupHeures.TabIndex = 55;
            // 
            // nupPrixAvion
            // 
            this.nupPrixAvion.DecimalPlaces = 2;
            this.nupPrixAvion.Location = new System.Drawing.Point(130, 145);
            this.nupPrixAvion.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nupPrixAvion.Name = "nupPrixAvion";
            this.nupPrixAvion.Size = new System.Drawing.Size(274, 27);
            this.nupPrixAvion.TabIndex = 53;
            // 
            // nupAnneeAvion
            // 
            this.nupAnneeAvion.Location = new System.Drawing.Point(128, 102);
            this.nupAnneeAvion.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nupAnneeAvion.Name = "nupAnneeAvion";
            this.nupAnneeAvion.Size = new System.Drawing.Size(274, 27);
            this.nupAnneeAvion.TabIndex = 52;
            // 
            // txtMarqueAvion
            // 
            this.txtMarqueAvion.Location = new System.Drawing.Point(128, 56);
            this.txtMarqueAvion.Name = "txtMarqueAvion";
            this.txtMarqueAvion.Size = new System.Drawing.Size(276, 27);
            this.txtMarqueAvion.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Marque : ";
            // 
            // FrmVehicules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1680, 939);
            this.Controls.Add(this.gbAvion);
            this.Controls.Add(this.gbVoiture);
            this.Controls.Add(this.gbStats);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.gbParc);
            this.Controls.Add(this.gbVehicules);
            this.Name = "FrmVehicules";
            this.Text = "Elan Mosquito Vehicules";
            this.Load += new System.EventHandler(this.FrmVehicules_Load);
            this.gbVehicules.ResumeLayout(false);
            this.gbDetailsVehicule.ResumeLayout(false);
            this.gbDetailsVehicule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixChange)).EndInit();
            this.gbParc.ResumeLayout(false);
            this.gbParc.PerformLayout();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.gbVoiture.ResumeLayout(false);
            this.gbVoiture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixVoiture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnnee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPuissance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCylindree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNbPortes)).EndInit();
            this.gbAvion.ResumeLayout(false);
            this.gbAvion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrixAvion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnneeAvion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVehicules;
        private System.Windows.Forms.Button btnDelVehicule;
        private System.Windows.Forms.GroupBox gbParc;
        private System.Windows.Forms.Button btnParc;
        private System.Windows.Forms.GroupBox gbDetailsVehicule;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.ListBox lsParcs;
        private System.Windows.Forms.Button btnDelParc;
        private System.Windows.Forms.ListBox lsVehicules;
        private System.Windows.Forms.Button btnMoins;
        private System.Windows.Forms.NumericUpDown nupPrixChange;
        private System.Windows.Forms.Label lblChangePrix;
        private System.Windows.Forms.TextBox txtPays;
        private System.Windows.Forms.Label lblPays;
        private System.Windows.Forms.TextBox txtVille;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.Label lblVehicule;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.GroupBox gbVoiture;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.Label lblAnnee;
        private System.Windows.Forms.NumericUpDown nupPrixVoiture;
        private System.Windows.Forms.NumericUpDown nupAnnee;
        private System.Windows.Forms.TextBox txtMarque;
        private System.Windows.Forms.Label lblMarque;
        private System.Windows.Forms.Button btnAddVoiture;
        private System.Windows.Forms.NumericUpDown nupPuissance;
        private System.Windows.Forms.NumericUpDown nupCylindree;
        private System.Windows.Forms.NumericUpDown nupKm;
        private System.Windows.Forms.NumericUpDown nupNbPortes;
        private System.Windows.Forms.Label lblCylindree;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.Label lblPuissance;
        private System.Windows.Forms.Label lblNbPortes;
        private System.Windows.Forms.GroupBox gbAvion;
        private System.Windows.Forms.ComboBox cbMoteur;
        private System.Windows.Forms.Button btnAddAvion;
        private System.Windows.Forms.Label lblHeures;
        private System.Windows.Forms.Label lblMoteur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupHeures;
        private System.Windows.Forms.NumericUpDown nupPrixAvion;
        private System.Windows.Forms.NumericUpDown nupAnneeAvion;
        private System.Windows.Forms.TextBox txtMarqueAvion;
        private System.Windows.Forms.Label label3;
    }
}

