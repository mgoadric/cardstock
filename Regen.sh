#!/bin/sh
java -jar antlr-4.5-complete.jar -Dlanguage=CSharp CardLanguage.g4
java -jar rrd-antlr4-0.1.1.jar CardLanguage.g4