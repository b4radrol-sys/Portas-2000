Console.WriteLine("Jelentkezzen be (Felhasználónév, Jelszó)");
Console.Write("kérem a felhasználónevet: ");
string username = Console.ReadLine();

Console.Write("kérem a jelszót: ");
string jelszo = Console.ReadLine();


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
            for (int i = 0;i < 3; i++)
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
                    Console.WriteLine($"Helytelen jelszó, próbálja újra{3-proba}próbálkozás maradt!");
                    Console.Write("kérem a jelszót újra: ");
                    jelszo = Console.ReadLine();
                }
            }
        }
    }
}

/*
void bekerauto()
{
    Console.Write("Márka: ");
    string marka = Console.ReadLine();

    Console.Write("Tipus: ");
    string tipus = Console.ReadLine();

    Console.Write("Rendszáma: ");
    string rendszam = Console.ReadLine();

    Console.Write("Szín: ");
    string szin = (Console.ReadLine());
}

bekerauto();


// auto -> True; False


void belepes()
{
    Console.WriteLine("Üdvözöljük!"){

    }
}
*/