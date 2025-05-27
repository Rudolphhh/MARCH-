using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class ColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;

    private Color normalColor;
    private Color hoverColor;

    private string originalText;

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#323232", out normalColor);
        ColorUtility.TryParseHtmlString("#444444", out hoverColor);

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
