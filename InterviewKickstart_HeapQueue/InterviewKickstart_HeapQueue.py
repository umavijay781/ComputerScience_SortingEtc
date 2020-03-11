
##
## Top K
## 
## Problem Statement:
## 
## You are given an array of integers arr, of size n, which is analogous to a continuous stream of integers input. Your task is to find K largest elements from a given stream of numbers.
## 
## By definition, we don't know the size of the input stream. Hence, produce K largest elements seen so far, at any given time. For repeated numbers, return them only once.
## 
## If there are less than K distinct elements in arr, return all of them.
## 
## Note:
## 
## Don't rely on size of input array arr.
## Feel free to use built-in functions if you need a specific data-structure.
## 
## Input/Output Format For The Function:
## 
## Input Format:
## 
## There is only one argument: Integer array arr.
## 
## Output Format:
## 
## Return an integer array res, containing K largest elements. If there are less than K unique elements, return all of them.
## 
## Order of elements in res does not matter.
## 
## Input/Output Format For The Custom Input:
## 
## Input Format:
## 
## The first line of input should contain an integer n, denoting size of input array arr. In next n lines, ith line should contain an integer arr[i], denoting a value at index i of arr.
## 
## In the next line, there should be an integer, denoting value of K.
## 
## If n = 5, arr = [1, 5, 4, 4, 2] and K = 2, then input should be:
## 
## 5
## 1
## 5
## 4
## 4
## 2
## 2
## 
## Output Format:
## 
## Let’s denote size of res as m, where res is the array of integers returned by solution function.
## 
## Then, there will be m lines of output, where ith line contains an integer res[i], denoting value at index i of res.
## 
## For input n = 5, arr = [1, 5, 4, 4, 2] and K = 2, output will be:
## 
## 4
## 5
## 
## Constraints:
## 
## 1 <= n <= 10^5
## 1 <= K <= 10^5
## arr may contains duplicate numbers.
## arr may or may not be sorted
## 
## Sample Test Case:
## 
## Sample Test Case 1:
## 
## Sample Input 1:
## 
## arr = [1, 5, 4, 4, 2]; K = 2
## 
## Sample Output 1:
## 
## [4, 5]
## 
## Sample Test Case 2:
## 
## Sample Input 2:
## 
## arr = [1, 5, 1, 5, 1]; K = 3
## 
## Sample Output 2:
## 
## [5, 1]
## 

import heapq  ## --- 3/10/2020 thomas downes

def topK(arr, k):
    
    ##
    ##      https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
    ##
    ##

    ## my_heap = heapq.heapify([])
    ## my_heap.add(arr);
    ## my_heap = heapq.heapify(arr)
    
    ## for item_in_array in arr:
    ##     heapq.heappush(my_heap.item_in_array)

    my_list_to_heap = [ ]  ## [ 0, 0, 0]

    ##
    ## To simulate a MAXHEAP in Python, you must multiply everything by -1.
    ##   (Of course, when you have done a "POP" to extract the value, 
    ##   you will want to multiply by -1 (negative one) once more, to remove the 
    ##   negative sign.)
    ##  
    ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
    ##
    ##  minimum_HEAP = heapq.heapify(my_empty_list)
    heapq.heapify(my_list_to_heap)

    ## my_dictionary = {} 

    ## thisdict =	{
    ##   "brand": "Ford",
    ##   "model": "Mustang",
    ##   "year": 1964
    ## }

    ##
    ##
    ## To simulate a MAXHEAP in Python, you must multiply everything by -1.
    ##   (Of course, when you have done a "POP" to extract the value, 
    ##   you will want to multiply by -1 (negative one) once more, to remove the 
    ##   negative sign.)
    ##  
    ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
    ##
    array_value = arr[0]
    array_value_inverse = (-1 * arr[0])

    # Store the first array value.  
    my_dictionary = {
        array_value: "n/a" ## This value ("n/a") is not important. 
       }

    for item_in_array in arr:
        # Don't add it to the heap if it is already there.
        boolDictionaryHasItAlready = False # Initialize Boolean.  
        if item_in_array in my_dictionary:
            # The dictionary has it already. 
            boolDictionaryHasItAlready = True
        else:
            my_dictionary[item_in_array] = "n/a" ## This value ("n/a") is not important.
            ## To create a MAXHEAP in Python, you must multiply everything by -1. 
            ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
            item_in_array_inverse = (-1 * item_in_array)
            ## heapq.heappush(minimum_HEAP, item_in_array_inverse)
            heapq.heappush(my_list_to_heap, item_in_array_inverse)

    array_output = []
    for indexOutput in range(0, k):
        ##
        ##   To simulate a MAXHEAP in Python, you must multiply everything by -1.
        ##   (Of course, when you have done a "POP" to extract the value, 
        ##   you will want to multiply by -1 (negative one) once more, to remove the 
        ##   negative sign.)
        ##  
        ##  https://stackoverflow.com/questions/2501457/what-do-i-use-for-a-max-heap-implementation-in-python
        ##
        if (0 < len(my_list_to_heap)):
            array_output.append(-1 * heapq.heappop(my_list_to_heap))

    return array_output

## print("The numbers 1234 + 1234 are equal to " + AddDecDigits_AnyLengths("1234", "1234"))
## print("The numbers  234 + 1234 are equal to " + AddDecDigits_AnyLengths("234", "1234"))
## print("The numbers  500 +  500 are equal to " + AddDecDigits_AnyLengths("500", "500"))
## print("The numbers  999 +  1 are equal to " + AddDecDigits_AnyLengths("999", "1"))

#array_input = [ 1, 2, 3, 4, 5, 6, 12, 13, 14, 41, 51, 61, 0, 1, 2, 61, 41, 5 ]
array_input = [ 4, 8, 9, 6, 6, 2, 10, 2, 8, 1, 2, 9 ]
array_output = topK(array_input, 7)

print("--------------------------- ")
print("----    OUTPUT   ---------- ")

for x_IN_value in array_input:
    print("The next input number is: " + str(x_IN_value))


print("--------------------------- ")
print("----    OUTPUT   ---------- ")

for x_OUT_value in array_output:
    print("The next output number is: " + str(x_OUT_value))





