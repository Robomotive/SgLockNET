namespace SgLockNET;

/// <summary>
/// The interface the lock is using.
/// </summary>
public enum LockInterface : uint
{
    /// <summary>
    /// USB port.
    /// </summary>
    USB = 0x0000,

    /// <summary>
    /// LPT port.
    /// </summary>
    LPT = 0x0001,
}
