using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private double temps;
    public Text score;
    public GameObject player;
    public path path;


	// Use this for initialization
	void Start () {
        temps = 0.0;
        score = GetComponent<Text>();
        path = player.GetComponent<path>();
        //isDisplay = false;
	}
	
	// Update is called once per frame
	void Update () {

        temps += Time.deltaTime;
        
        
	}
    private void OnGUI()
    {
        score.text = temps.ToString("F2");
         
    }
}
