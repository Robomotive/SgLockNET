using System.Runtime.InteropServices;

namespace SgLockNET;

/// <content>The counter part of the lock.</content>
internal static partial class SgLockNative
{
    /// <summary>
    /// Reads a 32-bit count value from the SG-Lock memory.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock.</param>
    /// <param name="counterNumber">
    /// Number of counter (0 to 15 - SG-Lock U3) (0 to 63 - SG-Lock U4).
    /// </param>
    /// <param name="data">Pointer to variable, that the counter value is assigned to.</param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// Counters are simple 32 bit data values in the SG-Lock memory. If desired, they can also be
    /// used for everything a 32 bit read/write variable is suitable for. By doing so you can extend
    /// the general purpose memory over the indicated size.
    /// </remarks>
    // public static extern uint SglReadCounter([Out] uint ProductId, [Out] uint CntNum, [In] uint[] Data);
    [LibraryImport(LibName, EntryPoint = "SglReadCounter")]
    public static partial ReturnCode ReadCounter(uint productId, uint counterNumber, out uint data);

    /// <summary>
    /// Writes a 32-bit count value from the SG-Lock memory.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock.</param>
    /// <param name="counterNumber">
    /// Number of counter (0 to 15 - SG-Lock U3) (0 to 63 - SG-Lock U4).
    /// </param>
    /// <param name="data">Pointer to variable, that the counter value is assigned to.</param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// Counters are simple 32 bit data values in the SG-Lock memory. If desired, they can also be
    /// used for everything a 32 bit read/write variable is suitable for. By doing so you can extend
    /// the general purpose memory over the indicated size.
    /// </remarks>
    // public static extern uint SglWriteCounter([Out] uint ProductId, [Out] uint CntNum, [Out] uint Data);
    [LibraryImport(LibName, EntryPoint = "SglWriteCounter")]
    public static partial ReturnCode WriteCounter(uint productId, uint counterNumber, uint data);
}
