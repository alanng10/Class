namespace Class.Console;

class ObjectString : ClassInfraGen
{
    public override bool Init()
    {
        base.Init();
        this.PrintableChar = PrintableChar.This;


        this.NodeType = typeof(NodeNode);
        this.CodeType = typeof(Code);
        this.TokenType = typeof(TokenToken);
        this.CommentType = typeof(TokenInfo);

        this.SComma = this.S(",");
        this.SSpace = this.S(" ");
        this.SNull = this.S("null");

        this.IndentSize = 4;
        return true;
    }

    protected virtual PrintableChar PrintableChar { get; set; }
    private String SComma { get; set; }
    private String SSpace { get; set; }
    private String SNull { get; set; }
    private long IndentSize { get; set; }
    private long SpaceCount { get; set; }
    private Type NodeType { get; set; }
    private Type CodeType { get; set; }
    private Type TokenType { get; set; }
    private Type CommentType { get; set; }

    public virtual String Result()
    {
        return this.AddResult();
    }

    public virtual bool Execute(object any)
    {
        this.AddClear();

        this.SpaceCount = 0;

        this.ExecuteAny(any);
        return true;
    }

    public virtual bool ExecuteAny(object any)
    {
        if (any == null)
        {
            this.Add(this.SNull).Add(this.SComma).AddLine();

            return true;
        }

        if (any is bool)
        {
            bool ka;
            ka = (bool)any;

            String aa;
            aa = null;
            if (ka)
            {
                aa = this.TextInfra.BoolTrueString;
            }
            if (!ka)
            {
                aa = this.TextInfra.BoolFalseString;
            }

            this.Add(aa).Add(this.SComma).AddLine();

            return true;
        }
        if (any is long)
        {
            long kb;
            kb = (long)any;

            this.Append(k.ToString()).Append(",").AppendLine();


            return true;
        }
        if (varObject is string)
        {
            string s;
            
            s = (string)varObject;


            s = this.EscapeString(s);


            this.Append("\"").Append(s).Append("\"").Append(",").AppendLine();


            return true;
        }



        Type objectType;
        
        objectType = varObject.GetType();


        string objectTypeName;
        
        objectTypeName = objectType.Name;



        this.Append(objectTypeName).AppendLine();
            

        this.AppendSpace().Append("{").AppendLine();


        this.SpaceCount = this.SpaceCount + this.IndentSize;

            



        this.PropertyList(objectType, varObject);
        







        this.SpaceCount = this.SpaceCount - this.IndentSize;


        this.AppendSpace().Append("}").Append(",").AppendLine();



        return true;
    }






    private bool PropertyList(Type objectType, object varObject)
    {
        IEnumerablePropertyInfo propertyInfoList;


        propertyInfoList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);



        PropertyInfoDictionary dictionary;
        
        dictionary = new PropertyInfoDictionary();



        foreach (PropertyInfo propertyInfo in propertyInfoList)
        {
            if (!dictionary.ContainsKey(propertyInfo.Name))
            {
                dictionary.Add(propertyInfo.Name, propertyInfo);
            }
        }



        propertyInfoList = dictionary.Values;




