namespace SgLockNET;

/// <content>The read data part of the lock.</content>
public partial class SgLock
{
    /// <summary>
    /// Read all data from the lock memory.
    /// </summary>
    /// <returns>All found data.</returns>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    public uint[] ReadAllData()
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        var data = new uint[ConfigData.MemorySize];
        var errorCode = SgLockNative.ReadData(ProductId, 0, (uint)data.Length, data);
        AssertErrorCode(errorCode);
        return data;
    }

    /// <summary>
    /// Read all data from the lock memory.
    /// </summary>
    /// <returns>All found data.</returns>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    public Task<uint[]> ReadAllDataAsync()
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        return Task.Run(() =>
        {
            var data = new uint[ConfigData.MemorySize];
            var errorCode = SgLockNative.ReadData(ProductId, 0, (uint)data.Length, data);
            AssertErrorCode(errorCode);
            return data;
        });
    }

    /// <summary>
    /// Read all data from the lock memory.
    /// </summary>
    /// <param name="startAdress">The adress to start reading from.</param>
    /// <param name="length">The number of elements to read.</param>
    /// <returns>All found data.</returns>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    public uint[] ReadData(uint startAdress, uint length)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startAdress + length, ConfigData.MemorySize, nameof(length));

        var data = new uint[length];
        var errorCode = SgLockNative.ReadData(ProductId, startAdress, length, data);
        AssertErrorCode(errorCode);
        return data;
    }

    /// <summary>
    /// Read all data from the lock memory.
    /// </summary>
    /// <param name="startAdress">The adress to start reading from.</param>
    /// <param name="length">The number of elements to read.</param>
    /// <returns>All found data.</returns>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    public Task<uint[]> ReadDataAsync(uint startAdress, uint length)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startAdress + length, ConfigData.MemorySize, nameof(length));

        return Task.Run(() =>
        {
            var data = new uint[length];
            var errorCode = SgLockNative.ReadData(ProductId, startAdress, (uint)data.Length, data);
            AssertErrorCode(errorCode);
            return data;
        });
    }

    /// <summary>
    /// Write data to the lock memory.
    /// </summary>
    /// <param name="data">The data to write.</param>
    /// <param name="startAdress">The adress to start wring from.</param>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the data can not fit in the memory.</exception>
    public void WriteData(uint[] data, uint startAdress)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startAdress + data.Length, ConfigData.MemorySize, nameof(startAdress));
        var errorCode = SgLockNative.WriteData(ProductId, startAdress, (uint)data.Length, data);
        AssertErrorCode(errorCode);
    }

    /// <summary>
    /// Write data to the lock memory.
    /// </summary>
    /// <param name="data">The data to write.</param>
    /// <param name="startAdress">The adress to start wring from.</param>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the data can not fit in the memory.</exception>
    public void WriteData(uint data, uint startAdress)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        var errorCode = SgLockNative.WriteData(ProductId, startAdress, 1, [data]);
        AssertErrorCode(errorCode);
    }

    /// <summary>
    /// Write data to the lock memory.
    /// </summary>
    /// <param name="data">The data to write.</param>
    /// <param name="startAdress">The adress to start wring from.</param>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the data can not fit in the memory.</exception>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WriteDataAsync(uint[] data, uint startAdress)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startAdress + data.Length, ConfigData.MemorySize, nameof(startAdress));
        return Task.Run(() =>
        {
            var errorCode = SgLockNative.WriteData(ProductId, startAdress, (uint)data.Length, data);
            AssertErrorCode(errorCode);
        });
    }

    /// <summary>
    /// Write data to the lock memory.
    /// </summary>
    /// <param name="data">The data to write.</param>
    /// <param name="startAdress">The adress to start wring from.</param>
    /// <exception cref="SgLockException">Is thrown when there is no data area.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the data can not fit in the memory.</exception>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WriteDataAsync(uint data, uint startAdress)
    {
        if (ConfigData.MemorySize <= 0)
        {
            throw new SgLockException("SG-Lock has no data memory");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(startAdress);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startAdress, ConfigData.MemorySize);
        return Task.Run(() =>
        {
            var errorCode = SgLockNative.WriteData(ProductId, startAdress, 1, [data]);
            AssertErrorCode(errorCode);
        });
    }
}
