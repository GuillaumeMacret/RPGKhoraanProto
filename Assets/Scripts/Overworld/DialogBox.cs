using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public static DialogBox instance;
    private TextMeshProUGUI m_Text;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            m_Text = GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>();
            if (m_Text == null) throw new System.Exception("No text item was found in dialogbox !");
            gameObject.SetActive(false);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(m_Text.pageToDisplay < m_Text.textInfo.pageCount)
            {
                m_Text.pageToDisplay++;
            }
        }
    }

    public bool isActive()
    {
        return gameObject.activeInHierarchy;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetText(string text)
    {
        m_Text.text = text;
    }
}
