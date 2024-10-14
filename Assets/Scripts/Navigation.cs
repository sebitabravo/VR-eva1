using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void cargarEscenaMain(){
        //Cargamos escena Main
        SceneManager.LoadScene("Scenes/MainScene");
    }
    public void cargarEscenaAction(){
        //Cargamos escena Main
        SceneManager.LoadScene("Scenes/ActionScene");
    }
}
