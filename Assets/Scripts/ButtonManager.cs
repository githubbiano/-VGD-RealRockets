using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void nuovaPartita(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
