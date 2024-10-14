using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionPlayer : MonoBehaviour
{

    //Creamos 2 objetos de la clase AudioSource. Los definimos públicos para controlarlos desde la escena.
    public AudioSource audioRecorrido;
    public AudioSource audioMeta;
    //Variable de objeto para panel a mostrar al llegar a la meta
    public GameObject panelMeta;
    //Variable para camara final
    public GameObject camaraMeta;
    //Variable para sonido de caida
    public AudioSource audioCaida;
    // umnral para determinar si el personaje ha caido
    private float umbralCaida = -1f;




    //Método para detectar colisión. Detecta cuando el personaje llega a la meta.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "MetaTag")
        {
            //Acciones cuando se produzca la colisión
            Debug.Log("Llegamos a la meta");
            //Se detiene el sonido de fondo 
            audioRecorrido.Stop();
            audioMeta.Play();
            panelMeta.SetActive(true);
            camaraMeta.SetActive(true);
            //Se detiene el timer o se oculta cuando llegamos a la meta
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        // Verificar si el jugador ha caído por debajo del umbral
        if (transform.position.y < umbralCaida)
        {
            // Reproducir el sonido de caída si no se está reproduciendo ya
            if (!audioCaida.isPlaying)
            {
                audioCaida.Play();
            }
        }
    }
}
