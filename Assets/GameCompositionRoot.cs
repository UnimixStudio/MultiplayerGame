using UnityEngine;

public class GameCompositionRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryUI _inventoryUI;

    private void Awake()
    {
        var inventory = new Inventory();
        var items = FindObjectsOfType<Item>();  // � ��������� ��� ����� �������� �� ���� ���������

        _player.Initialize(inventory);
        _inventoryUI.Initialize(inventory);

        new ItemCollector(items, inventory, _inventoryUI);
    }
}