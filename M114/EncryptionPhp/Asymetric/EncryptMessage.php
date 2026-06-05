<?php

$message = "Message secret";
$publicKey = file_get_contents("public.key");

if (!openssl_public_encrypt($message, $encrypted, $publicKey)) {
    error_log("openssl_public_encrypt: " . openssl_error_string());
}

file_put_contents("encryptedMessage.txt", $encrypted);