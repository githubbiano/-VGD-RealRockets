﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingSceneManager : MonoBehaviour
{
    GameManager manager;
    float startTime;
    float endTime;
    float timeToSwitchCamera;
 
    public GameObject mainCamera;
    public GameObject camera;
    public string scena;
    private bool done;
  


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        startTime = Time.time;
        endTime = 20f;
        timeToSwitchCamera = 10f;
        scena = "SampleScene";
        done = false;
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

        
        if (Time.time - startTime >= endTime && !done)
        {
            manager.LoadNextScene(scena);
            manager.UnloadScene("LoadingScene");
            done = true;
            //SceneManager.LoadSceneAsync(2);
        }
    }




}
