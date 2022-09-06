using UnityEngine;

public class SamplePlayer : Player
{
    private Vector3 _startPoint;
    private int _direction = 1;

    private void Start()
    {
        Speed = 0.009f;
        _startPoint = transform.position;
    }

    void Update()
    {
        CharacterController.Move(Vector3.forward * _direction * Speed);
        if (Mathf.Abs(_startPoint.z - transform.position.z) >= 2f)
        {
            _direction *= -1;
        }
    }
}
