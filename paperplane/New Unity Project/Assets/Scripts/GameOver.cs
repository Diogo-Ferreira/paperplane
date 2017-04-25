using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject player;
    public path path;
    private Text[] GOText;
    public Button ReTryButton;

	// Use this for initialization
	void Start () {
        GOText = FindObjectsOfType<Text>();
        ReTryButton = FindObjectOfType<Button>();
        foreach(Text g in GOText)
        {
            g.enabled = false;
        }
        ReTryButton.gameObject.SetActive(false);
        path = player.GetComponent<path>();

        ReTryButton.onClick.AddListener(retryOnClick);
	}
	
	// Update is called once per frame
	void Update () {

        if (!path.isAlive)
        {
            foreach(Text g in GOText)
            {
                g.enabled = true;
            }

            ReTryButton.gameObject.SetActive(true);
            //Time.timeScale = 0;
        }
	}

    void retryOnClick()
    {
        Debug.Log("Click");
        //Restart the game
        SceneManager.LoadScene("myscene", LoadSceneMode.Single);
    }
}
