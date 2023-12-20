using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{

    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        int hasPlayed = PlayerPrefs.GetInt("HasPlayed");

        if (hasPlayed == 0)
        {
            tutorial.SetActive(true);

            PlayerPrefs.SetInt("HasPlayed", 1);
        }
        else
        {
            tutorial.SetActive(false) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }
}
