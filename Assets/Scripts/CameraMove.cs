using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update()
    {
        var horInput = Input.GetAxis("Horizontal");
        var verInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horInput / 10);
        transform.Translate(Vector3.forward * verInput / 10);
    }
}
