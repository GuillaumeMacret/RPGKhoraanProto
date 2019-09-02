using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChoiceBox : MonoBehaviour
{
    public static ChoiceBox instance;

    public TextMeshProUGUI choiceItemPrefab;

    private List<TextMeshProUGUI> choicesList;

    private int indexHovered = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        choicesList = new List<TextMeshProUGUI>();

        //FIXME test purpose delete this
        TextMeshProUGUI newText = Instantiate(choiceItemPrefab);
        newText.gameObject.transform.SetParent(gameObject.transform);
        choicesList.Add(newText);
        newText = Instantiate(choiceItemPrefab);
        newText.gameObject.transform.SetParent(gameObject.transform);
        choicesList.Add(newText);

        NextItem();
        NextItem();
        NextItem();
        //END of test purpose

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextItem()
    {
        UnsetHovered(choicesList[indexHovered]);
        indexHovered++;
        indexHovered %= choicesList.Count;
        SetHovered(choicesList[indexHovered]);
    }

    private void UnsetHovered(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.fontStyle = FontStyles.Normal;
    }

    private void SetHovered(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.fontStyle = FontStyles.Bold;
    }

    public void PreviousItem()
    {
        UnsetHovered(choicesList[indexHovered]);
        indexHovered--;
        indexHovered += choicesList.Count;
        indexHovered %= choicesList.Count;
        SetHovered(choicesList[indexHovered]);
    }
}
