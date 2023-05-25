using Menu;

namespace SavingScripts
{
    [System.Serializable]
    public class PlayerSettings
    {
        public int resolutionIndex;
        public float volume;
        public bool isFullscreen;

        public PlayerSettings(SettingMenu settings)
        {
            resolutionIndex = settings.currentResolutionIndex;
            volume = settings.currentVolume;
            isFullscreen = settings.currentFullscreen;
        }
    }
}
