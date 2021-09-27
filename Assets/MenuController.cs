using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    
    public void CreateGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
