using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTargetOnClick : MonoBehaviour
{
    public Button button;

    Text m_Text;
    AbstractFightingEntity m_Target;

    public AbstractFightingEntity Target { get => m_Target; }

    private void Awake()
    {
        m_Text = GetComponentInChildren<Text>();
    }

    /**
     * Sets this target to the target given in parameter, then creates an onclick listener with this target
     * @param the entity corresponding to this button
     **/
    public void SetTarget(AbstractFightingEntity target)
    {
        this.m_Target = target;
        button.onClick.AddListener(() => AddEntityToTargeted());
        m_Text.text = target.name;
    }

    public void AddEntityToTargeted()
    {
        CombatMenuUI.instance.SetTarget(m_Target);
    }
}
