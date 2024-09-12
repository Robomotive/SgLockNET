namespace SgLockNET;

/// <summary>
/// Helper function for enciphering data.
/// </summary>
internal static class CipherHelper
{
    private const uint Delta = 0x9E3779B9;
    private const uint TeaSteps = 32;

    /// <summary>
    /// TEA decipher data.
    /// </summary>
    /// <param name="data">The data to decipher.</param>
    /// <param name="key">The decipher key.</param>
    /// <returns>The deciphered data.</returns>
    public static uint[] TeaDecipher(uint[] data, uint[] key)
    {
        var y = data[0];
        var z = data[1];
        uint sum;
        unchecked
        {
            sum = Delta * TeaSteps;
        }

        for (var i = 0; i < TeaSteps; i++)
        {
            z -= ((y << 4) + key[2]) ^ (y + sum) ^ ((y >> 5) + key[3]);
            y -= ((z << 4) + key[0]) ^ (z + sum) ^ ((z >> 5) + key[1]);
            sum -= Delta;
        }

        return [y, z];
    }

    /// <summary>
    /// TEA encipher data.
    /// </summary>
    /// <param name="data">The data to encipher.</param>
    /// <param name="key">The decipher key.</param>
    /// <returns>The data deciphered.</returns>
    public static uint[] TeaEncipher(uint[] data, uint[] key)
    {
        var y = data[0];
        var z = data[1];
        uint sum = 0;

        for (var i = 0; i < TeaSteps; i++)
        {
            sum += Delta;
            y += ((z << 4) + key[0]) ^ (z + sum) ^ ((z >> 5) + key[1]);
            z += ((y << 4) + key[2]) ^ (y + sum) ^ ((y >> 5) + key[3]);
        }

        return [y, z];
    }
}
