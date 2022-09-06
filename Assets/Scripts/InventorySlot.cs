using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _image;

    public bool IsUsed => _state == States.Used;
    public bool IsUnused => _state == States.Unused;

    private States _state = States.Unused;

    public enum States
    {
        Unused,
        Used
    }

    public void SetState(States state)
    {
        _state = state;
    }

    public void Set(IItem item)
    {
        _image.sprite = item.ItemSprite;
        SetState(States.Used);
    }

    // !!!
    public void Clear()
    {
        _image.sprite = null;
        SetState(States.Unused);
    }
}
