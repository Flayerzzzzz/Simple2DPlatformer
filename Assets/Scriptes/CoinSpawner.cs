using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawners;
    [SerializeField] private float _timeBetweenSpawn;

    private Transform[] _coinSpawners;

    private void Start()
    {
        _coinSpawners = new Transform[_spawners.childCount];

        for (int i = 0; i < _spawners.childCount; i++)
        {
            _coinSpawners[i] = _spawners.GetChild(i);
        }

        StartCoroutine(CoinSpawn());
    }

    private IEnumerator CoinSpawn()
    {
        for (int i = 0; i <= _coinSpawners.Length; i++)
        {
            Instantiate(_coin, _coinSpawners[i].position, Quaternion.identity);

            if (i == _coinSpawners.Length - 1)
            {
                i = -1;
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
