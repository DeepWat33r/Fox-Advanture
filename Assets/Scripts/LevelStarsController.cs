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
        //SceneManager.LoadScene(levelNumber, LoadSceneMode.Additive);
        _numberOfStars = PlayerPrefs.GetInt("Level_1");
        for (int i = 0; i < _numberOfStars; i++)
        {
            stars[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_numberOfStars);
        //Debug.Log(SceneManager.GetSceneByBuildIndex(1).name);
        //Debug.Log(SceneManager.GetSceneByBuildIndex(levelNumber).name);
    }
}
