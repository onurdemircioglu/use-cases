Sub interval_adhocs_solution_2()
    Dim MyArray() As Integer 'DECLARE DYNAMIC ARRAY
    
    'DELETING/CLEANING THE SOLUTION
    Application.DisplayAlerts = False
    On Error Resume Next
    Sheets("VBA_SOLUTION_2").Delete
    On Error GoTo 0 'Disables any enabled error handler in the current procedure >> https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/on-error-statement
    Application.DisplayAlerts = True
    
    'CREATE COPY OF Data SHEET AND RENAME IT AS VBA_SOLUTION_2
    Sheets("Data").Copy After:=Sheets(Sheets.Count)
    ActiveSheet.Name = "VBA_SOLUTION_2"
    

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
    
    'DEFINING ARRAY SIZE TO ROW COUNT - 1
    array_size = Application.WorksheetFunction.Count([B:B]) - 1
    ReDim MyArray(1 To array_size) ' RESIZE THE ARRAY

    
    'LOOPING THROUGH LIST AND ADDING TO ARRAY
    [B3].Select
    array_counter = 1
    Do Until ActiveCell.Value = ""
        MyArray(array_counter) = ActiveCell.Value - ActiveCell.Offset(-1, 0)
        ActiveCell.Offset(1, 0).Select 'SELECTING THE NEXT ROW
        array_counter = array_counter + 1
    Loop
    
    'CALCULATING AVERAGE ON ARRAY VALUES
    [E1] = "VBA ARRAY SOLUTION"
    [E2] = Application.WorksheetFunction.Average(MyArray)
    [E3] = Application.WorksheetFunction.RoundDown(Application.WorksheetFunction.Average(MyArray), 0)
    
    'MODIFYING E1 AND E2
    With Range("E1:E3")
        .Interior.Color = 65535 'YELLOW
        .Font.Color = -16776961 'RED
        .Font.Bold = True
        .HorizontalAlignment = xlCenter
        .EntireColumn.AutoFit
    End With
    
    MsgBox "Process Completed"
End Sub
