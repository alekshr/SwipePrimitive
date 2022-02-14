using System.Collections.Generic;

interface ManagmentObservable
{
    void RegisterObserver(IPlayer observer);
    void RemoveObserver(IPlayer observer);
    void NotifyObservers();
}


class ManagmentMove : ManagmentObservable
{
    private IList<IPlayer> observers;


    public ManagmentMove()
    {
        this.observers = new List<IPlayer>();
    }

    public void RegisterObserver(IPlayer observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IPlayer observer)
    {
        observers.Remove(observer);

    }
    public void NotifyObservers()
    {
        foreach (IPlayer observer in observers)
        {
            observer.Update();
        }
    }
}
