using DesignPatterns;

IHandler lower_case = new lowerCase();
IHandler multiplier = new Multiplier();
IHandler findemail = new FindEmail();

lower_case.Successor(multiplier);
multiplier.Successor(findemail); 

lower_case.Handle("ASJDASjskdas121312 AJKDjad 12131 jdajdjd@djs.com 31912 dsadfksdaf@kkfasd.com");
