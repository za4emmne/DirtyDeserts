using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsInstantiates : MonoBehaviour
{
    [SerializeField] private GameObject[] _clouds;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 0;

    private float _spawnTime;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY;
        float maxPositionY = transform.position.y + _devationPositionY;

        while (true)
        {
            float positionY = Random.Range(minPositionY, maxPositionY);
            _spawnTime = Random.Range(_minDelay, _maxDelay);
            var waitForSeconds = new WaitForSeconds(_spawnTime);
            GameObject gameObject = Instantiate(_clouds[Random.Range(0, _clouds.Length)],
                new Vector3(transform.position.x, positionY, transform.position.z), Quaternion.identity);

            yield return waitForSeconds;
        }

    }
}
