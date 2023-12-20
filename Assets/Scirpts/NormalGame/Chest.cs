using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public bool isPossessed = false;

    public Button possessButton;

    public Player ghost;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPossessed == true)
        {
            ghost.possessedObjects[2] = true;

            gameObject.tag = "isPossessed";

            anim.SetTrigger("isPossessed");
        }
        else
        {
            ghost.possessedObjects[1] = false;

            gameObject.tag = "objectToPossess";
        }

        possessButton.onClick.AddListener(PossessFurniture);
    }

    private void PossessFurniture()
    {
        if (ghost.objName == gameObject.transform.name)
        {
            isPossessed = true;

            ghost.isPossessing = true;

            print("C'est good !");

            Invoke("LeaveFurniture", 3f);
        }
    }

    private void LeaveFurniture()
    {
        ghost.isPossessing = false;

        isPossessed = false;
    }
}
