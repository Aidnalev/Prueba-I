using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaRect : MonoBehaviour
{
    private bool isStuck = false;
    private Rigidbody rb;

    public float attractionForce = 10f;
    public float attractionRadius = 5f;

    private Vector3 impactPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck)
        {
            ContactPoint contact = collision.contacts[0];

            StickToSurface(contact);

            impactPosition = contact.point;
        }
    }

    private void StickToSurface(ContactPoint contact)
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);

        transform.position = contact.point;

        isStuck = true;
        Destroy(gameObject, 6f);
    }

    private void FixedUpdate()
    {
        if (isStuck)
        {
            Collider[] colliders = Physics.OverlapSphere(impactPosition, attractionRadius);

            foreach (Collider collider in colliders)
            {
                Rigidbody otherRb = collider.GetComponent<Rigidbody>();
                if (otherRb != null && otherRb != rb)
                {
                    Vector3 direction = impactPosition - collider.transform.position;

                    otherRb.AddForce(direction.normalized * attractionForce, ForceMode.Acceleration);

                    Vector3 orbitalForce = Vector3.Cross(direction.normalized, Vector3.up) * attractionForce;
                    otherRb.AddForce(orbitalForce, ForceMode.Acceleration);
                }
            }
        }
    }
}
