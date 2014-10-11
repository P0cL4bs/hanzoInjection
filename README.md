<h1>:::HanzoInjection Tool:::</h1>
the HanzoIjection is a tool focused on injecting arbitrary codes in memory to bypass common antivirus solutions
<img src="https://dl.dropboxusercontent.com/u/97321327/HanzoInjetion/Screenshot_1.png"> 

Video Demo: https://www.youtube.com/watch?v=1Bb7ZuM3sho&list=UUx8AOiQBPughNfA-PsASZ9w
<h3>Documentation</h3>

------------------------------------------
<h4><strong>Commands list</strong></h4>

 OPTION        TYPE       DESCRIPTION<br>
-e,--execute  [.raw]      Name of file.bin, payload metasploit type raw<br>
-p,--payload  [.raw]      Payload meterpreter type [RAW]  requered parameter -o [output]<br>
-o,--output   [file.cs]   Output generate project file.cs injection memory payload c#<br>
-b,--binder   [NULL]      Binder File  EXE  with encrypt file PE not requered paramenter<br>
-h,--help     [Help]      show this help and exit<br>

------------------------------------------

<h4><strong>Example Usage:</strong></h4>

HanzoInjection.exe -e payload_meterpreter.bin<br>
HanzoInjection.exe -p meterpreter.bin -o injection_memory.cs<br>
HanzoInjection.exe -b<br>

------------------------------------------
<h4><strong>Hanzo Binder</strong></h4>
<img src="https://dl.dropboxusercontent.com/u/97321327/HanzoInjetion/Screenshot_2.png"> 



<h2>License</h2>
------------------------------------------
The MIT License (MIT)
Version 1.0
Copyright (c) 2014 Mh4-(msfcd3r) 
Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
