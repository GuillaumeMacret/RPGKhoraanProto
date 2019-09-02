using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayableCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnRaycast()
    {
        DialogBox.instance.SetText(GetComponentInChildren<Text>().text);
        DialogBox.instance.SetActive(true);
    }
}
