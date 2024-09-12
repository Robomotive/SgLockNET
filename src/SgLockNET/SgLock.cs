namespace SgLockNET;

/// <summary>
/// Interface for communicating with the lock.
/// </summary>
public partial class SgLock
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SgLock"/> class.
    /// </summary>
    /// <param name="productId">The product id linked to this lock.</param>
    /// <param name="configData">The configuration data.</param>
    private SgLock(uint productId, ConfigData configData)
    {
        ProductId = productId;
        ConfigData = configData;
    }

    /// <summary>
    /// Gets the serial number of the lock.
    /// </summary>
    public uint SerialNumber => ConfigData.SerialNumber;

    /// <summary>
    /// Get all connected keys.
    /// </summary>
    /// <returns>A collection of keys.</returns>
    public static IEnumerable<SgLock> GetAllKeys()
    {
        var foundProductIds = new uint[255];
        var errorCode = SgLockNative.ReadProductId(foundProductIds);
        AssertErrorCode(errorCode);

        foreach (var productId in foundProductIds)
        {
            if (productId is 0 or uint.MaxValue)
            {
                yield break;
            }

            var config = ReadConfig(productId);
            yield return new SgLock(productId, config);
        }
    }

    /// <summary>
    /// Get a <see cref="SgLock"/> by product id.
    /// </summary>
    /// <param name="productId">The product id to look for.</param>
    /// <returns>The found <see cref="SgLock"/>.</returns>
    public static SgLock GetLock(uint productId)
    {
        var errorCode = SgLockNative.SearchLock(productId);
        AssertErrorCode(errorCode);
        var config = ReadConfig(productId);
        return new SgLock(productId, config);
    }

    private static void AssertErrorCode(ReturnCode returnCode)
    {
        switch (returnCode)
        {
            case ReturnCode.Success:
                return;

            case ReturnCode.DglNotFound:
                throw new SgLockException("No SG-Lock found for current customer", returnCode);

            case ReturnCode.LptBusy:
                throw new SgLockException("LPT SG-Lock is busy", returnCode);

            case ReturnCode.LptOpenError:
                throw new SgLockException("Unable to open LPT SG-Lock", returnCode);

            case ReturnCode.NoLptPortFound:
                throw new SgLockException("No LPT port found on this system", returnCode);

            case ReturnCode.AuthenticationRequired:
                throw new SgLockException("Authentication is required first", returnCode);

            case ReturnCode.AuthenticationFailed:
                throw new SgLockException("Authentication failed", returnCode);

            case ReturnCode.FunctionNotSupported:
                throw new SgLockException("Function is not supported by this SG-Lock", returnCode);

            case ReturnCode.ParameterInvalid:
                throw new SgLockException("Invalid parameters passed to library", returnCode);

            case ReturnCode.SignatureInvalid:
                throw new SgLockException("Invalid signature", returnCode);

            case ReturnCode.UsbBusy:
                throw new SgLockException("USB SG-Lock is busy", returnCode);

            case ReturnCode.NotSupported:
                throw new SgLockException("Not supported", returnCode);

            case ReturnCode.Failed:
                throw new SgLockException("Command failed", returnCode);

            default:
                throw new SgLockException("Unknown return code", returnCode);
        }
    }
}
