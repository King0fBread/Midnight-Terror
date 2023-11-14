using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionsManager : MonoBehaviour
{
    public void MoveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MoveToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
