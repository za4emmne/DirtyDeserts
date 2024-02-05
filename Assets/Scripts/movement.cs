using UnityEngine;

[RequireComponent(typeof(GameManager))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameManager _gameManager;

    private Object[] _objects;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        _objects = FindObjectsOfType<Object>();
        _speed = _gameManager.GetSpeed;

        foreach (var obj in _objects)
        {
            obj.transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}
