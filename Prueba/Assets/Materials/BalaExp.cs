using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaExp : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 10f;
    public float delayBeforeExplosion = 3f;

    private bool hasExploded = false;
    private ParticleSystem explosionParticles;

    void Start()
    {
        explosionParticles = GetComponent<ParticleSystem>();
        StartCoroutine(StartExplosionTimer());
    }

    private IEnumerator StartExplosionTimer()
    {
        yield return new WaitForSeconds(delayBeforeExplosion);
        if (!hasExploded)
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        hasExploded = true;

        explosionParticles.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = nearbyObject.transform.position - transform.position;

                rb.AddForce(direction.normalized * explosionForce, ForceMode.Impulse);
            }
        }

    }
}
