using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<killObj>(out killObj killer))
            Destroy(this.gameObject);
    }
}
