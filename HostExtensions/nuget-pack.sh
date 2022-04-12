#!/bin/sh

dotnet pack -c release -o . -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg