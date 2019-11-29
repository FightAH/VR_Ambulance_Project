using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalktoMarshal : MonoBehaviour {

    public static int marshal = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        marshal = 1;
        Debug.Log("talking");
    }
}
