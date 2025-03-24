using Cysharp.Threading.Tasks;
using Main.Sounds.Data;

namespace Main.Sounds.Core
{
    public interface ISoundService
    {
        UniTask Play(SoundEffectData data, float fadeDuration = 0f);

        void PauseAll(float fadeDuration = 0f);
        void ResumeAll(float fadeDuration = 0f);
        void StopAll(float fadeDuration = 0f);
    }
}