using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
    // Reset the match manager.
    // TODO: There should be a better place for this.
    MatchManager.Instance.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
