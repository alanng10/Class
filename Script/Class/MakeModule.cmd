@echo off

echo Make Module
echo:
pushd Class\ClassExe
dotnet build -v quiet
popd