        foreach (PropertyInfo propertyInfo in propertyInfoList)
        {
            string fieldName;
                
            fieldName = propertyInfo.Name;


            Type resultType;
                
            resultType = propertyInfo.PropertyType;



            object fieldGetValue;


            fieldGetValue = propertyInfo.GetValue(varObject);



            bool b;
            b = false;
            bool objectIsNode;
            objectIsNode = this.IsType(objectType, this.NodeType);
            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "NodeAny")
                {
                    b = true;
                }
            }

            if (!b)
            {
                this.Field(fieldName, resultType, fieldGetValue);
            }
        }



        return true;
    }







    private bool Fields(Type objectType, object varObject)
    {
        IEnumerableFieldInfo fieldInfos;


        fieldInfos = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance);



        FieldInfoDictionary dictionary;
        
        dictionary = new FieldInfoDictionary();



        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (!dictionary.ContainsKey(fieldInfo.Name))
            {
                dictionary.Add(fieldInfo.Name, fieldInfo);
            }
        }



        fieldInfos = dictionary.Values;




        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            string fieldName;
                
            fieldName = fieldInfo.Name;


            Type resultType;
                
            resultType = fieldInfo.FieldType;



            object fieldGetValue;


            fieldGetValue = fieldInfo.GetValue(varObject);




            bool objectIsNode;

            objectIsNode = this.IsType(objectType, this.NodeType);



            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "Id")
                {
                    continue;
                }
            }



            this.Field(fieldName, resultType, fieldGetValue);
        }



        return true;
    }




    private bool Field(string fieldName, Type resultType, object fieldGetValue)
    {
        this.AppendSpace().Append(fieldName).Append(" ").Append(":").Append(" ");


        bool b;
        b = false;

        if (!b & this.IsType(resultType, typeof(IEnumerable)) & !resultType.Equals(typeof(string)))
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + fieldName.Length + 3;


            this.Append("[").AppendLine();


            this.SpaceCount = this.SpaceCount + this.IndentSize;


            IEnumerable objects;
            objects = (IEnumerable)fieldGetValue;


            IEnumerator enumerator;
            enumerator = objects.GetEnumerator();

            while (enumerator.MoveNext())
            {
                object o;
                o = enumerator.Current;


                this.AppendSpace();


                this.ExecuteObject(o);
            }


            this.SpaceCount = this.SpaceCount - this.IndentSize;


            this.AppendSpace().Append("]").Append(",").AppendLine();


            this.SpaceCount = lastSpaceCount;

            b = true;
        }
        if (!b & this.IsType(resultType, typeof(List)))
        {
            List list;
            list = (List)fieldGetValue;

            Iter iter;

            iter = list.IterCreate();


            this.ExecuteList(fieldName, list, iter);

            b = true;
        }
        if (!b)
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + fieldName.Length + 3;

            object n;
            n = fieldGetValue;
            this.ExecuteObject(n);


            this.SpaceCount = lastSpaceCount;
        }
        return true;
    }





    protected virtual bool ExecuteList(string fieldName, List list, Iter iter)
    {
        int lastSpaceCount;


        lastSpaceCount = this.SpaceCount;




        this.SpaceCount = this.SpaceCount + fieldName.Length + 3;




        this.Append("[").AppendLine();



        this.SpaceCount = this.SpaceCount + this.IndentSize;




        list.IterSet(iter);



        while (iter.Next())
        {
            object o;

            o = iter.Value;

            this.AppendSpace();
            this.ExecuteObject(o);
        }




        this.SpaceCount = this.SpaceCount - this.IndentSize;




        this.AppendSpace().Append("]").Append(",").AppendLine();




        this.SpaceCount = lastSpaceCount;




        return true;
    }




    private bool IsType(Type objectType, Type type)
    {
        bool b;


        b = type.IsAssignableFrom(objectType);



        bool ret;

        ret = b;

        return ret;
    }




    public string EscapeString(string o)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        PrintableChar printableChar;
        printableChar = this.PrintableChar;
        StringCreate stringCreate;
        stringCreate = this.StringCreate;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        int count;
        count = o.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = o[i];

            bool b;
            b = false;
            if (!b)
            {
                if (oc == '\\')
                {
                    this.JoinAppend(h, "\\\\");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    this.JoinAppend(h, "\\\"");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\t')
                {
                    this.JoinAppend(h, "\\t");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\n')
                {
                    this.JoinAppend(h, "\\n");
                    b = true;
                }
            }
            if (!b)
            {
                bool ba;
                ba = printableChar.Get(oc);

                if (!ba)
                {
                    int k;
                    k = oc;

                    char letterStart;
                    letterStart = 'a';

                    int countA;
                    countA = sizeof(char) * 2;

                    Data data;
                    data = new Data();
                    data.Count = countA * sizeof(char);
                    data.Init();

                    int iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        int index;
                        index = countA - 1 - iA;

                        int ka;
                        ka = k >> (index * 4);
                        ka = ka & 0xf;

                        char kb;
                        kb = textInfra.DigitChar(ka, letterStart);
                        
                        textInfra.DataCharSet(data, iA, kb);

                        iA = iA + 1;
                    }

                    string kk;
                    kk = stringCreate.Data(data, null);

                    this.JoinAppend(h, "\\u");
                    this.JoinAppend(h, kk);
                }

                if (ba)
                {
                    h.Execute(oc);
                }
            }

            i = i + 1;
        }


        string ret;
        ret = h.Result();

        return ret;
    }

    public virtual ObjectString AddSpace()
    {
        long count;
        count = this.SpaceCount;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(this.SSpace);

            i = i + 1;
        }
        return this;
    }
}