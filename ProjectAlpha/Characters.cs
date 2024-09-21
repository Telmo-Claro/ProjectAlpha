public static class Characters
{
    public static List<string> characters = new List<string>()
    {
        "Maxx", "Elmo", "Kasper", "Aksel"
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
                // case "Elmo":
                //     {
                //         Console.WriteLine("yu 8 magick muchroom.");
                //         ApplySpacyTheme();
                //         break;
                //     }
        }
    }
    // static void ApplySpacyTheme()
    // {
    //     Console.BackgroundColor = ConsoleColor.Black;
    //     Console.Clear();

    //     Console.ForegroundColor = ConsoleColor.Cyan;

    //     Console.WriteLine("   *        .        *          .     ");
    //     Console.WriteLine("    .         *      .    *       *    ");
    //     Console.WriteLine("  *     You are tripping!     .");
    //     Console.WriteLine("     *       .        *       .        ");
    //     Console.WriteLine("    .    *         *       .         * ");
    // }
}