class ClassNQueensSD():
    # Added 3/18/2020 thomas downes
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
        # Added 3/18/2020 thomas downes
        self.N_GeneralProblemSize = N_size
        ## self.AttackDetected = False
        self.N_numQueens = N_size ## self.N_GeneralProblemSize ## 2 ## Initialize. 
        self.N_numRows = N_size ## self.N_GeneralProblemSize ## 2 ## Initialize.
        self.N_numColumns = N_size ## It is a square board. 
        
        self.D_numDiagonalsLR = (-1 + (2 * self.N_numRows)) ## LR = //// diagonals slash-forward //// 
        self.D_numDiagonalsRL = (-1 + (2 * self.N_numRows)) ## RL = \\\\ diagonals slash-backward \\\\

        self.RowIndex = 0
        self.ColumnsSelected_EachRow = []   ## [-1, -1, -1, -1, -1, -1, -1, -1]

        for i in range(self.N_numRows):
            self.ColumnsSelected_EachRow.append(-1)  ## Initialize. 

        #
        # Columns
        #
        self.ColumnIsUsed = []
        for i in range(self.N_numColumns):
            self.ColumnIsUsed.append(False)  ## Initialize, no Queen present in the column. 

        #
        # Forward Diagonals ////
        #
        self.DiagonalsForward_1Queen = [] ## ///////////   
        self.DiagonalsForward_Attack = [] ## ///////////   
        
        for i in range(self.D_numDiagonalsLR):
            self.DiagonalsForward_1Queen.append(False)  ## Initialize, no Queen present in the diagonal. 

        #
        # Backward Diagonals \\\
        #
        self.DiagonalsBackslash_1Queen = [] ## \\\\\\\\
        self.DiagonalsBackslash_Attack = [] ## \\\\\\\\
        
        for i in range(self.D_numDiagonalsRL):
            self.DiagonalsBackslash_1Queen.append(False)  ## Initialize, no Queen present in the diagonal. 
            self.DiagonalsBackslash_Attack.append(False)  ## Initialize, no Queen present in the diagonal. 


    def AttackDetected_Columns(self):
        # Added 3/18/2020 thomas downes
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
        # Added 3/18/2020 thomas downes
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
        # 
        # ||| ||| ||| ||| ||| (part 1 of 2)
        #
        bColumnUsed = False
        for i in range(-1 + self.N_numRows):
            bColumnUsed = (bColumnUsed or (k_column == self.ColumnsSelected_EachRow[i]))
        # 
        # ||| ||| ||| ||| ||| (part 2 of 2)
        #
        bAlreadyTaken_Column = self.ColumnIsUsed[k_column]
        # return (bDiagonalLR or bDiagonalRL or bColumnUsed)
        return (bDiagonalLR or bDiagonalRL or bColumnUsed or bAlreadyTaken_Column)


    def AttackDetected_nextColumn(self, k_column):
        # Added 3/18/2020 thomas downes
        #
        # Called by the following:
        #      setColumnChoice_isItOkay
        #
        return self.AttackDetected_nextQueen(self.RowIndex, k_column)



    def setColumnChoice_isItOkay(self, k_column):
        # Added 3/18/2020 thomas downes
        #
        # Check to see if the column choice would cause problems
        #   or not, i.e. violate the constraint filter. 
        #
        # This calls:
        #     setColumnChoice_isItOkay_RowCol
        #
        boolIsOkay_NoAttacks = self.setColumnChoice_isItOkay_RowCol(self.RowIndex, k_column)
        ##--/----For the incrementation, see "(par_iRowIndex + 1)" in module moduleNQueens.py. 
        ##--/--self.RowIndex += 1
        return boolIsOkay_NoAttacks

    def setColumnChoice_isItOkay_RowCol(self, i_row, k_column):
        # Added 3/18/2020 thomas downes
        #
        # Check to see if the column choice would cause problems
        #   or not, i.e. violate the constraint filter. 
        #
        # This calls:
        #     AttackDetected_nextQueen
        #
        if self.AttackDetected_nextQueen(i_row, k_column):
            return false
        else:
            self.RowIndex = i_row
            # 
            # ||| ||| ||| ||| |||
            #
            bAlreadyTaken_Column = self.ColumnIsUsed[k_column]
            if (bAlreadyTaken_Column):
               #raise "This || column is already taken!!"
               Ex3 = ValueError()
               Ex3.strerror = "This || column is already taken!!"
               raise Ex3
               ##return false
            self.ColumnsSelected_EachRow[i_row] = k_column
            self.ColumnIsUsed[k_column] = True
            # 
            # /// /// /// /// ///
            #
            bAlreadyTaken_DiagForward = self.DiagonalsForward_1Queen[i_row + k_column]
            if (bAlreadyTaken_DiagForward):
               #raise "This // diagonal is already taken!!"
               Ex2 = ValueError()
               Ex2.strerror = "This // diagonal is already taken!!"
               raise Ex2
               ##return false
            self.DiagonalsForward_1Queen[i_row + k_column] = True # Indicate that this forward-slash diagonal // is now occupied.
            #
            # \\\ \\\ \\\ \\\ \\\
            #
            k_column_inverse = (self.N_numColumns - k_column - 1) # Subtract 1 to make the Column Inverse 0-based instead of 1-based.
            bAlreadyTaken_SlashBack = self.DiagonalsBackslash_1Queen[i_row + k_column_inverse]
            if (bAlreadyTaken_SlashBack):
               # raise "This \\ diagonal is already taken!!"
               Ex1 = ValueError()
               Ex1.strerror = "This \\ diagonal is already taken!!"
               raise Ex1
               ##return False
            self.DiagonalsBackslash_1Queen[i_row + k_column_inverse] = True # Indicate that this backslash diagonal \\ is now occupied. 
            ## Feedback to programmer
            strRowLine = self.ToString_Row(i_row)
            print("The following is partial feedback: " + strRowLine) ## Provide feedback.
            return True

        
    def removeLastColumnChoice(self, par_i_row):
        # Added 3/18/2020 thomas downes
        #
        # Remove the last prior column choice.
        #
        ##---i_row = self.RowIndex  
        if (par_i_row > (-1 + self.N_numRows)):
            #
            # Pass, since we don't need to do anything. 
            #
            pass
        else:
            #
            # Query for the selected column.
            #
            k_column = self.ColumnsSelected_EachRow[par_i_row]
            #
            # If (k_column == 1) then the following is _NOT_ needed.
            #
            if (k_column != -1):
                # |||||||||||||||||||||
                self.ColumnsSelected_EachRow[par_i_row] = -1 ## Re-initialize.
                # /// /// /// /// ///
                self.DiagonalsForward_1Queen[par_i_row + k_column] = False # Indicate that this forward-slash diagonal // is __not occupied. 
                # \\\ \\\ \\\ \\\ \\\
                k_column_inverse = (self.N_numColumns - k_column - 1) # Subtract 1 to make the Column Inverse 0-based instead of 1-based.
                self.DiagonalsBackslash_1Queen[par_i_row + k_column_inverse] = False # Indicate that this backslash diagonal \\ is __not occupied. 
                ##--/----For the incrementation, see "(par_iRowIndex + 1)" in module moduleNQueens.py. 
                ##--/--self.RowIndex += -1  # Decrement the Row Index.
        return 


    def Completed(self):
       # return (self.RowIndex >= (-1 + self.N_numRows))
       # return (self.RowIndex >= 2)
       # return (self.RowIndex >= 3)
       # return (self.RowIndex >= (-1 + self.N_numRows))
       return (self.RowIndex > (-1 + self.N_numRows))


    def Output_Array(self):
        # Added 3/18/2020 thomas downes
        return copy.copy(self.ColumnsSelected_EachRow)

    def Output_ArrayOfStrings(self):
        # Added 3/18/2020 thomas downes
        #
        # This returns the following array of strings:
        #
        #    ---q, --q-, -q--, q---
        #
        #return copy.copy(self.ColumnsSelected_EachRow)
        output_strings = []
        output_row = ""
        for i_row in range(self.N_numRows):
            output_row = ""
            #for k_col in range(self.N_numColumns):
            #    #if (self.ColumnsSelected_EachRow[i_row] == k_col):
            #    #    output_row = (output_row + "q")
            #    #else:
            #    #    output_row = (output_row + "-")
            output_row = self.ToString_Row(i_row)
            output_strings.append(output_row)
        return output_strings


    def ToString_Row(self, par_i_row):
        ##
        ## Converts a chess row to a string value.
        ##
        output_row = ""
        intColumnSelected = self.ColumnsSelected_EachRow[par_i_row]
        for k_col in range(self.N_numColumns):
            if (intColumnSelected == k_col):
                output_row = (output_row + "q")
            else:
                output_row = (output_row + "-")
        return output_row


    def Output_ChessboardString(self):
        # Added 3/18/2020 thomas downes
        #
        # This returns the following string with carriage returns:
        #
        #    ---q
        #    --q-
        #    -q--
        #    q---
        #
        output_strings = []
        output_chessboard = ""
        output_strings = self.Output_ArrayOfStrings()
        for each_string in output_strings:
            output_chessboard += (each_string + "\n")
        return output_chessboard


