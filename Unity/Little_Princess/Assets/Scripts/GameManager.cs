using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private Vector3 respawnPosition;

    private void Awake() // Creamos una instancia del GameManager
    {
        instance = this;
    }

    // cursor no aparezca

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnWaiter());
    }

    public IEnumerator RespawnWaiter() //Corutina
    {
        PlayerController.instance.gameObject.SetActive(false); //Desaparece el personaje 
        CameraController.instance.cmBrain.enabled = false; // La camara no sigue al presonaje cuando muere

        yield return new WaitForSeconds(2f); // Esperar 2 segundos cuando muere el personaje

        PlayerController.instance.transform.position = respawnPosition; // Cambiamos la posicion del personaje a la de respawn
        CameraController.instance.cmBrain.enabled = true; // La camara vuelve a seguir al personaje
        PlayerController.instance.gameObject.SetActive(true); //El personaje vuelve a aparecer
    }
}
