using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject exitPipe; // Assign the corresponding exit pipe in the inspector
    public Vector3 positionOffset = Vector3.zero; // Offset the position where the crate will appear
    public Vector3 rotationOffset = Vector3.zero; // Offset the rotation of the crate upon teleportation

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            TeleportCrate(other.gameObject);
        }
    }

    private void TeleportCrate(GameObject crate)
    {
        if (exitPipe != null)
        {
            // Set the position of the crate at the exit pipe plus any offset
            crate.transform.position = exitPipe.transform.position + positionOffset;

            // Set the rotation of the crate relative to the exit pipe plus any offset
            Quaternion targetRotation = Quaternion.Euler(rotationOffset) * exitPipe.transform.rotation;
            crate.transform.rotation = targetRotation;
        }
        else
        {
            Debug.LogError("Exit pipe not assigned or missing!");
        }
    }
}
