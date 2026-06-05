<?php
$encrypted = file_get_contents("encryptedMessage.txt");
$privateKey = file_get_contents("private.key");

if (!openssl_private_decrypt($encrypted, $message, $privateKey)) {
    error_log("openssl_private_decrypt: " . openssl_error_string());
}

file_put_contents("decryptedMessage.txt", $message);