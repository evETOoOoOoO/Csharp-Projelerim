//GOOD GAME
int heroHP = 100;
int monsterHP = 150;

Random dice = new Random();

static void ColorPrint(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

while (heroHP > 0 && monsterHP > 0)
{
    Console.WriteLine("Hamleni seç: 1-(Saldır),  2-(İksir iç), 3-(Blok)");
    string choise = Console.ReadLine();

    if (choise != "1" && choise != "2" && choise != "3")
    {
        ColorPrint("Geçersiz hamle! Lütfen 1, 2 veya 3 seçin.", ConsoleColor.Yellow);
        continue;
    }

    int luck = dice.Next(1, 11);

    if (choise == "1")
    {
        int attack = dice.Next(1, 16);

        if (luck <= 2)
        {
            ColorPrint("Saldırı başarısız oldu! Canavar hasar almadı.", ConsoleColor.DarkRed);
        }
        else if (luck >= 9)
        {
            ColorPrint($"Kritik vuruş! Canavar fazladan {attack * 2} hasar aldı.", ConsoleColor.Yellow);
            monsterHP -= attack * 2;
        }
        else
        {
            ColorPrint($"Normal vuruş! Canavar {attack} hasar aldı.", ConsoleColor.Red);
            monsterHP -= attack;
        }
    }
    else if (choise == "2")
    {
        if (luck <= 3)
        {
            ColorPrint("İksir bozuk çıktı! Hiçbir sağlık kazanılmadı.", ConsoleColor.DarkRed);
            continue;
        }
        ColorPrint("İksir içiliyor... 🍷", ConsoleColor.Cyan);
        if (heroHP >= 100)
        {
            ColorPrint("Sağlığınız zaten tam! İksir kullanılamaz.", ConsoleColor.Yellow);
            continue;
        }
        int heal = dice.Next(10, 21);
        heroHP += heal;
        if (heroHP > 100) heroHP = 100;

        ColorPrint($"İksir içildi! Kahraman {heal} sağlık kazandı.", ConsoleColor.Green);
    }
    else if (choise == "3")
    {
        ColorPrint("Kahraman blok pozisyonuna geçti! 🛡️", ConsoleColor.Cyan);
    }

    // CANAVARIN SIRASI
    if (monsterHP > 0)
    {
        int monsterAttack = dice.Next(1, 21);

        if (choise == "3")
        {
            int blockLuck = dice.Next(1, 11);
            if (blockLuck <= 6)
            {
                ColorPrint("Blok başarılı! Canavarın saldırısı boşa gitti.", ConsoleColor.Green);
            }
            else
            {
                ColorPrint($"Blok başarısız! Kahraman savunmasız yakalandı: {monsterAttack} hasar.", ConsoleColor.Magenta);
                heroHP -= monsterAttack;
            }
        }
        else
        {
            ColorPrint($"Canavar saldırıyor! Kahraman {monsterAttack} hasar aldı.", ConsoleColor.Magenta);
            heroHP -= monsterAttack;
        }
    }
}
ColorPrint("═════════════════════════════════════", ConsoleColor.White);
ColorPrint($"Kahraman HP: {heroHP}/100", ConsoleColor.Green);
ColorPrint($"Canavar HP:  {monsterHP}/150", ConsoleColor.Red);
ColorPrint("═════════════════════════════════════\n", ConsoleColor.White);

Console.WriteLine("\n⚔️ OYUN BİTTİ!\n");
if (heroHP > 0)
{
    ColorPrint("Büyük Düşman Yenildi!", ConsoleColor.Green);
}
else
{
    ColorPrint("Öldün!", ConsoleColor.Red);
}