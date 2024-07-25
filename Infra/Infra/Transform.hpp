#pragma once

#include <QTransform>

#include "TransformIntern.hpp"

#include "Probate.hpp"

struct Transform
{
    QTransform* Intern;
};

#define CP(a) ((Transform*)(a))

#define InternValue(a) \
Int a##_uu;\
a##_uu = Math_GetInternValue(0, a);\
qreal a##U;\
a##U = CastIntToDouble(a##_uu);\

