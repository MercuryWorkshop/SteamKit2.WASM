#include <stdint.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
/* #include <openssl/aes.h> */

#  define AES_MAXNR 14
# define AES_BLOCK_SIZE 16

#  define AES_DECRYPT     0

#  define AES_ENCRYPT     1
struct aes_key_st {
#  ifdef AES_LONG
    unsigned long rd_key[4 * (AES_MAXNR + 1)];
#  else
    unsigned int rd_key[4 * (AES_MAXNR + 1)];
#  endif
    int rounds;
};
typedef struct aes_key_st AES_KEY;

int AES_set_decrypt_key(const unsigned char *userKey, const int bits,
                        AES_KEY *key);

int AES_set_encrypt_key(const unsigned char *userKey, const int bits,
                        AES_KEY *key);
void AES_decrypt(const unsigned char *in, unsigned char *out,
                 const AES_KEY *key);
void AES_cbc_encrypt(const unsigned char *in, unsigned char *out,
                     size_t length, const AES_KEY *key,
                     unsigned char *ivec, const int enc);

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


    return ciphertext_length;
}
int AesEncryptCbc( uint8_t *key, int key_size, uint8_t *iv, uint8_t *plaintext, int plaintext_length, char *buffer ) {

    AES_KEY aes_key;
    if ( AES_set_encrypt_key( key, key_size * 8, &aes_key ) != 0 ) {
        return -1;
    }

    int pad_length = AES_BLOCK_SIZE - ( plaintext_length % AES_BLOCK_SIZE );
    if ( pad_length == 0 ) {
        pad_length = AES_BLOCK_SIZE;
    }


    uint8_t *ciphertext = malloc( plaintext_length + pad_length );
    if ( ciphertext == NULL ) {
        return -1;
    }
    memcpy( ciphertext, plaintext, plaintext_length );
    memset( ciphertext + plaintext_length, pad_length, pad_length );

    AES_cbc_encrypt( ciphertext, ciphertext, plaintext_length, &aes_key, iv, AES_ENCRYPT );

    memcpy( buffer, ciphertext, plaintext_length );

    return plaintext_length + pad_length;
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
