using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _spawnPauseDuration;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _timeElapsed;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if( _timeElapsed > _spawnPauseDuration)
        {
            if(TryGetObject(out GameObject pipe))
            {
                _timeElapsed = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}
