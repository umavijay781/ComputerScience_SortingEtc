#include "LinkedValue.h"

// Parameterized Constructor 
LinkedValue::LinkedValue(int par_x1)
{
	_value = par_x1;
	_pointer = nullptr;
}

void LinkedValue::AddNextValue(int par_x1)
{

	if (_pointer == nullptr)
	{
		LinkedValue oLV = LinkedValue(par_x1);
		_pointer = &oLV;  
	}
	else
	{
		_pointer->AddNextValue(par_x1);
	}
}



