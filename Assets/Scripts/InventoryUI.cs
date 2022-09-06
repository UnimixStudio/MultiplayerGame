using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;

    private List<InventorySlot> _inventorySlotList;

    private void Awake()
    {
        _inventorySlotList = GetComponentsInChildren<InventorySlot>().ToList();
    }

    private void OnEnable()
    {
        _inventory.ItemTaken += Add;
    }

    private void OnDisable()
    {
        _inventory.ItemTaken -= Add;
    }

    public void Add(Item item)
    {
        var slot = FindFirstUnusedSlot();
        slot.Add(item);
        slot.SetState(InventorySlot.States.Used);
    }

    // !!!
    //public void Remove(Item item)
    //{
    //    var slot = _inventorySlotList[_inventorySlotList.IndexOf(item) - 1];
    //    slot.SetState(InventorySlot.States.Unused);
    //    slot.Remove();
    //}

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    private InventorySlot FindFirstUnusedSlot() => _inventorySlotList.FirstOrDefault(item => item.IsUnused);
}