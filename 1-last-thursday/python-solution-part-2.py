# -*- coding: utf-8 -*-
import datetime as dt
from dateutil.relativedelta import relativedelta

sample_date = dt.datetime(2021,8,25) # YEAR, MONTH, DAY AND SO ON..

def last_weekday(v_date = dt.datetime.today(), weekday_input = -1):
    begin_month = v_date + relativedelta(months=+ 1) # CALCULATING THE NEXT MONTH FOR A GIVEN DATE
    begin_month = begin_month + relativedelta(days=- (int(dt.datetime.strftime(begin_month, "%d"))-1)) # AFTER CALCULATION OF NEXT MONTH, SUBTRACTING DAY TO FIND THE BEGINNING OF THIS MONTH

    end_month = v_date + relativedelta(months=+ 2) # SAME WITH begin_month CALCULATION BUT TO FIND THE LAST DATE OF NEXT MONTH WE JUMP 2 MONTHS FORWARD
    end_month = end_month + relativedelta(days=- (int(dt.datetime.strftime(end_month, "%d"))))

    if weekday_input == -1: # WE ARE NOT USING WEEKDAY NAME DUE TO IT DEPENDS ON LOCAL SETTINGS, ON THE OTHER HAND WEEKDAY NUMBER DOES NOT CHANGE. THURDAYS ARE ALWAYS 4TH DAY OF THE WEEK
        weekday_input = int(dt.datetime.strftime(v_date, "%w"))

    while begin_month <= end_month:
        if int(dt.datetime.strftime(begin_month, "%w")) == weekday_input and begin_month != end_month:
            result_date = begin_month
        begin_month += dt.timedelta(days = 1) # INCREMENTING THE DATE AS 1

    return result_date

print("sample_date >>", sample_date)
print("result_date >>", last_weekday(sample_date, 4))
print("result_date formatted>>", dt.datetime.strftime(last_weekday(sample_date, 4), "%Y-%m-%d"))

"""
SOURCES:
1) https://docs.python.org/3/library/datetime.html#strftime-strptime-behavior
2) https://www.geeksforgeeks.org/python-datetime-timedelta-function/
3) https://dateutil.readthedocs.io/en/stable/relativedelta.html
"""
