


import heapq  ## --- 3/17/2020 thomas downes

#
#
#  Testing Heap Sort  
#
#
def HeapSort_Heapify(par_arrayIntegers):  
    # Added 3/17/2020 thomas d. 
    heapq.heapify(par_arrayIntegers)
    return par_arrayIntegers

def HeapSort_Ascending(par_arrayIntegers):  
    # Added 3/17/2020 thomas d. 
    heapq.heapify(par_arrayIntegers)
    array_output = []
    indexOutput = 0
    intCountItems = len(par_arrayIntegers)  ## par_arrayIntegers.count()
    for indexOutput in range(intCountItems):
        array_output.append(heapq.heappop(par_arrayIntegers))
    return array_output

def HeapSort_Descending(par_arrayIntegers):    
    # Added 3/17/2020 thomas d. 
    ##
    ##      https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
    ##
    ## To simulate a MAXHEAP in Python, you must multiply everything by -1.
    ##   (Of course, when you have done a "POP" to extract the value, 
    ##   you will want to multiply by -1 (negative one) once more, to remove the 
    ##   negative sign.)
    ##  
    ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
    ##
    ##  minimum_HEAP = heapq.heapify(my_empty_list)

    ##  heapq.heapify(par_arrayIntegers)

    ## for item_in_array in arr:
        
    ##    item_in_array_inverse = (-1 * item_in_array)
    ##    ## heapq.heappush(minimum_HEAP, item_in_array_inverse)
    ##    ## heapq.heappush(my_list_to_heap, item_in_array_inverse)

    ##intCountItems = par_arrayIntegers.count()
    intCountItems = len(par_arrayIntegers)

    for index in range(0, intCountItems):
        par_arrayIntegers[index] = -1 * par_arrayIntegers[index]
    heapq.heapify(par_arrayIntegers)
    array_output = []
    indexOutput = 0
    for indexOutput in range(intCountItems):
        ##
        ##   To simulate a MAXHEAP in Python, you must multiply everything by -1.
        ##   (Of course, when you have done a "POP" to extract the value, 
        ##   you will want to multiply by -1 (negative one) once more, to remove the 
        ##   negative sign.)
        ##  
        ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
        ##
        ##if (0 < len(my_list_to_heap)):
        array_output.append(-1 * heapq.heappop(par_arrayIntegers))

    return array_output


## print("The numbers 1234 + 1234 are equal to " + AddDecDigits_AnyLengths("1234", "1234"))
## print("The numbers  234 + 1234 are equal to " + AddDecDigits_AnyLengths("234", "1234"))
## print("The numbers  500 +  500 are equal to " + AddDecDigits_AnyLengths("500", "500"))
## print("The numbers  999 +  1 are equal to " + AddDecDigits_AnyLengths("999", "1"))

#array_input = [ 1, 2, 3, 4, 5, 6, 12, 13, 14, 41, 51, 61, 0, 1, 2, 61, 41, 5 ]
array_input = [ 4, 8, 9, 6, 6, 2, 10, 2, 8, 1, 2, 9 ]
#array_output = HeapSort_Ascending(array_input)

print("--------------------------- ")
print("----     INPUT   ---------- ")
print("                            ")
print(array_input)
print("                            ")

for x_IN_value in array_input:
    print("The next input number is: " + str(x_IN_value))


print("------------------------------------- ")
print("----    OUTPUT OF HEAPIFY  ---------- ")
print("                            ")
array_output = HeapSort_Heapify(array_input)
print(array_output)
print("                            ")

# array_output = HeapSort_Heapify(array_input)
for x_OUT_value in array_output:
    print("The next output number is: " + str(x_OUT_value))


print("------------------------------------------------ ")
print("----    OUTPUT OF HEAPSORT ASCENDING  ---------- ")
print("                            ")

array_input = [ 4, 8, 9, 6, 6, 2, 10, 2, 8, 1, 2, 9 ]
array_output = HeapSort_Ascending(array_input)
print(array_output)
print("                            ")
for x_OUT_value in array_output:
    print("The next output number is: " + str(x_OUT_value))


print("------------------------------------------------ ")
print("----    OUTPUT OF HEAPSORT DESCENDING  ---------- ")
print("                            ")

array_input = [ 4, 8, 9, 6, 6, 2, 10, 2, 8, 1, 2, 9 ]
array_output = HeapSort_Descending(array_input)
print(array_output)
print("                            ")
for x_OUT_value in array_output:
    print("The next output number is: " + str(x_OUT_value))




