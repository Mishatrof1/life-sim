VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я счастлив в браке. Но недавно я встретил свою первую любовь, которую помнил всю жизнь. Она дала понять, что неравнодушна ко мне. Как быть?
* [Бросить все и и соединиться с той, кого любил все эти годы]
    -> res1
* [Завести с ней роман и этим завершить гештальт]
    -> res2
* [Не нужно ворошить угли в камине, можно обжечься. Я не стану менять свою жизнь]
    -> res3
* [Побольше узнаю об этой женщине. Неизвестно, какие у нее намерения]
    -> res4

=== res1 === 
Я ради нее пожертвовал всем, а онахитростью получила доступ к моему счету в банке и обворовала. теперь ее ловит полиция
~TextForLog = "После нескольких лет брака, я встретил свою самую первую любовь и получил возможность соединиться с ней. Я бросил ради нее свою прежнюю жизнь, а она обворовала меня."
* [Ok]
-> END
=== res2 === 
Мы с ней неплохо провели время, а когда я прервал отношения, она начадла меня шантажировать тем, что расскажет жене. Вот сволочь, придется заплатить!
~TextForLog = "После нескольких лет брака, я встретил свою самую первую любовь и получил возможность соединиться с ней. Я переспал с ней и она начала угрожать разоблачением. Пришлось заплатить за молчание."
* [Ok]
-> END
=== res3 === 
Мы разминулись в прошлом, разминулись и сейчас. Не знаю, была ли то случайность, или эта женщина нарочно нашла меня, да и не хочу знать
~TextForLog = "После нескольких лет брака, я встретил свою самую первую любовь и получил возможность соединиться с ней. Я отказался от отношений с ней. с ней."
* [Ok]
-> END
=== res4 === 
Хорошо, что я проявил осторожность: моя первая любовь сделалась профессиональной мошенницей, обирающей мужчин. Я не попался в ее сети
~TextForLog = "После нескольких лет брака, я встретил свою самую первую любовь и получил возможность соединиться с ней. Я проявил осторожность и навел справки. Оказалось, что моя первая любовь стала мошенницей - охотницей за деньгами мужчин."
* [Ok]
-> END