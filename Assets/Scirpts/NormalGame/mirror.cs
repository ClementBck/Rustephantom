using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Mirror : MonoBehaviour
{
    public bool isPossessed = false;

    public Button possessButton;

    public VideoPlayer mirrorImage;

    public Player ghost;


    // Start is called before the first frame update
    void Start()
    {
        mirrorImage.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPossessed == true)
        {
            mirrorImage.Play();

            ghost.possessedObjects[0] = true;

            gameObject.tag = "isPossessed";
        }
        else
        {
            //ghost.isPossessing = false;
            mirrorImage.Stop();

            ghost.possessedObjects[0] = false;


            gameObject.tag = "objectToPossess";
            
        }

        possessButton.onClick.AddListener(PossessMirror);
    }

    private void PossessMirror()
    {

        if (ghost.objName == gameObject.transform.name)
        {
            isPossessed = true;

            ghost.isPossessing = true;

            Invoke("LeaveMirror", 3f);
        }
    }

    private void LeaveMirror()
    {
        ghost.isPossessing = false;

        isPossessed = false;
    }
}
