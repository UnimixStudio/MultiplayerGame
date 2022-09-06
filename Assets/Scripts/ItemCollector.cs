public class ItemCollector
{
    public ItemCollector(Item[] items, Inventory inventory, InventoryUI inventoryUI)
    {
        foreach (var item in items)
        {
            item.Collected += inventory.Add;
            item.Collected += inventoryUI.Add;
        }
    }
}