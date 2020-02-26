using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = "SampleScene";//Scena di test
        StartCoroutine(LoadScene(scene));
    }


    // Update is called once per frame
    void Update()
    {

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

