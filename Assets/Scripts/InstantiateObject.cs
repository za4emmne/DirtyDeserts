using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    //[SerializeField] private int _objectsCount;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 0;

    private float _spawnTime;
    private bool _isGameOver = false;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {

        Debug.Log(_spawnTime);
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY;
        float maxPositionY = transform.position.y + _devationPositionY;
        

        
            float positionY = Random.Range(minPositionY, maxPositionY);
            _spawnTime = Random.Range(_minDelay, _maxDelay);
            GameObject gameObject = Instantiate(_templates[Random.Range(0, _templates.Length)],
                new Vector3(transform.position.x, positionY, transform.position.z), Quaternion.identity);
        

        yield return _spawnTime;
    }
}
