using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void Test()
    {
        SceneManager.LoadScene(1);
    }

    public void World1()
    {
        SceneManager.LoadScene(2);
    }

    public void World2()
    {
        SceneManager.LoadScene(3);
    }

    public void World3()
    {
        SceneManager.LoadScene(4);
    }
}
