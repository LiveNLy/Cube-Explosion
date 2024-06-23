using System;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Divider : MonoBehaviour
{
    [SerializeField] private int _chanceOfCopy = 100;

    private Cube _cube;
    private int _chanceReductionPercentage = 2;

    public event Action Exploding;
    public event Action Spawning;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        _cube.ChangingState += Clone;
    }

    private void Clone()
    {
        int chanceOfCloning = UnityEngine.Random.Range(0, 101);

        if (chanceOfCloning <= _chanceOfCopy)
        {
            _chanceOfCopy /= _chanceReductionPercentage;
            Spawning?.Invoke();
        }
        else
        {
            Exploding?.Invoke();
        }
    }
}