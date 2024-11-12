#include "Execute.hpp"

Int Execute()
{
    Main_Init();

    Int argArray;
    argArray = Main_Arg();

    Int argCount;
    argCount = Array_CountGet(argArray);

    if (!(argCount == 1))
    {
        return 270;
    }

    Int arg;
    arg = Array_ItemGet(argArray, 0);

    QString moduleRef;
    Int pModuleRef;
    pModuleRef = CastInt(&moduleRef);
    
    Bool ba;
    ba = ExecuteArg(pModuleRef, arg);

    if (!ba)
    {
        return 271;
    }

    QString moduleString;
    Int pModuleString;
    pModuleString = CastInt(&moduleString);

    Bool bb;
    bb = ExecuteModuleString(pModuleString, pModuleRef);

    if (!bb)
    {
        return 272;
    }

    QString varString;
    varString = moduleString;
    varString.append("_Var");

    QString initString;
    varString = moduleString;
    varString.append("_Init");

    QString entryString;
    varString = moduleString;
    varString.append("_Entry");


    Int eval;

    eval = Intern_Init();

    Int a;
    a = Intern_Execute(eval);

    Intern_Final(eval);

    Main_Final();

    return a;
}

Int ExecuteArg(Int result, Int arg)
{
    QString k;

    Int value;
    value = String_ValueGet(arg);
    Int count;
    count = String_CountGet(arg);

    Char* p;
    p = (Char*)value;

    Int i;
    i = 0;
    while (i < count)
    {
        Char n;
        n = p[i];

        if (!(n < 0x100))
        {
            return false;
        }

        QChar kk;
        kk = QChar(n);

        k.append(kk);

        i = i + 1;
    }

    QString* ke;
    ke = (QString*)result;

    *ke = k;
    return true;
}

Int ExecuteModuleString(Int result, Int moduleRef)
{
    QString* k;
    k = (QString*)moduleRef;

    qsizetype na;
    na = k->indexOf('-');

    QString ka;
    ka = k->mid(0, na);

    QString kb;
    kb = k->mid(na + 1);

    Int pka;
    pka = CastInt(&ka);

    QString moduleNameString;
    
    Int pkkk;
    pkkk = CastInt(&moduleNameString);

    Bool b;
    b = ExecuteModuleNameString(pkkk, pka);

    if (!b)
    {
        return false;
    }

    Int pkb;
    pkb = CastInt(&kb);

    Int moduleVer;
    moduleVer = 0;

    Int paa;
    paa = CastInt(&moduleVer);

    b = ExecuteModuleVer(paa, pkb);

    if (!b)
    {
        return false;
    }

    QString moduleVerString;
    moduleVerString = QString::number(moduleVer, 16);

    QString a;

    a.append(QChar('C'));
    a.append(QChar('_'));

    a.append(moduleNameString);

    a.append(QChar('_'));

    a.append(moduleVerString);

    QString* ke;
    ke = (QString*)result;

    *ke = a;

    return true;
}

Int ExecuteModuleVer(Int result, Int moduleVer)
{
    QString* k;
    k = (QString*)moduleVer;

    qsizetype na;
    na = k->indexOf('.');

    qsizetype nb;
    nb = k->indexOf('.', na + 1);

    QString ka;
    ka = k->mid(0, na);

    qsizetype countA;
    countA = nb - (na + 1);

    QString kb;
    kb = k->mid(na + 1, countA);

    QString kc;
    kc = k->mid(nb + 1);

    if (!(kb.length() == 2))
    {
        return false;
    }

    if (!(kc.length() == 2))
    {
        return false;
    }

    bool b;
    b = false;

    Int major;
    major = ka.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int minor;
    minor = kb.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int revise;
    revise = kc.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int a;
    a = 0;
    a = a | (major << 16);
    a = a | (minor << 8);
    a = a | revise;

    Int* ke;
    ke = (Int*)result;

    *ke = a;

    return true;
}

Int ExecuteModuleNameString(Int result, Int moduleName)
{
    QString a;

    QString* k;
    k = (QString*)moduleName;

    Int count;
    count = k->length();

    Int i;
    i = 0;
    while (i < count)
    {
        QChar na;
        na = k->at(i);

        Byte ka;
        ka = na.toLatin1();

        if (!(!(ka < '0' | '9' < ka) | !(ka < 'A' | 'Z' < ka) | !(ka < 'a' | 'z' < ka) | (ka == '_') | (ka == '.')))
        {
            return false;
        }

        Int kk;
        kk = ka;

        Int upper;
        Int lower;
        upper = kk >> 4;
        lower = kk & 0xf;

        Int upperChar;
        upperChar = ExecuteHexDigitChar(upper);

        Int lowerChar;
        lowerChar = ExecuteHexDigitChar(lower);

        Byte kaa;
        Byte kab;
        kaa = upperChar;
        kab = lowerChar;

        QChar kba;
        QChar kbb;
        kba = QChar(kaa);
        kbb = QChar(kab);

        a.append(kba);
        a.append(kbb);

        i = i + 1;
    }

    QString* ke;
    ke = (QString*)result;

    *ke = a;
    return true;
}

Int ExecuteHexDigitChar(Int value)
{
    if (value < 10)
    {
        Int aa;
        aa = '0' + value;
        return aa;
    }

    Int k;
    k = value - 10;

    Int a;
    a = 'a' + k;
    return a;
}