﻿/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016  Denis Kuzmin <entry.reg@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using net.r_eg.Conari.Types;

namespace net.r_eg.LunaRoad.Types
{
    /// <summary>
    /// lua_Number:
    ///  * typedef ... lua_Number; - By default this type is double, but that can be changed to a single float or a long double. 
    ///    (See LUA_FLOAT_TYPE in luaconf.h)
    /// </summary>
    public struct LuaNumber
    {
        private float_t val;

        public static implicit operator float_t(LuaNumber number)
        {
            return number.val;
        }

        public static implicit operator LuaNumber(float_t number)
        {
            return new LuaNumber(number);
        }

        public static implicit operator double(LuaNumber number)
        {
            return number.val;
        }

        public static implicit operator LuaNumber(double number)
        {
            return new LuaNumber(number);
        }

        public static implicit operator float(LuaNumber number)
        {
            return number.val;
        }

        // we also use this to initialize the float_t as the float type
        public static implicit operator LuaNumber(float number)
        {
            return new LuaNumber(number);
        }

        public LuaNumber(float_t number)
        {
            val = number;
        }
    }
}
