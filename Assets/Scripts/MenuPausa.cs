using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private GameManager gm;
    public static bool GiocoInPausa = false;
    public GameObject UIMenuPausa;

    private void Start()
    {
        gm= GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

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
        Cursor.visible = false;
    }
    void Pause()
    {
        UIMenuPausa.SetActive(true);
        Time.timeScale = 0F;
        GiocoInPausa = true;
        Cursor.visible = true;
    }

    //public void Riavvia()
    //{

    //    gm.LoadNextScene("MenuScene");
    //    gm.UnloadScene("SampleScene");
    //    gm.UnloadScene("MenuScene");
    //    gm.LoadNextScene("SampleScene");
    //}

    public void Esci()
    {
        Time.timeScale = 1F;
        gm.LoadNextScene("MenuScene");
        gm.UnloadScene("SampleScene");
    }

}
