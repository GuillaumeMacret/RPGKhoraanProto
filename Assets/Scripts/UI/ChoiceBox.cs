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
    private List<Func<string, int>> functionsList;

    private int indexHovered = 0;
    private const float inputDelay = 0.25f;
    private float inputDelayTimer;
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
        functionsList = new List<Func<string, int>>();

        AddItem("If you see this",null);
        AddItem("There is an error",null);

        if (choicesList.Count > 0) SetHovered(choicesList[indexHovered]);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputDelayTimer <= 0)
        {
            float vertical = Input.GetAxis("Vertical");
            if (!Mathf.Approximately(0, vertical))
            {
                if (vertical < 0)
                {
                    NextItem();
                }
                else
                {
                    PreviousItem();
                }
                inputDelayTimer = inputDelay;
            }
        }
        else
        {
            inputDelayTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.SetActive(false);
            TriggerHoveredItem();
        }

    }

    public void ClearItems()
    {
        foreach(TextMeshProUGUI item in GetComponentsInChildren<TextMeshProUGUI>())
        {
            Destroy(item.gameObject);
        }
        choicesList.Clear();
        functionsList.Clear();
    }

    private int NoActionBackup(string s)
    {
        Debug.Log("[WARN] No action set for " + s);
        return 0;
    }

    public void AddItem(string text, Func<string,int> function)
    {
        if (function == null) function = NoActionBackup;

        TextMeshProUGUI newText = Instantiate(choiceItemPrefab);
        newText.text = text;
        newText.gameObject.transform.SetParent(gameObject.transform);
        choicesList.Add(newText);

        functionsList.Add(function);
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
        textMeshProUGUI.fontSize = 18;
    }

    private void SetHovered(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.fontStyle = FontStyles.Bold;
        textMeshProUGUI.fontSize = 22;
    }

    public void PreviousItem()
    {
        UnsetHovered(choicesList[indexHovered]);
        indexHovered--;
        indexHovered += choicesList.Count;
        indexHovered %= choicesList.Count;
        SetHovered(choicesList[indexHovered]);
    }

    public void TriggerHoveredItem()
    {
        //NOTE : Here param is the choice's text, but it's not used unless reporting an error
        // Could be changed if needed
        functionsList[indexHovered](choicesList[indexHovered].text);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
