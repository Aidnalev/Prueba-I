using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    public enum TipoDisparo { Parabolico, Recto, ParabolicoDetonante }

    public Image canvasImage;
    private InteractableObject lastInteractedObject;
    public GameObject rectoPrefab;
    public GameObject parabolicoPrefab;
    public GameObject explosivoPrefab;
    public Vector3 offset = new Vector3(0, 1.5f, 0.295f);

    private void Start()
    {
        if (ControlDeAnimaciones.currentAnimation != null)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger(ControlDeAnimaciones.currentAnimation);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
        {
            InteractableObject interactableObject = hit.collider.gameObject.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                interactableObject.Interact(this);

                Material material = hit.collider.GetComponent<Renderer>().sharedMaterial;
                canvasImage.color = material.color;
            }
        }
    }


    public void SetLastInteractedObject(InteractableObject interactableObject)
    {
        lastInteractedObject = interactableObject;
    }

    private void Shoot()
    {
        if (lastInteractedObject != null)
        {
            TipoDisparo tipoDisparo = lastInteractedObject.tipoDisparo;

            switch (tipoDisparo)
            {
                case TipoDisparo.Parabolico:
                    DisparoParabolico();
                    break;
                case TipoDisparo.Recto:
                    DisparoRecto();
                    break;
                case TipoDisparo.ParabolicoDetonante:
                    DisparoParabolicoDetonante();
                    break;
                default:
                    Debug.LogError("Tipo de disparo no reconocido.");
                    break;
            }
        }
        else
        {

        }
    }

    private void DisparoParabolico()
    {
        GameObject bullet = Instantiate(parabolicoPrefab, transform.position + offset, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = Camera.main.transform.forward;
            rb.AddForce(direction * 20f, ForceMode.Impulse);
        }
        Destroy(bullet, 20f);
        Debug.Log("Disparo Parabólico");
    }

    private void DisparoRecto()
    {
        GameObject bullet = Instantiate(rectoPrefab, transform.position + offset, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = Camera.main.transform.forward;
            rb.AddForce(direction * 15f, ForceMode.Impulse);
        }
        Destroy(bullet, 20f);
        Debug.Log("Disparo Recto");
    }

    private void DisparoParabolicoDetonante()
    {
        GameObject bullet = Instantiate(explosivoPrefab, transform.position + offset, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = Camera.main.transform.forward;
            rb.AddForce(direction * 10f, ForceMode.Impulse);
        }
        Debug.Log("Disparo Detonante");
    }
}
