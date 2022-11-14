using System.Collections.Generic;
using SimpleMissions.Objectives;
using UnityEngine;

namespace SimpleMissions.Mission
{
    [CreateAssetMenu(
        fileName = "Data",
        menuName = "Objectives/Create Mission Position"
        )]
    public class MissionBase : ScriptableObject
    {
        [Header("Objective Info")]
        [SerializeField] private new string name;
        [TextArea][SerializeField] private string description;
        [SerializeField] private int id;
        
        [Header("Objective Requirements")]
        [SerializeField] public List<Objective> objectives;
        
    }
}
