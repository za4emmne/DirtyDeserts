using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _autors;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _highScoreText.text = "Highscore: " + _gameManager.GetHighscore().ToString();
        _autors.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Autors()
    {
        _menu.SetActive(false);
        _autors.SetActive(true);
    }

    public void Exit()
    {
       
    }

    public void AutorsExit()
    {
        _autors.SetActive(false);
        _menu.SetActive(true);
    }
}
