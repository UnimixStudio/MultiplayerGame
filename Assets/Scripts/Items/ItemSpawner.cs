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

    private void OnDrop(Item item)
    {
        Instantiate(_factory.Create(item), _player.transform.position+new Vector3(2, 0, 0), Quaternion.identity);
    }

    private void OnActivatedDrop(BonusItem item)
    {
        var activatedItem = Instantiate(_factory.Create(item), _player.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
      
        activatedItem.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * 6f;
        activatedItem.GetComponent<BonusItem>().SwitchState();
    }
}
