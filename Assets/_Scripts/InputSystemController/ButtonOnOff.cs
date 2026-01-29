using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class ButtonOnOff : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    [InputControl(layout = "Button")]
    [SerializeField]
    string _controlPath;

    protected override string controlPathInternal
    {
        get => _controlPath;
        set => _controlPath = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SendValueToControl(1.0f);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        SendValueToControl(0.0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (eventData.dragging || eventData.button != PointerEventData.InputButton.Left)
        //    SendValueToControl(1.0f);
        if(Pointer.current != null && Pointer.current.press.isPressed)
            SendValueToControl(1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SendValueToControl(0.0f);
    }

}
