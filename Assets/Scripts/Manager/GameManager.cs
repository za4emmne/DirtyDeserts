using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private PlayerJumping _playerJumping;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AudioSource _boomAudio;

    [Header("Мониторинг данных")]
    [SerializeField] private float _speed;

    private bool _isGameOver;
    private bool _isStopInstantiate;
    private float _speedStep;
    private float _playerGravityScale;

    public event Action SpawnTimeChanged;

    public bool IsGameOver => _isGameOver;
    public float Speed => _speed;
    public bool IsStopInstantiate => _isStopInstantiate;

    private void Start()
    {
        _playerGravityScale = _playerBoomed.GetComponent<Rigidbody2D>().gravityScale;
        _isStopInstantiate = true;
        _speed = 3;
        _speedStep = 0;
        _isGameOver = false;
    }

    private void Update()
    {
    }

    public void RestartPlayScene()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += BoomTNT;
        _scoreManager.StepScoreChanged += AddSpeed;
    }
    private void OnDisable()
    {
        _scoreManager.StepScoreChanged -= AddSpeed;
    }

    private void AddSpeed()
    {
        if (_speed < 7)
            _speedStep = UnityEngine.Random.Range(0.5f, 1f);
        else
            _speedStep = UnityEngine.Random.Range(0.1f, 0.5f);

        _speed += _speedStep;
        _playerGravityScale += 0.07f;
        _playerJumping.AddJumpForce(7);
        SpawnTimeChanged?.Invoke();
    }

    private void BoomTNT()
    {
        _isStopInstantiate = true;
        _isGameOver = true;
        _speed = 0;
    }
}