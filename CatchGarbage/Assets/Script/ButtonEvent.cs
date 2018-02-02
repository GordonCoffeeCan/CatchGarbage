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
                PlayerController.Instance.moveLeft = buttonDown;
                break;
            case ButtonName.RightButton:
                PlayerController.Instance.moveRight = buttonDown;
                break;
            case ButtonName.selectRecycle:
                if (buttonDown) {
                    PlayerController.Instance.characterID = 0;
                }
                break;
            case ButtonName.selectTrash:
                if (buttonDown) {
                    PlayerController.Instance.characterID = 1;
                }
                break;
            case ButtonName.selectFirefighter:
                if (buttonDown) {
                    PlayerController.Instance.characterID = 2;
                }
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        buttonDown = false;
    }
}
