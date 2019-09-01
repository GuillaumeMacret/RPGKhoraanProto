using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayableCharacter : MonoBehaviour
{

    public float displayTime = 4f;

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
        //FIXME Use the entity text field instead (temp solution before dialog trees)
        DialogBox.instance.SetText(GetComponentInChildren<Text>().text);
        DialogBox.instance.SetActive(true);
        timerDisplay = displayTime;
    }
}
