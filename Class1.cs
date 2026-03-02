//EndocrineCalculator.Lib(DLL kütüphanesi)
/* * UYARI: Bu kütüphane sadece eğitim ve bilgilendirme amaçlıdır. 
 * Tıbbi kararlarda veya klinik ortamlarda kullanılmak üzere tasarlanmamıştır.
 */
namespace EndocrineCalculator.Lib
{
    public static class HealthCalculator
    {
        // 1. HbA1c'den Tahmini Ortalama Glikoz (eAG)
        public static decimal CalculateEAG(decimal hba1c)
        {
            return (hba1c * 28.7m) - 46.7m;
        }

        // 2. HOMA-B (Pankreas Fonksiyonu)
        public static decimal CalculateHomaB(decimal fastingGlucose, decimal fastingInsulin)
        {
            // Tıbbi Düzeltme: mg/dL birimi için pay 360 olmalı. 
            // Güvenlik: Payda 0 veya negatif olmamalı.
            if (fastingGlucose <= 63m) return 0;
            return (360m * fastingInsulin) / (fastingGlucose - 63m);
        }

        // 3. HOMA-S (İnsülin Duyarlılığı)
        public static decimal CalculateHomaS(decimal fastingGlucose, decimal fastingInsulin)
        {
            decimal homaIr = (fastingGlucose * fastingInsulin) / 405m;
            // Güvenlik: Sıfıra bölme kontrolü
            if (homaIr == 0) return 0;
            return 100m / homaIr;
        }

        // 4. BAI (Vücut Yağlılık Endeksi)
        public static decimal CalculateBAI(decimal hipCircumference, decimal heightCm)
        {
            // Güvenlik: Boy 0 girilirse çökmemesi için
            if (heightCm == 0) return 0;
            double hM = (double)heightCm / 100.0;
            double hip = (double)hipCircumference;
            double sonuc = (hip / Math.Pow(hM, 1.5)) - 18.0;
            return (decimal)sonuc;
        }

        // 5. LAP (Lipid Birikim Ürünü)
        public static decimal CalculateLAP(string gender, decimal waistCircumference, decimal triglycerides)
        {
            decimal faktor = (gender == "M") ? 65m : 58m;
            decimal result = (waistCircumference - faktor) * triglycerides;
            // Tıbbi Düzeltme: Sonuç negatif çıkarsa 0 kabul edilir.
            return result < 0 ? 0 : result;
        }

        // 6. FFMI (Yağsız Kütle Endeksi)
        public static decimal CalculateFFMI(decimal weight, decimal heightCm, decimal bodyFatPercentage)
        {
            if (heightCm == 0) return 0;
            decimal heightM = heightCm / 100m;
            decimal leanMass = weight * (1 - bodyFatPercentage / 100m);
            return leanMass / (heightM * heightM);
        }

        // 7. WHtR (Bel/Boy Oranı)
        public static decimal CalculateWHtR(decimal waistCircumference, decimal heightCm)
        {
            if (heightCm == 0) return 0;
            return waistCircumference / heightCm;
        }

        // 8. WHR (Bel/Kalça Oranı)
        public static decimal CalculateWHR(decimal waistCircumference, decimal hipCircumference)
        {
            if (hipCircumference == 0) return 0;
            return waistCircumference / hipCircumference;
        }

        // 9. TDEE (Günlük Enerji Harcaması)
        public static decimal CalculateTDEE(decimal bmr, decimal activityFactor)
        {
            return bmr * activityFactor;
        }

        // 10. QUICKI Metodu
        public static decimal CalculateQUICKI(decimal fastingGlucose, decimal fastingInsulin)
        {
            // Güvenlik: Logaritma 0 veya negatif sayılarla çalışmaz.
            if (fastingGlucose <= 0 || fastingInsulin <= 0) return 0;
            double logG = Math.Log10((double)fastingGlucose);
            double logI = Math.Log10((double)fastingInsulin);
            return (decimal)(1.0 / (logG + logI));
        }

        // 11. Homa-IR (İnsülin Direnci)
        public static decimal CalculateHomaIR(decimal fastingGlucose, decimal fastingInsulin)
        {
            return (fastingGlucose * fastingInsulin) / 405m;
        }

        // 12. BMI (Vücut Kitle Endeksi)
        public static decimal CalculateBMI(decimal weight, decimal heightCm)
        {
            if (heightCm == 0) return 0;
            decimal heightM = heightCm / 100m;
            return weight / (heightM * heightM);
        }

        // 13. BMR (Metabolizma Hızı)
        public static decimal CalculateBMR(string gender, decimal weight, decimal heightCm, int age)
        {
            if (gender == "M")
                return 88.362m + (13.397m * weight) + (4.799m * heightCm) - (5.677m * age);

            return 447.593m + (9.247m * weight) + (3.098m * heightCm) - (4.330m * age);
        }
    }
}

/* =====================================================================================
 HASTA TEŞHİS VE ANALİZ İÇİN GEREKLİ VERİ LİSTESİ:
=====================================================================================
1. HOMA (IR, Beta, S) ve QUICKI: Açlık Kan Şekeri (mg/dL) + Açlık İnsülini (uIU/mL)
2. LAP (Yağ Birikimi): Cinsiyet + Bel Çevresi (cm) + Trigliserid (mg/dL)
3. BMI ve BMR: Cinsiyet + Yaş + Kilo (kg) + Boy (cm)
4. BAI ve WHR: Kalça Çevresi (cm) + Bel Çevresi (cm) + Boy (cm)
5. eAG (Ortalama Şeker): HbA1c (%)
6. FFMI (Kas Kütlesi): Kilo (kg) + Boy (cm) + Vücut Yağ Oranı (%)
7. TDEE: Bazal Metabolizma Hızı (BMR) + Aktivite Seviyesi (Katsayı)
=====================================================================================
*/