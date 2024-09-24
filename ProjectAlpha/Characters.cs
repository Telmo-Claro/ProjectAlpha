using System;
public static class Characters
{
    public static List<string> characters = new List<string>()
    {
        "Maxx", "Elmo", "Kasper", "Aksol"
    };
    public static void ItemAdd(Player Character)
    {
        switch (Character.Name)
        {
            case "Maxx":
                {
                    Console.WriteLine("You have been equipped with 5 pouches of snus.");
                    for (int i = 0; i < 5; i++)
                    {
                        Item snus = new Item(1, "Snus");
                        Character.Inventory.Items.Add(snus);
                    }
                    break;
                }
            case "Elmo":
                {
                    Console.WriteLine("yu 8 magick muchroom.");
                    SoundAccess.PlaySMB();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.SetWindowSize(100, 30);
                    Console.SetBufferSize(100, 500);
                    break;
                }
            case "Kasper":
                {
                    Console.WriteLine("you drankk too mucch beerrrr");
                    Item beer = new Item(3, "Beer");
                    for (int i = 0; i < 5; i++)
                    {
                        Character.Inventory.Items.Add(beer);
                    }
                    Thread.Sleep(1500);
                    break;
                }
            case "Aksol":
                {
                    Console.WriteLine("You got Trenbolone acetate in your inventory.. When injected you get superpowers but you only have 1 hp left...");
                    Item tren = new Item(4, "Tren");
                    Character.Inventory.Items.Add(tren);
                    Character.Current_hp = 1;
                    Thread.Sleep(1500);
                    break;
                }
        }
    }
    public static void ApplySpacyTheme()
    {
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("   *        .        *          .     ");
            Console.WriteLine("    .         *      .    *       *    ");
            Console.WriteLine("  *     ants are crawling under your skin *");
            Console.WriteLine("     *       .        *       .        ");
            Console.WriteLine("    .    *         *       .         * ");
            Thread.Sleep(150);
        }
        Console.Clear();
    }
}