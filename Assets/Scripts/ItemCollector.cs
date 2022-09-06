public class ItemCollector : ISubscribable
{
    private readonly Item[] _items;
    private readonly Inventory _inventory;

    public ItemCollector(Item[] items, Inventory inventory)
    {
        _items = items;
        _inventory = inventory;
    }

    public void Subscribe()
    {
        foreach (Item item in _items) 
            item.Collected += _inventory.Add;
    }
    public void UnSubscribe()
    {
        foreach (Item item in _items) 
            item.Collected -= _inventory.Add;
    }
}