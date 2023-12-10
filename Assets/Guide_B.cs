using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guide_B : MonoBehaviour
{
    public GameObject text, guide, button;
    
    // Start is called before the first frame update
    void Start()
    {
        guide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        if (!guide.activeInHierarchy)
        {
            guide.SetActive(true);
        }
        else if (guide.activeInHierarchy)
        {
            guide.SetActive(false);
        }
        else
        {
            Debug.Log("Something happened, button triggers failed.");
        }
    }

    public void OnSelect()
    {

        if(!guide.activeInHierarchy && !text.activeInHierarchy)
        {
            guide.SetActive(true);
        }
        else if (guide.activeInHierarchy && !text.activeInHierarchy)
        {
            guide.SetActive(false);
        }
        else
        {
            Debug.Log("Something happened, button triggers failed.");
        }
    }
}
