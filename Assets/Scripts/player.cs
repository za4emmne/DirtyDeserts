using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _tnt;

    private bool _isGround;  
    private Animator _animator;
    private int _score = 0;

    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        Jump();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if(hit.collider.gameObject == _tnt)
        {
            Debug.Log(_score++);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGround)
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
