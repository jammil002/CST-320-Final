using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCycle : MonoBehaviour
{
    public int garageID;
    public GameObject[] objects;
    public GameObject currentObject;
    public Vector3 displayPosition;
    public Vector3 holdPosition;
    public int currentDisplay;
    public int totalObjects;
    Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        //create list of objects 
        parentTransform = transform.parent;

        //turn off physics for all objects
        for (int i = 0; i < totalObjects; i++)
        {
            deactivatePhysics(objects[i]);
        }

        //assign values
        holdPosition = new Vector3(parentTransform.position.x, parentTransform.position.y - 20, parentTransform.position.z);
        displayPosition = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
        Debug.Log("displayPosition" + displayPosition);
        objects[0].transform.position = displayPosition;
        currentDisplay = 0;
        currentObject = objects[currentDisplay];
    }

    public void OnMouseDown()
    {
        if(currentDisplay + 1 >= totalObjects)
        {
            objects[currentDisplay].transform.position = holdPosition;
            currentDisplay = 0;
            currentObject = objects[currentDisplay];
            objects[currentDisplay].transform.position = displayPosition;
        }
        else
        {
            objects[currentDisplay].transform.position = holdPosition;
            currentDisplay++;
            currentObject = objects[currentDisplay];
            objects[currentDisplay].transform.position = displayPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float GetHeight(GameObject obj)
    {
        Collider objectCollider = obj.GetComponent<Collider>();

        float height = objectCollider.bounds.size.y;

        return height;
    }

    void deactivatePhysics(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
