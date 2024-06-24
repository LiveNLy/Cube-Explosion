using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube Spawn(Cube cube)
    {
        return Instantiate(cube, transform.position, transform.rotation);
    }
}