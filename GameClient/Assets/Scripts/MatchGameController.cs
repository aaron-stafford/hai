using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
    // Initialize the GameDataManager.
    // TODO: I think there is a better way to manage this...
    GameDataManager.Instance.Init();

    // Reset the match manager.
    // TODO: There should be a better place for this.
    MatchManager.Instance.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
