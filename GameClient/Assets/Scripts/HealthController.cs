using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    //public int m_TotalHealth;
    //private float m_InitialWidth;
    Image healthBar;
    float maxHealth = 100f;
    float health=ScoreManager.Instance.m_Score;
	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        health = ScoreManager.Instance.m_Score;
        healthBar.fillAmount = health / maxHealth;
	}
}
