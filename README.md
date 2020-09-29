Zadanie rekrutacyjne - ABB Ability™ Cloud Platform
==================================================

**1. Co ten kod robi?**

Kod ten jest odpowiedzialny za obsługiwanie połączenia klienta z Web API. Adres bazowy, czyli uri wyciągnięty jest z obiektu `_httpClientProxy`, a końcówka uri nie może się znaleźć w tej klasie, gdyż zależy od metody przekazywania danych.
 Celem parsera w tym przypadku jest przekształcenie danych otrzymanych w postaci np. JSON/XML mapując na np. jakiś wcześniej stworzony model danych.

**2. Jakie widać problemy?**

* `using System.Collections.Generic;` - redundantne użycie dyrektywy using (linijki 3 i 4)
* `Variable1` - zmienna nieużywana nigdzie (linjka 14)
* `pleaseProvideFullUrlHere` - niewłaściwa nazwa zmiennej (linijki 30 i 33)
* `TRequest request` - zmienna nieużywana nigdzie (linjka 29)
* `_httpClientProxy` - to pole klasy nie jest zainicjowane w konstruktorze (linjka 18)
* `if(payload == null)` i `if (headers == null)` - warunki nie są obsługiwane (linjki 37 i 47)
* `Exception ex` - brakuje zaimplementowanego Exception (linijka 71)

Poza tym, kod nie jest zbyt czytelny, znajdują się liczne spacje między wieraszami (linijki od 14 do 24)

**3. Co jest fajnego ?**

Podoba mi się, że kod jest rozszerzalny. Nie jest ograniczony do jednego rodzaju parsera czy dla jednego HttpClient. Posiada metody async czyli kod wykona się asynchronicznie. Klasa jest abstrakcynja czyli inne klasy mogą ją zaimplementować i modyfikować. Klasa jest generic co jest bardzo wygodne, jeśli trzeba ją zastosować dla różnych typów.

**4. Jakie widzimy niebezpieczeństwa używając tej metody?**

Występuje duże ryzyko, że jakiś błąd nie będzie obsługiwany. Może zakończyć się to błędem aplikacji. 
Nie wiadomo skąd Endpoint uri pochodzi, w źle zaprojektowanej aplikacji mogłoby dojść do wyodrębniania poufnych danych.

**Podsumowanie

https://docs.microsoft.com/ to najlepszy przyjaciel każdego programisty C#
