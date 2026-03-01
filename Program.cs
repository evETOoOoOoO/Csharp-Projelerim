//Endocrine Calculatorv0.5
Console.WriteLine("BMR(Bazal Metabolizma Hızı),VKI(Vücut Kitle Endeksi) ve HOMA-IR(İnsülin Direnci) Hesaplayıcı");
Console.WriteLine("Hesaplama için cinsiyetinizi girin(Cinsiyetiniz sadece BMR sonucunu etkiler VKI'yi ve HOMA-IR'ı etkilemez)(E/K):");
string cinsiyet = Console.ReadLine().ToUpper();
if (cinsiyet == "E")
{
    Console.Write("Kilonuzu Girin(kg):");
    var kilo = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Boyunuzu Girin(cm):");
    var boy = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Yaşınızı Girin:");
    decimal yaş = Convert.ToDecimal(Console.ReadLine());
    decimal bmr = 88.362m + (13.397m * kilo) + (4.799m * boy) - (5.677m * yaş);
    decimal boymetre = boy / 100m;
    decimal vki = kilo / (boymetre * boymetre);
    Console.Write("Açlık Kan Şekerinizi Girin(mg/dL):");
    decimal glikoz = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Açlık İnsülininizi Girin(µU/mL):");
    decimal insülin = Convert.ToDecimal(Console.ReadLine());
    decimal homaIr = (glikoz * insülin) / 405m;
    Console.WriteLine("BMR(Bazal Metobolizma Hızı) Sonucunuz:" + bmr);
    Console.WriteLine("VKI(Vücut Kitle Endeksi) Sonucunuz:" + vki);
    Console.WriteLine("HOMA-IR(İnsülin Direnci) Sonucunuz:" + homaIr);  
}
else if (cinsiyet == "K")
{
    Console.Write("Kilonuzu Girin(kg):");
    var kilo = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Boyunuzu Girin(cm):");
    var boy = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Yaşınızı Girin:");
    var yaş = Convert.ToDecimal(Console.ReadLine());
    decimal bmr = 447.593m + (9.247m * kilo) + (3.098m * boy) - (4.330m * yaş);
    decimal boymetre = boy / 100m;
    decimal vki = kilo / (boymetre * boymetre);
    Console.Write("Açlık Kan Şekerinizi Girin(mg/dL):");
    decimal glikoz = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Açlık İnsülininizi Girin(µU/mL):");
    decimal insülin = Convert.ToDecimal(Console.ReadLine());
    decimal homaIr = (glikoz * insülin) / 405m;
    Console.WriteLine("BMR(Bazal Metobolizma Hızı) Sonucunuz:" + bmr);
    Console.WriteLine("VKI(Vücut Kitle Endeksi) Sonucunuz:" + vki);
    Console.WriteLine("HOMA-IR(İnsülin Direnci) Sonucunuz:" + homaIr);
}

