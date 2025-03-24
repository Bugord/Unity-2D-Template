using Main.Application.State.States;

namespace Main.Application.State.Systems
{
    public class ApplicationStateMachine
    {
        private readonly IApplicationStateFactory applicationStateFactory;

        private BaseApplicationState currentState;

        public ApplicationStateMachine(IApplicationStateFactory applicationStateFactory)
        {
            this.applicationStateFactory = applicationStateFactory;
        }

        public void ChangeState<T>() where T : BaseApplicationState
        {
            currentState?.OnExit();
            var newState = applicationStateFactory.Create<T>(this);
            currentState = newState;
            currentState?.OnEnter();
        }
    }
}