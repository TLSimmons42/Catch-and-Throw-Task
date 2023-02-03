using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GunHandPosAssignment : XRGrabInteractable
{


    public Transform rightHandPos;
    public Transform leftHandPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("leftHand"))
        {
            attachTransform = leftHandPos;
        }
        else if(args.interactorObject.transform.CompareTag("rightHand"))
        {
            attachTransform = leftHandPos;
        }
        base.OnSelectEntered(args);
    }

}
