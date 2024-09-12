namespace SgLockNET;

/// <content>The product id part of the lock.</content>
public partial class SgLock
{
    /// <summary>
    /// Gets the product id of this lock.
    /// </summary>
    public uint ProductId
    {
        get;
        internal set;
    }

    /// <summary>
    /// Write a new product key to the lock.
    /// </summary>
    /// <param name="productId">The new product id.</param>
    public void WriteProductId(uint productId)
    {
        if (productId == ProductId)
        {
            return;
        }

        var errorCode = SgLockNative.WriteProductId(ProductId, productId);
        AssertErrorCode(errorCode);
        ProductId = productId;
    }

    /// <summary>
    /// Write a new product key to the lock.
    /// </summary>
    /// <param name="productId">The new product id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task WriteProductIdAsync(uint productId)
    {
        if (productId == ProductId)
        {
            return;
        }

        await Task.Run(() =>
        {
            var errorCode = SgLockNative.WriteProductId(ProductId, productId);
            AssertErrorCode(errorCode);
        }).ConfigureAwait(false);

        ProductId = productId;
    }
}
