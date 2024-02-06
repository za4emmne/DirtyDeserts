using UnityEngine;

public class boomTNT : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerRun player))
        {
            _animator.SetTrigger("Boom");
        }
    }
}
