using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript_Merge : MonoBehaviour
{
    float xVal;

    float yVal;

    float zVal;

    bool flipped;

    bool reset;

    int mode;

    public GameObject MergeCube;

    public Light NormalLight;

    public Light FlippedLight;

    int upsideDown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Update", 0f, 1f);
        zVal = 0f;
        mode = 1;
        FlippedLight.enabled = false;
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0)
        {
            upsideDown = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        zVal = MergeCube.transform.localEulerAngles.z;

        //Debug.Log("X: "+MergeCube.transform.localEulerAngles.x+"Y: "+MergeCube.transform.localEulerAngles.y+"Z: "+MergeCube.transform.localEulerAngles.z);
        //Debug.Log("X: "+MergeCube.transform.localEulerAngles.x);
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0)
        {
            //updateText();
            upsideDown = 1;
        }

        if (
            (Vector3.Dot(MergeCube.transform.up, Vector3.down) < 0) &
            upsideDown == 1
        )
        {
            //updateText();
            upsideDown = 0;
            Debug.Log("Flipped");
            mode = mode * -1;
        }
        if (mode == 1)
        {
            NormalLight.enabled = true;
            FlippedLight.enabled = false;
        }
        else if (mode == -1)
        {
            NormalLight.enabled = false;
            FlippedLight.enabled = true;
        }
    }
}
