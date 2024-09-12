namespace SgLockNET;

/// <content>The config part of the lock.</content>
public partial class SgLock
{
    /// <summary>
    /// Gets the features of the lock.
    /// </summary>
    public ConfigData ConfigData
    {
        get;
    }

    private static ConfigData ReadConfig(uint productId)
    {
        var config = default(ConfigData);
        var errorCode = SgLockNative.ReadConfig(productId, Categories.ReadConfigLockInfo, ref config);
        AssertErrorCode(errorCode);
        return config;
    }
}
