using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerGetScore _player;
    //[SerializeField] private GameObject _rulesGame;
    //[SerializeField] private Movement[] _movement;
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    [SerializeField] private float _speed;
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _nextStepScore = 4;
    [SerializeField] private int _highScore;
    [SerializeField] private GameObject _gameOver;

    private bool _isGameOver;
    private bool _isStopInstantiate;
    private float _speedStep;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("SaveScore");
        _isStopInstantiate = true;
        _speed = 3;
        _score = 0;
        _speedStep = 0;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _isStopInstantiate = false;
        //    _rulesGame.SetActive(false);
        //    _speed = 3;
        //}

        AddScore();
        BoomTNT();
        AddSpeed();
    }

    public float GetSpeed()
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

    public float GetSpeedStep()
    {
        return _speedStep;
    }

    public int GetHighscore()
    {
        return _highScore;
    }

    private void AddSpeed()
    {
        _speedStep = Random.Range(0.5f, 1f);
        int scoreStep = Random.Range(3, 5);

        if (_nextStepScore == _score)
        {
            _speed += _speedStep;
            _nextStepScore += scoreStep;
        }
    }

    private void BoomTNT()
    {
        if (_playerBoomTNT.Boom())
        {
            _gameOver.SetActive(true);
            _isStopInstantiate = true;
            _isGameOver = true;
            _speed = 0;
        }
        else
        {
            _gameOver.SetActive(false);
            _isGameOver = false;
            _isStopInstantiate = false;
        }
    }

    private void AddScore()
    {
        _score = _player.GetScore();
        _scoreText.text = "Score: " + _score.ToString();
        GetHighScore();
    }

    private void GetHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("SaveScore", _highScore);
        }
    }
}
