﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float gravity;
    // Start is called before the first frame update
    void Start()
    {

        Physics.gravity = new Vector3(0, -3f, 0);

        gravity = 120.0f;
        string mainScene = "MenuScene";//Debug scene
        LoadNextScene(mainScene);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public float getGravity()
    {
        return this.gravity;
    }
    public void setGravity(float g)
    {
        this.gravity = g;
    }

    public void LoadNextScene(string scene)//Allow Scene load from everywhere
    {
        StartCoroutine(LoadScene(scene));
    }
    public void UnloadScene(string scene)//Allow Scene load from everywhere
    {
        Scene sc = SceneManager.GetSceneByName(scene);
        SceneManager.UnloadSceneAsync(sc);
    }

    public string getCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public IEnumerator LoadScene(string scene) //Utile per capire quando una scena può essere settata come attiva, la scena da controllare viene passata in input come stringa ed appena è pronta viene
    {                                    //impostata come current
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        Scene sc = SceneManager.GetSceneByName(scene);
        while (!sc.isLoaded)
        {
            yield return null;
        }
        if (sc.isLoaded)
        {
            SceneManager.SetActiveScene(sc);
        }

    }
}

