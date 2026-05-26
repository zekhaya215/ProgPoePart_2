using System;
using System.IO;
using System.Media;

namespace ProgPoePart_2.Services
{
    public class VoiceManager
    {
        private readonly string soundPath;

        public VoiceManager()
        {
            // Path to your WAV file
            soundPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Audio",
                "welcome.wav");
        }

        public void PlayVoice()
        {
            try
            {
                if (File.Exists(soundPath))
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play();
                }
            }
            catch
            {
                // Ignore sound errors so app does not crash
            }
        }
    }
}