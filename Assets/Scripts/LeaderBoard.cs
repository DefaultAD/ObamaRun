using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeaderBoard : MonoBehaviour
{
    private List<string> names = new List<string>
    {
        "The Armor", "My Arsenal", "Annihilator", "Anomaly", "Arbitrage", "Team Arsenic", "Alien", "Abyss","CrazyBull","Agitator","Agony","Agrippa","Cargill","Albatross","resident evil","Skillz inc","Amaretto","Amazon","New Ambush","Angon","Animus","Stream Elements","Core Philosophies","Given Moment","Relative Performance","Trunk","Flagship Property","Critical Role","Digital","Blood","Sienna Princess","Scalp","Sky Bully","Steel Foil","Jawbone","Cool Iris","Tusk","Albatross","Bad Bunny","Titanium","Delivery Boy","Dug Funnie","Gunsly Bruce Lee","Harry Dotter","Manchu Man","Mighty Mafia","Anonymous Names","Homely Sharpshooters","Investor Relations","CobraBite","Bleed","Fisheye","Sidewalk Enforcer","Falcon","Bullet","Knuckles","Silver Stone","Roller Turtle","RoarSweetie","RedFeet","Reed Lady","Sythe","Kneecap","Acid Gosling","Rubble","Snake","Hazzard","Automatic Slicer","Boar","Devil Chick","Accidental Genius","Capital F","Ironsides","Aspect","Tweek","Gut","Blister","Saint La-Z-Boy","Geronimo","Lynch","Pursuit","ScaryPumpkin","Breaker","Wardon","Bowie","Grizzly","Iron-Cut","Dexter","Vulture","Schizo","Easy Sweep","Razor","Skull Crusher","Dark Horse","Cannon","Sniper","Darko","Cannon","Doz Killer","Footslam","Dust River","Polaroid Pal","Legend of Zelda","Demonic Criminals","Blistered Outlaw","Super Mario","Dooming","Pigeon","Bowser","Inch","Final Fantasy","Orphan","Aqua","Inferior","Invaders","Numb","Penguin","Nest","Harry Dotter","Astro Ashe","Airport Hobo","Armadillo","Gran Turismo","Eerie Mizzen","Devil Blade","Parrot","Pirate","Mario RPG","Decades","Bouncing","Flea","Cat","Diamond Gamer","Metal Gear Solid","Angry Stickman","Warrior Dude","Lara Croft","Mario Kart","The Legend of Zelda","Super Smash Bros","Megaman","Pokémonaa","Pac-Man","Baldur’s Gate","Meta Knight.","League of Legends.","Cherry.","Mario Brothers.","Ori Super.","Nidoking.","Link Man.","Evil Genius.","Wario.","Raptor.","Valgazza.","Madden NFL","Super Smash Bros","Feta","Alice","Alex Jones","Waluigi","Diablo","Dweezil","Mim","Zelda","Weim","Junk","Thermajin","Terraria","Advanced Gaming","Uncharted","Peach","Superboy","Donkey Kong","Dragon","Fallout","Raging Ogres","Powerdrive","Candy Cane","Magic","Minecraft","Umara","Pinball Tables","World of Warcraft","Ninjas in Pajamas","Lazir","Lara Croft","Nihnum","Trax","Rose","Fizz","Finger of Death","Criss Cross","Bug Blitz","Mad Dog","Ballistic","Uprising","Aero","K-9","Wildcat","Blonde","Electric Saturn","Fire Fish","Mortar","Steelshot","Vein","Socket","Arsenal","Wolf","Skinner","Fast Draw","Khan","Creep","Claw","Bitmap","Blistered Outlaw","Rocky Highway","Shadow Bishop","DriftDetector","Screw","Black Mamba","Tooth","Torque","Airport Hobo","Wrath","Mad Max","ElactixNova","Doom","Cujo","Betty Cricket","Tomcat","EyeShooter","Disco Thunder","Lash","Rapid River.","Rotten Zucchini.","Sandwich Deliveries.","Sharks of Atlantis.","Apple Bob.","Clash of Cooks.","Crayon Crime.","Crazy Factory.","Bananas n Chips.","Call of Dowson.","Candy Crush","Candy Land","Danknado","Dodge the Shoe","Fortnite Couch","Gardening Gophers","Grand Theft Auto","Grandma’s Nose","Horse Herpes","James Bomb","Kingdom of Memes","Mario Kart","Meme Man","Minecraft","Minecraft","Mustache Smack","My Little Balloon","Nesting Hens","Nintendo","Online Games","Pacman","Pinch the Pear","Pokemon","Pokemon","Puds","Skyrim","Star Wars","Super Mario","Superior Succotash","Outrageous Dominance","Bad Soldier","Demonic Criminals","Popular Game","Faulty Devils","Plain Privilege","Abnormal Vigor","Cloudy Perpetrator","Trollers Goals","Computing Tips","Fanatical Tyranny","Militaristic Fighting Machine","Psychedelic Servicemen","Disagreeable Liquidators","Positive Attitude","Cookie Jar","Greek Mythology","Bob Vaginer","Caps Gaming","Penn National","Chicky Fighter","Satre Chair","Monster Hunter","Ram","Reaper","Wolverine","Goshawk","Carbine","Hashtag","Napoleon","Cool Whip","Big Papa","Maximus","Atilla","Frenzy","Siege","Drugstore Cowboy","Gnaw","Sabotage","Desperado","FireByMisFire","ALLEY FROG.","NAILBLUE.","COBRAFIRE.","BUG FIRE.","TITOBOY.","CUTPRO.","ELDER POGUE.","SCARYNINJA.","PRISM GAMER.","CASTLEVANIA.","Tomclancy.","Super Smash Bros","Final FANTASY","Onision","Halo Gamer","Tomb Raider","Grandtheftautov","Stardew Valley","Sims","The Scarlet Blade","Metal Gear Solid","Dead Cells","Dead Pixels","Gears OF War","Guitar Hero","Dark Souls","Fortnite","Pac-Man","Livestrength","Phineas AND Ferb","Tetris","Overwatch","Knives Out","Peggle","Gorogoa","Pewdiepie","Happy Wheels","Knight OF Diamonds","Rainbow Six Seige","Frosty","Gta4","Call OF Duty","Grand Theft Auto","Pokemongo","Ghostrecon","Sonic","Assassin’s Creed","Crash Bandicoot","Candy Crush Saga","Battlefield","League OF LEGENDS","Duck Hunt","Madden","Fortnitebr","Double Fine Adventure","Mysims","Ideas BBY","Starlinkflighttest","Final Fantasy Vii","Zelda SKIT","Corridor Kombat","Neverhood","Tony Hawk","Guitar Hero","The App Games","My Cool Athlete","The Big Brand","The Extra Character","The Best Clan","Clan Names","Cool Names","My Fictional Character","Alpha Fighting Games","Gamer Girl","My Gaming Industry","Idea For Games","My Inspiration","Intellectual Property","Japanese Girl","The Legend","Mortified Coercion","Darling Peacock","Eerie Mizzen","Glock","Buckshot","Don Stab","Grave","Returns","Fire-Bred","Screwtape","Siddhartha","Back Bett","Digger","Fist Wizard","RedMouth","Prometheus","Viper","Ripley","Demented","rick n morty","LITHINA.","MINX.","AMAZO.","HEROIN.","HARLEM.","BLACK BEAUTY.","MANNEQUIN.","TERROR.","COSMA.","COLADA.","Thunderbird","Lolita","Pumps","Femme Fatale","Majesty","Stiletto","Infinity","Enchantress","Vixen","Cougar","Legacy","Vanity","Lotus","Half Pint","Wicked","Nova","Shadow","Temperance","Belladonna","Tattoo","Banshee","Malice","Geisha","Carbon","Roulette","Siren","Resin","Calypso","Ivy","Cascade","Raven","Voodoo","Ultra","Nightmare","Mirage","T-Back","Rogue","Widow","Xenon","Beretta","Countess","Tequila","Mademoiselle","Enigma","Anomaly","Goddess","Insomnia","Velvet","Nintendo Girl","Kitty","Alita","Clementine","Georgette","Kaitlyn","Angel","Kitty","Gamer Girl","Nerdy Princess","Sunshine","Snow","Serenity","Nuzzle","Climax","Saki","Eve","Necromancer","Zlatan","Amy","Remy","Sakura","Kiss","Peach","Nana","Lily","Belle","Linda","Roses","Bridgette","Cotton","Queen","Gretchen","Pixel Princess","Rosalie","Shelley","Kaylin","Pat","Pudding","Lava","Rockstar","Minecraft Girl","Karen","Whitney","Annie","Jaime","Legends Girl","Cherry","Eris","Ashley","Brigid","Carrie","Toffee","Chloe","Fairies","Blossom","Nina","Gamer Girl","Lara","Sugar","Adelaide","Rory","Loretta","Livy","Gaming Girl","Princess Avatar","Zombie Bunny","Lil Uzi","Gwen","Daggers.","Joy","Daredevil.","Dazzle","Darko.","Grace","Dazzler.","Zoe","Decay.","Shadow","Deception.","Breeze","Delirious","Leigh","Demented","The Daemon.","Demise","The Damned.","Derange","Dark Matter.","Detroit","Daydream.","Deviant","Deathstalker.","Dice","Deceit.","Dihya","Deep Pockets","Dismay","Delusion","Diviner","Dementor","Don","Demolition","Double Double","Destroyer","Dragon","Devi","Dutch","Diablo","Earth Metal","Die-hard","Electron","Dirty Dirty","Element","Dissent","Eliminator","Dom","Enchantress","Doom","Enmity","Dracula","Enyo","Duchess","Eowyn","Dux","Eternity","Egomania","Executioner","Elektra","Explosive","Elemental","The Hammer","Empress","Hey Harlem","Enigma","My Haunter","Entropy","The Hawkeye","Eon","Head-Knocker","Espada","Hellcat","Excavator","Hemlock","Exorcist","Heroin","Exterminator","High Roller","Hannibal","Hornet","Harpoon","Hostility","Hauteur","Howitzer","Hazzard","Hurricane","N Helium","Hypernova","Hell-Raiser","Illusion","Hero","Inferno","Herzogin","Insomnia","Hitter","Ion","Horror","Iron Heart","Hot Salt","Iron-Cut","Hua Mulan","Ironsides","Hydra","Isis","Illumine","Jaguar","Immortal","Jawbone","Infinity","Jezebel","Insurgent","Jubilee","Ire","K-9","Ironclad","Kahina","Irons","Katar","Ishtar","Kelpie","Ivy","Kevlar","Javelin","Kiddo","Jesse James","Kneecap","Joose","Kraken","Juno","Lance","Kafka","Legacy","Katana","Leonidas","Katniss","Abducted by Aliens","Keno","Accidental Genius","Khan","Agent Hercules","Killer","Alley Frog","Knuckles","Angels Creed","Lab Rat","Atomic Blastoid","Lash","Baby Brown","Leon","Bad Bunny","Leviathan","Bearded Angler","A Distraction","All Good Names Gone","Admiral Tot","Ashley Said What","Airport Hobo","Baby Bugga Boo","Alpha Returns","Xbox Gamer","Arsenic Coo","Gamer Twitter","Automatic Slicer","Raiden Story","Back Bett","All Cool Participants","Bazooka Har-de-har","My Online Games","Beetle King","Ninja Gamertag","Ariana Grandes Ponytail","Middle East Gamers","Babushka","Legend Geek","Gamer YouTube","Las Vegas Shots","Word for Games","Idea for Beginners","Season and Games","General Counsel","Person Tags","Executive Committee","Online Gaming","Conversation Team","North America","Betty Cricket","Nickname is Gone","Candy Butcher","Letter for Gamer","Cosmo","League Gamers","Crash Test","Kid Game Play","Criss Cross","Good Gamer Tag","Cupid Dust","Game Character","Baby Doodles","Esports Team","Banana Hammock","Consumers Goal","Big Foot Is Real","Bit Sentinel","Billy’s Mullet","Capital F","Born Confused","Crash Override","Calzone Zone","Crazy Eights","Casanova","Cross Thread","Cereal Killer","Daffy Girl","Cherry Picked","Bad Karma","Chris P Bacon","Behind You","Coolhunter","The Russian Spy","Cuddly Puddly","Blue Ivy’s Assistant","Darth Daenerys","Bud Lightyear","Desperate Enuf","Camelopard","Don Worry","Cats Or Dogs","Drooling","Heisenbug","Early Morning Coffee","Chin Chilin","Everybody","Colonel Mustards Rope","Fat Batman","Crazy Cat Lady","Fizzy Sodas","Cute As Ducks","Darling Peacock","Definitely Not An Athlete","Desert Haze","Dirtbag","Devil Blade","Doesn’t Anyone Care","Dexter","Drunk Gamer","Digger","Elfish Presley","Drop Stone","Fast And The Curious","Drugstore Cowboy","Fedora The Explorer","Earl of Arms","Darkside Orbit","Eerie Mizzen","Day Hawk","Father Abbot","Desperado","Fennel Dove","Devil Chick","Fiend Oblivion","Diamond Gamer","Gadget","Disco Potato","Global meltdown","Dropkick","Gov Skull","DuckDuck","Greek Rifle","Easy Sweep","Green Scavenger","FastLane","High Kingdom Warrior","FenderBoy","Hightower","Feral Mayhem","HollySparta","Frozen Explosion","Houston Rocket","Gas Man","Star Sword","Goatee Shield","Stacker of Wheat","Grave Digger","Spunky Comet","Green Ghost","Spider Fuji","Guillotine","Speedwell","Highlander Monk","Solo Kill","Hog Butcher","Snow White Lover","Houston","Snow Hound","Hyper","SnoopWoot","Stallion Patton","Snake Eyes","Squatch","Smash trash","SpitFire","Smartweeds","SpellTansy","Sky Herald","Speed Breaker","Skull Crusher","Sofa King","Silver Stone","Snow Pharaoh","Sidewalk Enforcer","Snow Cream","Sherwood Gladiator","SniperInstinct","Shadow Bishop","Snake Eye","Seal Snake","Smash Buster","Scrapper","Slow Trot","Hot Girl Bummer","Sky Bully","Honey Lemon","Sir Shove","Heart Ticker","Sienna Princess","Hanging With My Gnomes","Shooter","Greenmail","Shadow Chaser","Google Was My Idea","Sexual Chocolate","Gandoras","Screwtape","Frosted Cupcake","Hot Name Here","Freddie Not The Fish","Hoosier Daddy","Zesty Dragon","Hogwarts Failure","Yellow Menace","He You","Woo Woo","Hairy Poppins","Wolf Tribune","Granger Danger","Willow Dragon","Ghost Facings","Wholesome","Fur Real","Waylay Dave","Fried Chocolate","Vagabond Warrior","Fluffy Cookie","TulipCake","Zero Charisma","TrixiePhany","Wooden Man","Trash Sling","Wolverine","Toy Dogwatch","Winter Bite","Tough Nut","Widow Curio","ThunderStroke","White Snare","Third Moon","Washer","Celtic Charger","Turnip King","Cereal Killer","Troubadour","Chew Chew","Trick Baron","Chip Queen","Trash Master","App for Winners","ToxicCharger","Chocolate Thunder","Toolmaker","Club Nola","Thrasher","Congo Wire","Captain Peroxide","Shadow Bishop","Centurion Sherman","Screw","Chasm Face","Tooth","Chicago Blackout","Airport Hobo","Artificial Intelligence","Mad Max","Babbles Buzz","Doom","Chuckles","Arthas II","Commando","Cupcake","Cool Iris","Fury","DriftDetector","Gragas","Black Mamba","Illidan","Torque","King of the Kill","Wrath","Lucian","ElactixNova","Mordekaiser","Anubis Ara","Sejuani","Blood","Talon","Ezreal","Welp","General Grey","Gumdrop","Heimerdinger","Jackass","Ironman","Ralph","Leonidas","Shark Week","Malzahar","The Psychic","Orianna","The Mage","Siege","lazorbeam","Thor","gamenames","Ziggs","Far Cry","Herman","The Blade","Meryl","The Storm","Sasquatch","lzar","Spidypal","The Holy","Bloody","The Cat","The Hunter","The Angel","The Young","Pac Man World","Battletoads","Uncharted","Artemis","splinter","The Angler","The Walker","Super Mario Bros","The Red","Nemesis","NEO","The Slasher","Nintendo","The Black","The Spell","Microsoft","Soul Caliber","The Creator","The Hermit","lazor","The Winner","DarkSky","Oporto","World of Warcraft","Pac-Man","Hammer","Pac-Man","Cyberg","The Knight","Street Fighter","The First","Red Alert","The Fighter"
    };

    private string _name;
    private List<User> _randomUsers = new List<User>();

    [SerializeField] private Transform svContent;
    [SerializeField] private RectTransform scoreRecord;
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private GameObject selectNamePanel;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("HighScore") == 0)
            PlayerPrefs.SetInt("HighScore", 20);
        _name = PlayerPrefs.GetString("name");
    }

    public void OpenLeaderboard()
    {
        if (string.IsNullOrEmpty(_name))
            selectNamePanel.SetActive(true);
        else
        {
            leaderboardPanel.SetActive(true);
            if (_randomUsers.Count == 0)
                MakeRandomUsers();
            SetLeaderboard();
        }
    }

    public void EnterLeaderboard(TextMeshProUGUI textMeshProUGUI)
    {
        if (string.IsNullOrWhiteSpace(textMeshProUGUI.text))
            return;

        selectNamePanel.SetActive(false);
        PlayerPrefs.SetString("name", textMeshProUGUI.text);
        _name = textMeshProUGUI.text;
        leaderboardPanel.SetActive(true);

        MakeRandomUsers();

        SetLeaderboard();
    }

    private void SetLeaderboard()
    {
        // if (svContent.childCount > 1)
        //     return;
        //
        // int score = PlayerPrefs.GetInt("HighScore");
        // Vector2Int scoreRandomRange = new Vector2Int(score - 600, score + 600);
        // scoreRandomRange.x = (scoreRandomRange.x < 0) ? 0 : scoreRandomRange.x;
        // List<User> randomUsers = new List<User>();
        // for (int i = 0; i < 800; i++)
        // {
        //     User randomUser = new User(names[Random.Range(0, names.Count)],
        //         Random.Range(scoreRandomRange.x, scoreRandomRange.y));
        //     randomUsers.Add(randomUser);
        // }
        //
        // randomUsers.Add(new User(_name, score));
        // randomUsers.Sort((user, user1) => user1.HighScore.CompareTo(user.HighScore));
        //
        // // display on scrollView
        // Vector3 defaultHeight = new Vector3(0, -scoreRecord.rect.height * 3, 0);
        // for (var i = 0; i < randomUsers.Count; i++)
        // {
        //     User randomUser = randomUsers[i];
        //     RectTransform scoreRecordRT = Instantiate(scoreRecord, svContent);
        //     scoreRecordRT.gameObject.SetActive(false);
        //     scoreRecordRT.localPosition += defaultHeight + Vector3.down * i * scoreRecord.rect.height;
        //     scoreRecordRT.GetChild(1).GetComponent<Text>().text = $"{(i + 1).ToString()}-  {randomUser.Username}";
        //     scoreRecordRT.GetChild(2).GetComponent<Text>().text = randomUser.HighScore.ToString();
        //     if (randomUser.Username.Equals(_name) && randomUser.HighScore == score)
        //         scoreRecordRT.GetChild(1).GetComponent<Text>().fontSize += 10;
        // }
        //
        // svContent.GetComponent<RectTransform>().sizeDelta =
        //     new Vector2(svContent.GetComponent<RectTransform>().sizeDelta.x, 800 * scoreRecord.rect.height / 2);

        TextMeshProUGUI lbText = svContent.GetChild(1).GetComponent<TextMeshProUGUI>();
        lbText.text = "";
        int score = PlayerPrefs.GetInt("HighScore");
        int userIndex = -1;
        bool first3Dots = false;
        bool last3Dots = false;

        for (int i = 0; i < 800; i++)
            if (_randomUsers[i].Username == _name && _randomUsers[i].HighScore == score)
            {
                userIndex = i;
                break;
            }

        for (int i = 0; i < 800; i++)
        {
            User user = _randomUsers[i];

            if (i < 5)
            {
                if (user.Username == _name && user.HighScore == score)
                {
                    lbText.text += $"\n{(i + 1).ToString()}- \"{user.Username}\":  {user.HighScore.ToString()}";
                }
                else
                {
                    lbText.text += $"\n{(i + 1).ToString()}- {user.Username.ToString()}:  {user.HighScore.ToString()}";
                }
            }
            else
            {
                int distance = Mathf.Abs(i - userIndex);

                if (distance > 2)
                {
                    if (Mathf.Abs(i - 799) < 5)
                    {
                        lbText.text +=
                            $"\n{(i + 827023).ToString("N0")}- {user.Username.ToString()}:  {user.HighScore.ToString()}";
                        continue;
                    }

                    if (i < userIndex && first3Dots == false)
                    {
                        first3Dots = true;
                        lbText.text += "\n.\n.\n.";
                    }
                    else if (i > userIndex && last3Dots == false)
                    {
                        last3Dots = true;
                        lbText.text += "\n.\n.\n.";
                    }
                }
                else if (distance == 0)
                {
                    lbText.text +=
                        $"\n{(i + 1).ToString()}- \"{user.Username.ToString()}\":  {user.HighScore.ToString()}";
                }
                else
                {
                    lbText.text += $"\n{(i + 1).ToString()}- {user.Username.ToString()}:  {user.HighScore.ToString()}";
                }
            }
        }

        svContent.GetComponent<RectTransform>().sizeDelta = new Vector2(
            svContent.GetComponent<RectTransform>().sizeDelta.x,
            svContent.GetChild(svContent.childCount - 1).GetComponent<RectTransform>().sizeDelta.y + 550);
    }

    private void MakeRandomUsers()
    {
        int score = PlayerPrefs.GetInt("HighScore");
        // make _randomUsers List
        for (int i = 0; i < 800; i++)
        {
            User randomUser = new User(names[Random.Range(0, names.Count)], Random.Range(score - 400, score + 10000));
            if (randomUser.HighScore < 0)
                randomUser.HighScore = 0;
            _randomUsers.Add(randomUser);
        }

        _randomUsers.Add(new User(_name, score));
        _randomUsers.Sort((user, user1) => user1.HighScore.CompareTo(user.HighScore));
    }
}

class User
{
    public string Username;
    public int HighScore;

    public User(string username, int highScore)
    {
        Username = username;
        HighScore = highScore;
    }
}