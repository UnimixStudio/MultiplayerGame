using UnityEngine;

public class BonusItem : Item
{
    public bool IsEnabled => _state == States.Enabled;
    public bool IsDisabled => _state == States.Disabled;

    private enum States
    {
        Disabled,
        Enabled
    }
    private States _state = States.Disabled;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (IsEnabled)
            {
                ActivateBonus(player);
                transform.Translate(-Vector3.up*2); // Костыль исчезновения объекта. Тут создать пул.
            }
            else
            {
                player.Take(this);
            }
        }
        else if (IsEnabled)
        {
            Destroy(this);
        }
    }

    public void SwitchState()
    {
        _state = IsEnabled ? States.Disabled : States.Enabled;
    }

    public virtual void ActivateBonus(Player player) { }
}