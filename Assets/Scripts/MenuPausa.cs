using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool GiocoInPausa = false;
    public GameObject UIMenuPausa;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GiocoInPausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        UIMenuPausa.SetActive(false);
        Time.timeScale = 1F;
        GiocoInPausa = false;
    }
    void Pause()
    {
        UIMenuPausa.SetActive(true);
        Time.timeScale = 0F;
        GiocoInPausa = true;
    }

    public void Riavvia()
    {
        Debug.Log("Riavvio in corso ...");
    }

    public void Esci()
    {
        Debug.Log("Uscita in corso...");
        Application.Quit();
    }

}
