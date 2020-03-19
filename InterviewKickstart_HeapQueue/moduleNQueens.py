# Added 3/18/2020 thomas downes
from ClassNQueensSD import ClassNQueensSD

#
#
# N QUEENS 
#
#   See Problem Statement, in this project.
#
#   ----3/17/2020 thoms downes 
#
def GetSolutions_NQueens_Overall(N_RowsColumnsQueens):
    # Added 3/18/2020 thomas downes
    #
    #   
    #
    my_Subproblem = ClassNQueensSD(N_RowsColumnsQueens)
    my_PartialSolution = ClassNQueensSD(N_RowsColumnsQueens)
    output_Results = []
    NQueens_Helper(my_Subproblem, my_PartialSolution, output_Results)
    return output_Results

def NQueens_Helper(par_Subproblem, par_PartialSolution, par_Results):
    # Added 3/18/2020 thomas downes
    #
    # Added 3/17/2020 thomas downes
    #
    # par_SubProblem = ClassNQueensSD(8)
    # par_PartialSolution = ClassNQueensSD(8) 

    #
    #  Backtracking Case  
    #
    # if (par_PartialSolution.AttackDetected_Columns()):
    #    return

    #
    # Base Case - Leaf Worker
    #
    if (par_PartialSolution.Completed()):
        # Output the full solution.
        # par_Results.append(par_PartialSolution.OutputArray())
        par_Results.append(par_PartialSolution)
        return

    #
    # Recursive Case 
    #
    boolAttack = False
    intCountColumnsOkay = 0

    for iColIndex in range(par_Subproblem.N_GeneralProblemSize):
        #
        # Recursive Call
        #
        boolAttack = par_PartialSolution.AttackDetected_nextColumn(iColIndex)
        if (False == boolAttack):
            #
            # No Queen attacks are detected.  We can proceed
            #    with the recursive call. 
            #
            # This the top piece of bread of the "Omkar's Sandwich" (Interview Kickstart)
            boolItIsOkay = par_PartialSolution.setColumnChoice_isItOkay(iColIndex)
            if (boolItIsOkay):
                intCountColumnsOkay += 1
                NQueens_Helper(par_Subproblem, par_PartialSolution, par_Results)
                # This the bottom piece of bread of the "Omkar's Sandwich" (Interview Kickstart)
                par_PartialSolution.removeLastColumnChoice()
    return 

#
#
# Main Program 
# 
#
print("                                      ")
print("**************************************")
print("***      The N-Queens Problem      ***")
print("**************************************")
print("                                      ")

Results = GetSolutions_NQueens_Overall(4)

for each_ClassNQueens in Results:
    print(each_ClassNQueens.Output_MasterString())





