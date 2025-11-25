using System.Timers; // Importing the Timer class
using Timer = System.Timers.Timer; // Alias for Timer to avoid naming conflicts


// Declaration of the namespace
namespace TimerController
{
    /// <summary>
    /// Controller for managing a timer that counts up from a start time to a target time.
    /// </summary>
    public class TimerController
    {
        private readonly Timer? _timer; // Timer instance for managing time intervals

        /// <summary>
        /// Gets the current time value, in seconds.
        /// </summary>
        public int CurrentTimeSeconds { get; private set; }
        /// <summary>
        /// Gets the target time value, in seconds.
        /// </summary>
        public int TargetTimeSeconds { get; private set; }

        /// <summary>
        /// Occurs when the timer updates and provides the current timer values as an array of strings.
        /// </summary>
        /// <remarks>Subscribers receive an array of strings representing the updated timer values. The
        /// specific format and meaning of each string in the array depend on the timer implementation.</remarks>
        public event Action<string[]>? TimerUpdated;

        /// <summary>
        /// Initializes a new instance of the TimerController class with the specified timer interval.
        /// </summary>
        /// 
        /// <param name="time">
        /// The interval, in milliseconds,
        /// at which the timer elapses. Must be greater than zero. 
        /// The default is 1000
        /// milliseconds.
        /// </param>
        /// 
        /// <exception cref="NegativeTimeException">
        /// Thrown when the specified time is less than or equal to zero.
        /// </exception>

        public TimerController(int time = 1000)
        {
            // Validate the time parameter
            if (time <= 0)
                throw new NegativeTimeException("Timer interval must be greater than zero.");

            _timer = new Timer(time); // Tick every 'time' milliseconds
            _timer.Elapsed += OnTimerElapsed; // Subscribe to the Elapsed event
        }

        /// <summary>
        /// Starts the timer with the specified start and end times, measured in minutes.
        /// </summary>
        /// <remarks>If the start time is greater than or equal to the end time, the timer will not
        /// start.</remarks>
        /// <param name="startMinutes">The initial time, in minutes, from which the timer will start counting.</param>
        /// <param name="endMinutes">The target time, in minutes, at which the timer will stop.</param>
        /// 
        public void StartTimer(int startMinutes, int endMinutes)
        {
            // Check if the timer is initialized
            if (_timer == null) throw new TimerNotInitialized();
            if (startMinutes < 0 || endMinutes < 0)
                throw new NegativeTimeException("Start and end times must be non-negative.");

            CurrentTimeSeconds = startMinutes * 60;
            TargetTimeSeconds = endMinutes * 60;

            // If the start time is already at or beyond the target, do not start the timer
            if (CurrentTimeSeconds >= TargetTimeSeconds)
            {
                StopTimer();
                return;
            }

            _timer.Start();
        }

        /// <summary>
        /// Stops the timer if it is currently running.
        /// </summary>
        public void StopTimer() { if (_timer == null) throw new TimerNotInitialized(); _timer.Stop(); }

        /// <summary>
        /// Pauses the timer, preventing it from triggering further events.
        /// </summary>
        /// <remarks>This method disables the timer if it has been initialized. If the timer is already
        /// paused, calling this method has no effect.</remarks>
        /// <exception cref="TimerNotInitialized">Thrown if the timer has not been initialized before calling this method.</exception>
        public void PauseTimer() { if (_timer == null) throw new TimerNotInitialized(); _timer.Enabled = false; }
        
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            // Increment the current time
            CurrentTimeSeconds++;
            // Notify subscribers about the timer update
            TimerUpdated?.Invoke(new string[] { CurrentTimeSeconds.ToString(), TargetTimeSeconds.ToString() });
            // Check if the target time has been reached
            if (CurrentTimeSeconds >= TargetTimeSeconds)
            {
                StopTimer();
            }
        }
    }    
}