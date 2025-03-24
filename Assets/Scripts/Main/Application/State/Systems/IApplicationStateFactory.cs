using Main.Application.State.States;

namespace Main.Application.State.Systems
{
    public interface IApplicationStateFactory
    {
        T Create<T>(ApplicationStateMachine applicationStateMachine) where T : BaseApplicationState;
    }
}