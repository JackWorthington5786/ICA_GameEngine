using GD;
using System;
using UnityEngine;

namespace GD
{
    public class Cinemachine3rdPersonController : MonoBehaviour
    {
        [Header("Cinemachine")]
        [Tooltip("The look target set that any camera will follow")]
        public GameObject lookTarget;

        [SerializeField]
        private float minPitchAngle = -30;

        [SerializeField]
        private float maxPitchAngle = 70;

        [SerializeField]
        [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
        private float cameraAngleOverride;

        private float cameraTargetYaw;
        private Vector2 look;
        private float cameraTargetPitch;
        private GameObject mainCamera;
        private const float threshold = 0.01f;

        private void Awake()
        {
            if (mainCamera == null)
            {
                mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
                if (mainCamera == null)
                    throw new ArgumentNullException("Have you set the CinemachineCamera to the MainCamera tag?");
            }
        }

        private void Start()
        {
            cameraTargetYaw = lookTarget.transform.rotation.eulerAngles.y;
        }

        private void LateUpdate()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            // if there is an input and camera position is not fixed
            if (look.sqrMagnitude >= threshold)
            {
                cameraTargetYaw += look.x;
                cameraTargetPitch += look.y;
            }

            // clamp our rotations so our values are limited 360 degrees
            cameraTargetYaw = GDMathf.ClampAngle(cameraTargetYaw, float.MinValue, float.MaxValue);
            cameraTargetPitch = GDMathf.ClampAngle(cameraTargetPitch, minPitchAngle, maxPitchAngle);

            // camera will follow this target
            lookTarget.transform.rotation = Quaternion.Euler(cameraTargetPitch + cameraAngleOverride, cameraTargetYaw, 0.0f);
        }
    }
}