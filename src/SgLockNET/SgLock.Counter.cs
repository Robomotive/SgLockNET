namespace SgLockNET;

/// <content>The counter part of the lock.</content>
public partial class SgLock
{
    /// <summary>
    /// Decrement the counter by 1.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    public void DecrementCounter(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var oldValue = ReadCounter(counterIndex);
        var newValue = oldValue--;
        WriteCounter(counterIndex, newValue);
    }

    /// <summary>
    /// Decrement the counter by 1.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task DecrementCounterAsync(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var oldValue = await ReadCounterAsync(counterIndex).ConfigureAwait(false);
        var newValue = oldValue--;
        await WriteCounterAsync(counterIndex, newValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Increment the counter by 1.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    public void IncrementCounter(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var oldValue = ReadCounter(counterIndex);
        var newValue = oldValue++;
        WriteCounter(counterIndex, newValue);
    }

    /// <summary>
    /// Increment the counter by 1.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task IncrementCounterAsync(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var oldValue = await ReadCounterAsync(counterIndex).ConfigureAwait(false);
        var newValue = oldValue++;
        await WriteCounterAsync(counterIndex, newValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Read the counter at the given index.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <returns>The value of the counter.</returns>
    public uint ReadCounter(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var errorCode = SgLockNative.ReadCounter(ProductId, counterIndex, out var counterValue);
        AssertErrorCode(errorCode);
        return counterValue;
    }

    /// <summary>
    /// Read the counter at the given index.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <returns>The value of the counter.</returns>
    public Task<uint> ReadCounterAsync(uint counterIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        return Task.Run(() =>
        {
            var errorCode = SgLockNative.ReadCounter(ProductId, counterIndex, out var counterValue);
            AssertErrorCode(errorCode);
            return counterValue;
        });
    }

    /// <summary>
    /// Write the counter at the given index.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <param name="value">The new counter value.</param>
    public void WriteCounter(uint counterIndex, uint value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        var errorCode = SgLockNative.WriteCounter(ProductId, counterIndex, value);
        AssertErrorCode(errorCode);
    }

    /// <summary>
    /// Write the counter at the given index.
    /// </summary>
    /// <param name="counterIndex">The index of the counter.</param>
    /// <param name="value">The new counter value.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WriteCounterAsync(uint counterIndex, uint value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(counterIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(counterIndex, ConfigData.CounterCount);
        return Task.Run(() =>
        {
            var errorCode = SgLockNative.WriteCounter(ProductId, counterIndex, value);
            AssertErrorCode(errorCode);
        });
    }
}
