using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Reset : MonoBehaviour
{
    GameObject[] clones;

    // Start is called before the first frame update
    public void OnMouseDown()
    {
        if (clones != null)
        {
            clones = GameObject.FindGameObjectsWithTag("Spawned");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        clones = GameObject.FindGameObjectsWithTag("Spawned");
    }

    public void OnSelect()
    {
        if (clones != null)
        {
            clones = GameObject.FindGameObjectsWithTag("Spawned");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
