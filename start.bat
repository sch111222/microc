
set FSLEX6=%~dp0FsLexYacc.6.1.0\build
set FSLEX7=%~dp0FsLexYacc.7.0.6\build
set FSLEX=%FSLEX7%

set FS=%~dp0FSharp.Compiler.Tools.4.1.27\tools

set PATH=%FSLEX%;%FS%;%PATH%
echo Added %FSLEX% and %FS% to PATH.
cmd.exe