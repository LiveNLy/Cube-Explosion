using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CollorChanger : MonoBehaviour
{
    public void ChangeCollor(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
