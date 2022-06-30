using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip startGameSound, endGameSound;
    private bool isStartScene = false;

    // play audio when game starts

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Inicio")
        {
            isStartScene = true;

            // Recuperar el componente audio source;
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = startGameSound;
            audioSource.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isStartScene)
        {
            // Si pulsa la tecla P o hace clic izquierdo empieza el juego
            if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0))
            {
                // Cargo la escena de Juego 
                SceneManager.LoadScene("Juego");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = endGameSound;
            audioSource.Play();

            StartCoroutine(waitAudioPlays(audioSource));

        }
    }

    IEnumerator waitAudioPlays(AudioSource audioSource)
    {
        // wait until the clip is done playing
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("Inicio");
    }
}
