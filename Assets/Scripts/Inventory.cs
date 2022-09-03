using System.Collections.Generic;

public class Inventory
{
    private readonly int _capacity = 5;
    private List<Item> _items = new();
   
    public void Add(Item item)
    {
        if (!IsFull())
        {
            _items.Add(item);
        }   
    }

    public void Remove(Item item)
    {
        if (!IsEmpty())
        {
            _items.Remove(item);
        }  
    }

    public bool IsFull()
    {
        return _capacity == _items.Count;   
    }

    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    public Item Pop()
    {
        var lastItem = _items[^1];
        _items.RemoveAt(_items.Count - 1);
        return lastItem;
    }

    public Item Get(int index)
    {
        return _items[index];
    }
}
