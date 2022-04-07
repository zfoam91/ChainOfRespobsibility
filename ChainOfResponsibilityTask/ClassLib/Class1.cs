namespace DesignPatterns;
using System.Text.RegularExpressions;
using System;
public abstract class IHandler
{
    protected IHandler? nextHandler;
    protected IHandler? prevHandler;
    public void Successor(IHandler next){
        this.nextHandler = next;
        next.Predessor(this);
    }
    public void Predessor(IHandler prev){
        this.prevHandler = prev;
    }
    public IHandler(){
        this.nextHandler = null;
        this.prevHandler = null;
    }
    public abstract void Handle(string data);

}

public class lowerCase:IHandler{
    public override void Handle(string data)
    {
        string temp = data.ToLower();
        if(this.nextHandler != null){
            this.nextHandler.Handle(temp);
        }else{
            Console.WriteLine($"{temp}");
        }
    }
    public lowerCase():base(){}

}
public class Multiplier:IHandler{
    public override void Handle(string data)
    {
        string res="";
        int temp=0;
        bool flag=false;
        for(int i=0;i < data.Length;i++){
            if (data[i]< '0' || data[i] > '9' || i == data.Length - 1){
                if(flag==true){
                    res += temp.ToString();
                    temp=0;
                    flag=false;
                }
                res += data[i];
            }else{
                temp = temp*10+ (int)char.GetNumericValue(data[i])*2;
                flag=true;
            }
        }
        if(this.nextHandler != null){
            this.nextHandler.Handle(res);
        }else{
            Console.WriteLine($"{res}");
        }
        
    }
    public Multiplier():base(){}
}

public class FindEmail:IHandler{
    public override void Handle(string data)
    {

        Regex rg = new Regex("\\S+@\\S+\\.\\S+");
        MatchCollection match = rg.Matches(data);
        string newdata = data;
        Console.WriteLine($"{match.Count}");
        for(int i = 0; i< match.Count; i++){
            int ind = match[i].Value.IndexOf('@');
            newdata = Regex.Replace(newdata, match[i].Value, match[i].Value.Substring(ind));
        }
        if(this.nextHandler != null){
            this.nextHandler.Handle(newdata);
        }else{
            Console.WriteLine($"{newdata}");
        }

    }
    public FindEmail():base(){}
}