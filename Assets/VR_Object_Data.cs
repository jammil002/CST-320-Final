using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class VR_Object_Data : MonoBehaviour
{
    public int targetGarage;
    VR_GarageCycle[] scripts;
    public GameObject[] objects;
    public int totalObjects;
    int garageNum;
    public string o_name;
    public double o_mass;
    public double o_volume;
    // Start is called before the first frame update
    void Start()
    {
        totalObjects = 3;
        objects = new GameObject[totalObjects];
        objects[0] = GameObject.Find("Name");
        objects[1] = GameObject.Find("Mass");
        objects[2] = GameObject.Find("Size");
        scripts = FindObjectsOfType<VR_GarageCycle>();
        for (int i = 0; i < scripts.Length; i++)
        {
            if (scripts[i].garageID == targetGarage)
            {
                garageNum = scripts[i].garageID;
                break;
            }
        }
        o_name = scripts[garageNum].c_name;
        o_mass = scripts[garageNum].mass;
        o_volume = scripts[garageNum].volume;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void OnSelect()
    {
        o_name = scripts[garageNum].c_name;
        o_mass = scripts[garageNum].mass;
        o_volume = scripts[garageNum].volume;
        objects[0].GetComponent<TextMeshProUGUI>().text = "Object Name:\n" + o_name;
        objects[1].GetComponent<TextMeshProUGUI>().text = "Object Mass:\n" + o_mass.ToString("#.00");
        objects[2].GetComponent<TextMeshProUGUI>().text = "Object Volume:\n" + o_volume.ToString("#.00");
    }

    public void OnMouseDown()
    {
        o_name = scripts[garageNum].c_name;
        o_mass = scripts[garageNum].mass;
        o_volume = scripts[garageNum].volume;
        objects[0].gameObject.GetComponent<TextMeshProUGUI>().text = "Object Name:\n" + o_name;
        objects[1].gameObject.GetComponent<TextMeshProUGUI>().text = "Object Mass:\n" + o_mass.ToString("#.00");
        objects[2].gameObject.GetComponent<TextMeshProUGUI>().text = "Object Volume:\n" + o_volume.ToString("#.00");
    }
}
