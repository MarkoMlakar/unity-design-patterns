using Managers;
using UnityEngine;

namespace State_Pattern
{
    public class NPCIdleState: NPCBaseState
    {
        private static readonly int IsBreakDance = Animator.StringToHash("IsBreakDance");
        private static readonly int IsChickenDance = Animator.StringToHash("IsChickenDance");
        private static readonly int IsSexyDance = Animator.StringToHash("IsSexyDance");


        public override void EnterState(NPCStateManager npcStateManager, DanceType type)
        {
            switch (type)
            {
                case DanceType.Sexy:
                    npcStateManager.SwitchState(npcStateManager.npcSexyDanceState,type);
                    break;
                case DanceType.Idle:
                    npcStateManager.animator.SetBool(IsBreakDance,false);
                    npcStateManager.animator.SetBool(IsChickenDance, false);
                    npcStateManager.animator.SetBool(IsSexyDance,false);
                    AudioManager.Instance.ChangeStageMusic(type);
                    break;
                case DanceType.BreakDance:
                    npcStateManager.SwitchState(npcStateManager.npcBreakDanceState,type);
                    break;
                case DanceType.ChickenDance:
                    npcStateManager.SwitchState(npcStateManager.npcChickenDanceState,type);
                    break;
                default:
                    npcStateManager.SwitchState(npcStateManager.npcIdleState,type);
                    break;
            }
        }
    }
}