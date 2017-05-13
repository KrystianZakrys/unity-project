﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    public float speed = 5;
    public float turnDst = 5;

    Path path;

    void Start()
    {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] waypoints, bool pathSuccessfull)
    {
        if(pathSuccessfull)
        {
            path = new Path(waypoints, transform.position, turnDst);
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        while(true)
        {
          yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if (path!= null)
        {
            path.DrawWithGizmos();
        }
    }
}