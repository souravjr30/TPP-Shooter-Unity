using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [Header("Player Punch Var")]
    public Camera Camera;
    public float giveDamageOf = 10f;
    public float punchingRange = 5f;

    [Header("Punch Effects")]
    public GameObject WoodedEffect;

    public void Punch()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hitInfo, punchingRange))
        {
            Debug.Log(hitInfo.transform.name);

            ObjectToHit objectToHit = hitInfo.transform.GetComponent<ObjectToHit>();

            if (objectToHit != null)
            {
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject WoodGo = Instantiate(WoodedEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(WoodGo, 1f);
            }
        }
    }
}    
