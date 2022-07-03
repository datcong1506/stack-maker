using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDirec : MonoBehaviour,IDirec
{
    [SerializeField] private DirecType _direcType;
    public Vector3 GetDirec(Vector3 origin)
    {
        Debug.Log(origin);
        Vector3 rs = new Vector3();
        switch (_direcType)
        {
            case DirecType.ForwardRight:
                if (origin.x - transform.position.x == 0)
                {
                   rs=Vector3.left;
                }
                else
                {
                    rs = Vector3.back;
                }
                break;
            case DirecType.ForwardLeft:
                if (origin.x - transform.position.x == 0)
                {
                    rs=Vector3.right;
                }
                else
                {
                    rs = Vector3.back;
                }
                break;
            case DirecType.BackRight:
                if (origin.x - transform.position.x == 0)
                {
                    rs=Vector3.left;
                }
                else
                {
                    rs = Vector3.forward;
                }
                break;
            case DirecType.BackLeft:
                if (origin.x - transform.position.x == 0)
                {
                    rs=Vector3.right;
                }
                else
                {
                    rs = Vector3.forward;
                }
                break;
        }
        return rs;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name);

            var direc = GetDirec(other.transform.position+other.GetComponent<PlayerController>().direc);
            other.GetComponent<PlayerController>().direc = direc;
            other.GetComponent<PlayerController>().NewDirec = true;
        }
    }
}

public enum DirecType
{
    ForwardRight,
    ForwardLeft,
    BackRight,
    BackLeft,
}

