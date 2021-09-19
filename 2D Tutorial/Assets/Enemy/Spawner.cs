using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] GameObject _bossPrefab;
    float _xMin;
    float _xMax;
    float _ySpawn;
    // Start is called before the first frame update
    void Start()
    {

        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("spawn", 0, 2f);

        InvokeRepeating("spawnBoss", 10, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn() {

        float randX = Random.Range(_xMin, _xMax);

        Instantiate(_enemyPrefab, new Vector3(randX, _ySpawn, 0), Quaternion.identity);

    }

    void spawnBoss() {

        float randX = Random.Range(_xMin, _xMax);

        Instantiate(_bossPrefab, new Vector3(randX, _ySpawn, 0), Quaternion.identity);

    }
}
