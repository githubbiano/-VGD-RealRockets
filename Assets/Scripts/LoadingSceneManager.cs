using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingSceneManager : MonoBehaviour
{

    float startTime;
    float endTime;
    float timeToSwitchCamera;
 
    public GameObject mainCamera;
    public GameObject camera;
  


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        endTime = 20f;
        timeToSwitchCamera = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Time.time - startTime >= timeToSwitchCamera)
        {
            mainCamera.SetActive(false);
            camera.SetActive(true);
        }
        else
        {
            mainCamera.SetActive(true);
            camera.SetActive(false);
        }


        if (Time.time - startTime >= endTime)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }




}
