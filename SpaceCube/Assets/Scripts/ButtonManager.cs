using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject buildMenu, gameView;
    public Build build;

    void Start()
    {
        CloseBuildMenu();
    }
    public void OpenBuildMenu()
    {
        Time.timeScale = 0;
        buildMenu.SetActive(true);
        gameView.SetActive(false);
    }
    public void CloseBuildMenu()
    {
        Time.timeScale = 1;
        gameView.SetActive(true);
        buildMenu.SetActive(false);
    }
    public void BuildFarm(GameObject farm)
    {
        build.building = farm;
        CloseBuildMenu();
    }
}
