using System.Media;

public static class SoundAccess
{
    public static void PlaySMB()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.Combine(basePath, "..", "..", "..");

                // Combine with the relative path to the audio file in the project directory
                string soundFilePath = Path.Combine(projectRootPath, "audioFiles", "smbsound.wav");

                // Play the sound file
                using SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file 'smsound.wav' could not be found.");
            }
        }
    }

    public static void PlayRoblox()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.Combine(basePath, "..", "..", "..");

                // Combine with the relative path to the audio file in the project directory
                string soundFilePath = Path.Combine(projectRootPath, "audioFiles", "robloxsound.wav");

                // Play the sound file
                using SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file robloxsound.wav could not be found");
            }
        }
    }

    public static void PlayZyzz()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.Combine(basePath, "..", "..", "..");

                // Combine with the relative path to the audio file in the project directory
                string soundFilePath = Path.Combine(projectRootPath, "audioFiles", "zyzz.wav");

                // Play the sound file
                using SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file zyzz.wav could not be found");
            }
        }
    }

    public static void PlayAugh()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.Combine(basePath, "..", "..", "..");

                // Combine with the relative path to the audio file in the project directory
                string soundFilePath = Path.Combine(projectRootPath, "audioFiles", "augh.wav");

                // Play the sound file
                using SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file augh.wav could not be found");
            }
        }
    }

    public static void PlayFight()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.Combine(basePath, "..", "..", "..");

                // Combine with the relative path to the audio file in the project directory
                string soundFilePath = Path.Combine(projectRootPath, "audioFiles", "fight.wav");

                // Play the sound file
                using SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file fight.wav could not be found");
            }
        }
    }
}
