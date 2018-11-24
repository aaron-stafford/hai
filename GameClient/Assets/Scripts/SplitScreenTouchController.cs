using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SplitScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      Debug.Log("Left side");
    }
    else {
      Debug.Log("Right side");
    }
  }
}
