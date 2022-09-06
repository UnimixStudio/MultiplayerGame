public class SubscriptionManager
{
    private readonly ISubscribable[] _subscribables;

    public SubscriptionManager(params ISubscribable[] subscribables)
    {
        _subscribables = subscribables;
    }

    public void Subscribe()
    {
        foreach (ISubscribable subscribable in _subscribables) 
            subscribable.Subscribe();
    }

    public void UnSubscribe()
    {
        foreach (ISubscribable subscribable in _subscribables) 
            subscribable.UnSubscribe();
    }
}