using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Doozy.Engine.UI;

public class GameMenuManager : MonoBehaviour
{

    public InputActionProperty showButton;

    public UIView menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPerformedThisFrame())
        {
            menu.Show();
        }   
    }
}
