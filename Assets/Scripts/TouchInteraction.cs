using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TouchInteraction : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Tocaste el cubo. Cambiando de escena...");
                    ChangeScene();
                }
            }
        }
    }

    private void ChangeScene()
    {
        // Cambia al nombre de la escena que deseas cargar
        SceneManager.LoadScene("Prueba");
    }
}
