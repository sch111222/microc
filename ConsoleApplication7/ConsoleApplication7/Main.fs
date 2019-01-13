module ConsoleApplication7.Test


open System
open System.Diagnostics
open System.IO
open System.Reflection
open NUnit.Framework
open Compiler


let customTest() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;

        for(b<5, b=b+1;){
         a=1;
        }
	    return b;
}
      "
      let targetFileName = Path.Combine("Demo","custom.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode
let customTest1() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;

        while(b<5){
         b=b+1;
        }
	    return b;
}
      "
      let targetFileName = Path.Combine("Demo","custom1.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode
let customTest2() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;
        a=1;
        b=a+b;
	    return b;
}
      "
      let targetFileName = Path.Combine("Demo","custom2.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode
let customTest3() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;

        if(b<5){
         b=b+1;
        }
	    return b;
}
      "
      let targetFileName = Path.Combine("Demo","custom3.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode
let customTest4() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;

        if(b>5){
         b=b+1;
        }
        else{
        b=b-1;
        }
	    return b;
}
      "
      let targetFileName = Path.Combine("Demo","custom4.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode
let customTest5() =
      let code = "
       int a;
       int b;
        int main(void) {
        b=3;
        a=4
        
	    return a*b;
}
      "
      let targetFileName = Path.Combine("Demo","custom5.exe")
      Compiler.compileToFile targetFileName code

      let testProcess =Process.Start(targetFileName)
      testProcess.WaitForExit()

      testProcess.ExitCode

[<EntryPoint>]
let main args =
    Console.Write "\n"
    customTest()
    Console.Write "\n"
    customTest1()
    Console.Write "\n"
    customTest2()
    Console.Write "\n"
    customTest3()
    Console.Write "\n"
    customTest4()
    Console.Write "\n"
    0