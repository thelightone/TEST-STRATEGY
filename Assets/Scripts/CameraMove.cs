using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horInput = Input.GetAxis("Horizontal");
        var verInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right* horInput/10);
        transform.Translate(Vector3.forward * verInput/10);
    }
}
