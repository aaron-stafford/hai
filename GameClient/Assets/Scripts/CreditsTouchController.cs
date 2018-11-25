using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreditsTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  {

  public void OnPointerDown(PointerEventData eventData) {
    SceneManager.LoadScene("Gamev2");
  }

  public void OnPointerUp(PointerEventData eventData) {
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
