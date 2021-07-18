using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomVector
{
    public static class RandomVector
    {
        public static Vector3 random(float randomAmout)
        {
            return new Vector3(Random.Range(-randomAmout, randomAmout), Random.Range(-randomAmout, randomAmout), Random.Range(-randomAmout, randomAmout));
        }
    }
}
