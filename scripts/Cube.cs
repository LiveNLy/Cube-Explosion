using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceOfCopy = 100;
    [SerializeField] private Divider _divider;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Cube _cube;

    private int _chanceReductionPercentage = 2;

    private void OnMouseUpAsButton()
    {
        int chanceOfCloning = Random.Range(0, 101);

        if (chanceOfCloning <= _chanceOfCopy)
        {
            _chanceOfCopy /= _chanceReductionPercentage;
            _divider.Divide(_cube);
        }
        else
        {
            _exploder.Explode();
        }
    }

    public void ChangeColor()
    {
        _cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
