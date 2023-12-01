using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    void Update()
    {
        // Verifica si hay un toque en la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Convierte el toque en posición del mouse para verificar si se toca el botón
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Collider2D hitCollider = Physics2D.OverlapPoint(touchPos);

            // Si se toca el botón, carga la escena anterior
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                ReturnToScene();
            }
        }
    }

    public void ReturnToScene()
    {
        /*/ Obtén el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Si hay al menos dos escenas, carga la escena anterior
        if (currentSceneIndex >= 1)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }*/
       
            // Cambia al nombre de la escena que deseas cargar
      SceneManager.LoadScene("Prueba");
        
    }
}
