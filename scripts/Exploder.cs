using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Divider _controler;

    private Cube _cube;

    private void Start()
    {
        _cube = GetComponent<Cube>();
        _explosionForce /= _cube.transform.localScale.x;
        _explosionRadius /= _cube.transform.localScale.x;
    }

    private void OnEnable()
    {
        _controler.Exploding += Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

        Destroy(gameObject);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
