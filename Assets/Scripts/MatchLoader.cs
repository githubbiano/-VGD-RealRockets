using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchLoader : MonoBehaviour
{
    public float fillTime = 10f;
    private float timer;
    private bool gazedAt;
    private Coroutine fillBarRoutine;
    private Slider slider;
    private int value;
    public GameObject progressText;



    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }

    private void Update()
    {
        changeText();
    }
    
    public void changeText()
    {
        Debug.Log(slider.value);
        value = (int)(slider.value * 100f);
        string progress = value.ToString() +"%";    //((int)slider.value * 100f).ToString() + "%";
        progressText.GetComponent<Text>().text = progress;
    }

    public IEnumerator FillBar()
    {
        timer = 0f;

        while (timer < fillTime)
        {
            timer += Time.deltaTime/10;
            slider.value = timer / fillTime;
            
            yield return null;
        }
    }
    // Start is called before the first frame update

}
