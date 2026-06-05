<?php
    $key = file_get_contents("private.key");

$passphrase = "1234";
openssl_pkey_export($key, $encryptedPrivateKey, $passphrase, []);
if (!$encryptedPrivateKey) {
    error_log("openssl_pkey_export: " . openssl_error_string());
}

file_put_contents("privateCrypted.key", $encryptedPrivateKey);

?>
