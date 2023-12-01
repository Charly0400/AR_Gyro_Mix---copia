using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tpTo;
    public Transform tpToCamera;
    public Transform MainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TpPlayer(other.transform);
        }
    }

    private void TpPlayer(Transform player)
    {
        player.position = tpTo.position;

        MainCamera.position = tpToCamera.position;
        MainCamera.position += new Vector3(0, 50, 0);
    }
}
