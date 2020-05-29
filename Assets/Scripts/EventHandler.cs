using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public Movimento a;
    public Kick k;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Deactivate()
    {
        k.DeactivateHitbox();
    }
    public void Activate()
    {
        k.ActivateHitbox();
    }
}
