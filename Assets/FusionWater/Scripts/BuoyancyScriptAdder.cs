using UnityEngine;

public class BuoyancyScriptAdder : MonoBehaviour
{
    public GameObject targetObject; 

    public void AddBuoyancyDisplay()
    {
        if (targetObject != null && targetObject.GetComponent<Fusion.Fluid.BuoyancyDisplay>() == null)
        {
            targetObject.AddComponent<Fusion.Fluid.BuoyancyDisplay>();
        }
    }
}
