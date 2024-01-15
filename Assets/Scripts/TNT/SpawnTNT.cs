using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTNT : MonoBehaviour
{
    [SerializeField] private TNT _bomb; 
    [SerializeField] private float _minTimeBetweenRespawn;
    [SerializeField] private float _maxTimeBetweenRespawn;

    private float _spawnTime;


    void Update()
    {
        if (Time.time > _spawnTime)
        {
             var tnt = Instantiate(_bomb, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            _spawnTime = Time.time + Random.Range(_minTimeBetweenRespawn, _maxTimeBetweenRespawn);
        }
    }

       
}
