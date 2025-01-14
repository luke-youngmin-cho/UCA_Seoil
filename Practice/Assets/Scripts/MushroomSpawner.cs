using System;
using System.Collections;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField] GameObject _mushroom;
    [SerializeField] float _spawnPeriod = 0.5f;
    float _timer;
    bool _running = false;

    void Update()
    {
        if (!_running)
            return;

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            Vector3 targetPosition = Random.insideUnitSphere;
            Instantiate(_mushroom, targetPosition, Quaternion.identity);
            _timer = _spawnPeriod;
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                Vector3 targetPosition = Random.insideUnitSphere;
                Instantiate(_mushroom, targetPosition, Quaternion.identity);
                _timer = _spawnPeriod;
            }

            yield return null;
        }
    }

}
