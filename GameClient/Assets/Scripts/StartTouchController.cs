using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private bool m_TouchingDown = false;

  void Start() {
    m_TouchingDown = false;
  }

  public void OnPointerDown(PointerEventData eventData) {
    m_TouchingDown = true;
    StartCoroutine(EasterEgg());
  }

  public void OnPointerUp(PointerEventData eventData) {
    AudioSource audioSource = GetComponent<AudioSource> ();
    Assert.IsNotNull(audioSource);
    AudioClip clip1 = (AudioClip) Resources.Load("Audio/OnStartButtonPress");
    Assert.IsNotNull(clip1);
    audioSource.PlayOneShot(clip1, 0.7F);
    m_TouchingDown = false;
    StartCoroutine(Transition());
    GameObject gameObject = GameObject.Find("FadePanel");
    gameObject.GetComponent<Animator>().Play("FadeOut");
  }

  IEnumerator Transition () {
    yield return new WaitForSeconds (0.55f);
    SceneManager.LoadScene("MatchGame");
  }

  IEnumerator EasterEgg () {
    yield return new WaitForSeconds (3);
    if(m_TouchingDown) {
      SceneManager.LoadScene("Credits");
    }
  }
}
