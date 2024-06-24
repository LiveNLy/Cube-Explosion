using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Divider : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] CollorChanger _collorChanger;

    private Cube _cube;
    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _cubesCount;
    private int _scaleReducePercent = 2;

    private void Start()
    {
        _cube = GetComponent<Cube>();
    }

    public void Divide()
    {
        _cube.transform.localScale /= _scaleReducePercent;
        _cubesCount = Random.Range(_cubesCountMin, _cubesCountMax);

        for (int i = 0; i < _cubesCount; i++)
        {
            _collorChanger.ChangeCollor(_spawner.Spawn(_cube));
        }
    }
}