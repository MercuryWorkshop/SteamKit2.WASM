using System.Runtime.InteropServices;
using System;

public partial class NativeCrypto
{
    [DllImport( "NativeCrypto" )]
    public static unsafe extern int AesDecryptEcb( byte[] key, int key_size, byte* ciphertext, int ciphertext_length, byte* buffer );
    [DllImport( "NativeCrypto" )]
    public static unsafe extern int AesDecryptCbc( byte[] key, int key_size, byte* iv, byte* ciphertext, int ciphertext_length, byte* buffer );
    [DllImport( "NativeCrypto" )]
    public static unsafe extern int AesEncryptCbc( byte[] key, int key_size, byte* iv, byte* ciphertext, int ciphertext_length, byte* buffer );
}
