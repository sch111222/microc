

使用说明

A. fslex,fsyacc 生成 四则运算表达式语言 的 词法分析器 语法分析器
 
   // 输入ExprLex.fsl 生成词法分析器 "ExprLex.fs"
   fslex --unicode ExprLex.fsl
   
   //  输入 ExprPar.fsy 生成语法分析器
   fsyacc --module ExprPar ExprPar.fsy
   
   //生成action table goto table
   fsyacc -v --module ExprPar ExprPar.fsy
   
   // fsi Repl
   fsi -r FsLexYacc.Runtime.dll  Absyn.fs ExprPar.fs ExprLex.fs Parse.fs
   
   
   // 生成的文件 "ExprPar.fs" "ExprLex.fs" 需要
   // 引用运行时库  FsLexYacc.Runtime.dll 中的类型
   #r  "FsLexYacc.Runtime.dll"
   
   //加载 抽象语法定义"Absyn.fs" 
   //     词法分析器"ExprLex.fs" 
   //       语法分析器"ExprPar.fs" 
	//	  驱动模块"Parse.fs"
   #load "Absyn.fs" "ExprPar.fs" "ExprLex.fs" "Parse.fs"
 
   //打开Parse模块
   open Parse;;
 
   fromString "2 + 3 * 4";;
   fromString "let x = 3 in  2 + x * 4 end"
   fromFile "expr.in.txt";;        

   #q;; 


B. 生成词法分析器和语法分析器，并用解释器eval求值。编译器scomp编译到 stack Machine code , seval 执行 stack machine code 。

   fslex --unicode ExprLex.fsl
   fsyacc --module ExprPar ExprPar.fsy
   fsi -r  FsLexYacc.Runtime.dll  Absyn.fs ExprPar.fs ExprLex.fs Parse.fs Expr.fs

   open Parse;;
   open Expr;;
   run (fromString "2 + 3 * 4");;
   eval (fromString "2 + x * 4") [("x", 3)];;
   eval (fromString "let x = 1+2 in 2 + x * 4 end") [];;

   let code1 = scomp (fromString "2 + 3 * 4") [];;
   seval code1 [];;

   let code2 = scomp (fromString "2 + x * 4") [Bound "x"];;
   seval code2 [3];;

   let code3 = scomp (fromString "let x = 1+2 in 2 + x * 4 end") [];;
   seval code3 [];;

   #q;;
