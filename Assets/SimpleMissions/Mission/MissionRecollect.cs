using System.Collections.Generic;
using SimpleMissions.Objectives;
using UnityEngine;

namespace SimpleMissions.Mission
{
    [RequireComponent(typeof(Collider2D))]
    public class MissionRecollect : Mission
    {

        private List<Objective> _objectsToRecollect;
        [SerializeField] private bool debugCompleted;

        private Collider2D _collider2D;
        
        #region Unity Events

            protected override void Awake()
            {
                base.Awake();
                _objectsToRecollect = ObjectiveObjects;
                _collider2D = GetComponent<Collider2D>();
            }

            private void Update()
            {
                debugCompleted = IsCompleted;
            }

        #endregion
        
        
        #region Events

            protected override void CheckObjective(GameObject obj)
            {
                if ( Objective.CheckCompleted(ObjectiveObjects) && 
                     Vector2.Distance(gameObject.transform.position,
                         obj.transform.position) < _collider2D.bounds.size.x
                   )
                {
                    IsCompleted = true;
                }
            }

            private void ObjectRecollect(GameObject player, GameObject obj)
            {
                int index = _objectsToRecollect.FindIndex((elm) => elm.SameObject(obj) );
                if ( index == -1 ) return;
                _objectsToRecollect[index].StatusObjective(StatusObjective.Increase);
                Destroy(obj);
            }
            
        #endregion
        
        #region Enable/Disable Events

            protected override void OnEnable()
            {
                base.OnEnable();
                EventManager.OnObjectRecollect += ObjectRecollect;
            }

            protected override void OnDisable()
            {
                base.OnDisable();
                EventManager.OnObjectRecollect -= ObjectRecollect;
            }

        #endregion

    }
}
