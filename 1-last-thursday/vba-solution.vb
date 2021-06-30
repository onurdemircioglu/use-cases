
'FIRST THURSDAY BEFORE END OF NEXT MONTH (END OF NEXT MONTH IS NOT EXCLUDED/INCLUDED)
Sub finding_last_thursday()
    Dim v_date As Date, begin_month As Date, end_month As Date, result_date As Date, result_date2 As Date
    
    v_date = DateSerial(2021, 8, 22) 'SAMPLE DATE
'    v_date = [A1] 'CELL REFERENCE CAN BE GIVEN
    begin_month = Application.WorksheetFunction.EoMonth(v_date, 1) - Day(Application.WorksheetFunction.EoMonth(v_date, 1)) + 1
    end_month = Application.WorksheetFunction.EoMonth(v_date, 1)

    Do While begin_month <= end_month
        If Weekday(begin_month, vbMonday) = 4 Then 'STARTING MONDAY (1)
            result_date = begin_month
        End If
        
        If Weekday(begin_month, vbMonday) = 4 And Application.WorksheetFunction.EoMonth(begin_month, 0) <> begin_month Then
            result_date2 = begin_month
        End If
        
        begin_month = begin_month + 1
    Loop
    
    MsgBox "result_date >> " & CDate(result_date)
    MsgBox "result_date2 >> " & CDate(result_date2)
    
    'WRITING RESULT BACK TO WORKSHEET
'    [A2] = result_date
'    [A3] = result_date2
    
End Sub


'CREATING FUNCTION TO FIND LAST WEEKDAY
Function f_finding_last_thursday(Optional v_date As Date, Optional v_weekday_input As String = "NA")
    Dim begin_month As Date, end_month As Date, result_date As Date
    
    'ASSIGNING FIRST ARGUMENT IF IT IS EMPTY
    If IsNull(v_date) = True Then
        v_date = Date
    ElseIf IsEmpty(v_date) = True Then
        v_date = Date
    ElseIf v_date = 0 Then
        v_date = Date
    End If
    
    'CONVERTING WEEKDAY NAME TO WEEKDAY NUMBER
    v_weekday_number = Switch(v_weekday_input = "NA", Weekday(v_date, vbMonday) _
                            , v_weekday_input = "MONDAY", 1 _
                            , v_weekday_input = "TUESDAY", 2 _
                            , v_weekday_input = "WEDNESDAY", 3 _
                            , v_weekday_input = "THURSDAY", 4 _
                            , v_weekday_input = "FRIDAY", 5 _
                            , v_weekday_input = "SATURDAY", 6 _
                            , v_weekday_input = "SUNDAY", 7)
    
    If IsNull(Trim(v_date)) = True Then 'NULL CHECK
        f_finding_last_thursday = 0
    ElseIf IsDate(v_date) = False Then 'ACTUALLY THIS STEP IS A LITTLE BIT UNNECCESSARY BECAUSE WE DEFINE THIS VALUE AS DATE FORMAT AT THE BEGINNING. IT GIVES AN #VALUE! ERROR. IT ALSO GIVES AN ERROR IF MULTIPLE RANGE IS SELECTED IN FORMULA
        f_finding_last_thursday = 0
    Else 'TRUE CASE

        begin_month = Application.WorksheetFunction.EoMonth(v_date, 1) - Day(Application.WorksheetFunction.EoMonth(v_date, 1)) + 1
        end_month = Application.WorksheetFunction.EoMonth(v_date, 1)
    
        Do While begin_month <= end_month
            
            If Weekday(begin_month, vbMonday) = v_weekday_number And Application.WorksheetFunction.EoMonth(begin_month, 0) <> begin_month Then
                result_date = begin_month
            End If
            
            begin_month = begin_month + 1
        Loop
    End If
    
    f_finding_last_thursday = result_date 'RESULT
End Function
