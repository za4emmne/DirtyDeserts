using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerRun : MonoBehaviour
{


    [SerializeField] GameManager _gameManager;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        
    }
}
