using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    public enum ButtonName {
        LeftButton,
        RightButton,
        selectRecycle,
        selectTrash,
        selectFirefighter
    }

    public ButtonName buttonName;

    private bool buttonDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (buttonName) {
            case ButtonName.LeftButton:
                PlayerController.instance.moveLeft = buttonDown;
                break;
            case ButtonName.RightButton:
                PlayerController.instance.moveRight = buttonDown;
                break;
            case ButtonName.selectRecycle:
                if (buttonDown) {
                    PlayerController.instance.characterID = 0;
                }
                break;
            case ButtonName.selectTrash:
                if (buttonDown) {
                    PlayerController.instance.characterID = 1;
                }
                break;
            case ButtonName.selectFirefighter:
                if (buttonDown) {
                    PlayerController.instance.characterID = 2;
                }
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        buttonDown = true;
        PlayerController.instance.isTouchControl = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        buttonDown = false;
        PlayerController.instance.isTouchControl = false;
    }
}
