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

    MatchManager mm;

    public int scoreRed;
    public int scoreBlue;
    public Timer tempo;
    public int matchTime;
    public int startTime;


    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("MatchManager").GetComponent<MatchManager>();
        scoreBlue = 0;
        scoreRed = 0;
        startTime = (int)Time.time;
        tempo = new Timer(mm.getMatchTime());

    }

    // Update is called once per frame
    void Update()
    {
        scoreBlue = mm.getGolBlu();
        scoreRed = mm.getGolRosso();
        
        matchTime = (int)mm.getMatchTime()-((int)Time.time - startTime);
        //tempo = mm.getMatchTime();
        /*if(scoreBlue<0)
        {
            scoreBlue = 0;
        }

        if(scoreRed<0)
        {
            scoreRed = 0;
        }*/
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
        GUI.Box(new Rect((Screen.width / 2) - 100, 40, 100, 50), scoreRed+"");
        GUI.Box(new Rect((Screen.width / 2)+5, 40, 100, 50), scoreBlue+ "");
        GUI.skin = cronometro;
        GUI.Box(new Rect((Screen.width / 2)-25, 40, 50, 50), matchTime.ToString()/*mm.getMatchTime().ToString() "5:00"*/);
    }
}
