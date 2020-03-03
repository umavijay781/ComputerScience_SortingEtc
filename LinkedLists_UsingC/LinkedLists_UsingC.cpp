// LinkedLists_UsingC.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "LinkedValue.h"

int main()
{
    std::cout << "Hello World!\n";

    LinkedValue oLV = LinkedValue(57);
    oLV.AddNextValue(61);
    oLV.AddNextValue(72);
    oLV.AddNextValue(84);

    std::cout << oLV.GetValue_ByIndex(0);
    std::cout << oLV.GetValue_ByIndex(1);
    std::cout << oLV.GetValue_ByIndex(2);
    std::cout << oLV.GetValue_ByIndex(3);

    std::cout << "Is that the list you expect, 57 61 72 84 ?";

        int input_value = -1;
        std::cin >> input_value;

        //delete oLV;

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
