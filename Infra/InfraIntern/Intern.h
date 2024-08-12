#pragma once

#include "Probate.h"

#define BoolFalse 0x2000000000000000

#define BoolTrue 0x2000000000000001

#define RefKindClear(name) name = name & 0x0fffffffffffffff;

#define RefKindInt(name) name = name | 0x3000000000000000;

#define RefMemoryAddress(name) name = name & 0x0000ffffffffffff;

#define Return(ret, paramCount) \
eval->Stack[frame - (paramCount + 1)] = ret;\
eval->Index = frame - paramCount;\
return 0;\

