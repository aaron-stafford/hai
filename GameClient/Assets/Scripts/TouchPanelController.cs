using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchPanelController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

  void Start() {
    Debug.Log("Started");
  }

  public void OnPointerDown(PointerEventData eventData) {
    Debug.Log("Touched Down");
  }

  public void OnPointerUp(PointerEventData eventData) {
    Debug.Log("Touched Up");
    SceneManager.LoadScene("Game");
  }
}
