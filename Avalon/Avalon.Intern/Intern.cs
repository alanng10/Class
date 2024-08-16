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

    public virtual string ModuleFoldPath { get; set; }
    public virtual string ExecuteFoldPath { get; set; }

    public virtual ulong MaidePointer(SystemDelegate d)
    {
        SystemIntPtr u;
        u = Marshal.GetFunctionPointerForDelegate(d);
        ulong a;
        a = (ulong)u;
        return a;
    }

    public virtual bool CopyText(ulong dest, byte[] source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (byte* p = source)
            {
                char* pa;
                pa = (char*)p;
                pa = pa + index;
                ulong u;
                u = (ulong)pa;

                ulong oa;
                oa = count * sizeof(char);
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
                oa = count * sizeof(char);
                Extern.Copy(dest, u, oa);
            }
        }
        return true;
    }

    public virtual ulong TextEncodeCount(ulong innKind, ulong outKind, ulong data, ulong dataIndex, ulong dataCount)
    {
        ulong dataValue;
        dataValue = data + dataIndex;

        ulong a;
        a = Extern.TextEncode_ExecuteCount(0, innKind, outKind, dataValue, dataCount);
        return a;
    }

    public virtual bool TextEncodeResult(ulong result, ulong resultIndex, ulong innKind, ulong outKind, ulong data, ulong dataIndex, ulong dataCount)
    {
        ulong resultValue;
        resultValue = result + resultIndex;

        ulong dataValue;
        dataValue = data + dataIndex;

        Extern.TextEncode_ExecuteResult(0, resultValue, innKind, outKind, dataValue, dataCount);
        return true;
    }

    public virtual ulong TextEncodeCountArray(ulong innKind, ulong outKind, byte[] data, ulong dataIndex, ulong dataCount)
    {
        ulong a;
        a = 0;

        unsafe
        {
            fixed (byte* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                a = this.TextEncodeCount(innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return a;
    }

    public virtual ulong TextEncodeCountString(ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        ulong a;
        a = 0;

        unsafe
        {
            fixed (char* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                a = this.TextEncodeCount(innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return a;
    }

    public virtual bool TextEncodeResultArray(ulong result, ulong resultIndex, ulong innKind, ulong outKind, byte[] data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (byte* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                this.TextEncodeResult(result, resultIndex, innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextEncodeResultString(ulong result, ulong resultIndex, ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (char* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                this.TextEncodeResult(result, resultIndex, innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextEncodeResultArrayArray(byte[] result, ulong resultIndex, ulong innKind, ulong outKind, byte[] data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (byte* p = result)
            {
                ulong resultU;
                resultU = (ulong)p;

                this.TextEncodeResultArray(resultU, resultIndex, innKind, outKind, data, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextEncodeResultStringArray(byte[] result, ulong resultIndex, ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (byte* p = result)
            {
                ulong resultU;
                resultU = (ulong)p;

                this.TextEncodeResultString(resultU, resultIndex, innKind, outKind, data, dataIndex, dataCount);
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

    public virtual bool MathComp(ulong math, MathComp comp, long value)
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

            Extern.Math_Comp(math, u, ua, ub);

            comp.Cand = oa;
            comp.Expo = ob;
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

    public virtual bool CopyToByteArray(ulong source, byte[] dest, ulong index, ulong count)
    {
        unsafe
        {
            fixed (byte* uu = dest)
            {
                byte* destP;
                destP = uu + index;

                ulong destU;
                destU = (ulong)destP;

                Extern.Copy(destU, source, count);
            }
        }
        return true;
    }

    public virtual bool CopyFromByteArray(ulong dest, byte[] source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (byte* uu = source)
            {
                byte* sourceP;
                sourceP = uu + index;

                ulong sourceU;
                sourceU = (ulong)sourceP;

                Extern.Copy(dest, sourceU, count);
            }
        }
        return true;
    }

    public virtual uint VideoDataColor(ulong data, ulong width, ulong left, ulong up)
    {
        uint a;
        unsafe
        {
            uint* p;
            p = (uint*)data;

            uint* d;
            d = p + (up * width + left);

            a = *d;
        }
        return a;
    }

    public virtual long TypeIndexFromInternIndex(long u)
    {
        long a;
        a = u;

        long ua;
        ua = 0x80;

        long uu;
        uu = 0x01000000;

        if (!(a < uu))
        {
            a = a - uu;
            a = a + ua;
        }
        return a;
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