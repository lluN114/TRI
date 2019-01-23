using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric2_move : MonoBehaviour {

    public GameObject obj;

    // Use this for initialization
    void Start ()
    {	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = obj.transform.position;

	}


}
