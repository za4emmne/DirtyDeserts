using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetScore : MonoBehaviour
{
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TNTTrigger tnt))
        {
            _score++;
        }
    }
}
