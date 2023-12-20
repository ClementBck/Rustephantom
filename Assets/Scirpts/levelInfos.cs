using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelInfos : MonoBehaviour
{
    public RawImage chamber1Clear;
    public RawImage chamber2Clear;
    public RawImage DungeonClear;
    public RawImage LivingRoomClear;

    public List<GameObject> songInfoList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < songInfoList.Count; i++)
        {
            songInfoList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DatasScenes.chamber1Won == true)
        {
            chamber1Clear.enabled = true;
        }
        else
        {
            chamber1Clear.enabled = false;
        }

        if (DatasScenes.chamber2Won == true)
        {
            chamber2Clear.enabled = true;
        }
        else
        {
            chamber2Clear.enabled = false;
        }

        if (DatasScenes.dungeonWon == true)
        {
            DungeonClear.enabled = true;
        }
        else
        {
            DungeonClear.enabled = false;
        }

        if (DatasScenes.livingRoomWon == true)
        {
            LivingRoomClear.enabled = true;
        }
        else
        {
            LivingRoomClear.enabled = false;
        }
    }

    public void openSong1()
    {
        if (DatasScenes.song1Obtained == true)
        {
            songInfoList[0].SetActive(true);
        }
    }

    public void openSong2()
    {
        if (DatasScenes.song2Obtained == true)
        {
            songInfoList[1].SetActive(true);
        }
    }

    public void openSong3()
    {
        if (DatasScenes.song3Obtained == true)
        {
            songInfoList[2].SetActive(true);
        }
    }

    public void openSong4()
    {
        if (DatasScenes.song4Obtained == true)
        {
            songInfoList[3].SetActive(true);
        }
    }

    public void openSong5()
    {
        if (DatasScenes.song5Obtained == true)
        {
            songInfoList[4].SetActive(true);
        }
    }

    public void openSong6()
    {
        if (DatasScenes.song6Obtained == true)
        {
            songInfoList[5].SetActive(true);
        }
    }

    public void openSong7()
    {
        if (DatasScenes.song7Obtained == true)
        {
            songInfoList[6].SetActive(true);
        }
    }

    public void openSong8()
    {
        if (DatasScenes.song8Obtained == true)
        {
            songInfoList[7].SetActive(true);
        }
    }
}
