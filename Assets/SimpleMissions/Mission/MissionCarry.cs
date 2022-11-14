using System.Collections.Generic;
using SimpleMissions.Objectives;
using UnityEngine;

namespace SimpleMissions.Mission
{
    public class MissionCarry : Mission
    {
        private List<Objective> _objectsCarry;
        [SerializeField] private bool debugCompleted;

        #region Unity Events

            protected override void Start()
            {
                base.Start();
                _objectsCarry = ObjectiveObjects;
            }
            
            private void Update()
            {
                debugCompleted = IsCompleted;
            }
        
        #endregion


        #region Events

            protected override void CheckObjective(GameObject obj)
            {
                IsCompleted = Objective.CheckCompleted(_objectsCarry);
            }

            private void ArrivedToObjective(GameObject obj, StatusObjective status)
            {
                int index = _objectsCarry.FindIndex((elm) => elm.SameObject(obj) );
                if ( index == -1 ) return;
                _objectsCarry[index].StatusObjective(status);
            }

        #endregion

        #region Enable/Disable Events
        
            protected override void OnEnable()
            {
                base.OnEnable();
                EventManager.OnArrivedToObjective += ArrivedToObjective;
            }

            protected override void OnDisable()
            {
                base.OnDisable();
                EventManager.OnArrivedToObjective -= ArrivedToObjective;
            }

        #endregion
        
    }
}
