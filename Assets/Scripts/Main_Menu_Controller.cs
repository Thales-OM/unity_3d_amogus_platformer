using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{   
    public GameObject Main_menu;
    public GameObject Options_Menu;
    public void Open_Settings()
    {
        Main_menu.SetActive(false);
        Options_Menu.SetActive(true);   
    }
    public void Open_Main_Menu(){
        Main_menu.SetActive(true);
        Options_Menu.SetActive(false);   
    }
    public void Play_Game()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
