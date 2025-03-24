using Main.Application.State.Systems;

namespace Main.Application.State.States
{
    public abstract class BaseApplicationState
    {
        protected readonly ApplicationStateMachine ApplicationStateMachine;
        
        protected BaseApplicationState(ApplicationStateMachine applicationStateMachine)
        {
            ApplicationStateMachine = applicationStateMachine;
        }
        
        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}