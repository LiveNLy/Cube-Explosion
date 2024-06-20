using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _originaleCube;
    [SerializeField] private Controler _controler;
    [SerializeField] private CollorChanger _parameterChanger;

    private int _scaleReducePercent = 2;
    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _cubesCount;

    public event Action ParameterChanging;

    private void OnEnable()
    {
        _controler.Spawning += Spawn;
    }

    private void Spawn()
    {
        _cubesCount = UnityEngine.Random.Range(_cubesCountMin, _cubesCountMax);
        _originaleCube.transform.localScale /= _scaleReducePercent;

        for (int i = 0; i < _cubesCount; i++)
        {
            ParameterChanging?.Invoke();
            Instantiate(_originaleCube, transform.position, transform.rotation);
        }
    }
}
