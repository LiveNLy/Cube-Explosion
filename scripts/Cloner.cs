using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Cloner : MonoBehaviour
{
    [SerializeField] private GameObject _originaleCube;
    [SerializeField] private int _chanceOfCloning = 100;

    public event Action Exploding;

    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _cubesCount;
    private int _chanceReductionPercentage = 2;
    private float _scaleReducePercent = 2;

    private void OnMouseUpAsButton()
    {
        Clone();
    }

    private void Clone()
    {
        int chanceOfCloning = UnityEngine.Random.Range(0, 101);

        if (chanceOfCloning <= _chanceOfCloning)
        {
            _cubesCount = UnityEngine.Random.Range(_cubesCountMin, _cubesCountMax);
            _originaleCube.transform.localScale /= _scaleReducePercent;
            _chanceOfCloning /= _chanceReductionPercentage;

            for (int i = 0; i < _cubesCount; i++)
            {
                _originaleCube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                Instantiate(_originaleCube, transform.position, transform.rotation);
            }
        }
        else
        {
            Exploding?.Invoke();
        }
    }
}