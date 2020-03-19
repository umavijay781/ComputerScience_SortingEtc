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
    my_Subproblem_NotInUse = ClassNQueensSD(N_RowsColumnsQueens)
    my_PartialSolution = ClassNQueensSD(N_RowsColumnsQueens)
    output_Results = []
    i_row = 0
    NQueens_Helper(my_Subproblem_NotInUse, i_row, my_PartialSolution, output_Results)
    return output_Results


def NQueens_Helper(par_Subproblem_NotUsed, par_iRowIndex, par_PartialSolution, par_Results):
    # Added 3/18/2020 thomas downes
    #
    # Added 3/17/2020 thomas downes
    #
    # par_SubProblem = ClassNQueensSD(8)
    # par_PartialSolution = ClassNQueensSD(8) 

    #
    # For the incrementation, see "(par_iRowIndex + 1)" below. 
    #
    par_PartialSolution.RowIndex = par_iRowIndex

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
        # par_Results.append(par_PartialSolution)
        # par_Results.append(par_PartialSolution.Output_ChessboardString())
        strChessboard = par_PartialSolution.Output_ChessboardString()
        par_Results.append(strChessboard)
        return

    #
    # Recursive Case 
    #
    boolAttack = False
    intCountColumnsOkay = 0
    
    ##intN_ProblemSize = par_Subproblem.N_GeneralProblemSize
    intN_ProblemSize = par_PartialSolution.N_GeneralProblemSize

    ##
    ## Let's account for the fact that some rows might not allow 
    ##    any Queens, due to a small problem size &/or all the diagonals 
    ##    being occupied. 
    ##
    numRowsLeftToCheck = (par_PartialSolution.N_numRows - par_iRowIndex)
    for iRowTry in range(numRowsLeftToCheck - 1):
        #
        #Increment the Row Index.
        #
        curr_iRowIndex = (par_iRowIndex + iRowTry)
        par_PartialSolution.RowIndex = curr_iRowIndex

        #
        # Check each column. 
        #
        for iColIndex in range(intN_ProblemSize):  ## range(par_Subproblem.N_GeneralProblemSize):
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
                    ## NQueens_Helper(par_Subproblem_NotUsed, par_PartialSolution, par_Results)
                    NQueens_Helper(par_Subproblem_NotUsed, (curr_iRowIndex + 1), par_PartialSolution, par_Results)
                    # This the bottom piece of bread of the "Omkar's Sandwich" (Interview Kickstart)
                    par_PartialSolution.removeLastColumnChoice(curr_iRowIndex + 1)
                else:
                    pass
            else:
                pass

        if (0 < intCountColumnsOkay):
            # We have found a column to fill with a Queen, so we can stop the search.
            break

    #
    # If (despite iterating through the remaining rows) no Queens could be placed in 
    #   any of the remaining rows, output the Chessboard.
    #
    if (0 == intCountColumnsOkay):
        strChessboard = par_PartialSolution.Output_ChessboardString()
        par_Results.append(strChessboard)

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

##Results = GetSolutions_NQueens_Overall(4)
##--Results = GetSolutions_NQueens_Overall(1)
Results = GetSolutions_NQueens_Overall(2)

for each_strChessboard in Results:
    ## print(each_ClassNQueens.Output_MasterString())
    print(each_strChessboard)





