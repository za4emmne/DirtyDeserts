using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject _rulesGame;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOver;

    private int _score;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _score = _gameManager.GetScore;
        HideRules();
        _scoreText.text = "Score: " + _score.ToString();
        GameOver(_gameManager.GameOver());
    }

    private void HideRules()
    {
        if (_score > 1)
            _rulesGame.SetActive(false);
    }

    private void GameOver(bool isGameOver)
    {
        if (isGameOver)
            _gameOver.SetActive(true);
        else
            _gameOver.SetActive(false);
    }
}
