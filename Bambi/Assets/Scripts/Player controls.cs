using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class Playercontrols : MonoBehaviour
{
    void Update()
    {
        float Xoffset = .5f;
        float horizontalSteer = Input.GetAxis("Horizontal");
        float verticalSteer = Input.GetAxis("Vertical");
        float NewXpos = transform.localPosition.x + Xoffset;
    
        transform.localPosition = new Vector3
        (NewXpos, transform.localPosition.y, transform.localPosition.z);
    }
}
