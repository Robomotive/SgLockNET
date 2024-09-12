namespace SgLockNET;

/// <summary>
/// Return codes from the sgl library.
/// </summary>
public enum ReturnCode
{
    /// <summary>
    /// Command was successful.
    /// </summary>
    Success = 0x00,

    /// <summary>
    /// Dgl was not found.
    /// </summary>
    DglNotFound = 0x01,

    /// <summary>
    /// The lpt port is busy.
    /// </summary>
    LptBusy = 0x02,

    /// <summary>
    /// The lpt port errored while opening.
    /// </summary>
    LptOpenError = 0x03,

    /// <summary>
    /// No lpt port found.
    /// </summary>
    NoLptPortFound = 0x04,

    /// <summary>
    /// Authentication is required.
    /// </summary>
    AuthenticationRequired = 0x05,

    /// <summary>
    /// Authentication failed.
    /// </summary>
    AuthenticationFailed = 0x06,

    /// <summary>
    /// Function is not supported.
    /// </summary>
    FunctionNotSupported = 0x07,

    /// <summary>
    /// The parameters are invalid.
    /// </summary>
    ParameterInvalid = 0x08,

    /// <summary>
    /// Signature is invalid.
    /// </summary>
    SignatureInvalid = 0x09,

    /// <summary>
    /// The usb port is busy.
    /// </summary>
    UsbBusy = 0x0A,

    /// <summary>
    /// Command is not supported.
    /// </summary>
    NotSupported = 0xFE,

    /// <summary>
    /// The command failed.
    /// </summary>
    Failed = 0xFF,
}
