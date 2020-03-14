using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    GameManager manager;
    // Start is called before the first frame update
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void nuovaPartita(string scena)
    {
        manager.LoadNextScene(scena);
        manager.UnloadScene("MenuScene");
    }
}