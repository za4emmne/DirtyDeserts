using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private GameObject _rulesGame;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOver;

    private ScoreManager _scoreManager;
    private int _score;

    private void Start()
    {
        _gameOver.SetActive(false);
        _scoreManager = GetComponent<ScoreManager>();
    }

    private void Update()
    {
        _score = _scoreManager.Score;
        HideRules();
        _scoreText.text = "Score: " + _score.ToString();
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += GameOver;
    }

    private void OnDisable()
    {
        _playerBoomed.PlayerBoomed -= GameOver;
    }

    private void HideRules()
    {
        if (_score > 1)
            _rulesGame.SetActive(false);
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
    }
}
