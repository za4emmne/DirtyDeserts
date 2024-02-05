using UnityEngine;

[RequireComponent(typeof(GameManager))]

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject _rulesGame;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
