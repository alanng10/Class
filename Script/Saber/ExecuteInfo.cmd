@echo off

set InfoOutFold=.\Out\Info
mkdir %InfoOutFold% 1>NUL 2>NUL

Out\net8.0\saber.exe info "Docue" "%InfoOutFold%"
echo Status: %errorlevel%