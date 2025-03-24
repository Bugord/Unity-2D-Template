using Main.Application.State.States;
using Main.Application.State.Systems;
using Zenject;

namespace Main.Application.Services
{
    public class ApplicationEntryPoint : IInitializable
    {
        private readonly ApplicationStateMachine applicationStateMachine;

        public ApplicationEntryPoint(ApplicationStateMachine applicationStateMachine)
        {
            this.applicationStateMachine = applicationStateMachine;
        }

        public void Initialize()
        {
            InitApp();
        }

        public void InitApp()
        {
            UnityEngine.Application.targetFrameRate = 60;
            applicationStateMachine.ChangeState<LoadingApplicationState>();
        }
    }
}