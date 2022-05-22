namespace State_Pattern
{
    public abstract class NPCBaseState
    {
        public abstract void EnterState(NPCStateManager npcStateManager,DanceType type);
    }
}