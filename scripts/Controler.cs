using System;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private int _chanceOfCopy = 100;

    private int _chanceReductionPercentage = 2;

    public event Action Exploding;
    public event Action Spawning;

    private void OnMouseUpAsButton()
    {
        Clone();
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