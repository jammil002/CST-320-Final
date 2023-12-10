using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageSelect : MonoBehaviour
{
    public int targetGarage;
    GarageCycle[] scripts;
    int garageNum;
    // Start is called before the first frame update
    void Start()
    {
        scripts = FindObjectsOfType<GarageCycle>();
        for (int i  = 0; i < scripts.Length; i++) 
        {
            if (scripts[i].garageID == targetGarage)
            {
                garageNum = scripts[i].garageID;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Vector3 spawnPosition = new Vector3(-2.46f, 5f, 10.16f);
        GameObject selectedObject = Instantiate(scripts[garageNum].currentObject, spawnPosition, Quaternion.identity);
        selectedObject.gameObject.tag = "Spawned";
        activatePhysics(selectedObject);
    }

    void activatePhysics(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
