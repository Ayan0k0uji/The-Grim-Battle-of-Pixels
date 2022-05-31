using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnoffButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler, ISubmitHandler
{
    Text ButtonText;
    [SerializeField] string onText;
    [SerializeField] string offText;
    bool onSwitch = true;

    void Start()
    {
        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (onSwitch)
        {
            if (ButtonText.text != "[ " + onText + " ]")
                ButtonText.text = "[ " + onText + " ]";
        }
        else
        {
            if(ButtonText.text != "[ " + offText + " ]")
                ButtonText.text = "[ " + offText + " ]";
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (onSwitch)
            ButtonText.text = onText;
        else
            ButtonText.text = offText;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        onSwitch = !onSwitch;
    }

}
