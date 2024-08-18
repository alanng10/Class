namespace Z.Tool.PrusateGen;





class PrusateGen : Any
{
    public override bool Init()
    {
        base.Init();



        this.NewLine = "\n";


        this.IntTypeName = "Int";



        this.Combine = "_";




        this.FieldGetFunctionOperate = new FieldGetFunctionOperate();

        this.FieldGetFunctionOperate.Init();

        this.FieldGetFunctionOperate.Gen = this;



        this.FieldSetFunctionOperate = new FieldSetFunctionOperate();

        this.FieldSetFunctionOperate.Init();

        this.FieldSetFunctionOperate.Gen = this;



        this.MethodCallFunctionOperate = new MaideCallFunctionOperate();

        this.MethodCallFunctionOperate.Init();

        this.MethodCallFunctionOperate.Gen = this;




        this.PrudateFileName = "ToolData/Prusate/Prusate.txt";



        this.OutputFilePath = "../../Infra/Infra/Prusate.h";
        



        return true;
    }
    




    public virtual bool Execute()
    {
        string classListString;

        classListString = this.GetClassListString();



        string methodListString;

        methodListString = this.GetMethodListString();




        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead(this.PrudateFileName);


        StringBuilder sb;

        sb = new StringBuilder();


        sb.Append(ka);


        sb.Replace("#ClassList#", classListString);


        sb.Replace("#MethodList#", methodListString);




        string k;

        k = sb.ToString();



        infra.StorageTextWrite(this.OutputFilePath, k);




        return true;
    }
    




    public virtual ReadResult ReadResult { get; set; }





    protected virtual string PrudateFileName { get; set; }




    protected virtual string OutputFilePath { get; set; }




    public virtual string NewLine { get; set; }



    public virtual string IntTypeName { get; set; }



    public virtual string Combine { get; set; }





    protected virtual FieldGetFunctionOperate FieldGetFunctionOperate { get; set; }



    protected virtual FieldSetFunctionOperate FieldSetFunctionOperate { get; set; }



    protected virtual MaideCallFunctionOperate MethodCallFunctionOperate { get; set; }





    protected virtual string GetClassListString()
    {
        StringBuilder sb;
        sb = new StringBuilder();

        Table table;
        table = this.ReadResult.Class;
        
        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            this.AppendClass(sb, varClass);
        }

