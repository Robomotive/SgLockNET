using System.Runtime.InteropServices;

namespace SgLockNET;

/// <content>The read write product id part of the lock.</content>
internal static partial class SgLockNative
{
    /// <summary>
    /// Reads the 16-bit ProductId from the SG-Lock.
    /// </summary>
    /// <param name="productIdPtr">Pointer to variable, that the ProductId assigned to</param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    /// <remarks>
    /// The ProductId is an identifier that eases to distinguish between different protected
    /// applications of SG-Lock users.For example company X protects its application A and B with
    /// SG-Lock and gives all keys for application A the ProductId 1 and the keys for application B
    /// the ProductId 2, then all keys of application B are ”hidden“ for application A and vice
    /// versa.This simple mechanism offers an effective way to prevent confusion between keys of
    /// different applications (see also chapter 3.3.). Setting of the ProductId should be
    /// integrated into the initialization process of the SG-Locks before distributing with the
    /// protected software.
    /// </remarks>
    // public static extern uint SglReadProductId([In] uint[] ProductIdPtr);
    [LibraryImport(LibName, EntryPoint = "SglReadProductId")]
    public static partial ReturnCode ReadProductId(uint[] productIdPtr);

    /// <summary>
    /// Writes a new 16-bit ProductId to the SG-Lock.
    /// </summary>
    /// <param name="oldProductId">Indicates the actual ProductId of the SG-Lock.</param>
    /// <param name="newProductId">Indicates the new ProductId of the SG-Lock.</param>
    /// <returns>A <see cref="ReturnCode"/> indicating the result.</returns>
    // public static extern uint SglWriteProductId([Out] uint OldProductId, [Out] uint NewProductId);
    [LibraryImport(LibName, EntryPoint = "SglWriteProductId")]
    public static partial ReturnCode WriteProductId(uint oldProductId, uint newProductId);
}
