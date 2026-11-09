string previlagehozza = "";

Directory.CreateDirectory("../Fileok");
//----------------------------------------------------------------------------
//Innen Roland jön
string autofejlec = "ID, Márka, Tipus, Rendszám, Szín \n";
if (!File.Exists("../Fileok/autoadatok.txt"))
{
    File.WriteAllText("../Fileok/autoadatok.txt", autofejlec);
}

string emberfejlec = "ID, Név, Neme, Kor, Hajszín, Igazolványszám \n";
if (!File.Exists("../Fileok/emberadatok.txt"))
{
    File.WriteAllText("../Fileok/emberadatok.txt", emberfejlec);
}

string bejelentkezesfej = "Username/Password/Privileges\n" + "sysadmin/Menojelszo21/Admin\n";
if (!File.Exists("bejelentkezes.txt"))
{
    File.WriteAllText("bejelentkezes.txt", bejelentkezesfej);
    File.SetAttributes("bejelentkezes.txt", FileAttributes.Hidden);
}


void bekerauto()
{
    Console.WriteLine("-----------------");

    DateTime mostani = DateTime.Now;

    Console.Write("Márka: ");
    string marka = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(marka) || marka.Any(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Márka: ");
        marka = Console.ReadLine();
    }

    Console.Write("Tipus: ");
    string tipus = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(tipus))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Tipus: ");
        tipus = Console.ReadLine();
    }


    Console.Write("Rendszám: ");
    string rendszam = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(rendszam))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Rendszám: ");
        rendszam = Console.ReadLine();
    }

    Console.Write("Szín: ");
    string szin = (Console.ReadLine());

    while (string.IsNullOrWhiteSpace(szin) || szin.Any(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Szín: ");
        szin = Console.ReadLine();
    }



    List<string> autolista = new() { mostani.ToString("yyyy-MM-dd_HH:mm:ss") + "," + marka + "," + tipus + "," + rendszam + "," + szin };
    File.AppendAllLines("../Fileok/autoadatok.txt", autolista);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}


void bekerember()
{
    Console.WriteLine("-----------------");

    DateTime mostani = DateTime.Now;

    Console.Write("Név: ");
    string nev = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(nev) || nev.Any(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Név: ");
        nev = Console.ReadLine();
    }



    Console.Write("Neme: ");
    string nem = (Console.ReadLine());

    while (string.IsNullOrWhiteSpace(nem) || nem.Any(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Neme: ");
        nem = Console.ReadLine();
    }



    Console.Write("Kor: ");
    string kor = (Console.ReadLine());

    while (string.IsNullOrWhiteSpace(kor) || !kor.All(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Kor: ");
        kor = Console.ReadLine();
    }



    Console.Write("Hajszín / Kopasz: ");
    string hajszin = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(hajszin) || hajszin.Any(char.IsDigit))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Hajszín: ");
        hajszin = Console.ReadLine();
    }



    Console.Write("Igazolványszám: ");
    string igazolvanyszam = (Console.ReadLine());

    while (string.IsNullOrWhiteSpace(igazolvanyszam))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Igazolványszám: ");
        igazolvanyszam = Console.ReadLine();
    }



    List<string> emberadatok = new() { mostani.ToString("yyyy-MM-dd_HH:mm:ss") + "," + nev + "," + nem + "," + kor + "," + hajszin + "," + igazolvanyszam };
    File.AppendAllLines("../Fileok/emberadatok.txt", emberadatok);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}

void keresfajlban(string fajl, int oszlop, string keresett, string[] cimkek)
{
    string[] adatsorok = File.ReadAllLines(fajl);
    bool volt = false;

    foreach (string adatsor in adatsorok.Skip(1))
    {
        string[] adat = adatsor.Split(",");
        if (adat.Length == cimkek.Length && adat[oszlop].ToLower().Contains(keresett.ToLower()))
        {
            Console.WriteLine("-----------------");
            for (int i = 0; i < adat.Length; i++)
            {
                Console.WriteLine(cimkek[i] + ": " + adat[i]);
            }
            volt = true;
        }
    }

    if (!volt)
    {
        Console.WriteLine("Nincs találat.");
    }
    Console.WriteLine("-----------------");
}


