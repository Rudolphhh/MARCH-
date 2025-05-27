using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChangeFrontSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;

    private Color normalColor;
    private Color hoverColor;

    private string originalText;

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out normalColor);
        ColorUtility.TryParseHtmlString("#E5E5E5", out hoverColor);

        if (buttonText != null)
        {
            buttonText.color = normalColor;
            originalText = buttonText.text;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Najetí na tlačítko");
        if (buttonText != null)
        {
            buttonText.color = hoverColor;
            buttonText.text = "<u>" + originalText + "</u>";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Opuštění tlačítka");
        if (buttonText != null)
        {
            buttonText.color = normalColor;
            buttonText.text = originalText;
        }
    }
}
