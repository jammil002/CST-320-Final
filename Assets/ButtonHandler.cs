using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClickHandler : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public GameObject window;
    public RawImage garageImage;
    public RawImage layoutImage;
    public RawImage droppingImage;
    public RawImage controlsImage;

    void Start()
    {
        setImagesFalse();
    }

    public void OnButtonClick(string buttonName)
    {
        Debug.Log("Button Clicked: " + buttonName);
        if(buttonName == "Question1")
        {
            setImagesFalse();
            myText.text = "Buoyancy is the force that makes things float in water. It happens because water pushes up on objects, and if the object is lighter than the water it pushes away, it floats!";
        }
        else if(buttonName == "Question2")
        {
            setImagesFalse();
            myText.text = "The density of the object compared to the density of water determines whether it will float (less dense) or sink (more dense).";
        }
        else if(buttonName == "Question3")
        {
            setImagesFalse();
            myText.text = "The shape affects how much water the object displaces. Objects that displace more water are generally more buoyant.";  
        }
        else if (buttonName == "Question4")
        {
            setImagesFalse();
            myText.text = " For an object to float, its weight must be equal to or less than the buoyant force acting on it. If the weight is greater, the object will sink.";
        }
        else if (buttonName == "Question5")
        {
            setImagesFalse();
            controlsImage.gameObject.SetActive(true);
            myText.text = "";
        }
        else if (buttonName == "Question6")
        {
            setImagesFalse();
            droppingImage.gameObject.SetActive(true);
            myText.text = "";
        }
        else if (buttonName == "Question7")
        {
            setImagesFalse();
            layoutImage.gameObject.SetActive(true);
            myText.text = "";
        }

        else if (buttonName == "Question8")
        {
            setImagesFalse();
            garageImage.gameObject.SetActive(true);
            myText.text = "";

        }
        if(buttonName == "Close")
        {
            if(window != null)
            {
                myText.text = "Whats on your mind?";
                Debug.Log("afsf");
                window.SetActive(false);
            }
        }

    }

    void setImagesFalse()
    {
        garageImage.gameObject.SetActive(false);
        layoutImage.gameObject.SetActive(false);
        droppingImage.gameObject.SetActive(false);
        controlsImage.gameObject.SetActive(false);

    }

}