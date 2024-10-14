using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionUI : MonoBehaviour
{
    //Variable con camara meta
    public GameObject camaraMeta;
    //Variable de panel GameOver
    public GameObject panelGameOver;
    //Variable de Sonido de background
    public AudioSource audioBackgroud;
    //Variable sonido recorrido
    public AudioSource audioRecorrido;
    bool gameOver = false;
    //Variable para determinar si comenzo el juego
    bool juegoIniciado = false;
    //Variable de Sonido GameOver
    public AudioSource audioGameOver;
    // Variable para asociar el texto del timer
    public TMP_Text txt_timer;
    //Variable para contar el tiempo transcurrido
    private float tiempoTranscurrido = 0f;

    public GameObject panelInicio;
    //Objeto relacionado a la cámara
    public GameObject camaraInicio;
    //Método para comenzar
    public void ocultarPanelInicio()
    {
        audioBackgroud.Stop();
        audioRecorrido.Play();
        //ocultamos panel
        panelInicio.SetActive(false);
        //ocultamos cámara
        camaraInicio.SetActive(false);
        //Modificamos variable para permitir iniciar el timer
        juegoIniciado = true;
    }
    //Método update para actualizar el tiempo transcurrido
    void Update()
    {
        //Actualizamos el tiempo transcurrido
        if (juegoIniciado == true)
        {
            tiempoTranscurrido = tiempoTranscurrido + Time.deltaTime;
        }
        //Mostramos tiempo en Log
        //Debug.Log(tiempoTranscurrido);
        if (gameOver == false)
        {
            txt_timer.text = tiempoTranscurrido.ToString("F2");
        }
        //Al acabar el tiempo desplegamos elementos de UI y audio
        //Detectamos si se acabó el tiempo
        if (tiempoTranscurrido > 30f && gameOver == false)
        {
            //Debug.Log("Se acabó el tiempo");
            //Mostramos panel GameOver, silenciamos audio de fondo y ejecutamos audio game over
            panelGameOver.SetActive(true);
            audioRecorrido.Stop();
            audioGameOver.Play();
            gameOver = true;
            camaraMeta.SetActive(true);
            txt_timer.text = "";
        }

    }
}
