using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractableHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Interactable interactable = col.GetComponent<Interactable>();

        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
