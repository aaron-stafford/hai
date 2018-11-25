using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossFightTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization (Stuff you only want to do once)
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
  }

  // Called when the mouse or finger touch down
  public void OnPointerDown(PointerEventData eventData) {
  }

  // Called when the mouse or finger touch up
  public void OnPointerUp(PointerEventData eventData) {
  	// Could deal damage in some manner ?
  }
}
