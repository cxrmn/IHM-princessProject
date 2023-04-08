using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private Vector3 respawnPosition; // respaw position

    public int currentKeys ;

    private void Awake() // Creamos una instancia del GameManager
    {
        instance = this;
    }

    // cursor no aparezca

    void Start()
    {
        Debug.Log("hello");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
       
        
       
        // ManagerUI.instance.Keytext.text = "hello" ;
        // AddKey(0); I cannto call here cause its later call awake, awake problem
    }

    void Update()
    {
        //AddKey(1);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnWaiter());
    }

    public IEnumerator RespawnWaiter() //Corutina
    {
        PlayerController.instance.gameObject.SetActive(false); //Desaparece el personaje 
        CameraController.instance.cmBrain.enabled = false; // La camara no sigue al presonaje cuando muere

        ManagerUI.instance.fadeToBlack = true;


        yield return new WaitForSeconds(2f); // Esperar 2 segundos cuando muere el personaje

        ManagerUI.instance.fadeFromBlack = true;


        PlayerController.instance.transform.position = respawnPosition; // Cambiamos la posicion del personaje a la de respawn
        CameraController.instance.cmBrain.enabled = true; // La camara vuelve a seguir al personaje
        PlayerController.instance.gameObject.SetActive(true); //El personaje vuelve a aparecer
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint )
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn set");
    }

    public void AddKey(int keytoadd)
    {

        Debug.Log("Coin add: " + keytoadd);
        currentKeys += keytoadd;

        ManagerUI.instance.Keytext.text = "" + currentKeys;

    }
}