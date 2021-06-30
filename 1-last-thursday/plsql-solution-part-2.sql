CREATE OR REPLACE FUNCTION LAST_WEEKDAY ( V_DATE IN DATE DEFAULT TRUNC(SYSDATE), V_WEEKDAY_INPUT IN VARCHAR2 DEFAULT 'NA') RETURN DATE IS
    V_START_DATE DATE;
    V_END_DATE DATE;
    V_RESULT_DATE DATE; -- END OF NEXT MONTH IS NOT INCLUDED
    V_WEEKDAY_RESULT NUMBER;

BEGIN
    V_START_DATE := TRUNC(ADD_MONTHS(V_DATE,1),'MONTH');
    V_END_DATE := LAST_DAY(ADD_MONTHS(V_DATE,1));
    
    CASE V_WEEKDAY_INPUT
        WHEN 'NA' THEN V_WEEKDAY_RESULT := TO_CHAR(V_DATE ,'D');
        WHEN 'SUNDAY' THEN V_WEEKDAY_RESULT := 1;
        WHEN 'MONDAY' THEN V_WEEKDAY_RESULT := 2;
        WHEN 'TUESDAY' THEN V_WEEKDAY_RESULT := 3;
        WHEN 'WEDNESDAY' THEN V_WEEKDAY_RESULT := 4;
        WHEN 'THURSDAY' THEN V_WEEKDAY_RESULT := 5;
        WHEN 'FRIDAY' THEN V_WEEKDAY_RESULT := 6;
        WHEN 'SATURDAY' THEN V_WEEKDAY_RESULT := 7;
    END CASE;
    
    WHILE V_START_DATE <= V_END_DATE -- BEGINS FROM FIRST DAY OF NEXT MONTH (ALSO IT IS POSSIBLE TO START 3RD WEEK START)
    LOOP
        
        IF TO_CHAR(V_START_DATE ,'D') = V_WEEKDAY_RESULT AND V_START_DATE != LAST_DAY(V_START_DATE) THEN
            V_RESULT_DATE := V_START_DATE; -- WHEN IT FINDS IT ASSIGNS VALUE TO V_RESULT_DATE
        END IF;
        
        V_START_DATE := V_START_DATE + 1;
    END LOOP;
    
    RETURN V_RESULT_DATE; -- RETURNS THE LAST FOUNDED VALUE
END;
/


SELECT SYSDATE
        ,LAST_WEEKDAY() AS RESULT_01 -- IT USES 23-JUN-2021 AS DEFAULT VALUE AND WEDNESDAY BECAUSE SECOND PARAMETER SKIPPED IT USES WEEKDAY OF DEFAULT DATE
        ,LAST_WEEKDAY(TO_DATE('17072021' ,'DDMMYYYY')) AS RESULT_02 -- IT USES 17-JUL-2021 AND WEEKDAY OF THIS DATE (SATURDAY)
        ,LAST_WEEKDAY(TO_DATE('17072021' ,'DDMMYYYY') ,'TUESDAY') AS RESULT_03
FROM DUAL
;