using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerGetScore _player;
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    [SerializeField] private float _speed;
    [SerializeField] private int _score;
    [SerializeField] private float _nextStepScore = 4;
    [SerializeField] private int _highScore;

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

        //HideRules();
        AddScore();
        BoomTNT();
        AddSpeed();
    }

    public void RestartPlayScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public int GetScore
    {
        get { return _score; }
    }

    public float GetStepScore
    {
        get { return _nextStepScore; }
    }

    public float GetSpeed
    {
        get { return _speed; }
    }

    public int GetHighscore
    {
         get { return _highScore; }
    }

    public bool GameOver()
    {
        return _isGameOver;
    }

    public bool StopInstantiate()
    {
        return _isStopInstantiate;
    }

    //public float GetSpeedStep()
    //{
    //    return _speedStep;
    //}

    //private void HideRules()
    //{
    //    if(_score > 1)
    //    _rulesGame.SetActive(false);
    //}

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
            //_gameOver.SetActive(true);
            _isStopInstantiate = true;
            _isGameOver = true;
            _speed = 0;
        }
        else
        {
            //_gameOver.SetActive(false);
            _isGameOver = false;
            _isStopInstantiate = false;
        }
    }

    private void AddScore()
    {
        _score = _player.GetScore();
        //_scoreText.text = "Score: " + _score.ToString();
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
