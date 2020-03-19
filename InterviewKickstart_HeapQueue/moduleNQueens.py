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
    NQueensHelper(my_Subproblem, my_PartialSolution, output_Results)
    return output_Results

def NQueens_Helper(par_Subproblem, par_PartialSolution, par_Results):
    # Added 3/18/2020 thomas downes
    #
    # Added 3/17/2020 thomas downes
    #
    # par_SubProblem = ClassNQueensSD(8)
    # par_PartialSolution = ClassNQueensSD(8) 

    #
    # Backtracking Case  
    #
    if (par_PartialSolution.AttackDetected()):
        return

    #
    # Base Case - Leaf Worker
    #
    if (par_PartialSolution.Completed):
        # Output the full solution.
        par_Results.Add(par_PartialSolution.OutputArray())
        return

    #
    # Recursive Case 
    #
    boolAttack = False

    for iColIndex in range(par_Subproblem.N_GeneralProblemSize):
        #
        # Recursive Call
        #
        boolAttack = par_PartialSolution.AttackDetected_NextColumn(iColIndex)
        if (False == boolAttack ):
            #
            # No Queen attacks are detected.  We can proceed
            #    with the recursive call. 
            #
            par_PartialSolution.setColumnChoice_isItOkay(iColIndex)
            NQueens_Helper(par_Subproblem, par_PartialSolution, par_Results)
    return 

#
#
# Main Program 
# 
#
Results = GetSolutions_NQueens_Overall(4)

for each_ClassNQueens in Results:
    print(each_ClassNQueens.Output_MasterString())





