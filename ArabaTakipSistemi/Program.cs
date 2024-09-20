using ArabaTakipSistemi.Contexts;
using ArabaTakipSistemi.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaTakipSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            baslangıc();
            Console.ReadLine();
        }
        private static void GirisYap()
        {
            using (var giris = new AracTakip())
            {
                Console.Write("Kullanici Adınızı Girin: ");
                string ad = Console.ReadLine();
                Console.Write("Şifrenizi Girin: ");
                string sifre = Console.ReadLine();

                var result = giris.kullanicilar.FirstOrDefault(x => x.KullanicAdi == ad && x.Sifre == sifre);

                if (result != null)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giriş başarılı!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("------------------------------");

                    Console.WriteLine("Hoş geldin" + " " + result.Ad + "! " + "Yapmak istedğin işlem nedir?");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("1-Araba Listesini Gör");
                    Console.WriteLine("2-Araba Kirala");
                    Console.WriteLine("3-Fiyat Hakkında Bilgi");
                    string secim = Console.ReadLine();
                    switch (secim)
                    {
                        case "1":
                            AracListe();
                            Console.WriteLine("Geri Dönmek için 1'e basın..");
                            string sec = Console.ReadLine();
                            switch (sec)
                            {
                                case "1":
                                    Console.WriteLine("1-Araba Listesini Gör");
                                    Console.WriteLine("2-Araba Kirala");
                                    Console.WriteLine("3-Fiyat Hakkında Bilgi");
                                    string secim2 = Console.ReadLine();
                                    switch (secim2)
                                    {
                                        case "1":
                                            AracListe();
                                            break;

                                        case "2":
                                            Kirala();
                                            break;
                                        case "3":
                                            Bilgi();
                                            break;

                                        default:
                                            Console.WriteLine("Geçerli İşlem Yapınız..");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Geçerli İşlem Yapın");
                                    break;
                            }

                            break;

                        case "2":
                            Kirala();
                            break;

                        case "3":
                            Bilgi();
                            break;

                        default:
                            Console.WriteLine("Geçerli İşlem Yapınız..");
                            break;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kullanıcı adı veya şifre yanlış.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        private static void AracListe()
        {
            using (var liste = new AracTakip())
            {
                List<Araba> arabalar = liste.arabalar.ToList();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Şirketimizdeki Araçların Listesi");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------");
                Console.WriteLine(" ID " + " | " + " Marka " + " | " + " Model " + " | " + " Yıl " + " | " + " Yakıt " + " | " + " Fiyat ");
                Console.WriteLine("-------------------------------------------------");
                foreach (var araba in arabalar)
                {
                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", araba.Kod, "     ", araba.Marka, "     ", araba.Model, "    ", araba.Yıl, "    ", araba.Yakıt, "    ", araba.Fiyat);
                }
            }
        }
        private static void Kirala()
        {
            using (var kirala = new AracTakip())
            {
                AracListe();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Kiralamak İstediğiniz Aracın ID'sini girin.");
                Araba araba = kirala.arabalar.Find(Console.ReadLine());
                kirala.arabalar.Remove(araba);
                kirala.SaveChanges();


                Console.Write("Kullanıcı Adınızı Girin: ");
                string ad = Console.ReadLine();

                Console.Write("Araba Markasını Girin: ");
                string marka = Console.ReadLine();

                Console.Write("Araba Modeli Girin: ");
                string model = Console.ReadLine();
                
                Random rnd = new Random();
                int sayi = rnd.Next(1000, 9999);
                Console.WriteLine("Doğrulama Kodunuz: " + sayi);
                Console.WriteLine("Kod Giriniz");
                string kod = Console.ReadLine();

                İslem islem = new İslem
                {
                    kod = kod,
                    Ad = ad,
                    Marka = marka,
                    Model = model,
                    Tarih = DateTime.Now
                };
                kirala.islemler.Add(islem);
                kirala.SaveChanges();

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(marka + " " + model + " " + "Aracı kiraladınız kazasız sürüşler dileriz...");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Çıkış Yapmak İçin 'q' basınız");
                string cıkıs = Console.ReadLine();
                switch (cıkıs)
                {
                    case "q":
                        baslangıc();
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim...");
                        break;
                }
            }
        }

        private static void Bilgi()
        {
            using (var bilgi = new AracTakip())
            {
                using (var deger = new AracTakip())
                {
                    var min = deger.arabalar.Min(x => x.Fiyat);
                   
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Taban değer: {min}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        var max = deger.arabalar.Max(x => x.Fiyat);
                   
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Tavan değer: {max}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    

                    var ort = deger.arabalar.Average(x => x.Fiyat);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Ortalama değer: {ort}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;



                }
                Console.WriteLine("----------------------");
                Console.WriteLine("Geri Dönmek için 1'e basın..");
                string sec = Console.ReadLine();
                switch (sec)
                {
                    case "1":
                        Console.WriteLine("1-Araba Listesini Gör");
                        Console.WriteLine("2-Araba Kirala");
                        Console.WriteLine("3-Fiyat Hakkında Bilgi");
                        string secim = Console.ReadLine();
                        switch (secim)
                        {
                            case "1":
                                AracListe();
                                break;

                            case "2":
                                Kirala();
                                break;

                            case "3":
                                Bilgi();
                                break;

                            default:
                                Console.WriteLine("Geçerli İşlem Yapınız..");
                                break;


                        }
                        break;
                    default:
                        Console.WriteLine("Geçerli İşlem Yapın");
                        break;
                }
            }
        }
        private static void baslangıc()
        {
            Console.WriteLine("Yıldız Araç Kiralamaya Hoş Geldiniz.. Yapmak İstediğiniz İşlemi Seçin..");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1-Giriş Yap");
            Console.WriteLine("2-Kayıt Ol");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    GirisYap();
                    break;

                case "2":
                    KayıtOl();
                    break;
            }
        }

        private static void KayıtOl()
        {
            using (var takip = new AracTakip())
            {
                Random rnd = new Random();
                int sayi = rnd.Next(1000, 9999);
                Console.WriteLine("ID'niz: " + sayi);
                Console.WriteLine("ID Giriniz: ");
                string kod = Console.ReadLine();

                Console.WriteLine("Adınızı Giriniz: ");
                string ad = Console.ReadLine();

                Console.WriteLine("Kullanıcı Adınızı Giriniz: ");
                string kulad = Console.ReadLine();

                Console.WriteLine("Şifrenizi Giriniz: ");
                string sifre = Console.ReadLine();

                Console.WriteLine("Şehrinizi Giriniz: ");
                string sehir = Console.ReadLine();

                Console.WriteLine("Mesleğinizi Giriniz: ");
                string meslek = Console.ReadLine();


                Kullanici kullanici = new Kullanici
                {
                    Kod = kod,
                    Ad = ad,
                    KullanicAdi = kulad,
                    Sifre = sifre,
                    Şehir = sehir,
                    Meslek = meslek
                };
                takip.kullanicilar.Add(kullanici);
                takip.SaveChanges();
                Console.WriteLine("------------------");
                Console.WriteLine("Başarıyla Kayıt Oldunuz.");
                baslangıc();
            }
        }

        private static void List()
        {
            using (var takip = new AracTakip())
            {

                List<Kullanici> kullanicilar = takip.kullanicilar.ToList();
                Console.WriteLine(" İsim " + " | " + " Kullanıcı Adı " + " | " + " Meslek ");
                Console.WriteLine("-------------------------------------------------");
                foreach (var kullanici in kullanicilar)
                {
                    Console.WriteLine("{0},{1},{2},{3},{4}", kullanici.Ad, "       ", kullanici.KullanicAdi, "       ", kullanici.Meslek);
                }
            }
        }
    }
   
}
