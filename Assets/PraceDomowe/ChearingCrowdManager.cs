using System.Collections.Generic;
using UnityEngine;

//celem pracy domowej jest stworzenie skryptu zarządzającego publicznością
//W tym zadaniu należy zaimplememtnować 4 różne zachowań dla publiki
//1 - skakanie w górę 
//2 - przesunięcie się do przodu i powrót na miejsce
//3 - stworzenie obiektu a nastepnie zniszczenie go po 1 sekundzie
//4 - wyskok do góry z saltem (obrót o 360 stopni wokół osi z lub x)
//Jako przykład sprawdź ChearingCrowdTurn360
//obiekty niech bedą szcześcianami
//Jak to zrobisz napisz skrypt w ChearingCrowdManager, który upewni się że wszystkie akcje się skończyły i nie będzie odpalać żadnych akcji, jeśli któraś z nich trwa

// Stwórz 5 gamobjectów jako dzieci ChearingCrowdManagera
// implementując interface IChearingCrowd napisz powyższe działania w klasach MonoBehaviour
// upewnij sie że ogarniasz jak to działa https://docs.unity3d.com/ScriptReference/Component.GetComponentsInChildren.html
// W metodzie start przy użyciu GetComponentsInChildren<IChearingCrowd>() wypełnij tablicę chearingCrowd 


public class ChearingCrowdManager : MonoBehaviour
{
    private IChearingCrowd[] chearingCrowd;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < chearingCrowd.Length; i++)
            {
                chearingCrowd[i].Chear();
            }
        }
    }
}
