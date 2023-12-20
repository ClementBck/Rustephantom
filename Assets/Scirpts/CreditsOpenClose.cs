using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsOpenClose : MonoBehaviour
{
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }
}
