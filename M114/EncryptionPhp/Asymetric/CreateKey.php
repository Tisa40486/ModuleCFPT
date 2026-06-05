<?php
$config = array(
    "digest_alg" => "sha512",
    "private_key_bits" => 2048,
    "private_key_type" => OPENSSL_KEYTYPE_RSA);

$keypair = openssl_pkey_new($config);


if (!$keypair) {
    error_log("openssl_pkey_new: " . openssl_error_string());
}

$publicDetails = openssl_pkey_get_details($keypair);

$publicKey = $publicDetails['key'];

file_put_contents("public.key", $publicKey);

openssl_pkey_export($keypair, $privateKey, null, []);
if (!$privateKey) {
    error_log("openssl_pkey_export: " . openssl_error_string());
}

file_put_contents("private.key", $privateKey);

?>