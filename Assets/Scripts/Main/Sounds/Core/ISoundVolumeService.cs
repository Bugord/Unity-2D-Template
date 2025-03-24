namespace Main.Sounds.Core
{
    public interface ISoundVolumeService
    {
        bool IsMusicActive { get; set; }
        bool IsSfxActive { get; set; }
    }
}