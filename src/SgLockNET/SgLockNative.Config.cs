using System.Runtime.InteropServices;

namespace SgLockNET;

/// <content>The config part of the lock.</content>
internal static partial class SgLockNative
{
    /// <summary>
    /// Reads configuration information about SG-Lock.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock looked for.</param>
    /// <param name="category">Type of requested information 0: Information about SG-Lock module.</param>
    /// <param name="data">
    /// Pointer to Data array of 8 integers of 32-bit The meaning of the single values are: Index 0:
    /// Type Index 1: Interface Index 2: Software Version Index 3: Hardware Version Index 4: Serial
    /// number Index 5: Memory size in DWORD Index 6: Number of counters Index 7: Number of 128-Bit Keys.
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    // public static extern uint SglReadConfig([Out] uint ProductId, [Out] uint Category, [In] uint[] Data);
    [LibraryImport(LibName, EntryPoint = "SglReadConfig")]
    public static partial ReturnCode ReadConfig(uint productId, Categories category, ref ConfigData data);

    /// <summary>
    /// Write configuration information to SG-Lock.
    /// </summary>
    /// <param name="productId">Indicates the ProductId of the SG-Lock looked for.</param>
    /// <param name="category">Type of requested information 0: Information about SG-Lock module.</param>
    /// <param name="data">
    /// Pointer to Data array of 8 integers of 32-bit The meaning of the single values are: Index 0:
    /// Type Index 1: Interface Index 2: Software Version Index 3: Hardware Version Index 4: Serial
    /// number Index 5: Memory size in DWORD Index 6: Number of counters Index 7: Number of 128-Bit Keys.
    /// </param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    [LibraryImport(LibName, EntryPoint = "SglWriteConfig")]
    public static partial ReturnCode WriteConfig(uint productId, Categories category, ref ConfigData data);
}
