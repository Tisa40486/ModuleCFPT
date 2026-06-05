<?php
$secretKey = "1234";
$encryptedJson= file_get_contents("encrypted.txt");
$encryptedMessage = json_decode($encryptedJson, true);
//$encryptedMessage = "Salut";

$salt = hex2bin($encryptedMessage["salt"]);

$iv = hex2bin($encryptedMessage["iv"]);

$iterations = 999;

$key = hash_pbkdf2("sha512", $secretKey, $salt, $iterations, 64);

$signature = hash_hmac("sha256", $encryptedMessage["ciphertext"], $key);

if ($signature != $encryptedMessage["signature"]) {
    error_log("signature don’t match");
}

$message = openssl_decrypt(base64_decode($encryptedMessage["ciphertext"]), "aes-256-cbc",
    hex2bin($key), OPENSSL_RAW_DATA, $iv);

if (!$message) {
    error_log("openssl_decrypt: " . openssl_error_string());
}

$data = json_encode($message);

file_put_contents("decrypted.txt", $data);

?>