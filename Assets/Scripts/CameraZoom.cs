using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : BaseButton {

    public GameObject cam;
    public GameObject background;

    public override void DoButtonAction()
    {
        cam.GetComponent<Camera>().orthographicSize += 1;
        background.transform.localScale += new Vector3(0.5f, 0.5f, 0.0f);

        clearClick();
    }
}
