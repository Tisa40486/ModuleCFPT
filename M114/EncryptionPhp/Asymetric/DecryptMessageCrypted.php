<?php
$encryptedPrivateKey = file_get_contents("privateCrypted.key");
$encrypted = file_get_contents("encryptedMessage.txt");

$passphrase = "1234";
$privateKey = openssl_pkey_get_private($encryptedPrivateKey, $passphrase);

if (!$privateKey) {
    error_log("openssl_pkey_get_private: " . openssl_error_string());
}

if (!openssl_private_decrypt($encrypted, $message, $privateKey)) {
    error_log("openssl_private_decrypt: " . openssl_error_string());
}
file_put_contents("decryptedMessageKeyPrivateCrypted.txt", $message);