using System;
using System.Collections.Generic;

public class Inventory
{
    public readonly int Capacity = 4;

    public Action<Item> ItemTaken;

    private readonly List<Item> _items = new();

    public Inventory()
    {
        ItemTaken += Add;
    }

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    public bool IsFull()
    {
        return Capacity == _items.Count;   
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
