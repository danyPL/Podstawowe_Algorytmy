using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Alogrytmy
{
    public class Program
    {

        //  Zasada działania algorytmu:
        //  1. Jeśli liczba podana jest mniejsza niż 2, nie jest ona liczbą pierwszą
        //  2. Jeżeli liczba jest większa, bądź równa 2, algorytm sprawdza, czy dana liczba dzieli się bez
        //  reszty przez jakąkolwiek liczbę w zakresie od 2 do pierwiastka kwadratowego z tej
        //  liczby.Jeśli znajdzie taki dzielnik, liczba nie jest pierwsza.Jeśli nie znajdzie żadnego
        //  dzielnika, oznacza to, że liczba jest pierwsza.

        static Action<int> Zad1 = (n) =>
        {
            Console.WriteLine("Zadanie: Sprawdzanie czy liczba jest liczbą pierwszą");
            if(n < 2)
            {
                Console.WriteLine("liczba nie jest liczbą pierwszą");
            }
            for (int i = 2; i < n; i++) {
                if (n % i == 0) {
                    Console.WriteLine($"{n} nie jest liczba pierwszą\n");
                    return;
                }
            
            }
            Console.WriteLine($"Liczba {n} jest liczbą pierwszą");
        };
        //  Zasada działania algorytmu:
        // Algorytm Euklidesa służy do wyznaczania największego wspólnego dzielnika (NWD) dwóch liczb.
        // 1. Wejście: Dwie liczby całkowite a oraz b
        // 2. Sprawdzanie: Dopóki b nie jest równe zero:
        //      3. Obliczamy resztę z dzielenia a przez b
        //      4. Przypisujemy wartość b do a, a resztę z dzielenia tych liczb do b
        // 3. Wyjście: Kiedy b stanie się równe 0, liczba a jest największym wspólnym dzielnikiem.

        static Action<int, int> Zad2 = (a, b) =>
        {
            Console.WriteLine("Algorytm Euklidesa\r\n");
            while (b != 0)
            {
                int reszta = a % b;
                a = b;
                b = reszta;
            }
            if (b == 0) Console.WriteLine($"Liczba {a} jest najwiekszym wspólnym dzielnikem");
        };
        //  Zasada działania algorytmu:
        // Szyfr Cezara to jeden z najstarszych i najprostszych szyfrów, opierający się na przesunięciu liter w
        //alfabecie o stałą liczbę miejsc.Dla przykładu, jeśli przesuniemy litery o 3 miejsca, to 'A' stanie się
        //'D', 'B' stanie się 'E', i tak dalej.Przy końcu alfabetu, litery są "owijane" wokół, co oznacza, że po
        //'Z' wracamy do 'A'.


        // 1. Wejście: Tekst do zaszyfrowania i klucz (liczba), który określa, o ile miejsc w alfabecie przesuniemy litery.
        // 2. Przesunięcie liter: Dla każdej litery w tekście, zamieniamy ją na literę, która jest przesunięta
        //    o wartość klucza w alfabecie.
        // 3. Obsługa końców alfabetu: Jeśli przesunięcie wykracza poza 'Z', zaczynamy od początku alfabetu('A').
        static Action<string,int> Zad3 = (text,key) =>
        {
            Console.WriteLine("Zadanie Szyfr Cezara");
                       string txt = "";
            string decrypted = "";
            Func<char, int, char> przesunZnak = (z, klucz) =>
            {
                if (char.IsUpper(z)) {
                    return (char)((((z - 'A') + klucz) % 26) + 'A');
                }else if (char.IsLower(z))
                {
                    return (char)((((z - 'a') + klucz) % 26) + 'a');

                }
                else 
                    return z;
            };
       
            foreach (char c in text) {
                txt += przesunZnak(c,key);
            }
          
            Console.WriteLine($"Zaszyfrowany tekst: {txt}");
            
        };

        //  Zasada działania algorytmu:
        //  Ciąg Fibonacciego to sekwencja liczb, w której każda liczba jest sumą dwóch poprzednich, gdzie
        //  pierwsze liczby w ciągu to 0 oraz 1. Ogólnie dla n ≥ 2, ciąg Fibonacciego jest definiowany jako:
        //  F(n) = F(n−1) + F(n−2)
        // 1. Rozpocznij od dwóch pierwszych elementów
        // 2. Aby obliczyć kolejne elementy, użyj wzoru wypisanego wyżej
        // 3. Program przestaje liczyć dalej, kiedy osiągnie element n, który został podany przez użytkownika.
        static Action<int> Zad4 = (n) =>
        {
            Console.WriteLine("Zadanie Znajdowanie liczb w ciagu fibonacciego")
            ;
            static int fib(int n)
            {
                if (n < 2)
                    return n;
                return fib(n - 1) + fib(n - 2);
            }
            for( int i = 0; i < n; i++)
            {
                Console.WriteLine("Ciag fibbonaciego");
                Console.Write($"{n + 1}, {fib(n)} ");
            }
        };
        //  Zasada działania algorytmu:
        // Rozkład liczby na czynniki pierwsze polega na podzieleniu jej na możliwie najmniejsze liczby
        // pierwsze, które po pomnożeniu dają liczbę wyjściową.Na przykład rozkład liczby 60 na czynniki
        // pierwsze to 60=22 
        // ⋅ ⋅ ⋅ ⋅ ⋅ 3 5, ponieważ 2, 3 i 5 są liczbami pierwszymi, a 60=2 2 3 5.
        // 1. Wejście: Liczba n, którą chcemy rozłożyć na czynniki pierwsze.
        // 2. Algorytm dzieli n przez najmniejsze liczby pierwsze, zaczynając od 2, aż liczba n stanie się
        //. równa 1. Aby zwiększyć efektywność, możemy sprawdzać podzielność tylko do pierwiastka
        //  kwadratowego z liczby, ponieważ jeśli liczba ma dzielnik większy od swojego pierwiastka,
        //  to drugi dzielnik musi być mniejszy.

        static Action<int> Zad5 = (n) =>
        {

            Console.WriteLine($"\nZadanie Rozkład liczby na czynniki pierwsze:\n");

            Console.WriteLine($"Rozkład liczby {n} na czynniki pierwsze");

            while (n % 2 == 0)
            {
                Console.Write($"{2} ");
                n /= 2;
            }

            for (int i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    Console.Write($"{i} ");
                    n /= i;
                }
            }

            if (n > 1) Console.Write($"{n}"); 

            Console.WriteLine();
        };
        //  Zasada działania algorytmu:
        // Znajdowanie najmniejszego i największego elementu w zbiorze liczb to bardzo proste, ale
        // użyteczne zadanie.Aby znaleźć te elementy, iterujemy przez zbiór, porównując każdy element z
        // aktualnie najmniejszym i największym elementem, które zainicjujemy odpowiednimi wartościami
        // na początku.
        // 1. Zakładamy, że pierwszy element zbioru jest zarówno najmniejszy, jak i największy.
        // 2. Dla każdego elementu porównujemy go z bieżącym najmniejszym i największym
        //    elementem.Jeśli jest mniejszy od bieżącego najmniejszego, aktualizujemy najmniejszy
        //    element.Jeśli jest większy od bieżącego największego, aktualizujemy największy element.
        // 3. Po przetworzeniu wszystkich elementów zwracamy znalezione wartości.
        static Action<int[]> Zad6 = (liczby) =>
        {
            Console.WriteLine($"\nZadanie Znajdowanie Najwiekszej i Najmnieszej liczby w tabeli:\n");

            int min = liczby[0];
            int max = 0;
            
           for(int i = 0; i < liczby.Length; i++)
            {
            
                if (liczby[i] < min)
                {
                    min = liczby[i];
                }
                else if (liczby[i] > max) {
                    max = liczby[i];
                }
            }
            Console.WriteLine("Najmniejszy i Największy element w zbiorze:");
            foreach (int i in liczby) {
                Console.Write($"{i}, ");
            }
            Console.WriteLine($"To {min} i {max}");
        };
        //  Zasada działania algorytmu:
        // Sortowanie bąbelkowe(ang.bubble sort) to prosty algorytm sortowania, który działa, porównując
        // sąsiadujące ze sobą elementy w zbiorze i zamieniając je miejscami, jeśli są w złej kolejności.
        // Proces ten jest powtarzany wielokrotnie, aż cała lista zostanie posortowana.
        // 1. Algorytm przechodzi przez zbiór elementów i porównuje każdą parę sąsiadujących elementów.
        // 2. Jeśli element na lewej pozycji jest większy niż element na prawej pozycji, to zamienia je miejscami.
        // 3. Każda iteracja kończy się "wypchnięciem" największego(lub najmniejszego, w zależności od porządku) elementu na odpowiednie miejsce.
        //    Kolejne iteracje poruszają się coraz krócej, ponieważ największe elementy "osiadają" na końcu zbioru.
        // 4. Proces jest powtarzany aż do momentu, gdy w trakcie jednej pełnej iteracji nie dojdzie do żadnej zamiany.

        static Action<int[]> Zad7 = (tab) =>
        {
            Console.WriteLine($"\nZadanie Sortowanie Bąbelkowe:\n");

            int length = tab.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                    int temp = tab[j];
                    tab[j] = tab[j + 1];
                    tab[j + 1] = temp;
                    }
                    
                }
            }


            foreach(int i in tab)
            {
                Console.Write(i + ", ");
            }
        };
        //  Zasada działania algorytmu:
        // Sortowanie przez wybór(ang.selection sort) to prosty algorytm sortowania, który działa poprzez
        // znajdowanie najmniejszego(lub największego) elementu w zbiorze i zamienianie go miejscami z
        // pierwszym elementem.Proces jest powtarzany dla każdego podzbioru elementów, aż cały zbiór zostanie posortowany
        // 1. Algorytm przechodzi przez zbiór elementów i znajduje najmniejszy element.
        // 2. Po znalezieniu najmniejszego elementu, zamienia go z pierwszym elementem w zbiorze.
        // 3. Proces jest powtarzany dla pozostałej części zbioru (pomijając już posortowane elementy), 
        //    czyli algorytm ponownie szuka najmniejszego elementu w pozostałych elementach i zamienia go z następnym w kolejności miejscem.
        // 4. Algorytm kończy pracę, gdy wszystkie elementy zostaną posortowane
        static Action<int[]> Zad8 = (tab) =>
        {
            Console.WriteLine($"\nZadanie Sortowanie przez wybieranie:\n");

            for (int i = 0; i < tab.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < tab.Length; j++)
                    if (tab[j] < tab[min])
                        min = j;

                int temp = tab[min];
                tab[min] = tab[i];
                tab[i] = temp;
            }
            foreach (int i in tab)
            {
                Console.Write(i + ", ");
            }
        };
        //  Zasada działania algorytmu:
        // Sortowanie przez wstawianie(ang.insertion sort) to prosty algorytm sortowania, który działa
        // poprzez budowanie posortowanego zbioru elementów, jeden element na raz.Algorytm wybiera
        // element z nieposortowanej części zbioru i wstawia go na odpowiednie miejsce w części posortowanej
        // 1. Lista elementów jest podzielona na dwie części – posortowaną i nieposortowaną.Na
        //    początku posortowana część składa się tylko z pierwszego elementu.
        // 2. Algorytm bierze pierwszy element z nieposortowanej części i wstawia go w odpowiednie miejsce w posortowanej części.
        // 3. Powtarza ten proces dla każdego kolejnego elementu z nieposortowanej części, aż cała lista zostanie posortowana.
        // 4. Proces kończy się, gdy wszystkie elementy znajdują się w posortowanej części.
        static Action<int[]> Zad9 = (tab) =>
        {
            Console.WriteLine($"\nZadanie Sortowanie przez wstawianie:\n");

            for (int i = 1; i < tab.Length; i++)
            {
                int current = tab[i];
                int j = i - 1;
                while(j>=0 && tab[j] > current)
                {
                    tab[j + 1] = tab[j];
                }
                tab[j + 1] = current;
            }
            foreach (int i in tab)
            {
                Console.Write(i + ", ");
            }

        };
        static void Main(string[] args)
        {
            Zad1(4);
            Zad2(10,7);
            Zad3("TESTOWY",2);
            Zad4(4);
            Zad5(144);
            int[] n = { 4, 12, 5, 1, 8, 30, 182, 3, 6, 14, 28, 50, 13 };
            Zad6(n);
            Zad7(n);
            Zad8(n);
        }
    }
}