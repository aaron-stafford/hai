using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    AudioSource audioSource = GetComponent<AudioSource> ();
    Assert.IsNotNull(audioSource);
    AudioClip clip1 = (AudioClip) Resources.Load("Audio/OnStartButtonPress");
    Assert.IsNotNull(clip1);
    audioSource.PlayOneShot(clip1, 0.7F);
    StartCoroutine(Transition());
  }

  IEnumerator Transition () {
    yield return new WaitForSeconds (2);
    SceneManager.LoadScene("GameV2");
  }
}
