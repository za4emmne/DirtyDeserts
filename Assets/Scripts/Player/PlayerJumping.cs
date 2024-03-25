using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class PlayerJumping : MonoBehaviour
{
    public event Action AnimationJumpPlayed;

    [SerializeField] private PlayerBoomTNT _playerBoomTNT;

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce = 500;
    private bool _isGround;
    private AudioSource _audio;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void OnEnable()
    {
        _playerBoomTNT.PlayerBoomed += AddForce;
    }

    private void OnDisable()
    {
        _playerBoomTNT.PlayerBoomed -= AddForce;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            AnimationJumpPlayed?.Invoke();
            AddForce();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = true;
            _audio.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = false;
        }
    }

    private void AddForce()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
