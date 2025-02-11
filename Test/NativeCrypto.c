#include <stdint.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <openssl/aes.h>

int AesDecryptEcb( uint8_t *key, int key_size, uint8_t *ciphertext, int ciphertext_length, char *buffer ) {

    AES_KEY aes_key;
    if ( AES_set_decrypt_key( key, key_size * 8, &aes_key ) != 0 ) {
        return -1;
    }

    uint8_t *plaintext = malloc( ciphertext_length );
    if ( plaintext == NULL ) {
        return -1;
    }

    for ( int i = 0; i < ciphertext_length; i += AES_BLOCK_SIZE ) {
        AES_decrypt( ciphertext + i, plaintext + i, &aes_key );
    }

    memcpy( buffer, plaintext, ciphertext_length );


    return 0;
}

int AesDecryptCbc( uint8_t *key, int key_size, uint8_t *iv, uint8_t *ciphertext, int ciphertext_length, char *buffer ) {

    AES_KEY aes_key;
    if ( AES_set_decrypt_key( key, key_size * 8, &aes_key ) != 0 ) {
        return -1;
    }

    uint8_t *plaintext = malloc( ciphertext_length );
    if ( plaintext == NULL ) {
        return -1;
    }

    AES_cbc_encrypt( ciphertext, plaintext, ciphertext_length, &aes_key, iv, AES_DECRYPT );
    int new_length = ciphertext_length;
    int bytes_to_remove = plaintext[ciphertext_length - 1];
    if ( bytes_to_remove > 0 && bytes_to_remove <= 16 ) {
        new_length -= bytes_to_remove;
    }

    memcpy( buffer, plaintext, new_length );

    return new_length;
}
