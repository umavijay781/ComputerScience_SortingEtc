#pragma once
class LinkedValue
{
	//
	//Added 3/2/2020 thomas downes
	//
private: 
	//   https://www.geeksforgeeks.org/can-a-c-class-have-an-object-of-self-type/
	//   https://stackoverflow.com/questions/2706129/can-a-c-class-include-itself-as-an-member
	LinkedValue *_pointer = nullptr;

public:
	int _value = 0;

	// Parameterized Constructor 
	LinkedValue(int par_x1);

	void AddNextValue(int par_x1);





};

