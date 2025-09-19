using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Le doy feedback visual al botón cuando paso el cursor (hover) y cuando hago click.
/// En móvil no hay hover, pero en Editor/PC sí.
/// </summary>
[RequireComponent(typeof(Graphic))]
public class HoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Colores")]
    [SerializeField] private Color normal = Color.white;
    [SerializeField] private Color hover = new Color(1f, 1f, 1f, 0.9f);
    [SerializeField] private Color pressed = new Color(0.85f, 0.85f, 0.85f, 1f);

    private Graphic g;

    void Awake() => g = GetComponent<Graphic>();
    void OnEnable() { if (g) g.color = normal; }

    public void OnPointerEnter(PointerEventData eventData) { if (g) g.color = hover; }
    public void OnPointerExit(PointerEventData eventData) { if (g) g.color = normal; }
    public void OnPointerDown(PointerEventData eventData) { if (g) g.color = pressed; }
    public void OnPointerUp(PointerEventData eventData) { if (g) g.color = hover; }
}
