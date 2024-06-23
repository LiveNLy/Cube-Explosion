using System;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Divider _controler;
    [SerializeField] private CollorChanger _parameterChanger;

    private Cube _cube;
    private int _scaleReducePercent = 2;
    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _cubesCount;

    public event Action ParameterChanging;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        _controler.Spawning += Spawn;
    }

    private void Spawn()
    {
        _cubesCount = UnityEngine.Random.Range(_cubesCountMin, _cubesCountMax);
        _cube.transform.localScale /= _scaleReducePercent;

        for (int i = 0; i < _cubesCount; i++)
        {
            ParameterChanging?.Invoke();
            var cube = Instantiate(_cube, transform.position, transform.rotation);
        }
    }
}
