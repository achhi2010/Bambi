using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Playercontrols : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast the spaceship will go")]
    [SerializeField] float Steerspeed;
    [Header("Limiting movement settings")]
    [Tooltip("To limit the movement of our ship on x axis")]
    [SerializeField] float Xrange;
    [Tooltip("To limit the movement of our ship on y axis")]
    [SerializeField] float Yrange;
    [SerializeField] ParticleSystem[] lasers;
    [Header("Pitch, Yaw and Roll settings")]
    [Tooltip("Controls the amount of pitch which is on x axis")]
    [SerializeField] float PositionPitch;
    [SerializeField] float ControlPitch;
    [Tooltip("Controls the amount of yaw which is on y axis")]
    [SerializeField] float PositionYaw;
    [Tooltip("Controls the amount of roll which is on z axis")]
    [SerializeField] float PositionRoll;
    float horizontalSteer, verticalSteer;

    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float PitchduetoPosition = transform.localPosition.y * PositionPitch;
        float PitchduetoRotation = verticalSteer * ControlPitch;
        float pitch = PitchduetoPosition + PitchduetoRotation;
        float yaw = transform.localPosition.x * PositionYaw;
        float roll = transform.localPosition.x * PositionRoll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }



    void ProcessMovement()
    {
        horizontalSteer = Input.GetAxis("Horizontal");
        verticalSteer = Input.GetAxis("Vertical");
        float Xoffset = horizontalSteer * Time.deltaTime * Steerspeed;
        float Yoffset = verticalSteer * Time.deltaTime * Steerspeed;
        float OldXpos = transform.localPosition.x + Xoffset;
        float OldYpos = transform.localPosition.y + Yoffset;
        float ClampedXpos = Mathf.Clamp(OldXpos, -Xrange, Xrange);
        float ClampedYpos = Mathf.Clamp(OldYpos, -Yrange, Yrange);
        transform.localPosition = new Vector3
        (ClampedXpos, ClampedYpos);
    }
    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActivate(true); 
        }
        else
        {
            SetLasersActivate(false);
        }
}
    void SetLasersActivate(bool IsActive)
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = IsActive;
        }
    }
}
