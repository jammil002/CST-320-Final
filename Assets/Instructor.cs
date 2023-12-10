using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if(window != null)
        {
            window.SetActive(true);
        }


    }
    public void OnSelect()
    {
        if (window != null && window.activeInHierarchy)
        {
            window.SetActive(true);
        } else if (window != null && window.activeInHierarchy) { 
            window.SetActive(false);
        }


    }
}
