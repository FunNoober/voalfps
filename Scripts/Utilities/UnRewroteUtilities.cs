using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace funNoober.UnRewroteUtilities
{
    public static class UnRewroteUtilities
    {
        public static class RayCastUtilities
        {
            public static Vector3 GetHitPoint(Transform rayOrgin, LayerMask mask, float range)
            {
                if (Physics.Raycast(rayOrgin.position, rayOrgin.TransformDirection(Vector3.forward), out RaycastHit hit, range, mask))
                {
                    return hit.point;
                }
                else
                    return new Vector3(0, 0, 0);
            }

            public static Vector3 GetHitPoint(Transform rayOrgin, float range)
            {
                if (Physics.Raycast(rayOrgin.position, rayOrgin.TransformDirection(Vector3.forward), out RaycastHit hit, range))
                {
                    return hit.point;
                }
                else
                    return new Vector3(0, 0, 0);
            }

            public static GameObject GetHitObject(Transform rayOrgin, LayerMask mask, float range)
            {
                if (Physics.Raycast(rayOrgin.position, rayOrgin.TransformDirection(Vector3.forward), out RaycastHit hit, range, mask))
                {
                    return hit.collider.gameObject;
                }
                else
                    return null;
            }

            public static GameObject GetHitObject(Transform rayOrgin, float range)
            {
                if (Physics.Raycast(rayOrgin.position, rayOrgin.TransformDirection(Vector3.forward), out RaycastHit hit, range))
                {
                    return hit.collider.gameObject;
                }
                else
                    return null;
            }

            public static Vector3 MousePos3d(Camera orgin, LayerMask mask, float range)
            {
                Ray ray = orgin.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, range, mask))
                {
                    return hit.point;
                }
                else
                    return new Vector3(0, 0, 0);
            }

            public static Vector3 MousePos3d(Camera orgin, float range)
            {
                Ray ray = orgin.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, range))
                {
                    return hit.point;
                }
                else
                    return new Vector3(0, 0, 0);
            }
        }

        public static class AIUtilities
        {
            public static bool InLineOfSight(float detectionRaduis, float visionRange, LayerMask objectToDetectMask, LayerMask extraObjectsToDetectMask, Transform rayPoint, string tagToDetectFor, GameObject objectToLookFor)
            {
                bool inRadius = false;
                bool inSight = false;

                if (!inRadius)
                {
                    Collider[] collidersInRaduis = Physics.OverlapSphere(rayPoint.position, detectionRaduis, objectToDetectMask);
                    foreach (Collider collider in collidersInRaduis)
                    {
                        if (collider.gameObject.CompareTag(tagToDetectFor))
                        {
                            inRadius = true;
                        }
                    }
                }

                if (!inSight)
                {

                    rayPoint.LookAt(objectToLookFor.transform.position);
                    if (Physics.Raycast(rayPoint.position, rayPoint.forward, out RaycastHit hit, detectionRaduis, extraObjectsToDetectMask))
                    {
                        if (hit.collider.gameObject.CompareTag("Player"))
                        {
                            inSight = true;
                        }
                    }
                }

                if (inSight && inRadius)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
