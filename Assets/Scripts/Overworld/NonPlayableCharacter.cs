using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacter : MonoBehaviour
{

    public float displayTime = 4f;
    public GameObject dialogBox;

    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        timerDisplay = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                DialogBox.instance.SetActive(false);
            }
        }
    }

    public virtual void OnRaycast()
    {
        DialogBox.instance.SetText("Blabla");
        DialogBox.instance.SetActive(true);
        timerDisplay = displayTime;
    }
}
