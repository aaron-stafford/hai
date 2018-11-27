using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreditsTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  {
  public void OnPointerDown(PointerEventData eventData) {
    SceneManager.LoadScene("Start");
  }

  public void OnPointerUp(PointerEventData eventData) {
  }
}
