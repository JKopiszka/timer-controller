namespace TimerController
{
    /// <summary>
    /// The exception that is thrown when an operation is attempted on a timer that has not been initialized.
    /// </summary>
    /// <remarks>This exception typically indicates that a timer-related method was called before the timer
    /// was properly set up. Ensure that the timer is initialized before performing operations that depend on its
    /// state.</remarks>
    public class TimerNotInitialized : Exception
    {
        /// <summary>
        /// Initializes a new instance of the TimerNotInitialized exception with a predefined error message indicating
        /// that the timer cannot receive negative values.
        /// </summary>
        public TimerNotInitialized()
            : base("Timer can't receive negative values!") { }
        
        /// <summary>
        /// Initializes a new instance of the TimerNotInitialized exception with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TimerNotInitialized(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the TimerNotInitialized class with a specified error message and a reference
        /// to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is
        /// specified.</param>
        public TimerNotInitialized(string message, Exception inner)
            : base(message, inner) { }
    }
}

/// <summary>
/// The exception that is thrown when an operation attempts to use a negative or zero time interval where only positive
/// values are valid.
/// </summary>
/// <remarks>This exception is typically thrown by timer-related APIs that require a strictly positive time
/// interval. Catch this exception to handle cases where invalid time values are supplied by user input or program
/// logic.</remarks>
public class NegativeTimeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the NegativeTimeException class with a predefined error message indicating
    /// </summary>
    public NegativeTimeException()
        : base("Timer interval must be greater than zero.") { }

    /// <summary>
    /// Initializes a new instance of the NegativeTimeException class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NegativeTimeException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the NegativeTimeException class with a specified error message and a reference to
    /// the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is
    /// specified.</param>
    public NegativeTimeException(string message, Exception inner)
        : base(message, inner) { }
}