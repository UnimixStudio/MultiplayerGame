using UnityEngine;

[CreateAssetMenu]
public class ItemFactory : ScriptableObject
{
    [SerializeField] private GameObject _slowingItemPrefab;    
    [SerializeField] private GameObject _freezingItemPrefab;

    public GameObject Create(IItem item)
    {
        return item switch
        {
            SlowingItem => _slowingItemPrefab,
            FreezingItem => _freezingItemPrefab,
            _ => null
        };
    }
}
