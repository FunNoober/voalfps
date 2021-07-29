using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace funNoober.voal2.packages.bob
{
    public class BobSin : MonoBehaviour
    {
        public static float Bob(float time, float magnitude, float multiplyMagnitude)
        {
            float bob = magnitude * Mathf.Sin(Time.time * time);
            bob *= multiplyMagnitude;
            return bob;
        }

        public static float Bob(float time, float magnitude)
        {
            float bob = magnitude * Mathf.Sin(Time.time * time);
            return bob;
        }

        public static float BobRandom(float magnitude ,float min, float max)
        {
            float bob = magnitude * Mathf.Sin(Time.time * Random.Range(min, max));
            return bob;
        }
    }
}
