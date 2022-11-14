using System.Collections.Generic;
using SimpleMissions.Objectives;
using UnityEngine;

namespace SimpleMissions.Mission
{
    public class Mission : MonoBehaviour
    {
        [SerializeField] protected MissionBase missionBase;
        
        protected bool IsCompleted;

        protected List<Objective> ObjectiveObjects;

        #region Unity Events

            protected virtual void Awake()
            {
                // Generate the Objective Objects in the scene.
                ObjectiveObjects = missionBase.objectives;
                foreach (Objective objective in ObjectiveObjects)
                {
                    foreach (Vector2 position in objective.Position)
                    {
                        Instantiate(objective.Obj, position, Quaternion.identity);
                    }
                }
            }

            protected virtual void Start()
            {
                Objective.DefaultValues(ObjectiveObjects);
            }

        #endregion

        #region Events

            protected virtual void CheckObjective(GameObject obj){}

        #endregion

        #region Enable/Disable Events

            protected virtual void OnEnable()
            {
                EventManager.OnCheckObjective += CheckObjective;
            }
                
            protected virtual void OnDisable()
            {
                EventManager.OnCheckObjective -= CheckObjective;
            }

        #endregion

        #region Suscriptors

            protected void SubscribeToEvents(EventManager.ObjectRecollect obj)
            {
                EventManager.OnObjectRecollect += obj;
            }

            protected void SubscribeToEvents(EventManager.ArrivedToObjective obj)
            {
                EventManager.OnArrivedToObjective += obj;
            }
            
            protected void SubscribeToEvents(EventManager.CheckObjective obj)
            {
                EventManager.OnCheckObjective += obj;
            }
            
        #endregion
        
    }
}