using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class PlayerJumping : MonoBehaviour
{
    private const string AnimationRun = "Ground";

    private Rigidbody2D _rigidbody2D;
    private float _jumpForce = 500;
    private bool _isGround;
    private Animator _animator;
    private AudioSource _audio;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = true;
            //_audio.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = false;
        }
    }
}
