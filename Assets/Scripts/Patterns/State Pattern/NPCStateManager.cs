using Observer_Pattern;
using State_Pattern;
using UnityEngine;

public class NPCStateManager : MonoBehaviour
{
    private NPCBaseState currentState;
    public Animator animator;
    public NPCBreakDanceState npcBreakDanceState = new NPCBreakDanceState();
    public NPCSexyDanceState npcSexyDanceState = new NPCSexyDanceState();
    public NPCChickenDanceState npcChickenDanceState = new NPCChickenDanceState();
    public NPCIdleState npcIdleState = new NPCIdleState();

    private void Start()
    {
        currentState = npcIdleState;
        currentState.EnterState(this, DanceType.Idle);
    }

    private void OnEnable()
    {
        StageInteractable.OnInteract += OnStageInteract;
        StageInteractable.NotInteract += OnStageInteractEnd;
    }
    private void OnDisable()
    {
        StageInteractable.OnInteract -= OnStageInteract;
        StageInteractable.NotInteract -= OnStageInteractEnd;
    }
    
    private void OnStageInteract(DanceType type)
    {
        currentState.EnterState(this, type);
    }

    private void OnStageInteractEnd()
    {
        SwitchState(currentState, DanceType.Idle);
    }

    public void SwitchState(NPCBaseState state, DanceType type)
    {
        currentState = state;
        currentState.EnterState(this,type);
    }
}
