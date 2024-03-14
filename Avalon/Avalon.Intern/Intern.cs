namespace Avalon.Intern;






public class Intern : object
{
    public static Intern This { get; } = ShareCreate();




    private static Intern ShareCreate()
    {
        Intern share;

        share = new Intern();


        share.Init();


        return share;
    }





    public virtual bool Init()
    {
        return true;
    }








    [SystemThreadStatic]
    public static object ThisThread = null;







    public virtual ulong MaidePointer(SystemDelegate d)
    {
        SystemIntPtr u;

        u = Marshal.GetFunctionPointerForDelegate(d);



        ulong a;

        a = (ulong)u;



        return a;
    }






    public virtual bool CopyText(ulong dest, char[] source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (char* p = source)
            {
                char* pa;

                pa = p + index;



                ulong u;

                u = (ulong)pa;



                ulong oa;

                oa = count * 2;



                Extern.Copy(dest, u, oa);
            }
        }



        return true;
    }







    public virtual bool CopyString(ulong dest, string source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (char* p = source)
            {
                char* pa;

                pa = p + index;



                ulong u;

                u = (ulong)pa;



                ulong oa;

                oa = count * 2;



                Extern.Copy(dest, u, oa);
            }
        }



        return true;
    }






    public virtual bool StreamRead(ulong stream, byte[] dataArray, ulong data, ulong range)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                ulong u;

                u = (ulong)p;



                ulong dataValue;

                dataValue = u;



                Extern.Data_ValueSet(data, dataValue);



                Extern.Stream_Read(stream, data, range);



                Extern.Data_ValueSet(data, 0);
            }
        }



        return true;
    }





    public virtual bool StreamWrite(ulong stream, byte[] dataArray, ulong data, ulong range)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                ulong u;

                u = (ulong)p;



                ulong dataValue;

                dataValue = u;



                Extern.Data_ValueSet(data, dataValue);



                Extern.Stream_Write(stream, data, range);



                Extern.Data_ValueSet(data, 0);
            }
        }



        return true;
    }

    public virtual bool DataWriteInt(byte[] dataArray, long index, int value)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                int* po;

                po = (int*)pa;



                *po = value;
            }
        }



        return true;
    }






    public virtual bool DataWriteULong(byte[] dataArray, long index, ulong value)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                ulong* po;

                po = (ulong*)pa;



                *po = value;
            }
        }



        return true;
    }






    public virtual string StringCreate(ulong data, int count)
    {
        string a;


        unsafe
        {
            char* p;

            p = (char*)data;



            a = new string(p, 0, count);
        }


        return a;
    }





    public virtual int TextEncodeString(ulong intern, char[] result, int resultIndex, ulong data, byte[] dataValue, long dataIndex)
    {
        ulong k;


        unsafe
        {
            fixed (char* p = result)
            {
                fixed (byte* pa = dataValue)
                {
                    char* pu;

                    pu = p + resultIndex;



                    byte* pau;

                    pau = pa + dataIndex;



                    ulong ou;

                    ou = (ulong)pu;


                    ulong oau;

                    oau = (ulong)pau;




                    Extern.Data_ValueSet(data, oau);




                    k = Extern.TextEncode_String(intern, ou, data);
                }
            }
        }



        int a;

        a = (int)k;


        return a;
    }






    public virtual long TextEncodeData(ulong intern, byte[] result, long resultIndex, ulong fromText, char[] fromTextData, int fromTextIndex)
    {
        ulong k;


        unsafe
        {
            fixed (byte* p = result)
            {
                fixed (char* pa = fromTextData)
                {
                    byte* pu;

                    pu = p + resultIndex;



                    char* pau;

                    pau = pa + fromTextIndex;



                    ulong ou;

                    ou = (ulong)pu;


                    ulong oau;

                    oau = (ulong)pau;




                    Extern.String_DataSet(fromText, oau);




                    k = Extern.TextEncode_Data(intern, ou, fromText);
                }
            }
        }



        long a;

        a = (long)k;


        return a;
    }

    public virtual int FormatCount(ulong format, char[] baseArray, ulong baseIndex, ulong baseCount, ulong varBase, ulong argList)
    {
        ulong u;
        u = 0;
        unsafe
        {
            fixed (char* p = baseArray)
            {
                char* pa;
                pa = p + baseIndex;

                ulong ua;
                ua = (ulong)pa;

                Extern.String_CountSet(varBase, baseCount);
                Extern.String_DataSet(varBase, ua);

                u = Extern.Format_ExecuteCount(format, varBase, argList);
            }
        }
        int a;
        a = (int)u;
        return a;
    }


    public virtual bool FormatResult(ulong format, char[] baseArray, ulong baseIndex, ulong baseCount, ulong varBase, ulong argList, 
        char[] resultArray, ulong resultIndex, ulong resultCount, ulong result)
    {
        unsafe
        {
            fixed (char* p = baseArray)
            {
                fixed (char* pu = resultArray)
                {
                    char* pa;
                    pa = p + baseIndex;
                    ulong ua;
                    ua = (ulong)pa;

                    char* pua;
                    pua = pu + resultIndex;
                    ulong uua;
                    uua = (ulong)pua;

                    Extern.String_CountSet(varBase, baseCount);
                    Extern.String_DataSet(varBase, ua);
                    Extern.String_CountSet(result, resultCount);
                    Extern.String_DataSet(result, uua);

                    Extern.Format_ExecuteResult(format, varBase, argList, result);
                }
            }
        }
        return true;
    }


    public virtual bool FormatArgResult(ulong format, ulong arg, char[] resultArray, ulong resultIndex, ulong resultCount, ulong result)
    {
        unsafe
        {
            fixed (char* p = resultArray)
            {
                char* pa;
                pa = p + resultIndex;

                ulong ua;
                ua = (ulong)pa;

                Extern.String_CountSet(result, resultCount);
                Extern.String_DataSet(result, ua);

                Extern.Format_ExecuteArgResult(format, arg, result);
            }
        }
        return true;
    }





    public virtual bool MathCompose(ulong math, MathCompose compose, long value)
    {
        ulong u;

        u = (ulong)value;


        unsafe
        {
            ulong oa;

            ulong ob;

            oa = 0;

            ob = 0;


            ulong* pa;

            ulong* pb;


            pa = &oa;

            pb = &ob;



            ulong ua;

            ulong ub;


            ua = (ulong)pa;

            ub = (ulong)pb;


            Extern.Math_Compose(math, u, ua, ub);




            compose.Significand = oa;


            compose.Exponent = ob;
        }


        return true;
    }





    public virtual bool DrawGradientStopPointGet(ulong intern, ulong index, DrawGradientStopPoint result)
    {
        unsafe
        {
            ulong pos;

            ulong color;


            ulong* posU;

            ulong* colorU;


            posU = &pos;

            colorU = &color;



            ulong ua;

            ulong ub;


            ua = (ulong)posU;

            ub = (ulong)colorU;



            Extern.GradientStop_PointGet(intern, index, ua, ub);



            result.Pos = pos;

            result.Color = color;
        }



        return true;
    }






    public virtual bool CopyImageData(ulong dest, int destRowByteCount, int destLeft, int destUp, ulong source, int sourceRowByteCount, int sourceLeft, int sourceUp, int width, int height)
    {
        unsafe
        {
            byte* destU;

            byte* sourceU;


            destU = (byte*)dest;

            sourceU = (byte*)source;



            byte* p;

            byte* pa;


            uint* d;

            uint* da;



            int count;

            int countA;

            int i;

            int j;


            count = height;

            countA = width;


            i = 0;

            while (i < count)
            {
                j = 0;

                while (j < countA)
                {
                    p = sourceU + (sourceUp + i) * sourceRowByteCount + (sourceLeft + j) * 4;


                    pa = destU + (destUp + i) * destRowByteCount + (destLeft + j) * 4;



                    d = (uint*)p;


                    da = (uint*)pa;


                    *da = *d;



                    j = j + 1;
                }


                i = i + 1;
            }
        }



        return true;
    }





    public virtual object HandleTarget(ulong o)
    {
        SystemIntPtr u;

        u = (SystemIntPtr)o;




        SystemGCHandle uu;

        uu = SystemGCHandle.FromIntPtr(u);





        object a;

        a = uu.Target;


        return a;
    }
}