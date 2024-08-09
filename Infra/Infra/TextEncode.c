#include "TextEncode.h"

InfraClassNew(TextEncode)

TextEncode_CountMaide CountMaideArray[3][3] =
{
    { null, TextEncode_ExecuteCount8To16, TextEncode_ExecuteCount8To32},
    { TextEncode_ExecuteCount16To8, null, TextEncode_ExecuteCount16To32},
    { TextEncode_ExecuteCount32To8, TextEncode_ExecuteCount32To16, null}
};

TextEncode_ResultMaide ResultMaideArray[3][3] =
{
    { null, TextEncode_ExecuteResult8To16, TextEncode_ExecuteResult8To32},
    { TextEncode_ExecuteResult16To8, null, TextEncode_ExecuteResult16To32},
    { TextEncode_ExecuteResult32To8, TextEncode_ExecuteResult32To16, null}
};


Int TextEncode_Init(Int o)
{
    return true;
}

Int TextEncode_Final(Int o)
{
    return true;
}

Int TextEncode_ExecuteCount(Int o, Int innKind, Int outKind, Int data)
{
    TextEncode_CountMaide maide;
    maide = CountMaideArray[innKind][outKind];

    Int a;
    a = maide(o, data);
    return a;
}

Int TextEncode_ExecuteResult(Int o, Int result, Int innKind, Int outKind, Int data)
{
    return 0;
}


Int TextEncode_ExecuteCount32To8(Int o, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Char* p;
    p = CastPointer(dataValue);

    Int ka;
    ka = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / ka;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        if (oc < 0x80)
        {
            k = k + 1;
        }

        if (!(oc < 0x80) & oc < 0x800)
        {
            k = k + 2;
        }

        if (!(oc < 0x800) & oc < 0x10000)
        {
            k = k + 3;
        }

        if (!(oc < 0x10000) & oc < 0x110000)
        {
            k = k + 4;
        }

        i = i + 1;
    }

    Int a;
    a = k;
    return a;
}

Int TextEncode_ExecuteCount32To16(Int o, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Char* p;
    p = CastPointer(dataValue);

    Int ka;
    ka = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / ka;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        if (oc < 0x10000)
        {
            k = k + 1;
        }

        if (!(oc < 0x10000))
        {
            k = k + 2;
        }

        i = i + 1;
    }

    Int a;
    a = k * sizeof(Int16);
    return a;
}

Int TextEncode_ExecuteCount16To8(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount16To32(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount8To16(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount8To32(Int o, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Byte* p;
    p = CastPointer(dataValue);

    Int k;
    k = 0;

    Bool b;
    b = true;

    Int count;
    count = dataCount;

    Int i;
    i = 0;
    while (b & (i < count))
    {
        b = false;

        Byte ooa;
        ooa = p[i];

        Int aaa;
        aaa = ooa;

        if ((aaa >> 7) == 0)
        {
            i = i + 1;

            k = k + 1;

            b = true;
        }

        if ((aaa >> 5) == 0x6)
        {
            Int akb;
            akb = i + 2;

            if (!(count < akb))
            {
                i = akb;

                k = k + 1;

                b = true;
            }
        }

        if ((aaa >> 4) == 0xe)
        {
            Int akc;
            akc = i + 3;

            if (!(count < akc))
            {
                i = akc;

                k = k + 1;

                b = true;
            }
        }

        if ((aaa >> 3) == 0x1e)
        {
            Int akd;
            akd = i + 4;

            if (!(count < akd))
            {
                i = akd;

                k = k + 1;

                b = true;
            }
        }
    }

    Int a;
    a = k * sizeof(Char);
    return a;
}

Int TextEncode_ExecuteResult32To8(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Char* p;
    p = CastPointer(dataValue);

    Byte* dest;
    dest = CastPointer(resultValue);

    Int countA;
    countA = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / countA;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        Write8;

        i = i + 1;
    }

    return true;
}


Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Char* p;
    p = CastPointer(dataValue);

    Int16* dest;
    dest = CastPointer(resultValue);

    Int countA;
    countA = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / countA;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        Write16;

        i = i + 1;
    }

    return true;
}

