using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _enemy;

    private Transform[] _points;
    private WaitForSeconds _waitForSeconds;

    private float _timeToWait = 2f;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeToWait);

        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                yield return _waitForSeconds;
                Instantiate(_enemy, _points[i].position, Quaternion.identity);
            }
        }
    }
}
