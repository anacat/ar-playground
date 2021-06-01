using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void SimpleARBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MultipleObjectBtn()
    {
        SceneManager.LoadScene("MultipleObjects");
    }

    public void ImageTrackingBtn()
    {
        SceneManager.LoadScene("ImageTracking");
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
}
