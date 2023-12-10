using Fusion.Fluid;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VR_GarageCycle : MonoBehaviour
{
    public int garageID;
    public GameObject[] objects;
    public GameObject currentObject;
    public Vector3 displayPosition;
    public Vector3 holdPosition;
    public Vector3 size;
    public int currentDisplay;
    public int totalObjects;
    public string c_name;
    public double mass;
    public double volume;
    public double radius;
    public double height;
    Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
       //create list of objects 
        parentTransform = transform.parent;
        totalObjects = objects.Length;
        //turn off physics for all objects
        for (int i = 0; i < totalObjects; i++)
        {
            deactivatePhysics(objects[i]);
        }
        //assign values
        holdPosition = new Vector3(parentTransform.position.x, parentTransform.position.y - 10, parentTransform.position.z);
        displayPosition = new Vector3(parentTransform.position.x, parentTransform.position.y - 2.5f, parentTransform.position.z);
        Debug.Log("displayPosition" + displayPosition);
        objects[0].transform.position = displayPosition;
        currentDisplay = 0;
        currentObject = objects[currentDisplay];


        c_name = objects[0].name;
        mass = objects[0].GetComponent<Rigidbody>().mass;
        radius = objects[0].GetComponent<SphereCollider>().radius;
        volume = (4 / 3) * Mathf.PI * (radius * radius * radius);
    }

    public void OnSelect()
    {
        if (currentDisplay + 1 >= totalObjects)
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
        c_name = objects[currentDisplay].name;
        mass = objects[currentDisplay].GetComponent<Rigidbody>().mass;
        if (objects[currentDisplay].GetComponent<BoxCollider>() != null)
        {
            size = objects[currentDisplay].GetComponent<BoxCollider>().size;
            volume = size.x * size.y * size.z;
            objects[currentDisplay].GetComponent<BasicFluidInteractor>().customVolume = (float)volume;
        }
        else if (objects[currentDisplay].GetComponent<SphereCollider>() != null)
        {
            radius = objects[currentDisplay].GetComponent<SphereCollider>().radius;
            volume = (4 / 3) * Mathf.PI * ((0.5+radius) * (0.5+radius) * (0.5+radius));
            objects[currentDisplay].GetComponent<BasicFluidInteractor>().customVolume = (float)volume;
        }
        else if (objects[currentDisplay].GetComponent<CapsuleCollider>() != null)
        {
            radius = objects[currentDisplay].GetComponent<SphereCollider>().radius;
            height = objects[currentDisplay].GetComponent<CapsuleCollider>().height;
            volume = (4 / 3) * Mathf.PI * (radius * radius * height / 2);
            objects[currentDisplay].GetComponent<BasicFluidInteractor>().customVolume = (float)volume;
        } 
        else
        {
            volume = 2^3;
            objects[currentDisplay].GetComponent<BasicFluidInteractor>().customVolume = (float)volume;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (currentDisplay + 1 >= totalObjects)
        {
            holdPosition = new Vector3(parentTransform.position.x - 10, 0.5f * GetHeight(objects[0]), parentTransform.position.z);
            objects[currentDisplay].transform.position = holdPosition;
            currentDisplay = 0;
            currentObject = objects[currentDisplay];
            displayPosition = new Vector3(parentTransform.position.x, 0.5f * GetHeight(objects[0]), parentTransform.position.z);
            objects[currentDisplay].transform.position = displayPosition;
        }
        else
        {
            holdPosition = new Vector3(parentTransform.position.x - 10, 0.5f * GetHeight(objects[0]), parentTransform.position.z);
            objects[currentDisplay].transform.position = holdPosition;
            currentDisplay++;
            currentObject = objects[currentDisplay];
            objects[currentDisplay].transform.position = displayPosition;
        }
        c_name = objects[currentDisplay].name;
        mass = objects[currentDisplay].GetComponent<Rigidbody>().mass;
        if (objects[currentDisplay].GetComponent<BoxCollider>() != null)
        {
            size = objects[currentDisplay].GetComponent<BoxCollider>().size;
            volume = size.x * size.y * size.z;
        }
        else if (objects[currentDisplay].GetComponent<SphereCollider>() != null)
        {
            radius = objects[currentDisplay].GetComponent<SphereCollider>().radius;
            volume = (4 / 3) * Mathf.PI * ((0.5 + radius) * (0.5 + radius) * (0.5 + radius));
        }
        else if (objects[currentDisplay].GetComponent<CapsuleCollider>() != null)
        {
            radius = objects[currentDisplay].GetComponent<SphereCollider>().radius;
            height = objects[currentDisplay].GetComponent<CapsuleCollider>().height;
            volume = (4 / 3) * Mathf.PI * (radius * radius * height / 2);
        }
        else
        {
            volume = 2 ^ 3;
        }
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
        obj.GetComponent<XRGrabInteractable>().enabled = false;
    }
}