        string o;
        o = sb.ToString();
        return o;
    }





    protected virtual bool AppendClass(StringBuilder sb, Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AppendClassNew(sb, varClass);
        }

        


        this.AppendFieldArray(sb, varClass, varClass.Field);


        this.AppendNewLineIfNotEmpty(sb, varClass.Field);



        this.AppendMethodArray(sb, varClass, varClass.Maide);


        this.AppendNewLineIfNotEmpty(sb, varClass.Maide);




        this.AppendFieldArray(sb, varClass, varClass.StaticField);


        this.AppendNewLineIfNotEmpty(sb, varClass.StaticField);



        this.AppendMethodArray(sb, varClass, varClass.StaticMaide);


        this.AppendNewLineIfNotEmpty(sb, varClass.StaticMaide);




        this.AppendDelegateArray(sb, varClass, varClass.Delegate);


        this.AppendNewLineIfNotEmpty(sb, varClass.Delegate);




        return true;
    }





    protected virtual bool AppendFieldArray(StringBuilder sb, Class varClass, Array fieldArray)
    {
        int count;

        count = fieldArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Field field;

            field = (Field)fieldArray.GetAt(i);


            this.AppendField(sb, varClass, field);



            i = i + 1;
        }



        return true;
    }





    protected virtual bool AppendMethodArray(StringBuilder sb, Class varClass, Array methodArray)
    {
        int count;

        count = methodArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Maide method;

            method = (Maide)methodArray.GetAt(i);


            this.AppendMethod(sb, varClass, method);


            i = i + 1;
        }



        return true;
    }





    protected virtual bool AppendDelegateArray(StringBuilder sb, Class varClass, Array delegateArray)
    {
        int count;

        count = delegateArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Delegate varDelegate;

            varDelegate = (Delegate)delegateArray.GetAt(i);



            this.AppendDelegate(sb, varClass, varDelegate);



            i = i + 1;
        }



        return true;
    }






    protected virtual bool AppendField(StringBuilder sb, Class varClass, Field field)
    {
        this.FieldGetFunctionOperate.Class = varClass;

        this.FieldGetFunctionOperate.Field = field;



        this.FieldSetFunctionOperate.Class = varClass;

        this.FieldSetFunctionOperate.Field = field;




        this.AppendFunction(sb, this.FieldGetFunctionOperate);



        this.AppendFunction(sb, this.FieldSetFunctionOperate);




        return true;
    }





    protected virtual bool AppendMethod(StringBuilder sb, Class varClass, Maide method)
    {
        this.MethodCallFunctionOperate.Class = varClass;

        this.MethodCallFunctionOperate.Method = method;



        this.AppendFunction(sb, this.MethodCallFunctionOperate);




        return true;
    }






    protected virtual bool AppendFunction(StringBuilder sb, FunctionOperate functionOperate)
    {
        this.AppendFunctionHeader(sb);
        



        sb.Append(this.IntTypeName).Append(" ");
        
        

        functionOperate.ExecuteName(sb);
        
        
        
        sb.Append("(");

        

        functionOperate.ExecuteParam(sb);
        
        
        
        sb.Append(")").Append(";").Append(this.NewLine);




        return true;
    }





    protected virtual bool AppendFunctionHeader(StringBuilder sb)
    {
        sb.Append("Infra_Api").Append(" ");



        return true;
    }





    protected virtual bool AppendDelegate(StringBuilder sb, Class varClass, Delegate varDelegate)
    {
        sb
            .Append("typedef").Append(" ")
            .Append(this.IntTypeName).Append(" ")
            .Append("(").Append("*");


        this.AppendDelegateName(sb, varClass, varDelegate);


        sb
            .Append(")");



        sb
            .Append("(");



        this.AppendDelegateParam(sb, varDelegate.Param);


    
        sb
            .Append(")")
            .Append(";").Append(this.NewLine);




        return true;
    }





    protected virtual bool AppendDelegateName(StringBuilder sb, Class varClass, Delegate varDelegate)
    {
        sb.Append(varClass.Name).Append(this.Combine).Append(varDelegate.Name).Append(this.Combine).Append("Maide");


        return true;
    }





    protected virtual bool AppendDelegateParam(StringBuilder sb, Array param)
    {
        bool b;

        b = (param.Count == 0);


        if (!b)
        {
            string oa;

            oa = this.GetParamItem(param, 0);



            this.AppendVarDeclare(sb, oa);



            this.AppendParamWithOffset(sb, param, 1);
        }



        return true;
    }





    protected virtual string GetMethodListString()
    {
        StringBuilder sb;

        sb = new StringBuilder();



        int count;

        count = this.ReadResult.Maide.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Maide method;

            method = (Maide)this.ReadResult.Maide.GetAt(i);



            this.AppendMethod(sb, null, method);



            i = i + 1;
        }



        string o;

        o = sb.ToString();



        return o;
    }






    public virtual bool AppendParamWithOffset(StringBuilder sb, Array param, int offset)
    {
        int count;

        count = param.Count - offset;



        int i;

        i = 0;


        while (i < count)
        {
            int ia;

            ia = i + offset;



            string ka;

            ka = this.GetParamItem(param, ia);



            
            this.AppendParamCombine(sb);



            this.AppendVarDeclare(sb, ka);




            i = i + 1;
        }



        return true;
    }





    public virtual bool AppendVarDeclare(StringBuilder sb, string varName)
    {
        sb.Append(this.IntTypeName).Append(" ").Append(varName);



        return true;
    }




    public virtual bool AppendParamCombine(StringBuilder sb)
    {
        sb.Append(",").Append(" ");


        return true;
    }





    protected virtual bool AppendNewLineIfNotEmpty(StringBuilder sb, Array array)
    {
        if (array.Count == 0)
        {
            return true;
        }



        sb.Append(this.NewLine);



        return true;
    }





    public virtual string GetParamItem(Array param, int index)
    {
        return (string)param.GetAt(index);
    }




    protected virtual bool AppendClassNew(StringBuilder sb, Class varClass)
    {
        sb.Append("InfraApiNew").Append("(").Append(varClass.Name).Append(")").Append(this.NewLine);



        return true;
    }
}