using UnityEngine;
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ItemFactory _factory;

    private void OnEnable()
    {
        _player.ItemDropped += OnDrop;
        _player.ActivatedItemDropped += OnActivatedDrop;
    }

    private void OnDisable()
    {
        _player.ItemDropped -= OnDrop;
        _player.ActivatedItemDropped -= OnActivatedDrop;
    }

    private void OnDrop(IItem item)
    {
        Vector3 position = _player.transform.position + Vector3.right * 2f;
        
        GameObject original = _factory.Create(item);
        
        Instantiate(original, position, Quaternion.identity);
    }

    private void OnActivatedDrop(BonusItem item)
    {
        GameObject original = _factory.Create(item);
        Vector3 position = _player.transform.position + Vector3.right;
        GameObject activatedItem = Instantiate(original, position, Quaternion.identity);
        
        activatedItem.GetComponent<BonusItem>().Trow(Vector3.right * 6f);
    }
}