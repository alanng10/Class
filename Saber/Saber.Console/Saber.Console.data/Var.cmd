@echo off

set VarIsSet=0
set WorkingFold=%cd%

if "%QtRoot%" == "" (
    set /p QtRoot=<QtRootPathWindows.txt
    set VarIsSet=1
)

if "%VarIsSet%" == "1" (
    call "%QtRoot%\6.8.1\mingw_64\bin\qtenv2.bat"1>NUL
    cd "%WorkingFold%"
)