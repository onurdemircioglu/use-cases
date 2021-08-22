Requirements:

1. There are 2 versions.
    * In First Version it is quarter based
    * Second Version starts with report month and continues quarterly.
3. If report month is equal to end of any quarter First Version should be used (formatted as 2021 Q2)
4. If report month is not equal to end of any quarter Second Version should be used (formatted as 2021 Jul)
    * Both versions must include YTD (year to date) period based on report date
    * For First Version if report date is 31.07.2021, report date should be shown as 2021 Jul and YTD period should be 2021 Q4.
    * For Second Version if report date is 30.06.2021, report date should be shown as 2021 Q2 and YTD period should be 2021 Q4
    * For Second Version if there is no viable YTD column in periods then last quarter (THIRD QUARTER) must be shown YTD based on the report date
5. YTD period doesn't always need to be on the same column
6. For First Version, periods can't show the same quarter, if that happens duplicate quarter column must be shown previous quarter before itself 
7. For Second Version, first quarter (ordering is from right to left) should be first quarter before the report date
8. First Version contains 3 columns, Second Version contains 4 columns. Last column on the left should be empty for quarter based calculations
9. On last column (second or third depending on the version) it should only reach until 31.12.2017. Beware it needs to contain 3 months due to it always shows quarters. If it can't cover all 3 months, it wasn’t supposed to be on the report



