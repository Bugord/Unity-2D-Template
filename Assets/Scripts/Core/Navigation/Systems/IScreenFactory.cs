using Core.Navigation.Models;
using UnityEngine;

namespace Core.Navigation.Systems
{
    public interface IScreenFactory
    {
        T Create<T>(Transform parentTransform) where T : BaseScreen;
    }
}