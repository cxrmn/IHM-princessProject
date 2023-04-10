using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private Vector3 respawnPosition; // respaw position

    public int currentKeys ;

    public string levelToLoad;

    private bool isCursorDisabled = false;

    public int currentChicken;

    public int currentApples;

    private void Awake() // Creamos una instancia del GameManager
    {
        instance = this;
    }

    // cursor no aparezca

    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            DisableCursor();
        }
       
        respawnPosition = PlayerController.instance.transform.position;


        // ManagerUI.instance.Keytext.text = "hello" ;
        // AddKey(0); I cannto call here cause its later call awake, awake problem
    }

    void Update()
    {
        
    }

    void DisableCursor()
    {
        isCursorDisabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void EnableCursor()
    {
        isCursorDisabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

       // Debug.Log("Coin add: " + keytoadd + currentKeys);
        currentKeys += keytoadd;
        Debug.Log("Key add: " + currentKeys);

        ManagerUI.instance.Keytext.text = "" + currentKeys;

    }


    
    public void AddChicken(int chickenToAdd)
    {
        currentChicken += chickenToAdd;
        Debug.Log("Chicken add: " + currentChicken);

        ManagerUI.instance.Chickentext.text = "" + currentChicken;
    }


    public void AddApple(int applesToAdd)
    {
        currentApples += applesToAdd;
        Debug.Log("Apples add: " + currentApples);
        ManagerUI.instance.Appletext.text = "" + currentApples;
    }
    

    public IEnumerator LevelEndWaiter()
    {
        yield return new WaitForSeconds(1f);
        EnableCursor();

        // ManagerUI.instance.LevelEnd();
        SceneManager.LoadScene(0);
    }


   


}