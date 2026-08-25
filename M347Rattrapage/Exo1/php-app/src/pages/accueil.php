<?php
/**
 * Page d'accueil - Affiche les annonces depuis la base de données
 */
$pdo = getConnexion();

$stmt = $pdo->query('SELECT titre, contenu, date_publication FROM annonces ORDER BY date_publication DESC');
$annonces = $stmt->fetchAll(PDO::FETCH_ASSOC);
?>

<h2>Bienvenue sur notre site</h2>
<p>Découvrez nos dernières annonces ci-dessous.</p>

<section class="annonces">
    <?php if (empty($annonces)): ?>
        <p class="info">Aucune annonce pour le moment.</p>
    <?php else: ?>
        <?php foreach ($annonces as $annonce): ?>
            <article class="card">
                <h3><?= htmlspecialchars($annonce['titre']) ?></h3>
                <p><?= htmlspecialchars($annonce['contenu']) ?></p>
                <small>Publié le <?= htmlspecialchars($annonce['date_publication']) ?></small>
            </article>
        <?php endforeach; ?>
    <?php endif; ?>
</section>
