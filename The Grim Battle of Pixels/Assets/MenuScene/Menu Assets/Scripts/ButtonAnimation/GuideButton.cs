using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    [SerializeField] private GameObject infoPanel;

    public void OnDeselect(BaseEventData eventData)
    {
        infoPanel.SetActive(false);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        infoPanel.SetActive(true);
    }
}
