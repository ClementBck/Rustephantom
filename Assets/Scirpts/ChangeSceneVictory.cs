using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneVictory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chamber1ToMap()
    {
        SceneManager.LoadScene("Map");
        SceneManager.UnloadSceneAsync("Chamber1");
        DatasScenes.song2Obtained = true;
        DatasScenes.chamber1Won = true;
    }

    public void Chamber2ToMap()
    {
        SceneManager.LoadScene("Map");
        SceneManager.UnloadSceneAsync("Chamber2");
        DatasScenes.song4Obtained = true;
        DatasScenes.chamber2Won = true;
    }

    public void LivingRoomToMap()
    {
        SceneManager.LoadScene("Map");
        SceneManager.UnloadSceneAsync("Living Room");
        DatasScenes.song6Obtained = true;
        DatasScenes.livingRoomWon = true;
    }

    public void DungeonToMap()
    {
        SceneManager.LoadScene("Map");
        SceneManager.UnloadSceneAsync("Dungeon");
        DatasScenes.song8Obtained = true;
        DatasScenes.dungeonWon = true;
    }
}
