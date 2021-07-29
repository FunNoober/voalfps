using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.funNoober.packages.cameraShake
{
    public static class CameraShake
    {
        public static void Shake(float shakeForce, Camera mainCam)
        {
            mainCam.transform.localPosition = Random.insideUnitSphere * shakeForce;
        }

        public static void Reset(Camera mainCam)
        {
            mainCam.transform.localPosition = new Vector3(0, 1, 0);
        }
    }
}

