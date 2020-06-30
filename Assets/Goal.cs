using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    MatchManager mm;
    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("MatchManager").GetComponent<MatchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball") && gameObject.CompareTag("PortaBlu"))
        {
            print("Goal blu");
            mm.GoalBlu();

        }
        if (other.gameObject.CompareTag("ball") && gameObject.CompareTag("PortaRossa"))
        {
            print("Goal rosso");
            mm.GoalRosso();
        }
    }
}
