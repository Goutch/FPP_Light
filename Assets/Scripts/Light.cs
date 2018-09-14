using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Xml.Xsl;
using LOS;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class Light : MonoBehaviour
{
    private LOSRadialLight source;
    private float angle;
    private float faceAngle;
    private float radius;

    private void Start()
    {
        source = GetComponent<LOSRadialLight>();
        angle = source.coneAngle;
        radius = source.radius;
        faceAngle = source.faceAngle;
    }

    private void Update()
    {
        if (Vector2.Distance(this.transform.position, LightTrigger.Instance.transform.position) < radius)
        {
            float AngleRad =
                Mathf.Atan2(LightTrigger.Instance.transform.position.y - transform.position.y,
                    LightTrigger.Instance.transform.position.x - transform.position.x);
            //Angle en Degrés
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            if (AngleDeg < 0)
            {
                AngleDeg += 360;
            }

            if (source.CheckDegreeWithinCone(AngleDeg))
            {
                RaycastHit2D hit =
                    Physics2D.Raycast(transform.position, new Vector2(
                        LightTrigger.Instance.transform.position.x - transform.position.x,
                        LightTrigger.Instance.transform.position.y - transform.position.y), radius);
                Debug.DrawRay(transform.position, new Vector2(
                    LightTrigger.Instance.transform.position.x - transform.position.x,
                    LightTrigger.Instance.transform.position.y - transform.position.y),Color.green);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Avatar")
                    {
                        print("Inlight");
                        LightTrigger.Instance.NotifyInLight();
                    }


                    print("Hit" + hit.collider.name);
                }
            }
        }
    }
}