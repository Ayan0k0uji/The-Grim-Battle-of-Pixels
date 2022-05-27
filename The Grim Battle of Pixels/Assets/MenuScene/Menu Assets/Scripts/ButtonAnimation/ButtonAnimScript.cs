using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimScript : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler
{
    Text ButtonText;
    string standartText;

    void Start()
    {
        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
        standartText = ButtonText.text;
    }

    public void OnSelect(BaseEventData eventData)
    {
        ButtonText.text = "[ " + standartText + " ]";
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }
}