Int TextEncode_ExecuteResult16To8(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult16To32(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult8To32(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Byte* p;
    p = CastPointer(dataValue);

    Char* dest;
    dest = CastPointer(resultValue);

    Int k;
    k = 0;

    Bool b;
    b = true;

    Int count;
    count = dataCount;

    Int i;
    i = 0;
    while (b & (i < count))
    {
        b = false;

        Byte ooa;
        ooa = p[i];

        Int aaa;
        aaa = ooa;

        Char oc;
        oc = 0;

        if ((aaa >> 7) == 0)
        {
            Int akaa;
            akaa = aaa;

            oc = akaa;

            i = i + 1;

            b = true;
        }

        if ((aaa >> 5) == 0x6)
        {
            Int akb;
            akb = i + 2;

            if (!(count < akb))
            {
                Byte akboa;
                Byte akbob;
                akboa = p[i + 1];
                akbob = ooa;

                Int akba;
                Int akbb;
                Int akbc;
                akba = akboa & 0xf;
                akbb = ((akboa >> 4) & 0x3) | ((akbob & 0x3) << 2);
                akbc = (akbob >> 2) & 0x7;

                Int kkb;
                kkb = 0;
                kkb = kkb | (akba << (4 * 0));
                kkb = kkb | (akbb << (4 * 1));
                kkb = kkb | (akbc << (4 * 2));

                oc = kkb;

                i = akb;

                b = true;
            }
        }

        if ((aaa >> 4) == 0xe)
        {
            Int akc;
            akc = i + 3;

            if (!(count < akc))
            {
                Byte akcoa;
                Byte akcob;
                Byte akcoc;
                akcoa = p[i + 2];
                akcob = p[i + 1];
                akcoc = ooa;

                Int akca;
                Int akcb;
                Int akcc;
                Int akcd;
                akca = akcoa & 0xf;
                akcb = ((akcoa >> 4) & 0x3) | ((akcob & 0x3) << 2);
                akcc = (akcob >> 2) & 0xf;
                akcd = akcoc & 0xf;

                Int kkc;
                kkc = 0;
                kkc = kkc | (akca << (4 * 0));
                kkc = kkc | (akcb << (4 * 1));
                kkc = kkc | (akcc << (4 * 2));
                kkc = kkc | (akcd << (4 * 3));

                oc = kkc;

                i = akc;

                b = true;
            }
        }

        if ((aaa >> 3) == 0x1e)
        {
            Int akd;
            akd = i + 4;

            if (!(count < akd))
            {
                Byte akdoa;
                Byte akdob;
                Byte akdoc;
                Byte akdod;
                akdoa = p[i + 3];
                akdob = p[i + 2];
                akdoc = p[i + 1];
                akdod = ooa;

                Int akda;
                Int akdb;
                Int akdc;
                Int akdd;
                Int akde;
                Int akdf;
                akda = akdoa & 0xf;
                akdb = ((akdoa >> 4) & 0x3) | ((akdob & 0x3) << 2);
                akdc = (akdob >> 2) & 0xf;
                akdd = akdoc & 0xf;
                akde = ((akdoc >> 4) & 0x3) | ((akdod & 0x3) << 2);
                akdf = (akdod >> 2) & 0x1;

                Int kkd;
                kkd = 0;
                kkd = kkd | (akda << (4 * 0));
                kkd = kkd | (akdb << (4 * 1));
                kkd = kkd | (akdc << (4 * 2));
                kkd = kkd | (akdd << (4 * 3));
                kkd = kkd | (akde << (4 * 4));
                kkd = kkd | (akdf << (4 * 5));

                oc = kkd;

                i = akd;

                b = true;
            }
        }

        if (b)
        {
            Write32;
        }
    }

    Int a;
    a = k * sizeof(Char);
    return a;
}