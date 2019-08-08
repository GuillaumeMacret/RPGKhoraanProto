using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTargetOnClick : MonoBehaviour
{
    public Button button;
    
    AbstractFightingEntity target;

    public AbstractFightingEntity Target { get => target; }

    /**
     * Sets this target to the target given in parameter, then creates an onclick listener with this target
     * @param the entity corresponding to this button
     **/
    public void SetTargetAndOnClick(AbstractFightingEntity target)
    {
        this.target = target;
        button.onClick.AddListener(() => AddEntityToTargeted());
    }

    public void AddEntityToTargeted()
    {
        Debug.Log("Adding " + target);
    }
}
