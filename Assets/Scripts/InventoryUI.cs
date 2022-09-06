using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayout))]
public class InventoryUI : MonoBehaviour, ISubscribable
{
    [SerializeField] private InventorySlot _inventorySlotPrefab;

    private readonly List<InventorySlot> _slots = new();

    private Inventory _inventory;
    private List<InventorySlot> _inventorySlotList;
    private GridLayoutGroup _layoutGroup;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _layoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void Start()
    {
        RenderInventorySlots();
        _inventorySlotList = GetComponentsInChildren<InventorySlot>()
            .ToList();
        RenderInventoryPanel();
    }

    public void Subscribe()
    {
        _inventory.Changed += UpdateView;
    }

    public void UnSubscribe()
    {
        _inventory.Changed -= UpdateView;
    }

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void Add(IItem item)
    {
        InventorySlot slot = FindFirstUnusedSlot();
        Debug.Log("slot = " + slot, slot);

        slot.Set(item);
    }

    // !!!
    //public void Remove(Item item)
    //{
    //    var slot = _inventorySlotList[_inventorySlotList.IndexOf(item) - 1];
    //    slot.SetState(InventorySlot.States.Unused);
    //    slot.Remove();
    //}

    private InventorySlot FindFirstUnusedSlot() => _inventorySlotList.FirstOrDefault(item => item.IsUnused);

    private void RenderInventoryPanel()
    {
        float sizeX = _layoutGroup.cellSize.x * _inventorySlotList.Count;
        float sizeY = _layoutGroup.cellSize.y;

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeX);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeY);
    }

    private void RenderInventorySlots()
    {
        for (var i = 0; i < _inventory.Capacity; i++)
        {
            InventorySlot slot = Instantiate(_inventorySlotPrefab, transform, true);
            _slots.Add(slot);
        }
    }

    private void UpdateView()
    {
        IReadOnlyList<IItem> items = _inventory.Items;
        
        for (var i = 0; i < _slots.Count; i++)
        {
            InventorySlot slot = _slots[i];

            if (i >= items.Count)
                slot.Clear();
            else
                slot.Set(items[i]);
        }
    }
}