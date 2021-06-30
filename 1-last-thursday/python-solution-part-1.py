# -*- coding: utf-8 -*-
import datetime as dt
from dateutil.relativedelta import relativedelta

sample_date = dt.datetime(2021,8,25) # YEAR, MONTH, DAY AND SO ON..

begin_month = sample_date + relativedelta(months=+ 1) # CALCULATING THE NEXT MONTH FOR A GIVEN DATE
begin_month = begin_month + relativedelta(days=- (int(dt.datetime.strftime(begin_month, "%d"))-1)) # AFTER CALCULATION OF NEXT MONTH, SUBTRACTING DAY TO FIND THE BEGINNING OF THIS MONTH

end_month = sample_date + relativedelta(months=+ 2) # SAME WITH begin_month CALCULATION BUT TO FIND THE LAST DATE OF NEXT MONTH WE JUMP 2 MONTHS FORWARD
end_month = end_month + relativedelta(days=- (int(dt.datetime.strftime(end_month, "%d"))))

while begin_month <= end_month:
    day_name = dt.datetime.strftime(begin_month, "%A") # DAY NAME (LOCAL SETTINGS)
    weekday_number = dt.datetime.strftime(begin_month, "%w") # WEEKDAY NUMBER (SUNDAY=0)
    # print("begin_month >>", begin_month, ",day name >>", day_name, ",weekday number >>", weekday_number)
   
    if int(dt.datetime.strftime(begin_month, "%w")) == 4 and begin_month != end_month:
        result_date = begin_month
    begin_month += dt.timedelta(days = 1) # INCREMENTING THE DATE AS 1

print("sample_date >>", sample_date)
print("begin_month >>", begin_month)
print("end_month >>", end_month)
print("result_date >>", result_date)
print("result_date formatted>>", dt.datetime.strftime(result_date, "%Y-%m-%d"))


"""
USEFUL SOURCES:
1) https://docs.python.org/3/library/datetime.html#strftime-strptime-behavior
2) https://www.geeksforgeeks.org/python-datetime-timedelta-function/
3) https://dateutil.readthedocs.io/en/stable/relativedelta.html
"""
