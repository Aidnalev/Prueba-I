using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public PlayerInteraction.TipoDisparo tipoDisparo;

    public void Interact(PlayerInteraction playerInteraction)
    {
        playerInteraction.SetLastInteractedObject(this);
    }
}
