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
            _controlsText.text = "��� ����� ��������";
        }    
        else
        {
            _controlsText.text = "������";
            _controlsText.alignment = TextAlignmentOptions.Left;
        }
            
        
    }
}
