using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed
    {
        get
        {
            return _speed; 
        }
        set 
        {
            _speed = value; 
        }
    }

    public event Action<Item> ItemDropped;
    public event Action<BonusItem> ActivatedItemDropped;

    private Inventory _inventory;

    protected CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _speed = 2;
    }
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        characterController.SimpleMove((Vector3.forward*vertical+Vector3.right*horizontal)*_speed);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDropItem();

            // !!!
            //_inventoryUI.Remove();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_inventory.IsEmpty()) return;
            TryActivateBonus((BonusItem)_inventory.Pop());

            // !!!
            //_inventoryUI.Remove();
        }
    }

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void TryActivateBonus(BonusItem item)
    {
        if (item.IsDisabled)
        {
            ActivatedItemDropped?.Invoke(item);
        }
    }

    private void TryDropItem()
    {
        if (_inventory.IsEmpty())
        {
            print("Inventory is empty");
            return;
        }
        ItemDropped?.Invoke(_inventory.Pop());
    }

    public void TryTakeItem(Item item)
    {
        if (_inventory.IsFull()) return;
        Take(item);
    }

    public void Take(Item item)
    {
        _inventory.ItemTaken?.Invoke(item);

        Destroy(item.gameObject);
        print("Add an item in inventory");
    }

}