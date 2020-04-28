using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class ScoreBoard : MonoBehaviour
{
    public GUISkin logoRossi;
    public GUISkin logoBlu;
    public GUISkin scoreBoard;
    public GUISkin punteggi;
    public GUISkin cronometro;

    public int scoreRed;
    public int scoreBlue;
    public Timer tempo;


    // Start is called before the first frame update
    void Start()
    {   
        scoreBlue = 0;
        scoreRed = 0;
        tempo = new Timer(300);

    }

    // Update is called once per frame
    void Update()
    {
        if(scoreBlue<0)
        {
            scoreBlue = 0;
        }

        if(scoreRed<0)
        {
            scoreRed = 0;
        }
    }

    void OnGUI()
    {
        GUI.skin = logoRossi;
        GUI.Box(new Rect((Screen.width / 2) - 200, 10, 100, 100), "");
        GUI.skin = logoBlu;
        GUI.Box(new Rect((Screen.width / 2) +100, 10, 100, 100), "");
        GUI.skin = scoreBoard;
        GUI.Box(new Rect((Screen.width/2)-120, 10, 240, 120),"");
        GUI.skin = punteggi;
        GUI.TextArea(new Rect((Screen.width / 2) - 100, 50, 100, 50), scoreRed+"");
        GUI.TextArea(new Rect((Screen.width / 2)+5, 50, 100, 50), scoreBlue+ "");
        GUI.skin = cronometro;
        GUI.Box(new Rect((Screen.width / 2)-25, 40, 50, 50), "5:00");
    }
}
