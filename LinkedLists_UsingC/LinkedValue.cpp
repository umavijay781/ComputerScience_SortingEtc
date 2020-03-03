#include "LinkedValue.h"
#include <iostream>

// Parameterized Constructor 
LinkedValue::LinkedValue(int par_x1)
{
	_value = par_x1;
	_pointer = nullptr;
}


void LinkedValue::AddNextValue(int par_x1)
{
	//if (_pointer == nullptr)
	//{
	//	LinkedValue oLV = LinkedValue(par_x1);
	//	_pointer = &oLV;
	//}
	//else
	//{
	//	_pointer->AddNextValue(par_x1);
	//}
    // https://stackoverflow.com/questions/11279715/nullptr-and-checking-if-a-pointer-points-to-a-valid-object
	//
	try
	{
		if (_pointer)
		{
			_pointer->AddNextValue(par_x1);
		}
		else
		{
			_pointer = nullptr;   //Reintialize.  
			//LinkedValue oLV = LinkedValue(par_x1);
			//_pointer = &oLV;
			LinkedValue* oLV = new LinkedValue(par_x1);
			_pointer = oLV; 
		}
	}
	catch (...)    // (char* e)
	{
		//printf("Exception Caught: %s\n", e);
		//std::cout << "Exception caught";
		LinkedValue oLV = LinkedValue(par_x1);
		_pointer = &oLV;
	}
}


int LinkedValue::GetValue_ByIndex(int par_x1)
{
	//
	// Let's drill down until we get to the "bottom"
	//    (or our parameter has been decremented to zero)
	//    and then return the integer _value).
	//
	//if (_pointer == nullptr && par_x1 > 0)
	//{
	//	return -1;  //This is a "dummy" value, returned when something went wrong.
	//}
	//else if (par_x1 == 0)
	//{
	//	return _value;
	//}
	//else
	//{
	//	par_x1--;
	//	return _pointer->GetValue_ByIndex(par_x1);
	//}
	int intValue = 0;  //Added 3/3/2020 thomas downes

	if (_pointer)   // https://stackoverflow.com/questions/11279715/nullptr-and-checking-if-a-pointer-points-to-a-valid-object
	{
		if (par_x1 == 0)
		{
			return _value;
		}
		else
		{
			par_x1--;
			//return _pointer->GetValue_ByIndex(par_x1);
			intValue = (_pointer->GetValue_ByIndex(par_x1));
			return intValue; 
		}
	}
	else if (par_x1 == 0)
	{
		return _value;
	}
	else
	{
		//This is a "dummy" value, returned when something went wrong.
		return -1; 
	}

}


//LinkedValue::~LinkedValue(void) {
//	//cout << "Object is being deleted" << endl;
//	delete _pointer;
//}


