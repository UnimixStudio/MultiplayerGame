using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySlotPrefab;

    private Inventory _inventory;
    private List<InventorySlot> _inventorySlotList;

    private void Start()
    {
        for(int i = 0; i < _inventory.Capacity; i++)
        {
            var slot = Instantiate(_inventorySlotPrefab);
            slot.transform.SetParent(transform);
        }
        _inventorySlotList = GetComponentsInChildren<InventorySlot>().ToList();
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