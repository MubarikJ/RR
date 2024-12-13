using UnityEngine;

public class TrackerController : MonoBehaviour
{
    public Transform trackerTarget; // The Vive tracker's target
    public Transform ikTarget;     // The IK target in your rig
                                   //public Vector3 positionOffset;  // Optional offset for position
                                   // public Quaternion rotationOffset; // Optional offset for rotation

    [SerializeField] private float smoothFactor = 0.1f;
    private Vector3 smoothPosition;
    private Quaternion smoothRotation;

    void Update()
    {
        if (trackerTarget != null && ikTarget != null)
        {
            // Apply the position and rotation with offsets
            //ikTarget.position = trackerTarget.position + positionOffset;
            //ikTarget.rotation = trackerTarget.rotation * rotationOffset;

            // Smooth movement
            smoothPosition = Vector3.Lerp(ikTarget.position, trackerTarget.position, smoothFactor);
            smoothRotation = Quaternion.Slerp(ikTarget.rotation, trackerTarget.rotation, smoothFactor);

            ikTarget.position = smoothPosition;
            ikTarget.rotation = smoothRotation;
        }
    }

}
