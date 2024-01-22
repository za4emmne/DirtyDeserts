using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    //[SerializeField] private int _objectsCount;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 0;

    private float _spawnTime;
    private bool _isGameOver;
    //private float _currentTimeSpawn;

    private void Start()
    {
        //_currentTimeSpawn = _gameManager.GetSpeedStep();
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        _isGameOver = _gameManager.StopInstantiate();
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY;
        float maxPositionY = transform.position.y + _devationPositionY;

        while (_isGameOver == false)
        {
            float positionY = Random.Range(minPositionY, maxPositionY);
            //float speedStep = 0;

            //if(_currentTimeSpawn != _gameManager.GetSpeedStep())
            //{
            //    speedStep += _currentTimeSpawn / 2;
            //    _currentTimeSpawn = _gameManager.GetSpeedStep();
            //}

            //_minDelay -= speedStep;
            //_maxDelay -= speedStep;
            _spawnTime = Random.Range(_minDelay, _maxDelay);
            var waitForSeconds = new WaitForSeconds(_spawnTime);

            GameObject gameObject = Instantiate(_templates[Random.Range(0, _templates.Length)],
                new Vector3(transform.position.x, positionY, transform.position.z), Quaternion.identity);

            yield return waitForSeconds;
        }

    }
}
