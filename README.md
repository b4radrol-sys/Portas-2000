# Portás Rendszer 2000 🚗👤

Egy egyszerű C# konzolos program portások számára.

---

## Mit tud 🛠

**Bejelentkezés** 🐱‍👤
- Felhasználónévvel és jelszóval lehet belépni. Rossz jelszónál 3 próbálkozás van.
- Két jogkör létezik:
  - **Admin:** adatot rögzíthet, és új felhasználót is felvehet. 
  - **User:** csak adatot rögzíthet.
- Az első indításkor a program létrehoz egy alapértelmezett admin fiókot (`sysadmin`). A jelszót az első belépés után érdemes lecserélni egy sajátra (új admin felvétele után).

**Autó rögzítése** 🏎
- Bekéri a márkát, típust, rendszámot és színt.
- A márka és a szín nem tartalmazhat számot, és egyik mező sem lehet üres.
- Felvitel idejét nyilván tartja.

**Személy rögzítése** 👲🏾
- Bekéri a nevet, nemet, kort, hajszínt (vagy hogy kopasz) és az igazolványszámot.
- A név, nem és hajszín nem tartalmazhat számot, a kor nem tartalmazhat betűt, és egyik mező sem lehet üres.
- Felvitel idejét nyilván tartja.

---

## Menü

| Művelet | Admin | User |
| :--- | :---: | :---: |
| 1 – Beírás (autó vagy ember) | ✔ | ✔ |
| 2 – Meglévő keresése | ✔ | ✔ |
| 3 – Új felhasználó hozzáadása | ✔ | ✘ |
| 0 – Kilépés | ✔ | ✔ |

---

## Hol tárolja az adatokat 🍫

| Fájl | Szerkezet | Tartalom |
| :--- | :--- | :--- |
| `bejelentkezes.txt` | `Felhasználónév/Jelszó/Jogkör` | Felhasználók (rejtett fájl, a program mellett) |
| `../Fileok/autoadatok.txt` | `ID, Márka, Tipus, Rendszám, Szín` | Rögzített autók |
| `../Fileok/emberadatok.txt` | `ID, Név, Neme, Kor, Hajszín, Igazolványszám` | Rögzített személyek |

A `Fileok` mappának léteznie kell a program futtatási mappájához képest egy szinttel feljebb, a program a fájlokat csak létrehozza, a mappát nem.

---

## Futtatás 🏃🏾‍♂️

1. Töltsd le vagy klónozd a projektet.
2. Hozd létre a `Fileok` mappát a fent leírt helyen.
3. A projekt mappájában futtasd: `dotnet run`
4. Jelentkezz be.
