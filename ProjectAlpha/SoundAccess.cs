using System.Media;

public static class SoundAccess
{
    public static void PlaySMB()
    {
        if (OperatingSystem.IsWindows())
        {
            try
            {
                using SoundPlayer soundPlayer = new SoundPlayer("smbsound.wav");
                soundPlayer.PlaySync();
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
                using SoundPlayer soundPlayer = new SoundPlayer("robloxsound.wav");
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
                using SoundPlayer soundPlayer = new SoundPlayer("zyzz.wav");
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
                using SoundPlayer soundPlayer = new SoundPlayer("augh.wav");
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
                using SoundPlayer soundPlayer = new SoundPlayer("fight.wav");
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file fight.wav could not be found");
            }
        }
    }
}
