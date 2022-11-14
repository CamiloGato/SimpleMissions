using SimpleMissions.Objectives;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTest : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EventManager.ECheckObjective(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("ObjectPickable"))
            {
                EventManager.EObjectRecollect(gameObject, col.gameObject);
            }
        }
    }
}