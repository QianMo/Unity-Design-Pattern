//-------------------------------------------------------------------------------------
//	InterpreterExample2.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Reflection;

public class InterpreterExample2 : MonoBehaviour
{
	void Start ( )
	{
        string question1 = "2 Gallons to pints";
        AskQuestion(question1);

        string question2 = "4 Gallons to tablespoons";
        AskQuestion(question2);
    }

    protected void AskQuestion(string question)
    {
        ConversionContext context = new ConversionContext(question);

        string fromConversion = context.fromConversion; // in this example fromConversion is always the second word
        string toConversion = context.toConversion;
        double quantity = context.quantity;

        // Trying to get a matching class for the word "fromConversion"
        try
        {
            // Getting the type, we also have to define the namespace (in this case InterpreterPattern as defined above)
            // and fromConversion should hold the class name (in this case Gallons)
            Type type = Type.GetType("InterpreterPattern." + fromConversion);
            object instance = Activator.CreateInstance(type);
            Expression expression = instance as Expression;

            // Get the matching method: e.g. (toConversion = pints)
            MethodInfo method = type.GetMethod(toConversion);
            string result = (string)method.Invoke(instance, new object[] { quantity });

            Debug.Log("Output: " + quantity.ToString() + "  " + fromConversion + " are " + result + " " + toConversion);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}


// Context object that does try to make sense of an input string:
public class ConversionContext
{
    public string conversionQues { get; protected set; }

    public string fromConversion { get; protected set; }

    public string toConversion { get; protected set; }

    public double quantity { get; protected set; }

    protected string[] partsOfQues;



    // here happens the sensemaking
    public ConversionContext(string input)
    {
        Debug.Log("Input: " + input);
        this.conversionQues = input;
        this.partsOfQues = input.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

        if (partsOfQues.Length >= 4)
        {

            fromConversion = GetCapitalized(partsOfQues[1]);
            // 1 gallon to pints
            toConversion = GetLowerCase(partsOfQues[3]);

            // get quantitiy:
            double quant;
            double.TryParse(partsOfQues[0], out quant);
            this.quantity = quant;
        }
    }

    // Some helper methods:
    protected string GetCapitalized(string word)
    {
        word = word.ToLower();
        word = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);

        // make sure a 's' is appended
        if (word.EndsWith("s") == false)
        {
            word += "s";
        }

        return word;
    }

    protected string GetLowerCase(string word)
    {
        return word.ToLower();
    }
}




// Definition of all the things the concrete expression
// shall be able to convert into
public abstract class Expression
{
    public abstract string gallons(double quantity);

    public abstract string quarts(double quantity);

    public abstract string pints(double quantity);

    public abstract string cups(double quantity);

    public abstract string tablespoons(double quantity);
}


// concrete class
public class Gallons : Expression
{
    #region implemented abstract members of Expression

    public override string gallons(double quantity)
    {
        return quantity.ToString();
    }

    public override string quarts(double quantity)
    {
        return (quantity * 4).ToString();
    }

    public override string pints(double quantity)
    {
        return (quantity * 8).ToString();
    }

    public override string cups(double quantity)
    {
        return (quantity * 16).ToString();
    }

    public override string tablespoons(double quantity)
    {
        return (quantity * 256).ToString();
    }

    #endregion
}
