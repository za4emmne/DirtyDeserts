using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _autors;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _coinsInWallet;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Wallet _wallet;
    


    private void Start()
    {
        ChangeHighSCore();
        ChangeCoins();
        _autors.SetActive(false);
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
        Application.Quit();
    }

    public void AutorsExit()
    {
        _autors.SetActive(false);
        _menu.SetActive(true);
    }

    public void ChangeHighSCore()
    {
        _highScoreText.text = "Highscore: " + _scoreManager.HighScore.ToString();
    }

    public void ChangeCoins()
    {
        _coinsInWallet.text = _wallet.Coin.ToString() + " coins";
    }
}
