using System;
using UnityEngine;

public class Item : MonoBehaviour, IItem 
{
    [SerializeField] private Sprite _itemSprite;

    public Sprite ItemSprite =>_itemSprite;

    public Action<Item> Collected;
}