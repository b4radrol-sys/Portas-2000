# Autó és Ember kezelő Rendszer 🚗👤

Egy C# alapú  alkalmazás, ami autó, szeméy és fiók kezelésére szolgál. 🤯

---

## Fő funkciók 🛠

* **Felhasználókezelés:** 🐱‍👤
  * Jelszóval védett bejelentkezési rendszer (3 próbával).
  * Fiók erősség:
    * **Admin:** Adatbeírás, adatmódosítás.
    * **User:** Korlátozott adatbevitel.
* **Autók adatainak kezelése:** 🏎
  * Márka, típus, rendszám és szín bekérése.
  * Automatikus ID generálás.
  * Bemeneti adatok érvényesítése (típus- és karakterellenőrzés).
  * Adatok mentése CSV szerkezetű fájlba (`autoadatok.txt`).
* **Személyek adatinak kezelése:** 👲🏾
  * Név, nem, kor, hajszín és igazolványszám mentése.
  * Bemeneti adatok érvényesítése (típus- és karakterellenőrzés).
  * Adatok mentése CSV szerkezetű fájlba (`emberadatok.txt`).

---

## Adattárolási szerkezet 🍫

Az alkalmazás az alábbi `.txt` fájlokban tárolja az adatokat:

| Fájlnév | Formátum / Fejléc | Leírás |
| :--- | :--- | :--- |
| `bejelentkezes.txt` | `Felhasználónév/Jelszó/Jogkör` | Felhasználói erősségek (`Admin` / `User`) |
| `autoadatok.txt` | `ID, Márka, Tipus, Rendszám, Szín` | Rögzített gépjárművek adatai |
| `emberadatok.txt` | `ID, Név, Neme, Kor, Hajszín, Igazolványszám` | Rögzített személyek adatai |

---

### Futtatáshoz szükségek 🔩
* .NET SDK 6.0.

### Futtatás 🏃🏾‍♂️
1. Klónozd vagy töltsd le a projektet.
2. Futtasd le a Program.cs file-t
3. Indítsd el

### Adminoknak utasítás 😘
* Képes vagy módosítani, hozzáadni és szerkeszteni adatokat
