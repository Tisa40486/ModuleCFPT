<?php
$secretKey = "1234";
$message = "test";

$salt = openssl_random_pseudo_bytes(256);
$iv = openssl_random_pseudo_bytes(16);

$iterations = 999;

$key = hash_pbkdf2("sha512", $secretKey, $salt, $iterations, 64);

$encryptedData = openssl_encrypt($message, "aes-256-cbc", hex2bin($key),
    OPENSSL_RAW_DATA, $iv);

if (!$encryptedData) {
    error_log("openssl_encrypt: " . openssl_error_string());
}
$encryptedData = base64_encode($encryptedData);

$signature = hash_hmac("sha256", $encryptedData, $key);

$encryptedMessage = [
    "ciphertext" => $encryptedData,
    "salt" => bin2hex($salt),
    "iv" => bin2hex($iv),
    "signature" => $signature
    ];

$data = json_encode($encryptedMessage);
file_put_contents("encrypted.txt", $data);
?>