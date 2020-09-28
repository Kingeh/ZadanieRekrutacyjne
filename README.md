Zadanie rekrutacyjne - ABB Ability™ Cloud Platform
==================================================

**1. Co ten kod robi?**

Kod ten jest odpowiedzialny za obsługiwanie połączenia klienta z Web API. Adres bazowy, czyli uri wyciągnięty jest z obiektu `_httpClientProxy`, a końcówka uri nie może się znaleźć w tej klasie, gdyż zależy od metody przekazywania danych.
 Celem parsera w tym przypadku jest przekształcenie danych otrzymanych w postaci np. JSON/XML mapując na np. jakiś wcześniej przez nas stworzony model danych.

**2. Jakie widać problemy?**

* `using System.Collections.Generic;` - powtarza się 2 razy za dużo
* `Variable1` - zmienna nieużywana nigdzie
* `pleaseProvideFullUrlHere` - niewłaściwa nazwa zmiennej
* `TRequest request` - zmienna nieużywana nigdzie
* `_httpClientProxy` - członek klasy nie jest zainicjowany w konstruktorze
* `IHttpResponseParser` - w środku klasy abstract nie ma sensu
* `if(payload == null)` i `if (headers == null)` - warunki nie są obsługiwane
* `Exception ex` - brakuje zaimplementowanego Exception

Poza tym, kod nie jest zbyt czytelny, znajdują się liczne spacje między wieraszami

**3. Co jest fajnego ?**

Podoba mi się, że kod jest rozszerzalny. Nie jest ograniczony do jednego rodzaju parsera czy dla jednego HttpClient. Posiada metody async czyli kod wykona się asynchronicznie czyli nie powstaną tzw. "bottlenecki".

**4. Jakie widzimy niebezpieczeństwa używając tej metody?**

Występuje duże ryzyko, że jakiś błąd nie będzie obsługiwany czyli skończy się to błędem aplikacji. Nie wiadomo skąd Endpoint uri pochodzi, w źle zaprojektowanej aplikacji mogłoby dojść do wyodrębnianian poufnych danych.
