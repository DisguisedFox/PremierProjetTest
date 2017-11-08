using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private int lifes = 3;

    [SerializeField] private Text textLifes;

    private const string TEXT_LIFES = "Lifes : ";

    // Use this for initialization
    void Start () {
        textLifes.text = TEXT_LIFES + lifes;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerDie()
    {
        lifes--;
        if(lifes > 0)
        {
            textLifes.text = TEXT_LIFES + lifes;
        }
        else
        {
            SceneManager.LoadScene("DieMenu");
        }
    }

}
