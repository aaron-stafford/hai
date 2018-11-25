using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossFightTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization (Stuff you only want to do once)
	void Start () {
    ScoreManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
  }

  // Called when the mouse or finger touch down
  public void OnPointerDown(PointerEventData eventData) {
  }

  // Called when the mouse or finger touch up
  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      ScoreManager.Instance.AddToScore(10);
    }
    else {
      ScoreManager.Instance.AddToScore(-10);
    }

    if(ScoreManager.Instance.IsBossDead()) {
      SceneManager.LoadScene("Win");
    }
  }
}
