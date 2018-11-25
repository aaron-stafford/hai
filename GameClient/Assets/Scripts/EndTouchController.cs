using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  {
  private bool m_TouchingDown = false;
  void Start() {
    m_TouchingDown = false;
  }
  public void OnPointerDown(PointerEventData eventData) {
    m_TouchingDown = true;
    StartCoroutine(EasterEgg());
  }

  public void OnPointerUp(PointerEventData eventData) {
    SceneManager.LoadScene("Gamev2");
    m_TouchingDown = false;
  }

  IEnumerator EasterEgg () {
    yield return new WaitForSeconds (3);
    if(m_TouchingDown) {
      SceneManager.LoadScene("Credits");
    }
  }
}
