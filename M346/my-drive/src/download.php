<?php
require __DIR__ . '/../vendor/autoload.php';

use Dotenv\Dotenv;
use OpenStack\OpenStack;

$dotenv = Dotenv::createImmutable(__DIR__ . '/..');
$dotenv->load();

$openstack = new OpenStack([
    'authUrl' => $_ENV['OS_AUTH_URL'],
    'region'  => $_ENV['OS_REGION_NAME'],
    'user'    => [
        'name'     => $_ENV['OS_USERNAME'],
        'password' => $_ENV['OS_PASSWORD'],
        'domain'   => ['name' => $_ENV['OS_USER_DOMAIN_NAME']]
    ],
    'scope'   => ['project' => ['id' => $_ENV['OS_PROJECT_ID']]]
]);

$container = $openstack->objectStoreV1()->getContainer($_ENV['SWIFT_CONTAINER_NAME']);

if (isset($_GET['filename'])) {
    $filename = $_GET['filename'];

    // Récupérer l'objet depuis le conteneur
    try {
        $object = $container->getObject($filename);
        $stream = $object->download();
        $stream->rewind(); // Positionner le pointeur au début du stream

        header('Content-Type: ' . $object->contentType);
        header('Content-Disposition: attachment; filename="' . basename($filename) . '"');

        while (!$stream->eof()) {
            echo $stream->read(2048);
        }
    } catch (Exception $e) {
        echo "Erreur lors du téléchargement : " . $e->getMessage();
    }
} else {
    echo "Aucun fichier spécifié pour le téléchargement.";
}