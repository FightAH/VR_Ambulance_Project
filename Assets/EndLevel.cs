namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EndLevel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (TalktoMarshal.marshal == 1 && OpenDoor2.open == false && Openable_Door.open == false)
            {


                Debug.Log("End Level");

            }
            else
            {
                Debug.Log("talk to the marshal");
            }
        }
    }
}
