using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleMissions.Objectives
{
    public enum StatusObjective
    {
        Increase,
        Reduce,
    }
    
    [Serializable]
    public class Objective
    {
        [SerializeField] private GameObject obj;
        [SerializeField] private bool isNeededAmountAuto;
        [SerializeField] private int neededAmount;
        [SerializeField] private List<Vector2> position;
        // [SerializeField] private float distance;
        
        private bool _isCompleted;
        private int _amount;

        public void StatusObjective(StatusObjective status)
        {
            if (status == Objectives.StatusObjective.Increase) _amount++;
            else _amount--;
            _isCompleted = _amount >= neededAmount;
        }

        // Methods
        public bool SameObject(GameObject other)
        {
            return obj.name == other.name.Replace("(Clone)", "");
        }

        // Methods Statics and Checkers
        public static bool CheckCompleted(IEnumerable<Objective> objectives)
        {
            return objectives.All(objective => objective._isCompleted);
        }

        public static void DefaultValues(IEnumerable<Objective> objective)
        {
            foreach (var element in objective)
            {
                element._isCompleted = false;
                element._amount = 0;
                element.neededAmount = (element.isNeededAmountAuto) ?
                    element.position.Count : element.neededAmount;
            }
        }
        
        // Getters and Setters
        public List<Vector2> Position => position;
        public GameObject Obj => obj;
        // public float Distance => distance;

    }
}