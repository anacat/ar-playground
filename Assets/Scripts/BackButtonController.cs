using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
