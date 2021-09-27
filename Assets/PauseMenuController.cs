using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VehiclePhysics;

public class PauseMenuController : MonoBehaviour
{
    public VehicleBase vehicle;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetCar()
    {
        VPResetVehicle resetScript = vehicle.GetComponent<VPResetVehicle>();
        resetScript.DoReset();
        this.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);   
    }
}
