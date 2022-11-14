using SimpleMissions.Objectives;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class ObjectTest : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Objective"))
            {
                EventManager.EArrivedToObjective(gameObject);
                EventManager.ECheckObjective(gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Objective"))
            {
                EventManager.EArrivedToObjective(gameObject, StatusObjective.Reduce);
                EventManager.ECheckObjective(gameObject);
            }
        }
    }
}