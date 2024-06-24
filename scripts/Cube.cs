using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceOfCopy = 100;
    [SerializeField] private Divider _divider;
    [SerializeField] private Exploder _exploder;

    private int _chanceReductionPercentage = 2;

    private void OnMouseUpAsButton()
    {
        TakeAction();
    }

    private void TakeAction()
    {
        int chanceOfCloning = Random.Range(0, 101);

        if (chanceOfCloning <= _chanceOfCopy)
        {
            _chanceOfCopy /= _chanceReductionPercentage;
            _divider.Divide();
        }
        else
        {
            _exploder.Explode();
        }
    }
}
