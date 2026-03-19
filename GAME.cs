//GOOD GAME
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int level = 1;
int heroHP = 100;
int monsterHP = 150;
bool gameRunning = true;

Random dice = new Random();

void ColorPrint(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

while (level <= 5 && heroHP > 0 && gameRunning)
{
    int heroMaxHP = 100 + (level - 1) * 10;
    int monsterMaxHP = 150 + (level - 1) * 50;
    monsterHP = monsterMaxHP;
    heroHP = Math.Min(heroHP, heroMaxHP);

    ColorPrint($"\n⚔️  BÖLÜM {level} BAŞLIYOR! Bu bölümdeki canavar HP: {monsterMaxHP}", ConsoleColor.Cyan);

    while (heroHP > 0 && monsterHP > 0 && gameRunning)
    {
        Console.WriteLine();
        ColorPrint("═════════════════════════════════════", ConsoleColor.White);
        ColorPrint($"❤️  Kahraman HP : {heroHP}/{heroMaxHP}", ConsoleColor.Green);
        ColorPrint($"💀  Canavar HP  : {monsterHP}/{monsterMaxHP}", ConsoleColor.Red);
        ColorPrint("═════════════════════════════════════", ConsoleColor.White);
        Console.WriteLine();

        Console.WriteLine("[1] Saldır | [2] İksir | [3] Blok | [SPACE] Çıkış");

        var input = Console.ReadKey(true);

        if (input.Key == ConsoleKey.Spacebar)
        {
            gameRunning = false;
            break;
        }

        string choice = input.KeyChar.ToString();

        if (choice != "1" && choice != "2" && choice != "3")
        {
            ColorPrint("Geçersiz hamle! Lütfen 1, 2 veya 3 seçin.", ConsoleColor.Yellow);
            continue;
        }

        int luck = dice.Next(1, 11);

        if (choice == "1")
        {
            int heroAttack = dice.Next(5, 20);
            if (luck <= 2)
                ColorPrint("Saldırı başarısız oldu! Canavar hasar almadı.", ConsoleColor.DarkRed);
            else if (luck >= 8)
            {
                ColorPrint($"Kritik vuruş! Canavar fazladan {heroAttack * 2} hasar aldı.", ConsoleColor.Yellow);
                monsterHP -= heroAttack * 2;
            }
            else
            {
                ColorPrint($"Normal vuruş! Canavar {heroAttack} hasar aldı.", ConsoleColor.Red);
                monsterHP -= heroAttack;
            }
        }
        else if (choice == "2")
        {
            if (luck <= 3)
                ColorPrint("İksir bozuk çıktı! Hiçbir sağlık kazanılmadı.", ConsoleColor.DarkRed);
            else if (heroHP >= heroMaxHP)
                ColorPrint("Sağlığınız zaten tam! İksir kullanılamaz.", ConsoleColor.Yellow);
            else
            {
                int heal = dice.Next(10, 21);
                heroHP = Math.Min(heroHP + heal,heroMaxHP);
                ColorPrint($"İksir içildi! Kahraman {heal} sağlık kazandı.", ConsoleColor.Green);
            }
        }
        else if (choice == "3")
        {
            ColorPrint("Kahraman blok pozisyonuna geçti! 🛡️", ConsoleColor.Cyan);
        }

        if (monsterHP > 0)
        {
            int monsterAttack = dice.Next(5, 25);
            if (choice == "3")
            {
                int blockLuck = dice.Next(1, 11);
                if (blockLuck <= 6)
                    ColorPrint("Blok başarılı! Canavarın saldırısı boşa gitti.", ConsoleColor.Green);
                else
                {
                    ColorPrint($"Blok başarısız! Kahraman {monsterAttack} hasar aldı.", ConsoleColor.Magenta);
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

    if (!gameRunning) break;

    ColorPrint("═════════════════════════════════════", ConsoleColor.White);
    ColorPrint($"Kahraman HP: {heroHP}/{heroMaxHP}", ConsoleColor.Green);
    ColorPrint($"Canavar HP:  {monsterHP}/{monsterMaxHP}", ConsoleColor.Red);
    ColorPrint("═════════════════════════════════════\n", ConsoleColor.White);

    if (monsterHP <= 0 && heroHP > 0)
    {
        ColorPrint($"⚔️  BÖLÜM {level} BİTTİ! Canavar yenildi! 🎉", ConsoleColor.Green);
        level++;
        int newHeroMaxHP = 100 + (level - 1) * 10;
        heroHP = Math.Min(heroHP + 20, newHeroMaxHP);
        ColorPrint($"Sonraki bölüme geçiliyor... HP: {heroHP}/{newHeroMaxHP}\n", ConsoleColor.Cyan);
    }
    else if (heroHP <= 0)
    {
        break;
    }
}

Console.WriteLine();
if (!gameRunning)
{
    ColorPrint("Oyundan çıkıldı. Görüşürüz! 👋", ConsoleColor.Yellow);
}
else if (heroHP <= 0)
{
    ColorPrint("💀 Öldün! Oyun bitti.", ConsoleColor.Red);
}
else if (level > 5)
{
    ColorPrint("🏆 Tebrikler! Tüm 5 bölümü tamamladın!", ConsoleColor.Green);
}
