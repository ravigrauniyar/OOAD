namespace ExamPrep
{
    public interface IObserver
    {
        public string GetName();
        public void UpdateStatus();
    }
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
            Console.WriteLine("Inside {0}: ObserversCount in Subject = {1}.\n", _name, _subject.ObserversCount);
        }
    }
    public interface ISubject
    {
        public int ObserversCount { get; set; }
        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify();
    }
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers = [];
        private int _count = 0;
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
            Console.WriteLine("Detached {0}...", observer.GetName());
        }

        public void Notify()
        {
            _observers.ForEach((observer) =>
            {
                observer.UpdateStatus();
            });
        }
    }
    public static class ObserverDemo
    {
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