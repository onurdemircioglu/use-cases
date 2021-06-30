Sub interval_adhocs_solution_1()
    
    'DELETING/CLEANING THE SOLUTION
    Application.DisplayAlerts = False 'TO PREVENT WARNING POPUPS
    On Error Resume Next
    Sheets("VBA_SOLUTION_1").Delete
    On Error GoTo 0 'Disables any enabled error handler in the current procedure >> https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/on-error-statement
    Application.DisplayAlerts = True
    
    'CREATE COPY OF Data SHEET AND RENAME IT AS VBA_SOLUTION_1
    Sheets("Data").Copy After:=Sheets(Sheets.Count)
    ActiveSheet.Name = "VBA_SOLUTION_1"
    
    'CLEAR THE DATA
    [C:K].Delete

    'REMOVING DUPLICATE DATES
    ActiveSheet.Range("$B$1:$B$100000").RemoveDuplicates Columns:=1, Header:=xlYes
    
    'CLEANING EMPTY DATES AFTER REMOVING DUPLICATES
    [A1].Select

    Do Until ActiveCell.Value = ""
        If ActiveCell.Value <> "" And ActiveCell.Offset(0, 1) <> "" Then
            ActiveCell.Offset(1, 0).Select 'IT MOVES TO NEXT ROW, IF IT DOESN'T, LOOP CONDITION CALCULATES TRUE AND CAUSES AN INFINITE LOOP
        Else
            ActiveCell.EntireRow.Delete 'AFTER DELETION THERE IS NO NEED FOR MOVING TO NEXT ROW. BECAUS WHEN WE DELETE THE CURRENT ROW ALL ROWS BELOW MOVES ONE ROW UP. IF WE OFFSET THE NEXT ROW, WE ACCIDENTIALLY SKIP A ROW THAT MIGHT HAVE BLANK DATE
        End If
    Loop
    
    'MODIFYING & FORMATTING C1 CELL
    With Range("C1")
        .Value = "DIFFERENCE"
        .Interior.Color = 65535 'YELLOW
        .Font.Color = -16776961 'RED
        .Font.Bold = True
    End With
    
    'LOOPING THROUGH LIST AND INSERTING FORMULAS
    [B3].Select
    
    Do Until ActiveCell.Value = ""
        With ActiveCell.Offset(0, 1)
            .Formula = "=RC[-1]-R[-1]C[-1]" 'THIS IS A RELATIVE REFERENCE, TELLS THE FORMULA TO MAKE CALCULATION CURRENT ROW - PREVIOUS ROW
            .HorizontalAlignment = xlCenter
            .Interior.Color = 65535 'YELLOW
            .Font.Color = -16776961 'RED
        End With

        ActiveCell.Offset(1, 0).Select 'SELECTING THE NEXT ROW
    Loop
    
    'FORMATTING E1 AND F1
    With Range("E1:F1")
        .Interior.Color = 65535 'YELLOW
        .Font.Color = -16776961 'RED
        .Font.Bold = True
    End With
    
    'HEADERS
    [E1] = "STANDART AVERAGE FORMULA"
    [F1] = "ARRAY AVERAGE FORMULA"
    
    'INSERTING FORMULAS
    [E2].Formula = "=ROUNDDOWN(AVERAGE(R[1]C[-2]:R[56]C[-2]),0)"
'        .FormulaR1C1 = "=ROUNDDOWN(AVERAGE(C[-2]),0)" 'SAME RESULT IF WE DEFINE THE ENTIRE COLUMN AS AVERAGE RANGE, IT COLUD BE EASIER THAN DEFININ RANGE DYNAMICALLY.
    [E3].Formula = "=FORMULATEXT(R[-1]C[0])"
    
    [F2].FormulaArray = "=ROUNDDOWN(AVERAGE(R[1]C[-4]:R[28]C[-4]-RC[-4]:R[27]C[-4]),0)"
    [F3].Formula = "=FORMULATEXT(R[-1]C[0])"
    
    
    'MODIYFING FORMAT
    With Range("E1:F3")
        .HorizontalAlignment = xlCenter
        .Interior.Color = 65535 'YELLOW
        .Font.Color = -16776961 'RED
        .EntireColumn.AutoFit
    End With
    
    [A2].Select
    MsgBox "Process Completed"
End Sub
