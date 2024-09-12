using System.Runtime.InteropServices;

namespace SgLockNET;

/// <content>The read / write data part of the lock.</content>
internal static partial class SgLockNative
{
    /// <summary>
    /// Read 32-bit data from the SG-Lock memory.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock</param>
    /// <param name="address">
    /// Start address of data value block (0 to 63 - SG-Lock U3) (0 to 255 - SG-Lock U4)
    /// </param>
    /// <param name="count">Number of data values</param>
    /// <param name="data">
    /// Pointer to data array, in which the data values will be given back to the calling
    /// application. (The developer is responsible to provide an array with a sufficient size).
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    // public static extern uint SglReadData([Out] uint ProductId, [Out] uint Address, [Out] uint Count, [In] uint[] Data);
    [LibraryImport(LibName, EntryPoint = "SglReadData")]
    public static partial ReturnCode ReadData(uint productId, uint address, uint count, [In, Out] uint[] data);

    /// <summary>
    /// Writes 32-bit data values to SG-Lock memory.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock looked for.</param>
    /// <param name="address">
    /// Start address of data value block (0 to 63 - SG-Lock U3) (0 to 255 - SG-Lock U4)
    /// </param>
    /// <param name="count">Number of data values</param>
    /// <param name="data">
    /// Pointer to data array, in which the data values will be given back to the calling
    /// application. (The developer is responsible to provide an array with a sufficient size).
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    // public static extern uint SglWriteData([Out] uint ProductId, [Out] uint Address, [Out] uint Count, [In] uint[] Data);
    [LibraryImport(LibName, EntryPoint = "SglWriteData")]
    public static partial ReturnCode WriteData(uint productId, uint address, uint count, [In] uint[] data);
}
