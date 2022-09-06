using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Inventory
{
    private readonly List<IItem> _items = new();
    public readonly int Capacity = 4;
    public IReadOnlyList<IItem> Items => _items;

    public event Action Changed;

    public void Add(IItem item)
    {
        _items.Add(item);
        Changed?.Invoke();
        Debug.Log($"Add an item {item}in inventory", item as Object);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
        Changed?.Invoke();
    }

    public bool IsFull() => Capacity == Items.Count;

    public bool IsEmpty() => Items.Count == 0;

    public IItem Pop()
    {
        IItem lastItem = _items[^1];

        _items.RemoveAt(Items.Count - 1);

        Changed?.Invoke();

        return lastItem;
    }

    public IItem Get(int index) => _items[index];
}