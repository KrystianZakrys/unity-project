using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYP_JEDNOSTKI {
    RIDERS, SPIKE, ARCHER, MINOTAUR
}
public class Enemy : MonoBehaviour {

    [Header("Statystyki przeciwnika")]
    public float HP = 100;
    public float movementSpeed = 100;
    public float strenght = 20;
    public TYP_JEDNOSTKI typ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
