using System.Buffers.Binary;
using System.Net;

string previlagehozza = "";


Console.WriteLine("-----------------");

if (File.Exists("bejelentkezes.txt"))
{

    foreach (string sor in File.ReadLines("bejelentkezes.txt").Skip(1))
    {
        string[] reszek = sor.Split("/");
        Console.WriteLine(reszek[0]); // username 
        Console.WriteLine(reszek[1]); // pw
        Console.WriteLine(reszek[2]); // admin
        if (reszek[0] == username)
        {
            for (int i = 0; i < 3; i++)
            {
                int proba = 0;
                if (reszek[1] == jelszo)
                {
                    Console.WriteLine("Üdvözöljük!");
                    break;
                }
                else
                {
                    proba += 1;
                    Console.WriteLine($"Helytelen jelszó, próbálja újra{3 - proba}próbálkozás maradt!");
                    Console.Write("kérem a jelszót újra: ");
                    jelszo = Console.ReadLine();
                }
            }
        }
    }
}







//----------------------------------------------------------------------------
//Innen Roland jön
string autofejlec = "ID, Márka, Tipus, Rendszám, Szín \n";
if (!File.Exists("autoadatok.txt"))
{
    File.WriteAllText("autoadatok.txt", autofejlec);
}

string emberfejlec = "ID, Név, Neme, Kor, Hajszín, Igazolványszám \n";
if (!File.Exists("emberadatok.txt"))
{
    File.WriteAllText("emberadatok.txt", emberfejlec);
}



void bekerauto()
{
    Console.WriteLine("-----------------");

    int sorszam = File.ReadAllLines("autoadatok.txt").Length;

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
    File.AppendAllLines("autoadatok.txt", autolista);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}



void bekerember()
{
    Console.WriteLine("-----------------");

    int sorszam = File.ReadAllLines("emberadatok.txt").Length;

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
    File.AppendAllLines("emberadatok.txt", emberadatok);
    Console.WriteLine("---Sikeresen hozzáadva---");
    Console.WriteLine("-----------------");
}


bekerauto();
bekerember();
//Vége a mesének
//----------------------------------------------------------------------------


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

    File.AppendAllText("bejelentkezes.txt", $"{felhasznalohozza}/{jelszohozza}/{previlagehozza}");
}
hozzaad();

Console.WriteLine("Kérem jelentkezzen be");
Console.Write("Felhasználónév: ");
string username = Console.ReadLine();

Console.Write("Jelszó: ");
string jelszo = Console.ReadLine();

bool bejelentkezett = false;
byte muvelet = 1;

if (File.Exists("bejelentkezes.txt"))
{

    foreach (string sor in File.ReadLines("bejelentkezes.txt").Skip(1))
    {
        string[] reszek = sor.Split("/");
        Console.WriteLine(reszek[0]); // username 
        Console.WriteLine(reszek[1]); // pw
        Console.WriteLine(reszek[2]); // admin
        if (reszek[0] == username)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (reszek[1] == jelszo)
                {
                    Console.WriteLine("Üdvözöljük!");
                    bejelentkezett = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Helytelen jelszó, próbálja újra, {3 - i} próbálkozás van hátra!");
                    Console.Write("kérem a jelszót újra: ");
                    jelszo = Console.ReadLine();
                }
                Console.WriteLine("ASD");
                if (bejelentkezett == true)
                {
                    if (reszek[2] == "Admin")
                    {
                        while (muvelet != 0)
                        {
                            Console.Write("Milyen műveletet csinál (1.beírás 2.egy meglévő felülírása 3.új felhasználó hozzáadása 0.kilép)");
                            muvelet = byte.Parse(Console.ReadLine());
                            if (muvelet == 1)
                            {
                                //beker();
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
                            Console.Write("Milyen műveletet csinál (1.beírás 0.kilép)");
                            muvelet = byte.Parse(Console.ReadLine());
                        }
                        if (muvelet == 1)
                        {
                            //beker();
                        }
                    }

                }
            }
        }
    }
}