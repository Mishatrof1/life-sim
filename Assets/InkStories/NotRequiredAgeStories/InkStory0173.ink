VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я был в турпоездке в экзотической стране и случайно помочился на алтарь местного божества. Честное слово, я не знал, что это алтарь. Что делать?
* [Как можно скорее покинуть страну]
    -> res1
* [Мне пофиг, содеянного не исправить, не пропадать же отпуску]
    -> res2
* [Выяснить, как можно загладить свою вину]
    -> res3


=== res1 === 
Даже дома я живу в страхе. Мне снятся жрецы-убийцы с ритуальными кинжалами
~TextForLog = "Я был в турпоездке в экзотической стране и случайно помочился на алтарь местного божества. Я поспешил уехать и долго жил в страхе, что меня настигнет возмездие."
* [Ok]
-> END
=== res2 === 
Я прекрасно провел отпуск. Видимо, ради процветания туризма, в этой стране приезжим прощаются небольшие шалости
~TextForLog = "Я был в турпоездке в экзотической стране и случайно помочился на алтарь местного божества. Никаких последствий не было.  Видимо, ради процветания туризма, в этой стране приезжим прощаются небольшие шалости."
* [Ok]
-> END
=== res3 === 
$300 оказалось достаточно, чтобы исправить содеянное
~TextForLog = "Я был в турпоездке в экзотической стране и случайно помочился на алтарь местного божества. $300 оказалось достаточно, чтобы исправить содеянное."
* [Ok]
-> END