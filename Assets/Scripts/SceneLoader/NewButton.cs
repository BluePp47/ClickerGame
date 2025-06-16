using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButton : MonoBehaviour
{
    public void SceneLoader()
    {
        SceneManager.LoadScene("BreakKeyboard");
    }
}
