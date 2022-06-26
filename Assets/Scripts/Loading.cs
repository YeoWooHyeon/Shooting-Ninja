using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start()
    {
        Invoke("Load", 2.25f);
    }

    void Load()
    {
        SceneManager.LoadScene("GameScene");
    }
}
