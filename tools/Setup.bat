rem Generate visual studio files and run the devcmd init
@echo off
rem Set game paths below
cd tools
premake5.exe vs2022
cd ../build
call "C:\Program Files\Microsoft Visual Studio\2022\Preview\Common7\Tools\VsDevCmd.bat"
