
#
# Interview KickStart
#
# Recursive Model 
#
#   -----3/18/2020  
#
objResults = List_of_ObjectOrArray()

#
# Where does the Subproblem Definition get changed, if ever?
#
#
def RecursiveOverall(n_sizeProblem):
    #
    # Where does the Subproblem Definition get changed, if ever?
    #
    #
    objResults = List_of_ObjectOrArray()
    objSubproblemDef = ObjectOrArray()
    objEmptyBlankSlate = ObjectOrArray_Empty()
    # Huge call !!
    RecursiveHelper(objSubproblemDef, 0, objEmptyBlankSlate)
    return objResults

def RecursiveHelper(SubproblemDef, SubproblemLevel, PartialSolution_Slate):
    #
    # Where does the Subproblem Definition get changed, if ever?
    #
    # Backtracking Case (pruning the heuristic tree)
    #
    if (PartialSolution_Slate.Fails):
        return 

    #
    # Base Case (Leaf-Level Solution)
    #
    if (baseCondition):
        objResults.Add(PartialSolution_Slate)
        return 

    #
    # Recursive Case
    #
    for i in range(SubproblemDef.Size):
        ###############################################
        # Recursive Call & "Omkar's Sandwich"
        ###############################################
        # 
        # Enhance the P.S. Slate, to be XXXX_ from XXX__.
        SandwichBreadOnTop_AugmentPS_FillInBlank()
        # Recursive call
        RecursiveHelper(SubproblemDef, SubproblemLevel, PartialSolution_Slate)
        # Restore Partial-Solution Slate to: XXX__
        SandwichBreadOnBottom_RestorePS_RestoreBlank()





