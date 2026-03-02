//EndocrineCalculatorv1
Console.WriteLine("=== BMR (Basal Metabolic Rate), BMI (Body Mass Index) and HOMA-IR (Insulin Resistance) Calculator ===");
Console.WriteLine("=== BMR(Bazal Metabolizma Hızı),VKI(Vücut Kitle Endeksi) ve HOMA-IR(İnsülin Direnci) Hesaplayıcı ===");
Console.WriteLine("(Gender only affects BMR results; it does not affect BMI or HOMA-IR)");
Console.WriteLine("(Cinsiyetiniz sadece BMR sonucunu etkiler VKI'yi ve HOMA-IR'ı etkilemez)");
Console.WriteLine("Please enter your gender (M/F).");
Console.WriteLine("Cinsiyetinizi Girin(M=Erkek/F=Kadın)(M/F):");
string gender = Console.ReadLine().ToUpper();

Console.Write("Kilonuzu Girin / Enter your weight (kg): ");
var weight = Convert.ToDecimal(Console.ReadLine());

Console.Write("Boyunuzu Girin / Enter your height (cm): ");
var heightCm = Convert.ToDecimal(Console.ReadLine());

Console.Write("Yaşınızı Girin / Enter your age: ");
decimal age = Convert.ToDecimal(Console.ReadLine());

Console.Write("Açlık Kan Şekerinizi Girin / Enter Fasting Glucose (mg/dL): ");
decimal fastingGlucose = Convert.ToDecimal(Console.ReadLine());

Console.Write("Açlık İnsülininizi Girin / Enter Fasting Insulin (µU/mL): ");
decimal fastingInsulin = Convert.ToDecimal(Console.ReadLine());

decimal heightM = heightCm / 100m; 
decimal bmı = weight / (heightM * heightM);
decimal homaIr = (fastingGlucose * fastingInsulin) / 405m;

decimal bmr = 0;
if (gender =="M")
{
       bmr = 88.362m + (13.397m * weight) + (4.799m * heightCm) - (5.677m * age);
}
else if (gender =="F")
{
       bmr = 447.593m + (9.247m * weight) + (3.098m * heightCm) - (4.330m * age);
}
Console.WriteLine($"BMR (Basal Metabolic Rate) Sonucunuz / Your BMR Result: {bmr}");
Console.WriteLine($"VKI (Vücut Kitle Endeksi) Sonucunuz / Your BMI Result: {bmı}");
Console.WriteLine($"HOMA-IR (İnsülin Direnci) Sonucunuz/ Your HOMA-IR Result: {homaIr}");