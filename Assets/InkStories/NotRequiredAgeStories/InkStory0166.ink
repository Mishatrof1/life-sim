VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У соседей постоянно проходят шумные вечеринки. Это мешает мне отдыхать. Что делать?
* [После очередной вечеринки устроить соседям разнос]
    -> res1
* [Прийти к ним в разгар вечеринки и устроить скандал]
    -> res2
* [Когда соседей не будет дома, расписать им стену неприличными граффити]
    -> res3
* [В разгар очередной вечеринки вызвать полицию]
    -> res4

=== res1 === 
Соседи вежливо выслушали, но прекращать шумные вечеринки и не подумали
~TextForLog = "Мне мешают отдыхать шумные вечеринки у соседей. Я устроил им разнос. Они выслушали, но не прекратили шуметь."
* [Ok]
-> END
=== res2 === 
Скандал получился отменный, вечеринку я им сорвала, хотя была опасность, что гости набросятся на меня
~TextForLog = "Мне мешают отдыхать шумные вечеринки у соседей. Я устроила им скандал и сорвала вечеринку."
* [Ok]
-> END
=== res3 === 
Удивительно, поверх моих графити, появилось еще несколько. Соседи гадили всем в уши, а им нагадили в глаза. Справедливо!
~TextForLog = "Мне мешают отдыхать шумные вечеринки у соседей. В отместку я расписала им стену неприличными графити."
* [Ok]
-> END
=== res4 === 
Полицейские выписали им штраф. Вот и хорошо, если подобное повторится, я снова вызову полицию
~TextForLog = "Мне мешают отдыхать шумные вечеринки у соседей. Я вызвала полицию и соседям пришлось заплатить штраф."
* [Ok]
-> END