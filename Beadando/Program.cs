using System.Runtime.CompilerServices;

string previlagehozza = "";

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

string bejelentkezesfej = "Username/Password/Privileges\n" + "sysadmin/Menojelszo21/Admin";
if (!File.Exists("bejelentkezes.txt"))
{
    File.WriteAllText("bejelentkezes.txt", bejelentkezesfej);
    File.SetAttributes("bejelentkezes.txt",FileAttributes.Hidden);
}


void bekerauto()
{
    Console.WriteLine("-----------------");

    int sorszam = File.ReadAllLines("../Fileok/autoadatok.txt").Length;

    Console.Write("Márka: ");
    string marka = Console.ReadLine();

    while (marka.Any(char.IsDigit) || string.IsNullOrWhiteSpace(marka))
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


    Console.Write("Rendszáma: ");
    string rendszam = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(rendszam))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Rendszám: ");
        rendszam = Console.ReadLine();
    }



    Console.Write("Szín: ");
    string szin = (Console.ReadLine());

    while (szin.Any(char.IsDigit) || string.IsNullOrWhiteSpace(szin))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Szín: ");
        szin = Console.ReadLine();
    }



    List<string> autolista = new() { sorszam + "," + marka + "," + tipus + "," + rendszam + "," + szin };
    File.AppendAllLines("../Fileok/autoadatok.txt", autolista);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}



void bekerember()
{
    Console.WriteLine("-----------------");

    int sorszam = File.ReadAllLines("../Fileok/emberadatok.txt").Length;

    Console.Write("Név: ");
    string nev = Console.ReadLine();

    while (nev.Any(char.IsDigit) || string.IsNullOrWhiteSpace(nev))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Név: ");
        nev = Console.ReadLine();
    }



    Console.Write("Neme: ");
    string nem = (Console.ReadLine());

    while (nem.Any(char.IsDigit) || string.IsNullOrWhiteSpace(nem))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Neme: ");
        nem = Console.ReadLine();
    }



    Console.Write("Kor: ");
    string kor = (Console.ReadLine());

    while (kor.Any(char.IsLetter) || string.IsNullOrWhiteSpace(kor))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Kor: ");
        kor = Console.ReadLine();
    }



    Console.Write("Hajszín / Kopasz: ");
    string hajszin = Console.ReadLine();

    while (hajszin.Any(char.IsDigit) || string.IsNullOrWhiteSpace(hajszin))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Hajszín: ");
        hajszin = Console.ReadLine();
    }



    Console.Write("Igazolványszám: ");
    string igazolvanyszam = (Console.ReadLine());

    while (hajszin.Any(char.IsDigit) || string.IsNullOrWhiteSpace(hajszin))
    {
        Console.WriteLine("---Helytelen megadás---");
        Console.Write("Hajszín: ");
        hajszin = Console.ReadLine();
    }



    List<string> emberadatok = new() { sorszam + "," + nev + "," + nem + "," + kor + "," + hajszin + "," + igazolvanyszam };
    File.AppendAllLines("../Fileok/emberadatok.txt", emberadatok);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}

//Vége a mesének
//----------------------------------------------------------------------------

void beker()
{
    Console.Write("Ember vagy Autó érkezett(1. ember 2.autó)? ");
    byte bekerki = 0;

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
    }
}



void hozzaad()
{
    Console.Write("Mi legyen a felhasználónév: ");
    string felhasznalohozza = Console.ReadLine();

    Console.Write("Mi legyen a jelszo: ");
    string jelszohozza = Console.ReadLine();

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
}


Console.WriteLine("Kérem jelentkezzen be");
Console.Write("Felhasználónév: ");
string username = Console.ReadLine();

Console.Write("Jelszó: ");
string jelszo = Console.ReadLine();

bool bejelentkezett = false;
byte muvelet = 1;

if (File.Exists("bejelentkezes.txt"))
{
    string[] sorok = File.ReadAllLines("bejelentkezes.txt");

    foreach (string sor in sorok.Skip(1))
    {
        string[] reszek = sor.Split("/");
        if (reszek[0] == username)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (reszek[1] == jelszo)
                {
                    bejelentkezett = true;
                }
                else
                {
                    Console.WriteLine($"Helytelen jelszó, próbálja újra, {3 - i} próbálkozás van hátra!");
                    Console.Write("kérem a jelszót újra: ");
                    jelszo = Console.ReadLine();
                }
                if (bejelentkezett == true)
                {
                    Console.WriteLine("Üdvözöljük!");
                    if (reszek[2] == "Admin")
                    {
                        while (muvelet != 0)
                        {
                            Console.Write("Milyen műveletet csinál (1.beírás 2.egy meglévő felülírása 3.új felhasználó hozzáadása 0.kilép): ");
                            muvelet = byte.Parse(Console.ReadLine());
                            if (muvelet == 1)
                            {
                                beker();
                            }
                            if (muvelet == 2)
                            {
                                //modosit();
                            }
                            if (muvelet == 3)
                            {
                                hozzaad();
                            }
                        }
                    }
                    else
                    {
                        while (muvelet != 0)
                        {
                            Console.Write("Milyen műveletet csinál (1.beírás 0.kilép): ");
                            muvelet = byte.Parse(Console.ReadLine());
                            if (muvelet == 1)
                            {
                                beker();
                            }
                        }
                    }
                    Console.WriteLine("Viszont Látásra!");
                    break;
                }
            }
        }
    }
}