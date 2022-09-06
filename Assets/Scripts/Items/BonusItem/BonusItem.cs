using UnityEngine;

public abstract class BonusItem : Item
{
    [SerializeField] private Rigidbody _rigidbody;

    private void OnValidate() => _rigidbody ??= GetComponent<Rigidbody>();

    private States _state = States.Disabled;

    public bool IsEnabled => _state == States.Enabled;
    public bool IsDisabled => _state == States.Disabled;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (IsEnabled)
            {
                ActivateBonus(player);
                transform.Translate(-Vector3.up * 2); // ??????? ???????????? ???????. ????? ???????????? ? ???.
            }
            else
            {
                player.TryTakeItem(this);
            }
        }
        else if (IsEnabled)
        {
            Destroy(this);
        }
    }

    public void Trow(Vector3 direction)
    {
        _rigidbody.velocity = direction;
        SwitchState();
    }

    public void SwitchState() => 
        _state = IsEnabled 
            ? States.Disabled 
            : States.Enabled;

    public abstract void ActivateBonus(Player player);

    private enum States
    {
        Disabled,
        Enabled
    }
}