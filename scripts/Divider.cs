using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private int _cubesCountMax = 6;
    private int _cubesCountMin = 2;
    private int _scaleReducePercent = 2;

    public void Divide(Cube cube)
    {
        int cubesCount;
        cube.transform.localScale /= _scaleReducePercent;
        cubesCount = Random.Range(_cubesCountMin, _cubesCountMax + 1);

        for (int i = 0; i < cubesCount; i++)
        {
            Cube newCube = _spawner.Spawn(cube);
            newCube.ChangeColor();
        }
    }
}