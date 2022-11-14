using UnityEngine;

namespace SimpleMissions.Objectives
{
    public static class EventManager
    {

        // Events
        public delegate void ObjectRecollect(GameObject player, GameObject obj);
        public static event ObjectRecollect OnObjectRecollect;

        public delegate void ArrivedToObjective(GameObject obj, StatusObjective status);
        public static event ArrivedToObjective OnArrivedToObjective;

        public delegate void CheckObjective(GameObject other);
        public static event CheckObjective OnCheckObjective;


        public static void ECheckObjective(GameObject gameObject)
        {
            OnCheckObjective?.Invoke(gameObject);
        }

        public static void EObjectRecollect(GameObject player, GameObject obj)
        {
            OnObjectRecollect?.Invoke(player, obj);
        }
        
        public static void EArrivedToObjective(GameObject obj,
            StatusObjective status = StatusObjective.Increase)
        {
            OnArrivedToObjective?.Invoke(obj, status);
        }
        
    }
}
