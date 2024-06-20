using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CollorChanger : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ParameterChanging += ChangeParameters;
    }

    private void ChangeParameters()
    {
        _cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
