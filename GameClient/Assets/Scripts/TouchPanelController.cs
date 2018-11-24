using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchPanelController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    SceneManager.LoadScene("Game");
  }
}
