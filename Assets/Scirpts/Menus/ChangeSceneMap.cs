using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuToChamber1()
    {
        if (DatasScenes.chamber1Won == false)
        {
            SceneManager.LoadScene("Chamber1");
            SceneManager.UnloadSceneAsync("Map");
            DatasScenes.song1Obtained = true;
        }
    }

    public void MenuToChamber2()
    {
        if (DatasScenes.chamber2Won == false)
        {
            SceneManager.LoadScene("Chamber2");
            SceneManager.UnloadSceneAsync("Map");
            DatasScenes.song3Obtained = true;
        }
    }

    public void MenuToLivingRoom()
    {
        if (DatasScenes.livingRoomWon == false)
        {
            SceneManager.LoadScene("Living Room");
            SceneManager.UnloadSceneAsync("Map");
            DatasScenes.song5Obtained = true;
        }
    }

    public void MenuToDungeon()
    {
        if (DatasScenes.dungeonWon == false)
        {
            SceneManager.LoadScene("Dungeon");
            SceneManager.UnloadSceneAsync("Map");
            DatasScenes.song6Obtained = true;
        }
    }
}
