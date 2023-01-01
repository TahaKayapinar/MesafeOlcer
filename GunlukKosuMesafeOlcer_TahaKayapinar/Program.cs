using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GunlukKosuMesafeOlcer_TahaKayapinar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            int adimCM = 0;
            int kosuSaat = 0;
            int dakikaAdim = 0;
            int kosuDakika = 0;
            double toplamAdimSayisi = 0;
            double[] sonuc = new double[1];

            //Timer;
            double toplamSonuc = 0;
            Timer zaman = new Timer();
            zaman.Interval = 1500;
            zaman.Elapsed += gorev;
            

        YenidenBasla:
            try
            {
                try
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*****Bu bir manuel koşu/mesafe uygulama programıdır*****");
                        Console.WriteLine();
                        Console.WriteLine("Farklı hızlardaki koşularınızı, koşu ekleyerek bu program ile toplam koşu miktarınızı hesaplatabilirsiniz");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("1- Koşu eklemek için 1 e basınız...");
                        Console.WriteLine("2- Eklediğiniz koşuların toplam uzunluğunu hesaplatmak için 2 ye basınız...");
                        Console.WriteLine("3- Programı sonlandırmak için 3 e basınız...");
                        Console.WriteLine();

                        Console.WriteLine("Lütfen seçim yapınız");
                        int secim = Convert.ToInt32(Console.ReadLine());

                        if (secim == 1 || secim == 2 || secim == 3)
                        {
                            switch (secim)
                            {
                                case 1:
                                    {
                                        goto KosuEkle;

                                    }
                                case 2:
                                   {
                                        goto ToplamMesafeHesaplama;     
                                    }
                                case 3:
                                        {
                                        goto Kapat;  
                                        }

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen 1-2-3 tuşlarından birine basınız...");
                            Console.ReadKey();
                            goto YenidenBasla;
                        }
                    } while (true);
                                            
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen 1-2-3 tuşlarından birine basınız...");
                    Console.ReadKey();
                    goto YenidenBasla;
                }
                


            KosuEkle:
            TekrarAdimGir:
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ortalama bir adımınız kaç cm dir? CM cinsinden giriniz");
                    adimCM = Convert.ToInt32(Console.ReadLine());
                    if (adimCM < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Bir adım nasıl sıfırdan küçük olabilir? Geri geri mi gidiyorsunuz:) Lütfen tekrar adım cm girişi yapabilir misiniz?");
                        goto TekrarAdimGir;
                    }

                    if (adimCM > 150)
                    {
                        Console.Clear();
                        Console.WriteLine("Bir adım nasıl 1 buçuk metreden büyük olabilir? Adımınız çok mu büyük? Hatalı giriş yaptığınızı düşünüyouz. Lütfen tekrar adım cm giriş yapabilir misiniz?");
                        goto TekrarAdimGir;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Girilen format hatalı. Lütfen sadece rakam cinsinden giriş yapınız. Ör: Bir adımınız 60 cm ise, sadece '60' şeklinde giriş yapınız");
                    goto TekrarAdimGir;
                }
                Console.Clear();

            TekrarDakikaAdimGir:
                try
                {
                    Console.WriteLine("Bir dakikada kaç adım koşarsınız");
                    dakikaAdim = Convert.ToInt32(Console.ReadLine());
                    if (dakikaAdim < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Bir dakikada sıfırdan daha az adım atılamaz Lütfen tekrar giriş yapınız");
                        goto TekrarDakikaAdimGir;
                    }
                    if (dakikaAdim > 1000)
                    {
                        Console.Clear();
                        Console.WriteLine("Bir dakikada bu kadar adım atılamaz, hatalı giriş yaptınız. Lütfen tekrar giriş yapınız");
                        goto TekrarDakikaAdimGir;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Girilen format hatalı. Lütfen sadece rakam cinsinden giriş yapınız. Ör: Bir dakikada 100 adım koşuyorsanız '100' şeklinde giriş yapınız");
                    goto TekrarDakikaAdimGir;
                }
                Console.Clear();

            TekrarKosuSaatGir:
                try
                {
                    Console.WriteLine("Koşu sürenizin saat kısmını giriniz (Ör: 1 saat 35 dk koştuysanız 1 giriniz(saat cinsini))");
                    kosuSaat = Convert.ToInt32(Console.ReadLine());
                    if (kosuSaat < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Sıfırdan daha az saat koşulamaz. Lütfen tekrar giriş yapınız");
                        goto TekrarKosuSaatGir;
                    }
                    if (kosuSaat > 24)
                    {
                        Console.Clear();
                        Console.WriteLine("Bu program günlük koşu mesafesini ölçmektedir. Bir günde 24 saatten daha fazla koşulamaz, lütfen tekrar kaç saat koştuğunuz bilgisini giriniz");
                        goto TekrarKosuSaatGir;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Girilen format hatalı. Lütfen sadece rakam cinsinden giriş yapınız. Ör: Üç saat koştuysanız '3' şeklinde giriş yapınız (dakika bilgisi birazdan sorulacak, dakika bilgisi ile saat bilgisini karıştırmayınız)");
                    goto TekrarKosuSaatGir;
                }
                Console.Clear();




            TekrarKosuDakikaGir:
                try
                {
                    Console.WriteLine("Koşu sürenizin dakika kısmını giriniz (Ör: 1 saat 35 dakika koştuysanız 35 olarak giriniz)");
                    kosuDakika = Convert.ToInt32(Console.ReadLine());
                    if (kosuDakika < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Sıfırdan daha az dakika koşulamaz. Lütfen tekrar giriş yapınız");
                        goto TekrarKosuDakikaGir;
                    }
                    if (kosuDakika > 59)
                    {
                        Console.Clear();
                        Console.WriteLine("60 veya daha fazla dakika girişi yapılamaz. Lütfen tekrar girinziz...");
                        goto TekrarKosuDakikaGir;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Girilen format hatalı. Lütfen sadece rakam cinsinden giriş yapınız. Ör: 1 saat 15 dakika koştuysanız '15' şeklinde giriş yapınız");
                    goto TekrarKosuDakikaGir;
                }
                Console.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hatalı giriş yaptınız, ana ekrana yönlendiriliyorsunuz... Lütfen bir tuşa basınız");
                                Console.ReadKey();
                goto YenidenBasla;
            }

            sonuc[sonuc.Length - 1] = MesafeHesapla(adimCM, dakikaAdim, kosuSaat, kosuDakika);

            Console.Clear();
            Console.WriteLine($"Bu koşudaki toplam koştuğunuz mesafe {sonuc[sonuc.Length - 1]} metredir...");
            Console.ReadKey();

            Array.Resize(ref sonuc, sonuc.Length + 1);

            toplamSonuc = 0;
            for (int i = 0; i < sonuc.Length; i++)
            {
                toplamSonuc = sonuc[i] + toplamSonuc;
               // toplamAdimSayisi = toplamSonuc * 100 / adimCM;
            }

            
            
            goto YenidenBasla;

        ToplamMesafeHesaplama:

            Console.Clear();
            Console.WriteLine($"{now.ToLongDateString()}, saat {now.ToShortTimeString()}'a kadar toplam koştuğunuz mesafe {toplamSonuc} metredir..."); 
            //Console.WriteLine($"Toplam adım sayınız ise = {toplamAdimSayisi} adımdır..."); 
            Console.ReadKey();
            Console.Clear();
            goto YenidenBasla;


        Kapat: 
            Console.Clear();
            Console.WriteLine("...K A P A N I Y O R...");
            zaman.Start();
            Console.ReadKey();
           // Environment.Exit(0);

        }

        



        // F O N K S İ Y O N L A R
        private static float MesafeHesapla(int x, int y, int z, int t)
        {
            int sureHesaplaDk = (z * 60) + t;
            int toplamUzunlukMetre = (sureHesaplaDk * y * x / 100);
            return toplamUzunlukMetre;
        }

        private static void gorev(object source,System.Timers.ElapsedEventArgs Asya)
        {
            Environment.Exit(0);            
        }


    }
}
