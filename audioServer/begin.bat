A:
cd audioServer

pscp.exe -P 44888 -pw Maddoglogo8 text.txt logan@192.168.254.23:/srv/tts

plink.exe -P 44888 -pw Maddoglogo8 -m remoteCommands.txt logan@192.168.254.23 

pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/srv/tts/number.txt /audioServer
set /p number=<number.txt

pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/srv/tts/foutput%number%.wav output
pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/srv/tts/poutput%number%.wav output
pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/srv/tts/axOut/goutput%number%_MP3WRAP.mp3 output

plink.exe -P 44888 -pw Maddoglogo8 -m delOutput.txt logan@192.168.254.23 
echo %number%
pause
