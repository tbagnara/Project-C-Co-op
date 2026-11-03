using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private string buttonColor;
    [SerializeField] private UnityEvent buttonPressed;
    [SerializeField] private UnityEvent buttonUnpressed;
    public bool isPressed;
    private int objectsOnButton;
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        string spriteName = sp.sprite.name;
        if (spriteName.Equals("buttons_0") )    // Determines what color cube it is
        {
            buttonColor = "Red";
        }
        else if (spriteName.Equals("buttons_1") )
        {
            buttonColor = "Blue";
        }
        else
        {
            buttonColor = "Purple";
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        switch ( buttonColor ) // Function changes based on color of cube
        {
            case "Red":
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("SpritemapCharacters_0") || 
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("cubes_0") ) // Detects if it is being pressed by the correct player or cube
                {
                    objectsOnButton ++;
                    if (objectsOnButton == 1)
                    {
                        isPressed = true;
                        buttonPressed?.Invoke(); 
                    }
                }
                break;
            case "Blue": 
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("SpritemapCharacters_1") || 
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("cubes_1") ) // Detects if it is being pressed by the correct player or cube
                {
                    objectsOnButton ++;
                    if (objectsOnButton == 1)
                    {
                        isPressed = true;
                        buttonPressed?.Invoke(); 
                    }
                }
                break;
            case "Purple":
                objectsOnButton ++;
                if (objectsOnButton == 1)
                {
                    isPressed = true;
                    buttonPressed?.Invoke(); 
                }
                break;
        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
            
        switch ( buttonColor ) // Function changes based on color of cube
        {
            case "Red":
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("SpritemapCharacters_0") || 
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("cubes_0")) // Detects if it is being pressed by the correct player or cube
                {
                    objectsOnButton --;
                    if (objectsOnButton == 0)
                    {
                        isPressed = false;
                        buttonUnpressed?.Invoke(); 
                    }
                }
                break;
            case "Blue": 
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("SpritemapCharacters_1") || 
                    collision.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("cubes_1")) // Detects if it is being pressed by the correct player or cube
                {
                    objectsOnButton --;
                    if (objectsOnButton == 0)
                    {
                        isPressed = false;
                        buttonUnpressed?.Invoke(); 
                    }
                }
                break;
            case "Purple":
                objectsOnButton --;
                if (objectsOnButton == 0)
                {
                    isPressed = false;
                    buttonUnpressed?.Invoke(); 
                }
                break;
        }
    }

}
