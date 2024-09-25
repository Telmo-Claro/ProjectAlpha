public static class World
{

    public static readonly List<Weapon> Weapons = new List<Weapon>();
    public static readonly List<Monster> Monsters = new List<Monster>();
    public static readonly List<Quest> Quests = new List<Quest>();
    public static readonly List<Location> Locations = new List<Location>();
    public static readonly Random RandomGenerator = new Random();

    public const int INVENTORY_ITEM_SNUS = 1;
    public const int INVENTORY_ITEM_MUSHROOM = 2;
    public const int INVENTORY_ITEM_BEER = 3;
    public const int INVENTORY_ITEM_TREN = 4;
    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;
    public const int WEAPON_ID_AXE = 3;
    public const int WEAPON_ID_MACE = 4;
    public const int WEAPON_ID_SPEAR = 5;

    public const int MONSTER_ID_RAT = 1;
    public const int MONSTER_ID_SNAKE = 2;
    public const int MONSTER_ID_GIANT_SPIDER = 3;
    public const int MONSTER_ID_GOBLIN_THIEF = 4;

    public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
    public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
    public const int QUEST_ID_COLLECT_SPIDER_SILK = 3;
    

    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_SQUARE = 2;
    public const int LOCATION_ID_GUARD_POST = 3;
    public const int LOCATION_ID_ALCHEMIST_HUT = 4;
    public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
    public const int LOCATION_ID_FARMHOUSE = 6;
    public const int LOCATION_ID_FARM_FIELD = 7;
    public const int LOCATION_ID_BRIDGE = 8;
    public const int LOCATION_ID_SPIDER_FIELD = 9;

    public static string map =
        "         [P]          \n" +
        "         [A]          \n" +
        "   [V][F][T][G][B][S] \n" +
        "         [H]          \n";

    public static string Alchemist_quest = "Alchemist:\n�Those rats art nibbling on mine own h'rbs! I\r\ncouldst very much useth an adventur'r to taketh\r\ncareth of those folk ��";
    public static string Farmer_quest = "Farmer:\n�I can't w'rk mine own landeth with those pesky\r\nsnakes slith'ring 'round! Shall thee holp me?�";
    public static string Final_quest_Ready = "Guard:\n�thou hast profed thy grit, enter and slay The Giant Spider, bring me back his Silk as proof�";
    public static string Final_quest_UnReady = "Guard:\n�Turn back at once, peasant! Unless thee\r\nhast proof of thy grit.�";

    public static string Alchemist_quest_end = "Alchemist:\nAh, mine own h'rbs art finally safe! I can heareth the peace returneth to mine garden.\nThee hath done me a great service, adventur'r.\nH're, taketh this potion as a token of mine gratitude.\nMay it serveth thee well on thy travels!";
    public static string Farmer_quest_end = "Farmer:\nBless thee, kind soul! Mine fields art free of those cursed snakes, and I can w'rk the landeth again.\nMay thy crops groweth strong wh'rev'r thee go.\nH're, accept this humble gift, a fair recompense for thy hon'rable w'rk.";
    public static string Final_quest_end = "Guard:\nThou hast returned with the silk of the Giant Spider! Thy bravery doth knoweth no bounds.\nThy feat shall be spok'n of f'r years to cometh. As promiss'd, h're is thy rew'rd.\nGo now, and wear thy victory with pride!\n\n You won!!";
    static World()
    {
        PopulateWeapons();
        PopulateQuests();
        PopulateMonsters();
        PopulateLocations();
    }

    public static void PopulateWeapons()
    {
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 15));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Club", 25));
        Weapons.Add(new Weapon(WEAPON_ID_AXE, "Axe", 80));
        Weapons.Add(new Weapon(WEAPON_ID_MACE, "Mace", 75));
        Weapons.Add(new Weapon(WEAPON_ID_SPEAR, "Spear", 30));

    }

    public static void PopulateMonsters()
    {
        Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 15, 25, 25, QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN));


        Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 10, 7, 7, QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD));


        Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 3, 200, 200, QuestByID(QUEST_ID_COLLECT_SPIDER_SILK));


        Monster goblinThief = new Monster(MONSTER_ID_GOBLIN_THIEF, "Carlo The Goblin Thief", 2, 50, 50, null);


        Monsters.Add(rat);
        Monsters.Add(snake);
        Monsters.Add(giantSpider);
        Monsters.Add(goblinThief);

        giantSpider.Drop = new Item(420, "Spider Silk");
    }

    public static void PopulateQuests()
    {
        Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden");


        Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's field",
                "Kill snakes in the farmer's field");


        Quest clearSpidersForest =
                    new Quest(
                        QUEST_ID_COLLECT_SPIDER_SILK,
                        "Collect spider silk",
                        "Kill spiders in the spider forest");


        Quests.Add(clearAlchemistGarden);
        Quests.Add(clearFarmersField);
        Quests.Add(clearSpidersForest);

        // adds dialogue
        clearAlchemistGarden.BeginDialogue = Alchemist_quest;
        clearFarmersField.BeginDialogue = Farmer_quest;
        clearSpidersForest.BeginDialogue = Final_quest_Ready;

        clearAlchemistGarden.EndDialogue = Alchemist_quest_end;
        clearFarmersField.EndDialogue = Farmer_quest_end;
        clearSpidersForest.EndDialogue = Final_quest_end;

        // adds rewards to quests

        clearAlchemistGarden.Reward = new Potion(1, "Health Potion", 20);
        clearFarmersField.Reward = WeaponByID(WEAPON_ID_CLUB);
    }

    public static void PopulateLocations()
    {
        // Create each location
        Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");
        home.Friendly = true;

        Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");
        townSquare.Friendly = true;

        Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
        alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

        Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
        alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

        Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
        farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

        Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
        farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

        Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.");

        Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");
        bridge.QuestAvailableHere = QuestByID(QUEST_ID_COLLECT_SPIDER_SILK);

        Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
        spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

        // Link the locations together
        home.LocationToNorth = townSquare;

        townSquare.LocationToNorth = alchemistHut;
        townSquare.LocationToSouth = home;
        townSquare.LocationToEast = guardPost;
        townSquare.LocationToWest = farmhouse;

        farmhouse.LocationToEast = townSquare;
        farmhouse.LocationToWest = farmersField;

        farmersField.LocationToEast = farmhouse;

        alchemistHut.LocationToSouth = townSquare;
        alchemistHut.LocationToNorth = alchemistsGarden;

        alchemistsGarden.LocationToSouth = alchemistHut;

        guardPost.LocationToEast = bridge;
        guardPost.LocationToWest = townSquare;

        bridge.LocationToWest = guardPost;
        bridge.LocationToEast = spiderField;

        spiderField.LocationToWest = bridge;

        // Add the locations to the static list
        Locations.Add(home);
        Locations.Add(townSquare);
        Locations.Add(guardPost);
        Locations.Add(alchemistHut);
        Locations.Add(alchemistsGarden);
        Locations.Add(farmhouse);
        Locations.Add(farmersField);
        Locations.Add(bridge);
        Locations.Add(spiderField);
    }

    public static Location LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Weapon WeaponByID(int id)
    {
        foreach (Weapon item in Weapons)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }



    public static Monster MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    public static Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }
}
