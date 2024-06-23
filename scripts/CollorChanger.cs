using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Cube))]
public class CollorChanger : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

     private Cube _cube;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        _spawner.ParameterChanging += ChangeParameters;
    }

    private void ChangeParameters()
    {
        _cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
