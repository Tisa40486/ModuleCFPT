-- Initialisation de la base de données pour l'examen M347
-- Ce script est exécuté automatiquement au premier démarrage de MariaDB

CREATE DATABASE IF NOT EXISTS site_db;
USE site_db;

-- Table des annonces affichées sur la page d'accueil
CREATE TABLE IF NOT EXISTS annonces (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titre VARCHAR(200) NOT NULL,
    contenu TEXT NOT NULL,
    date_publication DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Table des messages du formulaire de contact
CREATE TABLE IF NOT EXISTS messages (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL,
    sujet VARCHAR(200) NOT NULL,
    contenu TEXT NOT NULL,
    date_envoi DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Données initiales : quelques annonces
INSERT INTO annonces (titre, contenu, date_publication) VALUES
('Bienvenue sur le site', 'Notre nouvelle plateforme est en ligne. Découvrez toutes nos fonctionnalités !', '2026-03-01 09:00:00'),
('Maintenance prévue', 'Une maintenance est planifiée le 15 mars 2026 de 22h à 23h.', '2026-03-10 14:30:00'),
('Nouvelle fonctionnalité', 'Le formulaire de contact est désormais disponible. N''hésitez pas à nous écrire.', '2026-03-12 10:00:00');
