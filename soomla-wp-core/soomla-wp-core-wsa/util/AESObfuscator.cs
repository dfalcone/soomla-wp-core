using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace SoomlaWpCore.util
{
    public class AESObfuscator
    {
        private const String TAG = "SOOMLA AESObfuscator";

        public static String ObfuscateString(String plainText)
        {
            try
            {
                return AESObfuscator.Encrypt(plainText, Soomla.SECRET, SoomlaConfig.obfuscationSalt);
            }
            catch (Exception ex)
            {
                SoomlaUtils.LogDebug(TAG, "Encryption Error " + ex.Message);
            }
            return null;

        }

        public static String UnObfuscateString(String encryptedString)
        {
            try
            {
                return AESObfuscator.Decrypt(encryptedString, Soomla.SECRET, SoomlaConfig.obfuscationSalt);
            }
            catch (Exception ex)
            {
                SoomlaUtils.LogDebug(TAG, "Decryption Error " + ex.Message);
            }
            return null;
        }

        private static void GenerateKeyMaterial(string salt, string password, out IBuffer keyMaterial, out IBuffer iv)
        {
            // Setup KDF parameters for the desired salt and iteration count 
            IBuffer saltBuffer = CryptographicBuffer.ConvertStringToBinary(salt, BinaryStringEncoding.Utf8);
            KeyDerivationParameters kdfParameters = KeyDerivationParameters.BuildForPbkdf2(saltBuffer, 10000);

            // Get a KDF provider for PBKDF2, and store the source password in a Cryptographic Key
            // Use SHA1 for pseudo-random number generator
            KeyDerivationAlgorithmProvider kdf = KeyDerivationAlgorithmProvider.OpenAlgorithm(KeyDerivationAlgorithmNames.Pbkdf2Sha1);
            IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
            CryptographicKey passwordSourceKey = kdf.CreateKey(passwordBuffer);

            // Generate key material from the source password, salt, and iteration count.  Only call DeriveKeyMaterial once, 
            // since calling it twice will generate the same data for the key and IV. 
            int keySize = 256 / 8;
            int ivSize = 128 / 8;
            uint totalDataNeeded = (uint)(keySize + ivSize);
            IBuffer keyAndIv = CryptographicEngine.DeriveKeyMaterial(passwordSourceKey, kdfParameters, totalDataNeeded);

            // Split the derived bytes into a seperate key and IV 
            byte[] keyMaterialBytes = keyAndIv.ToArray();
            keyMaterial = WindowsRuntimeBuffer.Create(keyMaterialBytes, 0, keySize, keySize);
            iv = WindowsRuntimeBuffer.Create(keyMaterialBytes, keySize, ivSize, ivSize);
        }

        public static String Encrypt(string dataToEncrypt, string password, string salt)
        {
            //Generate a Key based on a Password and HMACSHA1 pseudo-random number generator
            //Salt must be at least 8 bytes long
            //Use an iteration count of at least 1000
            IBuffer plainText = CryptographicBuffer.ConvertStringToBinary(dataToEncrypt, BinaryStringEncoding.Utf8);
            IBuffer aesKeyMaterial;
            IBuffer iv;
            GenerateKeyMaterial(salt, password, out aesKeyMaterial, out iv);

            // Setup an AES key, using AES in CBC mode and applying PKCS#7 padding on the input             
            SymmetricKeyAlgorithmProvider aesProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(Windows.Security.Cryptography.Core.SymmetricAlgorithmNames.AesCbcPkcs7);
            CryptographicKey aesKey = aesProvider.CreateSymmetricKey(aesKeyMaterial);

            // Encrypt the data and convert it to a Base64 string 
            IBuffer encrypted = CryptographicEngine.Encrypt(aesKey, plainText, iv);
            return CryptographicBuffer.EncodeToBase64String(encrypted);


            /* Windows Phone 8 implementation
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 10000);

            //Create AES algorithm
            aes = new AesManaged();
            //Key derived from byte array with 32 pseudo-random key bytes
            aes.Key = rfc2898.GetBytes(32);
            //IV derived from byte array with 16 pseudo-random key bytes
            aes.IV = rfc2898.GetBytes(16);

            //Create Memory and Crypto Streams
            memoryStream = new MemoryStream();
            cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            //Encrypt Data
            byte[] data = Encoding.UTF8.GetBytes(dataToEncrypt);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            //Return Base 64 String
            return Convert.ToBase64String(memoryStream.ToArray());
            */

        }

        public static String Decrypt(string dataToDecrypt, string password, string salt)
        {
            // Generate a key and IV from the password and salt 
            IBuffer aesKeyMaterial;
            IBuffer iv;
            GenerateKeyMaterial(salt, password, out aesKeyMaterial, out iv);

            // Setup an AES key, using AES in CBC mode and applying PKCS#7 padding on the input            
            SymmetricKeyAlgorithmProvider aesProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(Windows.Security.Cryptography.Core.SymmetricAlgorithmNames.AesCbcPkcs7);
            CryptographicKey aesKey = aesProvider.CreateSymmetricKey(aesKeyMaterial);

            // Convert the base64 input to an IBuffer for decryption 
            IBuffer ciphertext = CryptographicBuffer.DecodeFromBase64String(dataToDecrypt);

            // Decrypt the data and convert it back to a string 
            IBuffer decrypted = CryptographicEngine.Decrypt(aesKey, ciphertext, iv);
            return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, decrypted);

            /* Windows Phone 8 implementation
            AesManaged aes = null;
            MemoryStream memoryStream = null;

            try
            {
                //Generate a Key based on a Password and HMACSHA1 pseudo-random number generator
                //Salt must be at least 8 bytes long
                //Use an iteration count of at least 1000
                Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 10000);

                //Create AES algorithm
                aes = new AesManaged();
                //Key derived from byte array with 32 pseudo-random key bytes
                aes.Key = rfc2898.GetBytes(32);
                //IV derived from byte array with 16 pseudo-random key bytes
                aes.IV = rfc2898.GetBytes(16);

                //Create Memory and Crypto Streams
                memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                //Decrypt Data
                byte[] data = Convert.FromBase64String(dataToDecrypt);
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                //Return Decrypted String
                byte[] decryptBytes = memoryStream.ToArray();

                //Dispose
                if (cryptoStream != null)
                    cryptoStream.Dispose();

                //Retval
                return Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Dispose();

                if (aes != null)
                    aes.Clear();
            }
            */
        }
    }
}
