<?php
/**
 * Page de contact - Formulaire avec enregistrement en base de données
 */
$pdo = getConnexion();
$message_ok = '';
$message_erreur = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $nom = trim($_POST['nom'] ?? '');
    $email = trim($_POST['email'] ?? '');
    $sujet = trim($_POST['sujet'] ?? '');
    $contenu = trim($_POST['message'] ?? '');

    if ($nom && $email && $sujet && $contenu) {
        $stmt = $pdo->prepare('INSERT INTO messages (nom, email, sujet, contenu) VALUES (?, ?, ?, ?)');
        $stmt->execute([$nom, $email, $sujet, $contenu]);
        $message_ok = 'Votre message a été envoyé avec succès !';
    } else {
        $message_erreur = 'Veuillez remplir tous les champs.';
    }
}
?>

<h2>Contactez-nous</h2>

<?php if ($message_ok): ?>
    <p class="success"><?= htmlspecialchars($message_ok) ?></p>
<?php endif; ?>
<?php if ($message_erreur): ?>
    <p class="error"><?= htmlspecialchars($message_erreur) ?></p>
<?php endif; ?>

<form method="post" action="index.php?page=contact">
    <label for="nom">Nom :</label>
    <input type="text" id="nom" name="nom" required>

    <label for="email">Email :</label>
    <input type="email" id="email" name="email" required>

    <label for="sujet">Sujet :</label>
    <input type="text" id="sujet" name="sujet" required>

    <label for="message">Message :</label>
    <textarea id="message" name="message" rows="5" required></textarea>

    <button type="submit">Envoyer</button>
</form>
