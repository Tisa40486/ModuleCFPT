<?php
require 'vendor/autoload.php';

$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->load();

$openstack = new OpenStack\OpenStack([
    'authUrl' => $_ENV['OS_AUTH_URL'],
    'region'  => $_ENV['OS_REGION_NAME'],
    'user'    => [
        'name'     => $_ENV['OS_USERNAME'],
        'password' => $_ENV['OS_PASSWORD'],
        'domain'   => ['name' => $_ENV['OS_USER_DOMAIN_NAME']],
    ],
    'scope'   => ['project' => ['id' => $_ENV['OS_PROJECT_ID']]],
]);

$container = $openstack->objectStoreV1()->getContainer($_ENV['SWIFT_CONTAINER_NAME']);

// Traitement de l'upload
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_FILES['fileToUpload'])) {
    $file = $_FILES['fileToUpload'];
    if ($file['error'] === UPLOAD_ERR_OK) {
        $filename = $file['name'];
        $fileContent = file_get_contents($file['tmp_name']);

        try {
            $container->createObject([
                'name' => $filename,
                'content' => $fileContent,
            ]);
            $message = "Fichier '$filename' uploadé avec succès.";
        } catch (Exception $e) {
            $message = "Erreur lors de l'upload : " . $e->getMessage();
        }
    } else {
        $message = "Erreur d'upload : " . $file['error'];
    }
}

// Traitement de la suppression
if ($_SERVER['REQUEST_METHOD'] === 'POST' && !empty($_POST['filenameToDelete'])) {
    $filenameToDelete = $_POST['filenameToDelete'];
    try {
        $container->getObject($filenameToDelete)->delete();
        $message = "Fichier '$filenameToDelete' supprimé avec succès.";
    } catch (Exception $e) {
        $message = "Erreur lors de la suppression : " . $e->getMessage();
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Gestion de fichiers dans my-drive</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" 
    rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" 
    crossorigin="anonymous">
</head>
<body>
<div class="container mt-4">
    <h5>Liste des fichiers dans my-drive</h5>
    <table class="table">
        <thead>
            <tr>
                <th>Nom du fichier</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <?php
            try {
                $objects = $container->listObjects();
                foreach ($objects as $object) {
                    echo "<tr><td>" . htmlspecialchars($object->name) . "</td><td>";
                    echo "<form action='src/download.php' method='get' style='display:inline;'>";
                    echo "<input type='hidden' name='filename' value='" . htmlspecialchars($object->name) . "'>";
                    echo "<button type='submit' class='btn btn-primary btn-sm'>Télécharger</button>";
                    echo "</form> ";
                    echo "<form action='index.php' method='post' style='display:inline;'>";
                    echo "<input type='hidden' name='filenameToDelete' value='" . htmlspecialchars($object->name) . "'>";
                    echo "<button type='submit' class='btn btn-danger btn-sm' onclick=\"return confirm('Êtes-vous sûr de vouloir supprimer ce fichier ?');\">Supprimer</button>";
                    echo "</form></td></tr>";
                }
            } catch (Exception $e) {
                echo "<tr><td colspan='2'>Erreur lors de la récupération des objets : " . $e->getMessage() . "</td></tr>";
            }
            ?>
        </tbody>
    </table>
    <h5>Ajouter un fichier dans my-drive</h5>
    <form action="index.php" method="post" enctype="multipart/form-data">
        <div class="row align-items-center g-2">
            <div class="col-sm">
                <input type="file" class="form-control" name="fileToUpload" id="fileToUpload" required="">
            </div>
            <div class="col-auto">
                <button type="submit" class="btn btn-success" name="submit">Ajouter le fichier</button>
            </div>
        </div>
    </form>

    <?php if (!empty($message)) : ?>
        <br>
        <div class="alert alert-info"><?php echo $message; ?></div>
    <?php endif; ?>

</div>
<!-- Bootstrap 5 Bundle JS (includes Popper) -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" 
integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" 
crossorigin="anonymous"></script>

</body>
</html>
