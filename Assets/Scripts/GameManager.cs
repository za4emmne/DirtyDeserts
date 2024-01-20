using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerGetScore _player;
    //[SerializeField] private GameObject _rulesGame;
    //[SerializeField] private Movement[] _movement;
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    [SerializeField] private int _speed;
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;

    private bool _isGameOver;
    private bool _isStopInstantiate;

    private void Start()
    {
        _isStopInstantiate = true;
        _speed = 0;
        _score = 0;        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _isStopInstantiate = false;
        //    _rulesGame.SetActive(false);
        //    _speed = 3;
        //}

        _speed = 3;
        PlusScore();
        BoomTNT();
        AddSpeed();
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public bool GameOver()
    {
        return _isGameOver;
    }

    public bool StopInstantiate()
    {
        return _isStopInstantiate;
    }

    private void AddSpeed()
    {
        if(_score > 5)
        {
            _speed = 4;
        }
    }

    private void BoomTNT()
    {
        if (_playerBoomTNT.Boom())
        {
            _isStopInstantiate = true;
            _isGameOver = true;
            _speed = 0;
        }
        else
        {
            _isGameOver = false;
            _isStopInstantiate = false;
        }
    }

    private void PlusScore()
    {
            _score = _player.GetScore();
            _scoreText.text = "Score: " + _score.ToString();
            //Debug.Log(_score);
    }
}
