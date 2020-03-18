
import ClassNQueensSD

#
#
# N QUEENS 
#
#   See Problem Statement, in this project.
#
#   ----3/17/2020 thoms downes 
#
def GetSolutions_NQueens(N_RowsColumnsQueens):
    #
    #   
    #
    my_Subproblem = ClassNQueensSD(N_RowsColumnsQueens)
    my_PartialSolution = ClassNQueensSD(N_RowsColumnsQueens)



def NQueens_Helper(Subproblem, PartialSolution):
    #
    # Added 3/17/2020 thomas downes
    #

    #
    # Backtracking Case  
    #
    if (PartialSolution.AttackDetected()):
        return

    #
    # Base Case
    #


    #
    # Recursive Case 
    #
    boolAttack = False

    for iColIndex in range(Subproblem.N_GeneralProblemSize):
        #
        # Recursive Call
        #
        boolAttack = PartialSolution.AttackDetected(iColIndex)
        if (False == boolAttack ):
            NQueens_Helper(Subproblem, PartialSolution)





