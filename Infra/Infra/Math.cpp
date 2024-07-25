#include "Math.hpp"

CppClassNew(Math)

Int Math_Init(Int o)
{
    return true;
}

Int Math_Final(Int o)
{
    return true;
}

MathMaide(Sin, sin)
MathMaide(Cos, cos)
MathMaide(Tan, tan)
MathMaide(ASin, asin)
MathMaide(ACos, acos)
MathMaide(ATan, atan)
MathMaide(SinH, sinh)
MathMaide(CosH, cosh)
MathMaide(TanH, tanh)
MathMaide(ASinH, asinh)
MathMaide(ACosH, acosh)
MathMaide(ATanH, atanh)

Int Math_GetInternValue(Int o, Int value)
{
    Int aa;
    Int ab;
    aa = 0;
    ab = 0;
    Int uoa;
    Int uob;
    uoa = CastInt(&aa);
    uob = CastInt(&ab);

    Math_Compose(o, value, uoa, uob);

    SInt oaa;
    SInt oab;
    oaa = aa;
    oab = ab;

    double uaa;
    uaa = oaa;
    int uab;
    uab = oab;

    double ou;
    ou = std::ldexp(uaa, uab);

    Int a;
    a = CastDoubleToInt(ou);
    return a;
}

Int Math_GetValueFromInternValue(Int o, Int u)
{
    double ou;
    ou = CastIntToDouble(u);

    int exp;
    exp = 0;

    double uu;
    uu = std::frexp(ou, &exp);

    double uua;
    uua = std::ldexp(uu, 49);

    int expa;
    expa = exp - 49;

    SInt aa;
    aa = uua;

    SInt ab;
    ab = expa;

    Int oa;
    Int ob;
    oa = aa;
    ob = ab;

    Int a;
    a = Math_GetValueFromCompose(o, oa, ob);
    return a;
}

Int Math_GetValueFromCompose(Int o, Int significand, Int exponent)
{
    SInt aa;
    aa = significand;
    aa = aa << 4;
    aa = aa >> 4;

    SInt ab;
    ab = exponent;
    ab = ab << 4;
    ab = ab >> 4;

    Int ka;
    ka = 1;
    ka = ka << 50;
    Int kaa;
    kaa = ka - 1;

    Int kb;
    kb = 1;
    kb = kb << 10;
    Int kab;
    kab = kb - 1;

    Int ku;
    ku = ab;
    ku = ku & kab;
    ku = ku << 50;

    Int k;
    k = aa;
    k = k & kaa;
    k = k | ku;
    return k;
}

Int Math_Compose(Int o, Int value, Int significand, Int exponent)
{
    SInt aa;
    aa = value;
    aa = aa << 14;
    aa = aa >> 14;

    SInt ab;
    ab = value;
    ab = ab << 4;
    ab = ab >> 54;

    Int oa;
    Int ob;
    oa = aa;
    ob = ab;

    Int* ua;
    ua = (Int*)significand;
    Int* ub;
    ub = (Int*)exponent;

    *ua = oa;
    *ub = ob;
    return true;
}

Int Math_Value(Int o, Int significand, Int exponent)
{
    SInt aa;
    aa = significand;
    aa = aa << 4;
    aa = aa >> 4;
    SInt ab;
    ab = exponent;
    ab = ab << 4;
    ab = ab >> 4;

    double uaa;
    uaa = aa;
    int uab;
    uab = ab;

    double oo;
    oo = std::ldexp(uaa, uab);

    End
}


Int Math_ValueTen(Int o, Int significand, Int exponentTen)
{
    SInt aa;
    aa = significand;
    aa = aa << 4;
    aa = aa >> 4;
    SInt ab;
    ab = exponentTen;
    ab = ab << 4;
    ab = ab >> 4;

    double uua;
    uua = 10;
    double au;
    au = ab;

    double uu;
    uu = std::pow(uua, au);

    double u;
    u = aa;
    u = u * uu;

    double oo;
    oo = u;

    End
}