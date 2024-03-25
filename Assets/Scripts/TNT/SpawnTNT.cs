using UnityEngine;

public class SpawnTNT : MonoBehaviour
{
    [SerializeField] private TNT _bomb;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _minDeviationY;
    [SerializeField] private float _maxDeviationY;

    private void OnEnable()
    {
        _gameManager.SpawnTimeChanged += SpawnRandomTNT;
    }

    private void OnDisable()
    {
        _gameManager.SpawnTimeChanged -= SpawnRandomTNT;
    }

    private void SpawnRandomTNT()
    {
        float deviationY = Random.Range(_minDeviationY, _maxDeviationY);
        var tnt = Instantiate(_bomb, new Vector3(transform.position.x + deviationY, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
