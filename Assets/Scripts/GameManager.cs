using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string scene;
    private float gravity;
    // Start is called before the first frame update
    void Start()
    {
        scene = "SampleScene";//Scena di test
        StartCoroutine(LoadScene(scene)); //UNCOMMENT BEFORE RELEASE
        gravity = 120.0f;
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

    IEnumerator LoadScene(string scene) //Utile per capire quando una scena può essere settata come attiva, la scena da controllare viene passata in input come stringa ed appena è pronta viene
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

