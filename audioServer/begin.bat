A:
cd audioServer

pscp.exe -P 44888 -pw Maddoglogo8 text.txt logan@192.168.254.23:/home/logan/tts

plink.exe -P 44888 -pw Maddoglogo8 -m remoteCommands.txt logan@192.168.254.23 

pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/home/logan/tts/number.txt /audioServer
set /p number=<number.txt

pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/home/logan/tts/foutput%number%.wav output
pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/home/logan/tts/poutput%number%.wav output
pscp.exe -P 44888 -pw Maddoglogo8 logan@192.168.254.23:/home/logan/tts/axOut/goutput%number%_MP3WRAP.mp3 output

plink.exe -P 44888 -pw Maddoglogo8 -m delOutput.txt logan@192.168.254.23 
echo %number%
pause
