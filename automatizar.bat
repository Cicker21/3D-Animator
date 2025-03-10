@echo off
color a
set /p commitMsg=Ingrese el mensaje del commit: 
git add -A
git commit -m "%commitMsg%"
git push origin main
pause
