namespace Z.Tool.NodeListSourceGen;






public class NodeGen : Any
{
    public override bool Init()
    {
        base.Init();



        this.ToolInfra = ToolInfra.This;



        return true;
    }





    public virtual Array ClassArray { get; set; }



    protected virtual ToolInfra ToolInfra { get; set; }



    protected virtual string NodeSourceText { get; set; }



    public virtual bool Execute()
    {
        this.NodeSourceText = this.ToolInfra.ReadTextFile("NodeSource.txt");




        int count;

        count = this.ClassArray.Count;



        int i;

        i = 0;


        while (i < count)
        {
            Class varClass;

            varClass = (Class)this.ClassArray.Get(i);



            this.ExecuteClass(varClass);



            i = i + 1;
        }




        return true;
    }



    protected virtual bool ExecuteClass(Class varClass)
    {
        string fieldListString;

        fieldListString = this.GetFieldListString(varClass.Field);



        StringBuilder sb;

        sb = new StringBuilder();


        sb.Append(this.NodeSourceText);



        sb.Replace("#ClassName#", varClass.Name);


        sb.Replace("#BaseClassName#", varClass.Base);


        sb.Replace("#FieldList#", fieldListString);




        string k;

        k = sb.ToString();



        string outputFilePath;

        outputFilePath = "../../Class/Class.Node/Z_Node_" + varClass.Name + ".cs";




        this.ToolInfra.WriteTextFile(outputFilePath, k);




        return true;
    }

    protected virtual string GetFieldListString(Array fieldList)
    {
        StringBuilder sb;
        sb = new StringBuilder();

        int count;
        count = fieldList.Count;
        Field field;
        int i;
        i = 0;
        while (i < count)
        {
            field = (Field)fieldList.Get(i);
            this.AppendField(sb, field);
            i = i + 1;
        }
        string k;
        k = sb.ToString();
        return k;
    }

    protected virtual bool AppendField(StringBuilder sb, Field field)
    {
        this.ToolInfra.AppendIndent(sb, 1);




        string className;

        className = this.GetGenFieldClassName(field.Class);



        sb
            .Append("public").Append(" ").Append("virtual").Append(" ")
            .Append(className).Append(" ").Append(field.Name).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(";").Append(" ").Append("set").Append(";")
            .Append(" ").Append("}")
            .Append(this.ToolInfra.NewLine)
            ;



        return true;
    }





    protected virtual string GetGenFieldClassName(string fieldClassName)
    {
        string k;


        k = fieldClassName;



        bool b;

        b = false;



        if (!b & k == "Bool")
        {
            k = "bool";


            b = true;
        }
        if (!b & k == "Int")
        {
            k = "long";


            b = true;
        }
        if (!b & k == "String")
        {
            k = "string";


            b = true;
        }
        return k;
    }
}