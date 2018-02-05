using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : BaseButton {

    public GameObject cam;

    public override void DoButtonAction()
    {
        cam.GetComponent<Camera>().orthographicSize += 1;
    }
}
