using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Button next;
    public string cena;
    // Start is called before the first frame update
    void Start()
    {
        next.onClick.AddListener(TaskOnClick);   
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(cena);
    }

}
