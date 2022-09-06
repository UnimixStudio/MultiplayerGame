using UnityEngine;

public class GameCompositionRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryUI _inventoryUI;

    private SubscriptionManager _subscriptionManager;

    private void Awake()
    {
        var inventory = new Inventory();

        _player.Initialize(inventory);
        _inventoryUI.Initialize(inventory);

        Item[] items = FindObjectsOfType<Item>();  // в дальнешем это будет получено от пула предметов
        
        var itemCollector = new ItemCollector(items, inventory);
        
        _subscriptionManager = new SubscriptionManager
        (
            itemCollector, 
            _inventoryUI
        );
    }

    private void Start()
    {
        _subscriptionManager.Subscribe();
    }

    private void OnDestroy()
    {
        _subscriptionManager.UnSubscribe();
    }
}