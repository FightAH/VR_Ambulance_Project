namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;
    using UnityEngine.SceneManagement;

    public class MovetoAmbulance : VRTK_InteractableObject
    {
        [Header("VRTK Door Options")]
        public bool flipped = false;
        public bool rotated = false;

        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        private float doorOpenAngle = -90f;
        private bool open = false;

        private Vector3 defaultRotation;
        private Vector3 openRotation;

        [Header("Salty Puppies Door Options")]
        public bool unlocked = true;
        public AudioClip doorLocked;
        public AudioClip doorOpening;
        private AudioSource audioPlayer;
        public GameObject stretcher1;
        public GameObject stretcher2;
        public static int canTalk = 0;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            if (PutonStretcher.playerOnstretcher == 1 && OpenDoor2.open == true && Openable_Door.open == true)
            {
                stretcher2.SetActive(true);
                stretcher1.SetActive(false);
                canTalk = 1;
            }
            else
            {
                Debug.Log("Player not on stretcher");
            }

        }

        protected void Start()
        {
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
        }

        protected override void Update()
        {
            base.Update();
            if (open)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * smooth);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
            }
        }

        private void SetRotation()
        {
            openRotation = new Vector3(defaultRotation.x, defaultRotation.y + (doorOpenAngle * (sideFlip * side)), defaultRotation.z);
        }

        private void SetDoorRotation(Vector3 interacterPosition)
        {
            side = ((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
        }

        public void UnlockDoor()
        {
            unlocked = true;
        }

    }
}
