## OpenCodeDev.Reflection.Helper
Note: Not even Alpha, Do Not use this package before its shipped on NuGet :)

This package is a helper package we developed and regularly used to work with Reflection.

It contains only extension method to extend for instance "PropertyInfo" and other stuff related to reflection;

An example would be to check if a prop is bool...

```
using OpenCodeDev.Reflection.Helper;

PropertyInfo myprop = blah blah blah get property info....
myprop.IsBool();

```