using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongMenu : MonoBehaviour
{
    public Image menu;
    public List<Button> buttonList;

    // Start is called before the first frame update
    void Start()
    {
        menu.enabled = false;

        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        if (menu.enabled == false)
        {
            menu.enabled = true;
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].gameObject.SetActive(true);
            }
        }
        else
        {
            menu.enabled=false;
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].gameObject.SetActive(false);
            }
        }
    }

}
