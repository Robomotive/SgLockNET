namespace SgLockNET;

/// <content>The authentication part of the lock.</content>
public partial class SgLock
{
    /// <summary>
    /// Authenticate with the key.
    /// </summary>
    /// <param name="authenticationCode">The unique user code.</param>
    /// <exception cref="ArgumentException">
    /// Is thrown when the <paramref name="authenticationCode"/> is not the right length.
    /// </exception>
    /// <exception cref="SgLockException">Is thrown when authentication failed.</exception>
    public static void Authenticate(uint[] authenticationCode)
    {
        if (authenticationCode.Length != 12)
        {
            throw new ArgumentException("Code needs to be 48 bytes long (12 uint)", nameof(authenticationCode));
        }

        var random = new Random();
        var randomNumbers = new uint[] { (uint)random.Next(), (uint)random.Next() };
        var appRandomNumbers = new uint[] { randomNumbers[0], randomNumbers[1] };
        var libRandomNumbers = new uint[2];

        var errorCode = SgLockNative.Authenticate(authenticationCode[..8], appRandomNumbers, libRandomNumbers);
        AssertErrorCode(errorCode);
        var encipheredNum = CipherHelper.TeaEncipher(randomNumbers, authenticationCode[8..12]);

        if (!encipheredNum.SequenceEqual(appRandomNumbers))
        {
            throw new SgLockException("Enciphered numbers are not the same between SG-Lock and Application");
        }

        var libRandNumEnciphered = CipherHelper.TeaEncipher(libRandomNumbers, authenticationCode[8..12]);
        errorCode = SgLockNative.Authenticate(libRandNumEnciphered);
        AssertErrorCode(errorCode);
    }
}
