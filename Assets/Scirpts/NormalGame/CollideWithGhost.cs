using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideWithGhost : MonoBehaviour
{
    public Transform parent;
    
    public Button freeButton;
    public Button possessButton;
    
    public bool isTriggered = false;
    public bool canBePossessed = false;
    public bool isPossessed = false;
    

    public Player myPlayer;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {

        possessButton.onClick.AddListener(Possession);

        freeButton.onClick.AddListener(FreeObject);

    }

    // Update is called once per frame
    void Update()
    {
      if (canBePossessed == true)
        {
            possessButton.gameObject.SetActive(true);
        }
      else
        {
            possessButton.gameObject.SetActive(false);
        }

      if (isPossessed == true)
        {
            transform.position = parent.position;

            possessButton.gameObject.SetActive(false);

            freeButton.gameObject.SetActive(true);


            myPlayer.isPossessing = true;

            transform.Rotate(1, 1, 1 * Time.deltaTime);
        }
       else
        { 
            freeButton.gameObject.SetActive(false);

            myPlayer.isPossessing = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isPossessed == false)
        {
            canBePossessed = true;
            print(canBePossessed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPossessed == false)
        {
            canBePossessed = false;
            print(canBePossessed);
        }
    }


    private void Possession()
    {
        isPossessed = true;

        freeButton.gameObject.SetActive(true);
    }

    private void FreeObject()
    {
        isPossessed = false;
    }

}
