using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayout))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySlotPrefab;

    private Inventory _inventory;
    private List<InventorySlot> _inventorySlotList;

    private RectTransform _rectTransform;
    private GridLayoutGroup _layoutGroup;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _layoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void Start()
    {
        RenderInventorySlots();
        _inventorySlotList = GetComponentsInChildren<InventorySlot>().ToList();
        RenderInventoryPanel();
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

    private void RenderInventoryPanel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _layoutGroup.cellSize.x * _inventorySlotList.Count);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _layoutGroup.cellSize.y);
    }
    private void RenderInventorySlots()
    {
        for (int i = 0; i < _inventory.Capacity; i++)
        {
            var slot = Instantiate(_inventorySlotPrefab);
            slot.transform.SetParent(transform);
        }
    }
}