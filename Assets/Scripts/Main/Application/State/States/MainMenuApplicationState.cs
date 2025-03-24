using Core.Logging;
using Main.Application.State.Systems;

namespace Main.Application.State.States
{
    public class MainMenuApplicationState : BaseApplicationState
    {
        private readonly ILogger<MainMenuApplicationState> logger;

        public MainMenuApplicationState(ApplicationStateMachine applicationStateMachine, ILogger<MainMenuApplicationState> logger) : base(applicationStateMachine)
        {
            this.logger = logger;
        }
        
        public override void OnEnter()
        { 
            logger.Log("Loaded Main Menu");
        }
    }
}