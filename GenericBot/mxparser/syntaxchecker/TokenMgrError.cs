/* Generated By: CSCC: 4.0 (03/25/2012)  Do not edit this line. TokenMgrError.cs Version 3.0 */
using System;
namespace org.mariuszgromada.math.mxparser.syntaxchecker{

public class TokenMgrError : System.Exception{
    public class EOFException : System.IO.IOException{}
   /*
    * Ordinals for various reasons why an Error of this type can be thrown.
    */

   /**
    * Lexical error occured.
    */
   public static int LEXICAL_ERROR = 0;

   /**
    * An attempt wass made to create a second instance of a static token manager.
    */
   public static int STATIC_LEXER_ERROR = 1;

   /**
    * Tried to change to an invalid lexical state.
    */
   public static int INVALID_LEXICAL_STATE = 2;

   /**
    * Detected (and bailed out of) an infinite loop in the token manager.
    */
   public static int LOOP_DETECTED = 3;

   /**
    * Indicates the reason why the exception is thrown. It will have
    * one of the above 4 values.
    */
   int errorCode;

   /**
    * Replaces unprintable characters by their espaced (or unicode escaped)
    * equivalents in the given string
    */
   public static String addEscapes(String str) {
      System.Text.StringBuilder retval = new System.Text.StringBuilder();
      char ch;
      for (int i = 0; i < str.Length; i++) {
        switch (str[i]){
           case (char)0 : continue;
           case '\b':
              retval.Append("\\b");
              continue;
           case '\t':
              retval.Append("\\t");
              continue;
           case '\n':
              retval.Append("\\n");
              continue;
           case '\f':
              retval.Append("\\f");
              continue;
           case '\r':
              retval.Append("\\r");
              continue;
           case '\"':
              retval.Append("\\\"");
              continue;
           case '\'':
              retval.Append("\\\'");
              continue;
           case '\\':
              retval.Append("\\\\");
              continue;
           default:
              if ((ch = str[i]) < 0x20 || ch > 0x7e) {
                 String s = "0000" + ((int)ch).ToString("X");
                 retval.Append("\\u" + s.Substring(s.Length - 4, s.Length));
              } else {
                 retval.Append(ch);
              }
              continue;
        }
      }
      return retval.ToString();
   }

   /**
    * Returns a detailed message for the Error when it is thrown by the
    * token manager to indicate a lexical error.
    * Parameters : 
    *    EOFSeen     : indicates if EOF caused the lexicl error
    *    curLexState : lexical state in which this error occured
    *    errorLine   : line number when the error occured
    *    errorColumn : column number when the error occured
    *    errorAfter  : prefix that was seen before this error occured
    *    curchar     : the offending character
    * Note: You can customize the lexical error message by modifying this method.
    */
   protected static String LexicalError(bool EOFSeen, int lexState, int errorLine, int errorColumn, String errorAfter, char curChar) {
      return("Lexical error at line " +
           errorLine + ", column " +
           errorColumn + ".  Encountered: " +
           (EOFSeen ? "<EOF> " : ("\"" + addEscapes(""+(curChar)) + "\"") + " (" + (int)curChar + "), ") +
           "after : \"" + addEscapes(errorAfter) + "\"");
   }

   /**
    * You can also modify the body of this method to customize your error messages.
    * For example, cases like LOOP_DETECTED and INVALID_LEXICAL_STATE are not
    * of end-users concern, so you can return something like : 
    *
    *     "Internal Error : Please file a bug report .... "
    *
    * from this method for such cases in the release version of your parser.
    */
   public override String Message {
     get { return base.Message; }
   }

   /*
    * Constructors of various flavors follow.
    */

   public TokenMgrError() {
   }

   public TokenMgrError(String message, int reason) : base(message)
   { errorCode = reason; }

   public TokenMgrError(bool EOFSeen, int lexState, int errorLine, int errorColumn, String errorAfter, char curChar, int reason)
      : this(LexicalError(EOFSeen, lexState, errorLine, errorColumn, errorAfter, curChar), reason) {}
}

}
