using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    [SerializeField] private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    public event Action<IItem> ItemDropped;
    public event Action<BonusItem> ActivatedItemDropped;

    private Inventory _inventory;

    protected CharacterController CharacterController;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _speed = 2;
    }

    private void Update()
    {
        Vector3 direction = 
            Vector3.forward * Vertical + 
            Vector3.right * Horizontal;
        
        direction.Normalize();
        
        CharacterController.SimpleMove(direction * _speed);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDropItem();

            // !!!
            //_inventoryUI.Remove();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_inventory.IsEmpty()) 
                return;
            
            TryActivateBonus((BonusItem)_inventory.Pop());

            // !!!
            //_inventoryUI.Remove();
        }
    }

    private static float Vertical => Input.GetAxis(VERTICAL);

    private static float Horizontal => Input.GetAxis(HORIZONTAL);

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
        if (_inventory.IsFull()) 
            return;
        Take(item);
    }

    public void Take(Item item)
    {
        item.Collected?.Invoke(item);

        Destroy(item.gameObject);
    }
}