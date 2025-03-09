using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Necesario para los eventos de puntero

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite;
    public Sprite hoverSprite;
    private Image buttonImage;
    private RectTransform rectTransform;  // Declarar el RectTransform
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1);

    void Start()
    {
        buttonImage = GetComponent<Image>();  // Obtener el componente Image del botón
        rectTransform = GetComponent<RectTransform>();  // Obtener el componente RectTransform
        buttonImage.sprite = normalSprite;  // Asignar la imagen normal al inicio
    }

    // Cambiar imagen a la de hover cuando el puntero pasa por encima
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;

        if (rectTransform != null)
        {
            rectTransform.localScale = hoverScale;  // Cambiar la escala
        }
    }

    // Volver a la imagen normal cuando el puntero sale
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;

        if (rectTransform != null)
        {
            rectTransform.localScale = Vector3.one;  // Volver a la escala original
        }
    }
}