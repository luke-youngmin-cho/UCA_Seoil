using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField] GameObject _mushroom;
    [SerializeField] float _spawnPeriod = 0.5f;
    

    // Start 함수는 코루틴으로 사용할수있다 (별도의 StartCoroutine 호출 불필요)
    //IEnumerator Start()
    //{
    //    GameObject go = new GameObject();
    //    go.AddComponent<Rigidbody>();
    //}

    void Start()
    {
        StartCoroutine(new SpawnCoroutine(_mushroom, 3f,_spawnPeriod, 3));
        StartCoroutine(Spawn());

        List<int> list = new List<int>();

        IEnumerator enumerator = list.GetEnumerator();

        while (enumerator.MoveNext())
        {
            //Console.WriteLine(enumerator.Current);
        }


        foreach (var item in list)
        {

        }
    }

    public struct SpawnCoroutine : IEnumerator
    {
        public SpawnCoroutine(GameObject prefab, float timer, float spawnPeriod, int spawnCount)
        {
            Current = null;
            this._prefab = prefab;
            this._timer = timer;
            this._spawnPeriod = spawnPeriod;
            this._spawnCount = spawnCount;
        }


        public object Current { get; private set; }
        GameObject _prefab;
        float _timer;
        float _spawnPeriod;
        int _spawnCount;

        public bool MoveNext()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                Vector3 targetPosition = Random.insideUnitSphere;
                GameObject.Instantiate(_prefab, targetPosition, Quaternion.identity);
                _timer = _spawnPeriod;
                _spawnCount--;
            }

            if (_spawnCount > 0)
            {
                Current = null;
                return true;
            }

            return false;
        }

        public void Reset()
        {
        }
    }


    IEnumerator Spawn()
    {
        float timer = 3f;
        bool running = false;

        while (true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Vector3 targetPosition = Random.insideUnitSphere;
                Instantiate(_mushroom, targetPosition, Quaternion.identity);
                timer = _spawnPeriod;
            }

            yield return null;
        }
    }

}
