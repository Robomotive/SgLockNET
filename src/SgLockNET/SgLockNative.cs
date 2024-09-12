using System.Runtime.InteropServices;

namespace SgLockNET;

/// <summary>
/// Native binding for the SG-Lock.
/// </summary>
internal static partial class SgLockNative
{
    private const string LibName = "SG-Lock";

    /// <summary>
    /// Reads the for every SG-Lock unique serial number.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock</param>
    /// <param name="serialNumber">
    /// Points to variable, in which the serial number will be given back to the calling application
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// Every SG-Lock has a serial number that is unique, which is also not depending on type and interface.
    /// </remarks>
    // public static extern uint SglReadSerialNumber([Out] uint ProductId, [In] uint[] SerialNumber);
    [LibraryImport(LibName, EntryPoint = "SglReadSerialNumber")]
    public static partial ReturnCode ReadSerialNumber(uint productId, out uint serialNumber);

    /// <summary>
    /// Searches for a SG-Lock device.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock looked for.</param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    // public static extern uint SglSearchLock([Out] uint ProductId);
    [LibraryImport(LibName, EntryPoint = "SglSearchLock")]
    public static partial ReturnCode SearchLock(uint productId);
}
