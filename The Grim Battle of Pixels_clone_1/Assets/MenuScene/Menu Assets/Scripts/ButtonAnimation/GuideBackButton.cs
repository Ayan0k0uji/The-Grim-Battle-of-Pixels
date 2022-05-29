using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideBackButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    [SerializeField] private GameObject abliText;
    [SerializeField] private GameObject ultText;
    [SerializeField] private GameObject backText;

    public void OnDeselect(BaseEventData eventData)
    {
        abliText.SetActive(true);
        ultText.SetActive(true);
        backText.SetActive(false);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        abliText.SetActive(false);
        ultText.SetActive(false);
        backText.SetActive(true);
    }
}
