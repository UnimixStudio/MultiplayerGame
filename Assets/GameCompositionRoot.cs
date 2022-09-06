using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompositionRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryUI _inventoryUI;

    private void Awake()
    {
        var inventory = new Inventory();

        inventory.ItemTaken += _inventoryUI.Add;

        _player.Initialize(inventory);
        _inventoryUI.Initialize(inventory);
    }
}
