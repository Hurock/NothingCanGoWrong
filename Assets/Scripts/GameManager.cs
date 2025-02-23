using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    static GameUI gameUI;
    public static bool gamePaused;


    void Start()
    {
    }


    public void Awake()
    {
    }
}
