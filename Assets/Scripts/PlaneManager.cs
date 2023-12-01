using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private GameObject prefab;

    private List<ARPlane> planes = new List<ARPlane>();
    private GameObject prefabPlaced;

    private void OnEnable()
    {
        arPlaneManager.planesChanged += PlaneFound;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= PlaneFound;
    }

    private void PlaneFound(ARPlanesChangedEventArgs planeData)
    {
        if (planeData.added != null && planeData.added.Count > 0)
        {
            planes.AddRange(planeData.added);
        }

        if (prefabPlaced == null)
        {
            foreach (var plane in planes)
            {
                if (plane.extents.x * plane.extents.y >= 0.1)
                {
                    CreatePrefab(plane);
                    StopPlaneDetection();
                    break; // Rompe el bucle después de encontrar el primer plano adecuado
                }
            }
        }
    }

    private void CreatePrefab(ARPlane plane)
    {
        float yOffset = plane.transform.localScale.y / 2f + 0.1f;
        prefabPlaced = Instantiate(prefab, new Vector3(plane.center.x, plane.center.y + yOffset, plane.center.z), Quaternion.identity);
        prefabPlaced.transform.forward = plane.normal;
    }

    private void StopPlaneDetection()
    {
        arPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
