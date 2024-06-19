using UnityEngine;

public class Cloner : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private GameObject _originaleCube;

    private int _percentOfCloning = 100;
    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _cubesCount;
    private int _chanceReductionPercentage = 2;
    private float _scaleReducePercent = 2;

    private void OnEnable()
    {
        _exploder.Cloning += Clone;
    }

    private void Clone()
    {
        int chanceOfCloning = Random.Range(0, 101);

        if (chanceOfCloning <= _percentOfCloning)
        {
            _cubesCount = Random.Range(_cubesCountMin, _cubesCountMax);
            _originaleCube.transform.localScale /= _scaleReducePercent;

            for (int i = 0; i < _cubesCount; i++)
            {
                _originaleCube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                _percentOfCloning /= _chanceReductionPercentage;
                Instantiate(_originaleCube, transform.position, transform.rotation);
            }
        }

    }
}