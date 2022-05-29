using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimKost2Script : MonoBehaviour, ISelectHandler, IDeselectHandler, IUpdateSelectedHandler
{
    Text ButtonText;
    [SerializeField] string standartText;

    void Start()
    {
        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ButtonText.text = "[ " + standartText + " ]";
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (ButtonText.text != "[ " + standartText + " ]")
            ButtonText.text = "[ " + standartText + " ]";
    }
}
