using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class Playercontrols : MonoBehaviour
{
    [SerializeField] float Steerspeed;
    [SerializeField] float Xrange;
    [SerializeField] float Yrange;
    void Update()
    {
        float horizontalSteer = Input.GetAxis("Horizontal");
        float verticalSteer = Input.GetAxis("Vertical");
        float Xoffset = horizontalSteer * Time.deltaTime * Steerspeed;
        float Yoffset = verticalSteer * Time.deltaTime * Steerspeed;
        float OldXpos = transform.localPosition.x + Xoffset;
        float OldYpos = transform.localPosition.y + Yoffset;
        float ClampedXpos = Mathf.Clamp(OldXpos, -Xrange, Xrange);
        float ClampedYpos = Mathf.Clamp(OldYpos, -Yrange, Yrange);    
        transform.localPosition = new Vector3
        (ClampedXpos, ClampedYpos);
    }
}
