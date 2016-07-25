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

using System;

namespace net.r_eg.LunaRoad.Types
{
    /// <summary>
    /// lua_Integer - The type of integers in Lua v5.3+:
    ///  * typedef ... lua_Integer; 
    ///  
    ///  By default this type is long long, (usually a 64-bit two-complement integer), 
    ///  but that can be changed to long or int (usually a 32-bit two-complement integer)
    ///  (See LUA_INT_TYPE in luaconf.h.)
    /// </summary>
    public struct LuaInteger
    {
        private long val;

        public static implicit operator long(LuaInteger number)
        {
            return number.val;
        }

        /// <exception cref="OverflowException">number is greater than Int32.MaxValue</exception>
        public static implicit operator Int32(LuaInteger number)
        {
            return Convert.ToInt32(number.val);
        }

        public static implicit operator LuaInteger(long number)
        {
            return new LuaInteger(number);
        }

        public LuaInteger(long number)
        {
            val = number;
        }
    }
}