using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarsController : MonoBehaviour
{
    public GameObject[] stars;
    public int levelNumber;
    private int _numberOfStars;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfStars = PlayerPrefs.GetInt(SceneName.GetSceneNameByBuildIndex(levelNumber));
        for (int i = 0; i < _numberOfStars; i++)
            stars[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
