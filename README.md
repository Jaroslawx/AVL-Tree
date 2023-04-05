# AVL

Zaimplementuj operacje (search, insert, delete, KLP) na drzewie AVL.

- Węzeł drzewa AVL powinien zawierać: klucz (typu int), współczynnik wyważenia (element ze zbioru {-1, 0, 1}), wskaźnik na lewe poddrzewo, wskaźnik na prawe poddrzewo.
- W węźle drzewa nie można umieszczać wskaźnika na ojca tego węzła.
- Po wstawieniu (usunięciu) elementu do drzewa AVL poprawiamy współczynniki wyważania jedynie na ścieżce wstawianego (usuwanego) elementu.
 
Do testowania drzewa AVL przygotuj:

a) Wczytywanie elementów (typu int) z pliku InTest1.txt do drzewa AVL:
 
InTest1.txt 46 43 52 46 45 765 73 5 63 45 4 65 67 65 73 56 24 53 42 34 23 465 376 93 65 8

b) Losowanie elementów (typu int) z ustalonego zakresu i wczytywanie ich do drzewa AVL (kolejność losowanych elementów powinna zostać zapisana w pliku OutTest2.txt).

c) Wykonanie operacji w wyniku wyboru pozycji z następującego menu:
- Zapisz elementy drzewa AVL do pliku OutTest3.txt w kolejności KLP.
- Dodaj element do drzewa AVL.
