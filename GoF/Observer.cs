namespace ExamPrep
{
    /// <summary>
    /// Represents an observer that watches the subject and gets notified about changes.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Gets the name of the observer.
        /// </summary>
        /// <returns>The name of the observer.</returns>
        public string GetName();

        /// <summary>
        /// Updates the status of the observer.
        /// </summary>
        public void UpdateStatus();
    }

    /// <summary>
    /// Represents an observer implementation that subscribes to a subject.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Observer"/> class.
    /// </remarks>
    public class Observer(ISubject subject, string name) : IObserver
    {
        private readonly string _name = name;
        private readonly ISubject _subject = subject;
        public string GetName()
        {
            return _name;
        }
        public void UpdateStatus()
        {
            Console.WriteLine("\nInside {0}: ObserversCount in Subject = {1}.", _name, _subject.ObserversCount);
        }
    }

    /// <summary>
    /// Represents a subject being observed.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Gets or sets the number of observers attached to the subject.
        /// </summary>
        public int ObserversCount { get; set; }

        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        public void Attach(IObserver observer);

        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        public void Detach(IObserver observer);

        /// <summary>
        /// Notifies all attached observers about changes in the subject.
        /// </summary>
        public void Notify();
    }

    /// <summary>
    /// Represents a subject being observed.
    /// </summary>
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private int _count = 0;

        /// <summary>
        /// Gets or sets the number of observers attached to the subject.
        /// </summary>
        public int ObserversCount
        {
            get
            {
                return _count;
            }
            set
            {
                if (_count != value)
                {
                    _count = value;
                    Notify();
                }
            }
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine("\nAttached {0}...", observer.GetName());
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("\nDetached {0}...", observer.GetName());
        }
        public void Notify()
        {
            _observers.ForEach((observer) =>
            {
                observer.UpdateStatus();
            });
        }
    }

    /// <summary>
    /// Provides a method to test the functionality of the observer pattern.
    /// </summary>
    public static class ObserverDemo
    {
        /// <summary>
        /// Tests the observer pattern.
        /// </summary>
        public static void TestObserver()
        {
            Subject subject = new();
            IObserver firstObserver = new Observer(subject, "First Observer");
            IObserver secondObserver = new Observer(subject, "Second Observer");

            subject.Attach(firstObserver);
            subject.Attach(secondObserver);
            subject.ObserversCount = 2;

            subject.Detach(firstObserver);
            subject.ObserversCount = 1;
        }
    }
}
