namespace SgLockNET;

/// <summary>
/// The lock series currently connected.
/// </summary>
public enum LockSeries : uint
{
    /// <summary>
    /// A series 2 lock.
    /// </summary>
    Series2 = 0x0001,

    /// <summary>
    /// A series 3 lock.
    /// </summary>
    Series3 = 0x0002,

    /// <summary>
    /// A series 4 lock.
    /// </summary>
    Series4 = 0x0003,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved01 = 0x0004,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved02 = 0x0005,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved03 = 0x0006,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved04 = 0x0007,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved05 = 0x0008,

    /// <summary>
    /// For future use.
    /// </summary>
    Reserved06 = 0x0009,
}
