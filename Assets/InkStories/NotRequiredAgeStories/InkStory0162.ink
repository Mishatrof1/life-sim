VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я приехал в экзотическую страну ради секс-туризма.  Меня повезли, якобы, к девочкам, но завезли в плохой район, избили и ограбили. Нет документов, денег. Что же делать?
* [Обращусь в посольство моей страны за документами и уеду]
    -> res1
* [Заявлю в местную полицию об ограблении]
    -> res2
* [Я попытаюсь самостоятельно найти виновных и наказать]
    -> res3


=== res1 === 
Я уехал домой и попытался как можно скорее забыть это ужасное приключение
~TextForLog = "Я приехал в экзотическую страну ради секс-туризма.  Меня повезли, якобы, к девочкам, но завезли в плохой район, избили и ограбили. Хорошо, что удалось добраться до своего посольства. Еле ноги унес."
* [Ok]
-> END
=== res2 === 
Местные полицейские были вежливы, приняли заявление, но, как я понял, искать они никого даже не пытались. Я зря потерял время и уехал домой
~TextForLog = "Я приехал в экзотическую страну ради секс-туризма.  Меня повезли, якобы, к девочкам, но завезли в плохой район, избили и ограбили. Я заявил в полицию, но они никого не нашли, пришлось уехать."
* [Ok]
-> END
=== res3 === 
Злодеи даже не прятались и вели себя, как будто им ничего не угрожает. Зря. Я выследил одного из них и избил обрезком трубы. В результате, он мне дал денег даже больше чем украл. Я уехал домой довольный: это было лучше, чем секс
~TextForLog = "Я выследил одного из злодеевх и избил обрезком трубы. В результате, он мне дал денег даже больше чем украл. Я уехал домой довольный: это было лучше, чем секс."
* [Ok]
-> END