void keres()
{
    string[] emberek = { "Időpont", "Név", "Neme", "Kor", "Hajszín", "Igazolványszám" };
    string[] autok = { "Időpont", "Márka", "Tipus", "Rendszám", "Szín" };

    string valasz = "";
    while (valasz != "0")
    {
        Console.Write("Mi alapján keres (1.személy neve 2.rendszám 3.típus 4.márka 0.vissza): ");
        valasz = Console.ReadLine();

        if (valasz == "1")
        {
            Console.Write("Név: ");
            keresfajlban("../Fileok/emberadatok.txt", 1, Console.ReadLine(), emberek);
        }
        else if (valasz == "2")
        {
            Console.Write("Rendszám: ");
            keresfajlban("../Fileok/autoadatok.txt", 3, Console.ReadLine(), autok);
        }
        else if (valasz == "3")
        {
            Console.Write("Típus: ");
            keresfajlban("../Fileok/autoadatok.txt", 2, Console.ReadLine(), autok);
        }
        else if (valasz == "4")
        {
            Console.Write("Márka: ");
            keresfajlban("../Fileok/autoadatok.txt", 1, Console.ReadLine(), autok);
        }
        else if (valasz != "0")
        {
            Console.WriteLine("Nincs ilyen lehetőség, írja be újra!");
        }
    }
}
//Vége a dalnak
//----------------------------------------------------------------------------

void beker()
{
    Console.Write("Ember vagy Autó érkezett(1. ember 2.autó)? ");
    byte bekerki = 0;
    while (bekerki != 1 && bekerki != 2)
    {

        bekerki = byte.Parse(Console.ReadLine());
        if (bekerki == 1)
        {
            bekerember();
        }
        else if (bekerki == 2)
        {
            bekerauto();
        }
        else
        {
            Console.WriteLine("Nem jót adott meg");
            Console.Write("Ember vagy Autó érkezett(1. ember 2.autó)? ");
        }
    }
}



void hozzaad()
{
    Console.Write("Mi legyen a felhasználónév: ");
    string felhasznalohozza = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(felhasznalohozza))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Mi legyen a felhasználónév: ");
        felhasznalohozza = Console.ReadLine();
    }

    Console.Write("Mi legyen a jelszo: ");
    string jelszohozza = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(jelszohozza))
    {

        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Mi legyen a jelszo: ");
        jelszohozza = Console.ReadLine();
    }


    Console.Write("Mi legyen a felhasználó jogköre (1.Admin 0.User): ");
    byte previlage = byte.Parse(Console.ReadLine());
    if (previlage == 1)
    {
        previlagehozza = "Admin";
    }
    else
    {
        previlagehozza = "User";
    }

    File.AppendAllText("bejelentkezes.txt", $"{felhasznalohozza}/{jelszohozza}/{previlagehozza}\n");
    Console.WriteLine("---Sikeresen hozzáadva---");
}


Console.WriteLine("Kérem jelentkezzen be");
Console.Write("Felhasználónév: ");
string username = Console.ReadLine();

Console.Write("Jelszó: ");
string jelszo = Console.ReadLine();

bool bejelentkezett = false;
byte muvelet = 1;
string[] talalt = null;

string[] sorok = File.ReadAllLines("bejelentkezes.txt");

foreach (string sor in sorok.Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        continue;
    }

    string[] reszek = sor.Split("/");
    if (reszek.Length == 3 && reszek[0] == username)
    {
        talalt = reszek;
        break;
    }
}

if (talalt == null)
{
    Console.WriteLine("Nincs ilyen felhasználó!");
}
else
{
    for (int i = 1; i <= 3; i++)
    {
        if (talalt[1] == jelszo)
        {
            bejelentkezett = true;
            break;
        }

        Console.WriteLine($"Helytelen jelszó, {3 - i} próbálkozás van hátra!");
        if (i < 3)
        {
            Console.Write("kérem a jelszót újra: ");
            jelszo = Console.ReadLine();
        }
    }

    if (bejelentkezett)
    {
        Console.WriteLine("Üdvözöljük!");

        if (talalt[2] == "Admin")
        {
            while (muvelet != 0)
            {
                Console.Write("Milyen műveletet csinál (1.beírás 2.egy meglévő keresése 3.új felhasználó hozzáadása 0.kilép): ");
                if (!byte.TryParse(Console.ReadLine(), out muvelet))
                {
                    muvelet = 255;
                }

                if (muvelet == 1)
                {
                    beker();
                }
                else if (muvelet == 2)
                {
                    keres();
                }
                else if (muvelet == 3)
                {
                    hozzaad();
                }
                else if (muvelet != 0)
                {
                    Console.WriteLine("Nincs ilyen lehetőség, írja be újra!");
                }
            }
        }
        else
        {
            while (muvelet != 0)
            {
                Console.Write("Milyen műveletet csinál (1.beírás 2. egy meglévő keresése 0.kilép): ");
                if (!byte.TryParse(Console.ReadLine(), out muvelet))
                {
                    muvelet = 255;
                }

                if (muvelet == 1)
                {
                    beker();
                }
                else if (muvelet == 2)
                {
                    keres();
                }
                else if (muvelet != 0)
                {
                    Console.WriteLine("Nincs ilyen lehetőség, írja be újra!");
                }
            }
        }

        Console.WriteLine("Viszont Látásra!");
    }
}