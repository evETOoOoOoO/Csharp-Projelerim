//Çok sinirli bu hesap makinesi..
decimal sonuc = 0;
Console.WriteLine("Kardeş bak 2 bit hafızam var zaten çok zor hesap sorma bana");
Console.Write("Bir sayı gir lan:");
var sayı1 = Console.ReadLine();
var AlınanSayı1 = Convert.ToDecimal(sayı1);
Console.Write("Bir sayı daha gir lan:");
var sayı2 = Console.ReadLine();
var AlınanSayı2 = Convert.ToDecimal(sayı2);
Console.Write("Yapmak istediğin işlem ne lan hırto(+,-,*,/):");
var islem = Console.ReadLine();
if (islem == "+")
{
    sonuc = (AlınanSayı1 + AlınanSayı2);
    Console.WriteLine("Malesefki sonuç: " + sonuc);
}
else if (islem == "-")
{
    sonuc = (AlınanSayı1 - AlınanSayı2);
    Console.WriteLine("Malesefki sonuç: " + sonuc);
}
else if (islem == "*")
{
    sonuc = (AlınanSayı1 * AlınanSayı2);
    Console.WriteLine("Malesefki sonuç: " + sonuc);
}
else if (islem == "/")
{
    if (AlınanSayı2 != 0)
    {
        sonuc = (AlınanSayı1 / AlınanSayı2);
        Console.WriteLine("Zordu bölmek 2 bit dedim sana aman neyse sonuç:" + sonuc);
    }
    else
        Console.WriteLine("LAN KARADELİKMİ OLUŞSUN İSTİYON NASI 0 I BÖLEM BEN");
}
else
{
    Console.WriteLine("2 bitlik dedim 256 bitlik soru sordun Allah aşkına daha soru sorma.");
}
Console.WriteLine($"Sistem resetlendi ramım boşaltıldı malesefki yeni soru sorabilirsin tabi programı yeniden çalıştırcak kadar beni sevdiysen ve işlem sonucun: {AlınanSayı1} {islem} {AlınanSayı2} = {sonuc}");
Console.ReadLine();