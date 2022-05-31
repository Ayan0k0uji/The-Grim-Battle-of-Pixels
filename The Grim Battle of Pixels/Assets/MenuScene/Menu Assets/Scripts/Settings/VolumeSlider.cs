using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    
    private float volume = 100f;
    private string stringVolume;
    [SerializeField] private AudioMixer am;
    [SerializeField] private Text textValue;




   void Start()
    {
        am.GetFloat("masterVolume", out volume);
        //volume *= 100;
        this.gameObject.GetComponent<Slider>().value = volume;
        stringVolume = (((int)volume + 75) * 4 / 3).ToString() + " %";
        textValue.text = stringVolume;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        //if (textValue.text != "[ " + stringVolume + " ]")
        //{
            stringVolume = (((int)volume + 75)*4/3).ToString() + " %";
            textValue.text = "[ " + stringVolume + " ]";
       // }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        textValue.text = stringVolume;
    }

    public void onChangeValue()
    {
        volume = this.gameObject.GetComponent<Slider>().value;
        am.SetFloat("masterVolume", volume );
    }
}
