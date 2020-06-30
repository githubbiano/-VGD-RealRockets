using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float startTime;
    private float matchTime;
    private int goalBlu;
    private int goalRosso;

    GameManager manager;
    private bool first;
    //int scoreCasa, scoreTrasferta;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        first = false;
        matchTime = 500f;

        //scoreCasa = 0;
        //scoreTrasferta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.getCurrentScene().Equals("MenuScene"))
        {
            first = true;
        }
            if (manager.getCurrentScene().Equals("SampleScene"))
        {
            if (first)
            {
                goalBlu = 0;
                goalRosso = 0;
                startTime = Time.time;
                first = false;
                //portaBlu = GameObject.FindGameObjectWithTag("PortaBlu");
                //portaRossa = GameObject.FindGameObjectWithTag("PortaRossa");
            }
            if (Time.time - startTime >= matchTime) //condizione di end game
            {
                manager.LoadNextScene("MenuScene");
                manager.UnloadScene("SampleScene");
            }
        }

    }
    public void GoalRosso()
    {
        goalRosso++;
    }
    public void GoalBlu()
    {
        goalBlu++;
    }
}
