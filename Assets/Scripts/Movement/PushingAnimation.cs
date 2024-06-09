using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.SetBool("PushingCrate", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.SetBool("PushingCrate", false);
        }
    }
}
