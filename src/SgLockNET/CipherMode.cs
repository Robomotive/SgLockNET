namespace SgLockNET;

/// <summary>
/// The mode for the decrypt/encrypt module.
/// </summary>
internal enum CipherMode : uint
{
    /// <summary>
    /// Encrypt mode.
    /// </summary>
    Encrypt = 0,

    /// <summary>
    /// Decrypt mode.
    /// </summary>
    Decrypt = 1,
}
