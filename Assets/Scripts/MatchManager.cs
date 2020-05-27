using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float matchTime;

    GameManager manager;

    //int scoreCasa, scoreTrasferta;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        startTime = Time.time;
        matchTime = 20f;

        //scoreCasa = 0;
        //scoreTrasferta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= matchTime)
        {

            //manager.LoadNextScene("MenuScene");
            manager.LoadScene("MenuScene");
            manager.UnloadScene("SimpleScene");
            //Termina partita
            //SceneManager.UnloadSceneAsync("SampleScene");
            //SceneManager.LoadScene("MenuScene");
        }

    }
}
