using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomTNT : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            _animator.SetTrigger("Boom");
        //Destroy(this.gameObject);
    }
}
