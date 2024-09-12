namespace SgLockNET;

/// <content>Methods to access the cryptographic functions.</content>
public partial class SgLock
{
    /// <summary>
    /// Decrypts one or more 64-bit data blocks with 128-bit key.
    /// </summary>
    /// <remarks>The cryptographic algorithm is TEA.</remarks>
    /// <param name="encryptedData">The data to decrypt.</param>
    /// <param name="keyIndex">Number of the key to use.</param>
    /// <returns>The decrypted data.</returns>
    /// <exception cref="ArgumentException">When the key index is out of range.</exception>
    public uint[] DecryptData(uint[] encryptedData, uint keyIndex)
    {
        if (keyIndex > ConfigData.KeyCount)
        {
            throw new ArgumentException($"SG-Lock only has {ConfigData.KeyCount}", nameof(keyIndex));
        }

        var inputData = (uint[])encryptedData.Clone();
        var errorCode = SgLockNative.CryptLock(ProductId, keyIndex, CipherMode.Decrypt, (uint)inputData.Length, inputData);
        AssertErrorCode(errorCode);
        return inputData;
    }

    /// <summary>
    /// Decrypts one or more 64-bit data blocks with 128-bit key.
    /// </summary>
    /// <remarks>The cryptographic algorithm is TEA.</remarks>
    /// <param name="encryptedData">The data to decrypt.</param>
    /// <param name="keyIndex">Number of the key to use.</param>
    /// <returns>The decrypted data.</returns>
    /// <exception cref="ArgumentException">When the key index is out of range.</exception>
    public Task<uint[]> DecryptDataAsync(uint[] encryptedData, uint keyIndex)
    {
        if (keyIndex > ConfigData.KeyCount)
        {
            throw new ArgumentException($"SG-Lock only has {ConfigData.KeyCount}", nameof(keyIndex));
        }

        var inputData = (uint[])encryptedData.Clone();
        return Task.Run(() =>
         {
             var errorCode = SgLockNative.CryptLock(ProductId, keyIndex, CipherMode.Decrypt, (uint)inputData.Length, inputData);
             AssertErrorCode(errorCode);
             return inputData;
         });
    }

    /// <summary>
    /// Encrypts one or more 64-bit data blocks with 128-bit key.
    /// </summary>
    /// <remarks>The cryptographic algorithm is TEA.</remarks>
    /// <param name="data">The data to encrypt.</param>
    /// <param name="keyIndex">Number of the key to use.</param>
    /// <returns>The decrypted data.</returns>
    /// <exception cref="ArgumentException">When the key index is out of range.</exception>
    public uint[] EncryptData(uint[] data, uint keyIndex)
    {
        if (keyIndex > ConfigData.KeyCount)
        {
            throw new ArgumentException($"SG-Lock only has {ConfigData.KeyCount}", nameof(keyIndex));
        }

        var inputData = (uint[])data.Clone();

        var errorCode = SgLockNative.CryptLock(ProductId, keyIndex, CipherMode.Encrypt, (uint)inputData.Length, inputData);
        AssertErrorCode(errorCode);
        return inputData;
    }

    /// <summary>
    /// Encrypts one or more 64-bit data blocks with 128-bit key.
    /// </summary>
    /// <remarks>The cryptographic algorithm is TEA.</remarks>
    /// <param name="data">The data to encrypt.</param>
    /// <param name="keyIndex">Number of the key to use.</param>
    /// <returns>The decrypted data.</returns>
    /// <exception cref="ArgumentException">When the key index is out of range.</exception>
    public Task<uint[]> EncryptDataAsync(uint[] data, uint keyIndex)
    {
        if (keyIndex > ConfigData.KeyCount)
        {
            throw new ArgumentException($"SG-Lock only has {ConfigData.KeyCount}", nameof(keyIndex));
        }

        var inputData = (uint[])data.Clone();

        return Task.Run(() =>
        {
            var errorCode = SgLockNative.CryptLock(ProductId, keyIndex, CipherMode.Encrypt, (uint)inputData.Length, inputData);
            AssertErrorCode(errorCode);
            return inputData;
        });
    }
}
