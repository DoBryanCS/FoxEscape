using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Game : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Main_Game", LoadSceneMode.Single);
    }
}
