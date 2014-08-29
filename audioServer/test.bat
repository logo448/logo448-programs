SetLocal EnableDelayedExpansion
set number=
for /F "delims=" %%i in (number.txt) do set number=!number! %%i

set "str=umber.txt"
set "str2=%content%%str%"
type %str2%
type %content%umber.txt
EndLocal
pause