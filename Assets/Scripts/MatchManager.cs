using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float matchTime;
  
    //int scoreCasa, scoreTrasferta;
    void Start()
    {
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
            //Termina partita
            SceneManager.LoadScene("MenuScene");
        }

    }
}
