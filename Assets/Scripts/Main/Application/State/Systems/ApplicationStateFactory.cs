using Main.Application.State.States;
using Zenject;

namespace Main.Application.State.Systems
{
    public class ApplicationStateFactory : IApplicationStateFactory
    {
        private readonly DiContainer diContainer;

        public ApplicationStateFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public T Create<T>(ApplicationStateMachine applicationStateMachine) where T : BaseApplicationState
        {
            return diContainer.Instantiate<T>(new[] { applicationStateMachine });
        }
    }
}