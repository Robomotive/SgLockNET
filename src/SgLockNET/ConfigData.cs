using System.Runtime.InteropServices;

namespace SgLockNET;

/// <summary>
/// The config from a lock key.
/// </summary>
/// <param name="ModelId"> Gets the type of lock used. </param>
/// <param name="LockInterface"> Gets the interface of the lock. </param>
/// <param name="SoftwareVersion"> Gets the software version of the lock. </param>
/// <param name="HardwareVersion"> Gets the hardware version of the lock. </param>
/// <param name="SerialNumber"> Gets the serial number of the lock key. </param>
/// <param name="MemorySize"> Gets the total available memory size in DWORD (int). </param>
/// <param name="CounterCount"> Gets the amount of counters available. </param>
/// <param name="KeyCount"> Gets the amount of 128 bit keys available. </param>
[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public readonly record struct ConfigData(
    LockSeries ModelId,
    LockInterface LockInterface,
    uint SoftwareVersion,
    uint HardwareVersion,
    uint SerialNumber,
    uint MemorySize,
    uint CounterCount,
    uint KeyCount)
{
    /// <summary>
    /// Gets the major software version.
    /// </summary>
    public ushort SoftwareVersionMajor => (ushort)(SoftwareVersion >> 16);

    /// <summary>
    /// Gets the minor software version.
    /// </summary>
    public ushort SoftwareVersionMinor => (ushort)(SoftwareVersion & 0x0000FFFFU);

    /// <summary>
    /// Gets the major hardware version.
    /// </summary>
    public ushort HardwareVersionMajor => (ushort)(HardwareVersion >> 16);

    /// <summary>
    /// Gets the minor hardware version.
    /// </summary>
    public ushort HardwareVersionMinor => (ushort)(HardwareVersion & 0x0000FFFFU);
}
