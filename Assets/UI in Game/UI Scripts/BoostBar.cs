using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour
{

    public int boost;
    public int boostMax = 100;

    public GUISkin skinBarra;

    // Start is called before the first frame update
    void Start()
    {
        boost = boostMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (boost > boostMax)
        {
            boost = boostMax;
        }

        if (boost < 0)
        {
            boost = 0;
        }
    }
    private void OnGUI()
    {
        
        GUI.Box(new Rect(Screen.width - 70, Screen.height - 40, 60, 20), boost + " / " + boostMax);
        GUI.Box(new Rect(Screen.width-50, Screen.height - 50, 20, -Screen.height / 3), "");

        if(boost>0)
        {
            GUI.skin = skinBarra;
            GUI.Box(new Rect(Screen.width - 50, Screen.height-50, 20, - Screen.height / 3 * (((float)boost)/(float)boostMax)), "");
        }
    }


}
