using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerGetScore _player;
    //[SerializeField] private Movement[] _movement;
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    [SerializeField] private int _speed;
    [SerializeField] private int _score;

    private bool _isGameOver;

    private void Start()
    {
        //_movement = FindObjectsOfType<Movement>();
        _score = 0;
        _speed = 3;
    }

    private void Update()
    {
        PlusScore();
        BoomTNT();

    }

    public int GetSpeed()
    {
        return _speed;
    }

    public bool GameOver()
    {
        return _isGameOver;
    }

    private void BoomTNT()
    {
        if (_playerBoomTNT.Boom())
        {
            _isGameOver = true;
            _speed = 0;
        }
        else
        {
            _isGameOver = false;
        }
    }

    private void PlusScore()
    {
            _score = _player.GetScore();
            //Debug.Log(_score);   
    }
}
