namespace SgLockNET;

/// <summary>
/// The exception that is thrown when there is a error in the sgl wrapper.
/// </summary>
[Serializable]
public class SgLockException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SgLockException"/> class.
    /// </summary>
    public SgLockException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SgLockException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public SgLockException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SgLockException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception. If the innerException parameter is
    /// not a null reference, the current exception is raised in a catch block that handles the
    /// inner exception.
    /// </param>
    public SgLockException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SgLockException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="returnCode">The <see cref="ReturnCode"/> that caused this exception.</param>
    public SgLockException(string message, ReturnCode returnCode)
        : this(message)
        => ReturnCode = returnCode;

    /// <summary>
    /// Gets the <see cref="ReturnCode"/> that caused this exception.
    /// </summary>
    public ReturnCode ReturnCode
    {
        get;
    }
}
