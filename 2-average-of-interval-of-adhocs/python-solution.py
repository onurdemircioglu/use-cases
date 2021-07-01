# -*- coding: utf-8 -*-

import pandas as pd
import datetime as dt
import numpy as np

# Our sample file
my_file = (r'E:\Interval of ad hocs.xlsx')

# Reading excel with Pandas
df = pd.read_excel(my_file, sheet_name = "Data" , header = 0, index_col = 0, usecols = "A:B")

# Removing duplicates (if exist)
df.drop_duplicates(subset ="Request Date",
                     keep = False, inplace = True)

# Sorting, they should be ascending order same as before to make calculations with previous row
df.sort_values("Request Date", inplace = True)

# Creating new column with the previous row value
df["Previous Record"] = df.shift(1, axis = 0)

# Creating new column with calculated difference between current and previous row
df["Difference"] = df["Request Date"] - df["Previous Record"]
# print(df.head(7))

# Calculating the average
my_avg = df["Difference"].mean()
print("my_avg >> ",my_avg)
print("type of my_avg >> ", type(my_avg))

# Rounding to nearest integer that is equal to or less than.
my_avg2 = my_avg.floor('1D')
print("my_avg2 >> ",my_avg2)

# Converting strint to removing unnecessary formats
my_avg3 = str(my_avg2).replace(" 00:00:00","")

print("The average of the differences in request dates >> ", my_avg3)
