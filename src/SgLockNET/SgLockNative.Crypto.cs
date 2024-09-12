using System.Runtime.InteropServices;

namespace SgLockNET;

/// <content>The cryptographic part of the lock.</content>
internal static partial class SgLockNative
{
    /// <summary>
    /// En- or decrypts one or more 64-bit data blocks with 128-bit key. The cryptographic algorithm
    /// is TEA
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock.</param>
    /// <param name="keyNumber">Number of the key to use (0 to 1 - SG-Lock U3) (0 to 15 - SG-Lock U4)</param>
    /// <param name="cryptMode">Working mode (0 - Encrypt) (1 - Decrypt)</param>
    /// <param name="blockCount">Number of data blocks to en- or decrypt</param>
    /// <param name="data">
    /// Pointer to data array, where values shall be copied to. (The developer is responsible to
    /// provide an array with a sufficient size). Size must be BlockCnt * 8 Bytes.
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// The function uses destructive data processing mode. That means the input of the parameter
    /// Data will be overwritten during execution of the function.
    /// </remarks>
    // public static extern uint SglCryptLock([Out] uint ProductId, [Out] uint KeyNum, [Out] uint CryptMode, [Out] uint BlockCnt, [In] uint[] Data);
    [LibraryImport(LibName, EntryPoint = "SglCryptLock")]
    public static partial ReturnCode CryptLock(uint productId, uint keyNumber, CipherMode cryptMode, uint blockCount, [In, Out] uint[] data);

    /// <summary>
    /// Writes a 128-bit key to the SG-Lock key memory.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock looked for.</param>
    /// <param name="keyNum">
    /// Number of the key to be written (0 to 1 - SG-Lock U3) (0 to 15 - SG-Lock U4)
    /// </param>
    /// <param name="key"></param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// L2,U2: Key fixed - that means not writeable number of key:
    /// L3,U3: 0-1 ;
    /// L4,U4: 0-15 128-Bit (16 Bytes) Key, write only!!!
    /// </remarks>
    // public static extern uint SglWriteKey([Out] uint ProductId, [Out] uint KeyNum, [In] uint[] Key);
    [LibraryImport(LibName, EntryPoint = "SglWriteKey")]
    public static partial ReturnCode WriteKey(uint productId, uint keyNum, uint[] key);
}
