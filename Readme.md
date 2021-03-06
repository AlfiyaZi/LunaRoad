# LunaRoad

[![](https://raw.githubusercontent.com/3F/LunaRoad/master/LunaRoad/Resources/LunaRoad_v3_96px.png)](https://github.com/3F/LunaRoad/fork)

Lua C API for .NET 

LunaRoad represents a flexible platform to work with Lua.

*Works via powerful [Conari](https://github.com/3F/Conari) engine.*

[![Build status](https://ci.appveyor.com/api/projects/status/94y78phdvkoi5oda/branch/master?svg=true)](https://ci.appveyor.com/project/3Fs/lunaroad/branch/master)
[![release-src](https://img.shields.io/github/release/3F/LunaRoad.svg)](https://github.com/3F/LunaRoad/releases/latest)
[![License](https://img.shields.io/badge/License-MIT-74A5C2.svg)](https://github.com/3F/LunaRoad/blob/master/LICENSE)
[![NuGet package](https://img.shields.io/nuget/v/LunaRoad.svg)](https://www.nuget.org/packages/LunaRoad/) 

Easy to start:

```csharp
using(var l = new Lua<ILua51>("Lua51.dll")) {
    // ...
}
```

Flexible binding with any exported function of library:

```csharp
// custom binding:
using(ILua l = new Lua("Lua52.dll"))
{
    l.bind<Action<LuaState, LuaCFunction, int>>("pushcclosure")(L, onProc, 0);
    l.bind<Action<LuaState, string>>("setglobal")(L, "onKeyDown");
    //or any exported function like: bindFunc<...>("_full_name_")
    ...
    LuaNumber num = l.bind<Func<LuaState, int, LuaNumber>>("tonumber")(L, 7);
}

// API layer:
using(var l = new Lua<ILua53>("Lua53.dll"))
{
    l.API.pushcclosure(L, onProc, 0); // ILua53 lua = l.API
    l.API.setglobal(L, "onKeyDown");
}
```

*Since the LunaRoad works over [Conari](https://github.com/3F/Conari), it also does not require the creation of any additional* ***delegate***. *We'll do it* ***automatically*** *instead of you.* [[?](https://github.com/3F/LunaRoad/wiki/API)]


Unified API level between different versions:

```csharp
Lua<ILua53> l;
...
// to avoid ambiguity if exists: l.U as ILua51 ~
l.U.arith(L, LUA_OPSUB);
l.U.pop(L, 1);
```

and light access to specific:

```csharp
// from the higher version to the lower, for example: v5.2 -> v5.1
((ILua51)l.API).pushcclosure(L, onProc, 0); 

// not important, for example: v5.2 <-> v5.1
l.v<ILua51>().pushcclosure(L, onProc, 0); 
```

Powerful work with several libraries:

```csharp
using(var lSpec = new Lua("SpecLib.dll")) {
    using(ILua l = new Lua<ILua52>("Lua52.dll")) {
        //...
    }
}
```

Additional types:

```csharp

size_t len;
CharPtr name = lua.tolstring(L, 1, out len);
...
string myName += name; // (IntPtr)name; .Raw; .Ansi; .Utf8; ...
...
LuaNumber mv = lua.tonumber(L, 2);
```

Lazy loading:

```csharp
using(var l = new Lua<ILua51>(
                    new LuaConfig("Lua51.dll") {
                        LazyLoading = true
                    }))
{
    ...
}
```

and more ...

----


## License

The [MIT License (MIT)](https://github.com/3F/LunaRoad/blob/master/LICENSE) - be a ~free~ and open

```
Copyright (c) 2016  Denis Kuzmin <entry.reg@gmail.com>
```

##

### How to Get

Available variants:

* NuGet PM: `Install-Package LunaRoad`
* [GetNuTool](https://github.com/3F/GetNuTool): `msbuild gnt.core /p:ngpackages="LunaRoad"` or [gnt](https://github.com/3F/GetNuTool/releases/download/v1.5/gnt.bat) /p:ngpackages="LunaRoad"
* NuGet Commandline: `nuget install LunaRoad`
* [/releases](https://github.com/3F/LunaRoad/releases) ( [latest](https://github.com/3F/LunaRoad/releases/latest) )
* [Nightly builds](https://ci.appveyor.com/project/3Fs/LunaRoad/history) (`/artifacts` page). But remember: It can be unstable or not work at all. Use this for tests of latest changes.


### Roadmap

The LunaRoad already provides powerful and flexible binding. And as you can see above, you already may work between different versions via lambda-functions.
However, the main tasks: to provide fully compatible API layer for more comfortable work with Lua 5.1, 5.2, 5.3 ...


### How to Contribute

Extend our API layer or improve all of what you want. It easy and completely transparent with our flexible architecture.

If you ready to contribute, just use the pull requests or send .patch file. If it's not a simple binding to cover API, please also provide a correct unit-tests.

The Application Program Interface of Lua:

* [v5.1](https://www.lua.org/manual/5.1/manual.html#3)
* [v5.2](https://www.lua.org/manual/5.2/manual.html#4)
* [v5.3](https://www.lua.org/manual/5.3/manual.html#4)

The documentation **[here](https://github.com/3F/LunaRoad/wiki/API)** - *try with us*

#### How to Build

Current repository contains [git submodules](https://git-scm.com/book/en/Git-Tools-Submodules), and all this should be restored before build.

Our build-scripts solves it automatically instead of you:

* Inside IDE by [vsSBE](https://visualstudiogallery.msdn.microsoft.com/0d1dbfd7-ed8a-40af-ae39-281bfeca2334/) ([this script](https://gist.github.com/3F/a7f8eeb59ade9139d4da4862e03ee225) is also reloads all unavailable projects inside solution after updating submodules)
* With msbuild tools (and other) by `submodules.bat`. Just command > build

*It also prepares NuGet package as a `LunaRoad.<version>.nupkg` etc.*

But, just a note, how to do it manually:

* For initial cloning repo:

```
git clone --recursive https://github.com/3F/LunaRoad.git
```

* For already cloned:

```
git submodule update --init --recursive
```
