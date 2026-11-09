using System.Buffers.Binary;
using System.Net;

string previlagehozza = "";


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