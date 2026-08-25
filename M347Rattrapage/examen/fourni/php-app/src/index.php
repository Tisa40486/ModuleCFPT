<?php
/**
 * Point d'entrée principal de l'application
 * Routeur simple vers les pages du site
 */

// Récupération de la page demandée (par défaut : accueil)
$page = isset($_GET['page']) ? $_GET['page'] : 'accueil';

// Pages autorisées
$pages_autorisees = ['accueil', 'contact', 'about'];

// Vérification que la page demandée existe
if (!in_array($page, $pages_autorisees)) {
    $page = 'accueil';
}

// Connexion à la base de données via variables d'environnement
function getConnexion() {
    $host = getenv('DB_HOST') ?: 'mariadb';
    $dbname = getenv('DB_NAME') ?: 'site_db';
    $user = getenv('DB_USER') ?: 'app_user';
    $password = getenv('DB_PASSWORD') ?: 'app_pass';

    try {
        $pdo = new PDO(
            "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
            $user,
            $password,
            [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]
        );
        return $pdo;
    } catch (PDOException $e) {
        die("Erreur de connexion : " . $e->getMessage());
    }
}
?>
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mon Site - <?= ucfirst($page) ?></title>
    <link rel="stylesheet" href="assets/style.css">
</head>
<body>
    <header>
        <h1>Mon Site</h1>
        <nav>
            <a href="index.php?page=accueil" class="<?= $page === 'accueil' ? 'active' : '' ?>">Accueil</a>
            <a href="index.php?page=contact" class="<?= $page === 'contact' ? 'active' : '' ?>">Contact</a>
            <a href="index.php?page=about" class="<?= $page === 'about' ? 'active' : '' ?>">À propos</a>
        </nav>
    </header>

    <main>
        <?php include "pages/$page.php"; ?>
    </main>

    <footer>
        <p>&copy; 2026 Mon Site - M347 Examen</p>
    </footer>
</body>
</html>
