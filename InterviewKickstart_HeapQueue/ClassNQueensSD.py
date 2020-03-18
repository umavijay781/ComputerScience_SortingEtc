class ClassNQueensSD():
    """description of class"""
      #
    # N Queens Problem
    #     
    #   SD = Subproblem Definition  
    #   
    #   All arrays & row- & column-numberings are 0-based !!   
    #
    #   All numberings are top-to-bottom, left-to-right.  
    #
    def __init__(self, N_size = 2):
        self.N_GeneralProblemSize = N_size
        ## self.AttackDetected = False
        self.N_numQueens = N_size ## self.N_GeneralProblemSize ## 2 ## Initialize. 
        self.N_numRows = N_size ## self.N_GeneralProblemSize ## 2 ## Initialize.
        self.N_numColumns = N_size ## It is a square board. 
        
        self.D_numDiagonalsLR = (-1 + 2 * self.N_numRows) ## LR = //// diagonals slash-forward //// 
        self.D_numDiagonalsRL = (-1 + 2 * self.N_numRows) ## RL = \\\\ diagonals slash-backward \\\\

        self.RowIndex = 0
        self.ColumnsSelected_EachRow = []   ## [-1, -1, -1, -1, -1, -1, -1, -1]

        for i in range(N_numRows):
            self.ColumnsSelected_EachRow.append(-1)  ## Initialize. 

        #
        # Columns
        #
        self.ColumnIsUsed = []
        for i in range(N_numColumns):
            self.ColumnIsUsed.append(false)  ## Initialize, no Queen present in the column. 

        #
        # Forward Diagonals ////
        #
        self.DiagonalsForward_1Queen = [] ## ///////////   
        self.DiagonalsForward_Attack = [] ## ///////////   
        
        for i in range(D_numDiagonalsLR):
            self.DiagonalsForward.append(false)  ## Initialize, no Queen present in the diagonal. 

        #
        # Backward Diagonals \\\
        #
        self.DiagonalsBackslash_1Queen = [] ## \\\\\\\\
        self.DiagonalsBackslash_Attack = [] ## \\\\\\\\
        
        for i in range(D_numDiagonalsRL):
            self.DiagonalsBackslash_1Queen.append(false)  ## Initialize, no Queen present in the diagonal. 
            self.DiagonalsBackslash_Attack.append(false)  ## Initialize, no Queen present in the diagonal. 


    def AttackDetected_Columns(self):
        sorted_array = self.ColumnsSelected_EachRow[:]
        sorted_array.sort()
        col_redundancy = False # Initialize.
        for i in range(-1 + N_numRows):
            ## We will range { 0, 1, 2, 3, 4, 5, 6 }  when it's a standard chess board,
            ##  so we can compare to the next-adjacent [i+1] row { 1, 2, 3, 4, 5, 6, 7 } 
            ##  respectively. -----3/17/2020 td 
            col_redundancy = (self.ColumnsSelected_EachRow[i] == self.ColumnsSelected_EachRow[i + 1]) 
        return col_redundancy



    def AttackDetected_nextQueen(self, i_row, k_column):
        #
        # Called by the following:
        #      setColumnChoice_isItOkay
        #
        # /// /// /// /// ///
        #
        bDiagonalLR = self.DiagonalsForward_1Queen[i_row + k_column] # Check if this forward-slash diagonal // is now occupied. 
        # 
        # \\\ \\\ \\\ \\\ \\\
        #
        k_column_inverse = (self.N_numColumns - k_column - 1) # Subtract 1 to make the Column Inverse 0-based instead of 1-based.
        bDiagonalRL = self.DiagonalsBackslash_1Queen[i_row + k_column_inverse] # Check if this backslash diagonal \\ is now occupied. 
        bColumnUsed = false
        for i in range(-1 + N_numRows):
            bColumnUsed = (bColumnUsed or (k_column == self.ColumnsSelected_EachRow[i]))
        return (bDiagonalLR or bDiagonalRL or bColumnUsed)


    def AttackDetected_nextColumn(self, k_column):
        #
        # Called by the following:
        #      setColumnChoice_isItOkay
        #
        return AttackDetected_nextQueen(self.RowIndex, k_column)



    def setColumnChoice_isItOkay(self, k_column):
        #
        # Check to see if the column choice would cause problems
        #   or not, i.e. violate the constraint filter. 
        #
        # This calls:
        #     setColumnChoice_isItOkay_RowCol
        #
        return setColumnChoice_isItOkay_RowCol(self.RowIndex, k_column)

    def setColumnChoice_isItOkay_RowCol(self, i_row, k_column):
        # Check to see if the column choice would cause problems
        #   or not, i.e. violate the constraint filter. 
        #
        # This calls:
        #     AttackDetected_nextQueen
        #
        if AttackDetected_nextQueen(i_row, k_column):
            return false
        else:
            self.RowIndex = i_row
            bAlreadyTaken_Column = self.ColumnIsUsed[k_column]
            if (bAlreadyTaken_Column):
               raise "This || column is already taken!!"
               return false
            self.ColumnsSelected_EachRow[i_row] = k_column
            self.ColumnIsUsed[k_column] = true
            # 
            # /// /// /// /// ///
            #
            bAlreadyTaken_DiagForward = self.DiagonalsForward_1Queen[i_row + k_column]
            if (bAlreadyTaken_DiagForward):
               raise "This // diagonal is already taken!!"
               return false
            self.DiagonalsForward_1Queen[i_row + k_column] = true # Indicate that this forward-slash diagonal // is now occupied.
            #
            # \\\ \\\ \\\ \\\ \\\
            #
            k_column_inverse = (self.N_numColumns - k_column - 1) # Subtract 1 to make the Column Inverse 0-based instead of 1-based.
            bAlreadyTaken_SlashBack = self.DiagonalsBackslash_1Queen[i_row + k_column]
            if (bAlreadyTaken_SlashBack):
               raise "This \\ diagonal is already taken!!"
               return false
            self.DiagonalsBackslash_1Queen[i_row + k_column_inverse] = true # Indicate that this backslash diagonal \\ is now occupied. 
            return true

        
    def removeLastColumnChoice(self):
        #
        # Remove the last prior column choice.
        #  
        self.RowIndex += -1
        self.ColumnsSelected_EachRow[i_row] = -1 ## Re-initialize.
        # /// /// /// /// ///
        self.DiagonalsForward_1Queen[i_row + k_column] = false # Indicate that this forward-slash diagonal // is __not occupied. 
        # \\\ \\\ \\\ \\\ \\\
        k_column_inverse = (self.N_numColumns - k_column - 1) # Subtract 1 to make the Column Inverse 0-based instead of 1-based.
        self.DiagonalsBackslash_1Queen[i_row + k_column_inverse] = false # Indicate that this backslash diagonal \\ is __not occupied. 
        return 



