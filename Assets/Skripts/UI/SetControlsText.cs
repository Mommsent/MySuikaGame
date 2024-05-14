using TMPro;
using UnityEngine;

public class SetControlsText : MonoBehaviour
{
    private TextMeshProUGUI _controlsText;
    private void Start()
    {
        _controlsText = GetComponent<TextMeshProUGUI>();

        if (Application.isMobilePlatform)
        {
            _controlsText.text = "Тап двумя пальцами";
        }    
        else
        {
            _controlsText.text = "Пробел";
            _controlsText.alignment = TextAlignmentOptions.Left;
        }
            
        
    }
}
