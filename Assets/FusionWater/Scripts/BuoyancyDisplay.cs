using UnityEngine;
using UnityEngine.UI;

namespace Fusion.Fluid
{
    [RequireComponent(typeof(BasicFluidInteractor))]
    public class BuoyancyDisplay : MonoBehaviour
    {
        public Text buoyancyText;
        private BasicFluidInteractor fluidInteractor;

        private float minBuoyancyForce = float.MaxValue;
        private float maxBuoyancyForce = float.MinValue;

        private void Start()
        {
            buoyancyText.text = "Buoyancy Force: ";
            fluidInteractor = GetComponent<BasicFluidInteractor>();
        }

        private void Update()
        {
            if (fluidInteractor != null && buoyancyText != null)
            {
                float currentForce = fluidInteractor.BuoyancyForce.y;
                minBuoyancyForce = Mathf.Min(minBuoyancyForce, currentForce);
                maxBuoyancyForce = Mathf.Max(maxBuoyancyForce, currentForce);

                string text = $"Buoyancy Force: {currentForce}\n" +
                              $"Min Force: {minBuoyancyForce}\n" +
                              $"Max Force: {maxBuoyancyForce}";
                buoyancyText.text = text;

                Debug.Log(text);
            }
            else
            {
                Debug.Log("Fluid Interactor or Text is null");
            }
        }
    }
}
