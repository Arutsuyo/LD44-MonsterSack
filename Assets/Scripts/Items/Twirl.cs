using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twirl : MonoBehaviour
{

    public Transform mesh;
    private Vector3 origPos;
    private Quaternion origRot;
    public float updownSpeed = 0.01f;
    public float spinSpeed = 0.5f;


    private float updownPos = 0;
    private float spinPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        origPos = mesh.position;
        origRot = mesh.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        updownPos += Time.deltaTime * updownSpeed;
        spinPos += Time.deltaTime * spinSpeed;

        mesh.position = origPos + new Vector3(0, Mathf.Sin(updownPos * (2 * Mathf.PI)), 0);
        mesh.rotation = origRot * Quaternion.Euler(0, spinPos * 360, 0);
    }
}
