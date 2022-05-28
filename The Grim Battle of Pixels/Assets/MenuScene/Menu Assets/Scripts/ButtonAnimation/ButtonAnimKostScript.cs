using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimKostScript : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler
{
    Text ButtonText;
    [SerializeField]string standartText;

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

    public void OnSubmit(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }
}
