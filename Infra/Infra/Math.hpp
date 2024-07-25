#pragma once

#include <cmath>

#include "Probate.hpp"

struct Math
{
};

#define CP(a) ((Math*)(a))

#define Start \
    Int ua;\
    ua = Math_GetInternValue(o, value);\
    double u;\
    u = CastIntToDouble(ua);\
\


#define End \
    Int ub;\
    ub = CastDoubleToInt(oo);\
    Int a;\
    a = Math_GetValueFromInternValue(o, ub);\
    return a;\


#define MathMethod(name, f) \
Int Math_##name(Int o, Int value)\
{\
    Start\
    double oo;\
    oo = std::f(u);\
    End\
}\


Int Math_GetValueFromCompose(Int o, Int significand, Int exponent);
