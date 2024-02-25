namespace ExamPrep.Interfaces
{
    // Interfaces for Design Pattern Demo

    //
    // 1. ADAPTER PATTERN
    //
    /// <summary>
    /// Represents a client's request to fetch data.
    /// </summary>
    public interface IClientRequest
    {
        /// <summary>
        /// Fetches data for the client.
        /// </summary>
        public void ClientFetchData(int pageNumber, int pageSize);
    }

    /// <summary>
    /// Represents an interface for fetching data from the app.
    /// </summary>
    public interface IAdaptee
    {
        /// <summary>
        /// Fetches data from the app.
        /// </summary>
        public void AppFetchData(int pageNumber);
    }

    //
    // 2. FACTORY PATTERN
    //
    /// <summary>
    /// Represents a technician who performs website and API actions.
    /// </summary>
    public interface ITech
    {
        /// <summary>
        /// Performs website-related action.
        /// </summary>
        public void WebsiteAction();

        /// <summary>
        /// Performs API-related action.
        /// </summary>
        public void ApiAction();
    }

    /// <summary>
    /// Represents a shape with a method to show its properties.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Displays the properties of the shape.
        /// </summary>
        public void ShowShapeProps();
    }

    //
    // 3. OBSERVER PATTERN
    //
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
}