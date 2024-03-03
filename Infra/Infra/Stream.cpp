#include "Stream.hpp"

CppClassNew(Stream)

#define StreamKindCount (4)

Int Stream_HasPos_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};

Int Stream_HasCount_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};

Stream_Flush_Maide Stream_Flush_MaideArray[StreamKindCount] =
{
    null,
    null,
    &Stream_FlushStorage,
    &Stream_FlushNetwork,
};

Int Stream_Init(Int o)
{
    return true;
}

Int Stream_Final(Int o)
{
    return true;
}

CppFieldGet(Stream, Kind)

Int Stream_KindSet(Int o, Int value)
{
    Stream* m;

    m = CP(o);



    Int kind;

    kind = value;



    m->Kind = kind;






    m->HasPos = Stream_HasPos_Array[kind];




    m->HasCount = Stream_HasCount_Array[kind];




    m->CanRead = false;



    m->CanWrite = false;





    return true;
}

CppFieldGet(Stream, Value)

Int Stream_ValueSet(Int o, Int value)
{
    Stream* m;

    m = CP(o);




    m->Value = value;



    m->Status = 0;



    m->Intern = (QIODevice*)(m->Value);




    return true;
}





Int Stream_CountGet(Int o)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasCount))
    {
        return 0;
    }



    QIODevice* ua;

    ua = m->Intern;



    qint64 ub;

    ub = ua->size();



    Int oa;

    oa = CastInt(ub);



    return oa;
}





Int Stream_PosGet(Int o)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasPos))
    {
        return 0;
    }




    QIODevice* ua;

    ua = m->Intern;



    qint64 ub;

    ub = ua->pos();



    Int oa;

    oa = CastInt(ub);



    return oa;
}






Bool Stream_PosSet(Int o, Int value)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasPos))
    {
        return true;
    }




    Int count;

    count = Stream_CountGet(o);



    if (count < value)
    {
        return true;
    }





    qint64 ua;

    ua = value;





    bool bu;


    bu = m->Intern->seek(ua);




    Bool bo;

    bo = bu;




    Int status;


    status = 0;




    if (!bo)
    {
        status = 150;
    }





    m->Status = status;





    return true;
}





Bool Stream_HasPos(Int o)
{
    Stream* m;

    m = CP(o);



    return m->HasPos;
}





Bool Stream_HasCount(Int o)
{
    Stream* m;

    m = CP(o);



    return m->HasCount;
}






Int Stream_CanRead(Int o)
{
    Stream* m;

    m = CP(o);



    return m->CanRead;
}







Int Stream_CanWrite(Int o)
{
    Stream* m;

    m = CP(o);



    return m->CanWrite;
}

CppFieldSet(Stream, CanRead)
CppFieldSet(Stream, CanWrite)

Int Stream_GetStatus(Int o)
{
    Stream* m;

    m = CP(o);


    return m->Status;
}






Int Stream_Read(Int o, Int data, Int range)
{
    Stream* m;
    m = CP(o);

    if (!(m->CanRead))
    {
        return true;
    }

    Int dataValue;
    dataValue = Data_ValueGet(data);
    Int dataCount;
    dataCount = Data_CountGet(data);

    Int start;
    Int end;
    start = Range_StartGet(range);
    end = Range_EndGet(range);

    if (!Stream_CheckRange(dataCount, start, end))
    {
        m->Status = 100;
        return true;
    }

    Int count;
    count = end - start;

    Int aaa;
    aaa = dataValue + start;

    char* dataU;
    dataU = (char*)aaa;

    qint64 maxSize;
    maxSize = count;

    qint64 oo;
    oo = m->Intern->read(dataU, maxSize);

    Int status;
    status = 0;

    Bool b;
    b = false;
    if ((!b) & (oo < 0))
    {
        status = 210;
        b = true;
    }
    if ((!b) & (!(oo == maxSize)))
    {
        status = 200;
        b = true;
    }

    m->Status = status;
    return true;
}

Int Stream_Write(Int o, Int data, Int range)
{
    Stream* m;
    m = CP(o);

    if (!(m->CanWrite))
    {
        return true;
    }

    Int dataValue;
    dataValue = Data_ValueGet(data);
    Int dataCount;
    dataCount = Data_CountGet(data);

    Int start;
    Int end;
    start = Range_StartGet(range);
    end = Range_EndGet(range);

    if (!Stream_CheckRange(dataCount, start, end))
    {
        m->Status = 100;
        return true;
    }

    Int count;
    count = end - start;

    Int aaa;
    aaa = dataValue + start;

    const char* dataU;
    dataU = (const char*)aaa;

    qint64 maxSize;
    maxSize = count;

    qint64 oo;
    oo = m->Intern->write(dataU, maxSize);

    Int status;
    status = 0;

    Bool b;
    b = false;
    if ((!b) & (oo < 0))
    {
        status = 310;
        b = true;
    }
    if ((!b) & (!(oo == maxSize)))
    {
        status = 300;
        b = true;
    }

    if (!b)
    {
        Int uoo;
        uoo = Stream_InternFlush(o);

        if (uoo == 1)
        {
            status = 330;
        }
    }

    m->Status = status;
    return true;
}

Int Stream_InternFlush(Int o)
{
    Stream* m;

    m = CP(o);




    Int kind;

    kind = m->Kind;


    Int value;

    value = m->Value;




    Stream_Flush_Maide maide;

    maide = Stream_Flush_MaideArray[kind];



    if (maide == null)
    {
        return 2;
    }




    Bool b;

    b = maide(value);



    b = (!b);



    Int aa;

    aa = b;


    return aa;
}

Int Stream_CheckRange(Int dataCount, Int start, Int end)
{
    return ((!(dataCount < start)) & (!(dataCount < end)));
}

Int Stream_Intern(Int o)
{
    Stream* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}
