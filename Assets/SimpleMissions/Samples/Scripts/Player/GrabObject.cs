using UnityEngine;

namespace Player
{
    public class GrabObject : MonoBehaviour
    {
        public Transform boxHolder;

        public float maxPickUpDistance;
        public float forceMulti;

        public bool readyToThrow;
        public bool objectIsPicked;



        private void Update()
        {
            if (Input.GetKey(KeyCode.E) && objectIsPicked && readyToThrow)
            {
                forceMulti += 300 * Time.deltaTime;
            }

            float pickUpDistance = Vector2.Distance(boxHolder.position, transform.position);

            if (pickUpDistance < maxPickUpDistance)
            {
                if (Input.GetKey(KeyCode.E) && !objectIsPicked && boxHolder.childCount < 1)
                {
                    transform.parent = boxHolder;
                    forceMulti = 0;
                    objectIsPicked = true;
                }

                if (objectIsPicked)
                {
                    transform.position = boxHolder.position;
                    GetComponent<Collider2D>().enabled = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.E) && objectIsPicked)
            {

                readyToThrow = true;
                if (forceMulti > 10)
                {
                    this.transform.parent = null;
                    GetComponent<Collider2D>().enabled = true;
                    objectIsPicked = false;
                    forceMulti = 0;
                    readyToThrow = false;

                }
                forceMulti = 0;
            }
        }

    }
}