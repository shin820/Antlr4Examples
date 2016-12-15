@ECHO OFF

SET CLASSPATH=%SystemDrive%%HomePath%\.nuget\packages\Antlr4.CodeGenerator\4.5.4-beta001\tools\antlr4-csharp-4.5.4-SNAPSHOT-complete.jar
SET Namespace=Antlr4Examples.Calculator
SET  G4Folder=%~dp0
SET   Options=-Dlanguage=CSharp_v4_5 -package %Namespace% -visitor -listener -encoding UTF8

FOR /r  %%i in (*.g4) DO ECHO %%~ni

SET    G4File=CalculatorLexer
DEL /Q ^
	%G4Folder%%G4File%.tokens		  ^
	%G4Folder%%G4File%.cs

SET    G4File=CalculatorParser
DEL /Q ^
	%G4Folder%%G4File%.tokens		  ^
	%G4Folder%%G4File%.cs		  ^
	%G4Folder%%G4File%Listener.cs	  ^
	%G4Folder%%G4File%BaseListener.cs ^
	%G4Folder%%G4File%Visitor.cs	  ^
	%G4Folder%%G4File%BaseVisitor.cs

SET G4File=Calculator
SET FullPath=%G4Folder%%G4File%.g4
JAVA org.antlr.v4.Tool %FullPath% %Options%

PAUSE
